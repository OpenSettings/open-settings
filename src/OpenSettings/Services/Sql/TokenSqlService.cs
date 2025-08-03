using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Sql.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace OpenSettings.Services.Sql
{
    internal sealed class TokenSqlService : TokenServiceBase, ITokenSqlService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly ILogger _logger;

        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly ProviderInfo _providerInfo;
        private readonly SigningCredentials _signingCredentials;
        private readonly bool _isOAuth2AuthorityMissing;

        public TokenSqlService(IServiceProvider serviceProvider, IHttpClientFactory httpClientFactory, IOpenSettingsMemoryCache openSettingsMemoryCache, OpenSettingsConfiguration openSettingsConfiguration, ProviderInfo providerInfo) : base(new JwtSecurityTokenHandler())
        {
            _serviceProvider = serviceProvider;
            _httpClientFactory = httpClientFactory;
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _logger = openSettingsConfiguration.LoggerFactory.CreateLogger<TokenSqlService>();
            _openSettingsConfiguration = openSettingsConfiguration;
            _providerInfo = providerInfo;

            var keys = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"{openSettingsConfiguration.Client.Secret}"));
            _signingCredentials = new SigningCredentials(keys, SecurityAlgorithms.HmacSha256);

            _isOAuth2AuthorityMissing = string.IsNullOrWhiteSpace(providerInfo.OAuth2.Authority);
        }
     
        public ValueTask<bool> IsUserTokenExpiredAsync(string accessToken, Func<Task<string>> refreshTokenRetrieveFunc)
        {
            var jwtSecurityToken = ReadJwtToken(accessToken);

            return IsUserTokenExpiredAsync(jwtSecurityToken, refreshTokenRetrieveFunc);
        }

        public async ValueTask<bool> IsUserTokenExpiredAsync(JwtSecurityToken jwtSecurityToken, Func<Task<string>> refreshTokenRetrieveFunc)
        {
            var refreshTokenKey = OpenSettingsDefaults.Caches.TokenServiceRefreshTokenCacheEntry.GetKey(jwtSecurityToken.Id);

            if (Helper.IsTokenExpired(jwtSecurityToken))
            {
                refreshTokenKey.Remove(_openSettingsMemoryCache);
                return true;
            }

            if (refreshTokenKey.TryGetValue(_openSettingsMemoryCache, out _))
            {
                return false;
            }

            var refreshToken = await refreshTokenRetrieveFunc();

            if (!string.IsNullOrWhiteSpace(refreshToken))
            {
                refreshTokenKey.Set(_openSettingsMemoryCache, refreshToken, cacheEntry =>
                {
                    cacheEntry.AbsoluteExpiration = new DateTimeOffset(jwtSecurityToken.ValidTo, TimeSpan.Zero);
                });
            }

            return false;
        }

        public async Task<IResponse<RefreshUserTokenResponse>> RefreshUserTokenAsync(string accessToken,
            CancellationToken cancellationToken = default)
        {
            var jwtSecurityToken = ReadJwtToken(accessToken);

            var refreshTokenKey = OpenSettingsDefaults.Caches.TokenServiceRefreshTokenCacheEntry.GetKey(jwtSecurityToken.Id);

            var currentTime = DateTime.UtcNow;

            if (Helper.IsTokenExpired(jwtSecurityToken, currentTime))
            {
                return HttpStatusCode.Forbidden.ToFailureResponse<RefreshUserTokenResponse, Errors>(Errors.TokenExpired);
            }
            
            if (!Helper.IsTokenExpirationTimeLessThan(jwtSecurityToken, TimeSpan.FromMinutes(1), currentTime))
            {
                return HttpStatusCode.BadRequest.ToFailureResponse<RefreshUserTokenResponse, Errors>(Errors.TokenRefreshNotAllowedYet);
            }

            if (!refreshTokenKey.TryGetValue(_openSettingsMemoryCache, out string cachedRefreshToken) || // CachedRefreshToken stored during the initial login process. // todo we should store this in the persistent so it will be distributed
                string.IsNullOrWhiteSpace(cachedRefreshToken))
            {
                return HttpStatusCode.NotFound.ToFailureResponse<RefreshUserTokenResponse, Errors>(Errors.RefreshTokenNotFound);
            }

            if (_isOAuth2AuthorityMissing)
            {
                return HttpStatusCode.InternalServerError.ToFailureResponse<RefreshUserTokenResponse, Errors>(Errors.MissingOAuth2Authority);
            }

            using (var request = new HttpRequestMessage(HttpMethod.Post, "connect/token"))
            {
                request.Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>(OpenSettingsDefaults.ClaimTypes.GrantType, OpenSettingsDefaults.ClaimTypes.RefreshToken),
                    new KeyValuePair<string, string>(OpenSettingsDefaults.ClaimTypes.RefreshToken, cachedRefreshToken),
                    new KeyValuePair<string, string>(OpenSettingsDefaults.ClaimTypes.ClientId, _openSettingsConfiguration.Controller.OAuth2.ClientId),
                    new KeyValuePair<string, string>(OpenSettingsDefaults.ClaimTypes.ClientSecret, _openSettingsConfiguration.Controller.OAuth2.ClientSecret)
                });

                using (var response = await GetOAuth2AuthorityHttpClient().SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync(
#if NET5_0_OR_GREATER
                            cancellationToken
#endif
                            );

                        _logger.LogError("Failed to refresh user token. Status Code: {statusCode}, Content: {content}", response.StatusCode, content);

                        return response.StatusCode.ToFailureResponse<RefreshUserTokenResponse>(content);
                    }

                    var connectTokenResponse = await response.Content.ReadFromJsonAsync<ConnectTokenResponse>(cancellationToken: cancellationToken);

                    var refreshedJwtSecurityToken = ReadJwtToken(connectTokenResponse.AccessToken);

                    refreshTokenKey = OpenSettingsDefaults.Caches.TokenServiceRefreshTokenCacheEntry.GetKey(refreshedJwtSecurityToken.Id);

                    refreshTokenKey.Set(_openSettingsMemoryCache, connectTokenResponse.RefreshToken, cacheEntry =>
                    {
                        cacheEntry.AbsoluteExpiration = new DateTimeOffset(refreshedJwtSecurityToken.ValidTo, TimeSpan.Zero);
                    });

                    return HttpStatusCode.OK.ToSuccessResponseOf(new RefreshUserTokenResponse
                    {
                        AccessToken = connectTokenResponse.AccessToken
                    });
                }
            }
        }

        public async Task<IResponse<GenerateTokenResponse>> GenerateTokenAsync(GenerateTokenInput input, CancellationToken cancellationToken)
        {
            var claims = new Claim[]
            {
                new Claim(OpenSettingsDefaults.ClaimTypes.ClientId, $"{input.ClientId}"),
                new Claim(OpenSettingsDefaults.ClaimTypes.JsonTokenId, $"{Guid.NewGuid()}")
            };

            using (var scope = _serviceProvider.CreateScope())
            {
                var appService = scope.ServiceProvider.GetRequiredService<IAppService>();

                var registeredAppResponse = await appService.GetRegisteredAppAsync(new GetRegisteredAppInput
                {
                    ClientId = input.ClientId,
                    ClientSecret = input.ClientSecret
                }, cancellationToken);

                var registeredApp = registeredAppResponse.Data;

                if (!registeredApp.IsClientSecretMatched)
                {
                    return HttpStatusCode.Unauthorized.ToFailureResponse<GenerateTokenResponse>();
                }

                var expires = DateTimeOffset.UtcNow.AddMinutes(30);

                var token = new JwtSecurityToken(
                    issuer: _openSettingsConfiguration.Client.Name,
                    audience: registeredApp.ClientName,
                    claims: claims,
                    expires: expires.UtcDateTime,
                    signingCredentials: _signingCredentials
                );

                var accessToken = WriteJwtToken(token);

                return HttpStatusCode.OK.ToSuccessResponseOf(new GenerateTokenResponse(accessToken, expires));
            }
        }

        private HttpClient GetOAuth2AuthorityHttpClient()
        {
            var httpClient = _httpClientFactory.CreateClient();

            httpClient.BaseAddress = new Uri(_providerInfo.OAuth2.Authority);

            return httpClient;
        }
    }
}