using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

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

            _signingCredentials = new SigningCredentials(OpenSettingsDefaults.Caches.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            _isOAuth2AuthorityMissing = string.IsNullOrWhiteSpace(providerInfo.OAuth2.Authority);
        }

        public async Task<IResponse<GenerateMachineToMachineTokenResponse>> GenerateMachineToMachineTokenAsync(GenerateMachineToMachineTokenInput input, CancellationToken cancellationToken)
        {
            var clientId = $"{input.ClientId}";
            var clientSecret = $"{input.ClientSecret}";

            if (input.CallerType == CallerType.Service)
            {
                return await GenerateMachineToMachineTokenForServiceAsync(input, clientId, clientSecret, cancellationToken);
            }

            var expires = DateTimeOffset.UtcNow + OpenSettingsDefaults.TimeSpans.TokenExpiryTimeSpan;

            var response = await InternalGenerateMachineToMachineTokenAsync(input, clientId, clientSecret, expires, cancellationToken);

            return response == null
                ? HttpStatusCode.Unauthorized.ToFailureResponse<GenerateMachineToMachineTokenResponse>()
                : HttpStatusCode.OK.ToSuccessResponseOf(response);
        }

        public ValueTask<bool> IsOAuth2TokenExpiredAsync(string accessToken, Func<Task<string>> refreshTokenRetrieveFunc)
        {
            var jwtSecurityToken = ReadJwtToken(accessToken);

            return IsOAuth2TokenExpiredAsync(jwtSecurityToken, refreshTokenRetrieveFunc);
        }

        public async ValueTask<bool> IsOAuth2TokenExpiredAsync(JwtSecurityToken jwtSecurityToken, Func<Task<string>> refreshTokenRetrieveFunc)
        {
            var refreshTokenKey = OpenSettingsDefaults.Caches.TokenServiceRefreshOAuth2TokenCacheEntry.GetKey(jwtSecurityToken.Id);

            if (TokenHelper.IsTokenExpired(jwtSecurityToken))
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

        public async Task<IResponse<RefreshUserTokenResponse>> RefreshOAuth2TokenAsync(string accessToken,
            CancellationToken cancellationToken = default)
        {
            var jwtSecurityToken = ReadJwtToken(accessToken);

            var refreshTokenKey = OpenSettingsDefaults.Caches.TokenServiceRefreshOAuth2TokenCacheEntry.GetKey(jwtSecurityToken.Id);

            var currentTime = DateTime.UtcNow;

            if (TokenHelper.IsTokenExpired(jwtSecurityToken, currentTime))
            {
                return HttpStatusCode.Forbidden.ToFailureResponse<RefreshUserTokenResponse, Errors>(Errors.TokenExpired);
            }

            if (!TokenHelper.IsTokenExpirationTimeLessThan(jwtSecurityToken, TimeSpan.FromMinutes(1), currentTime))
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

                        _logger.LogError("Failed to refresh oauth2 token. Status Code: {statusCode}, Content: {content}", response.StatusCode, content);

                        return response.StatusCode.ToFailureResponse<RefreshUserTokenResponse>(content);
                    }

                    var connectTokenResponse = await response.Content.ReadFromJsonAsync<ConnectTokenResponse>(cancellationToken: cancellationToken);

                    var refreshedJwtSecurityToken = ReadJwtToken(connectTokenResponse.AccessToken);

                    refreshTokenKey = OpenSettingsDefaults.Caches.TokenServiceRefreshOAuth2TokenCacheEntry.GetKey(refreshedJwtSecurityToken.Id);

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

        private async Task<IResponse<GenerateMachineToMachineTokenResponse>> GenerateMachineToMachineTokenForServiceAsync(GenerateMachineToMachineTokenInput input, string clientId, string clientSecret, CancellationToken cancellationToken)
        {
            var tokenCacheEntryKey = OpenSettingsDefaults.Caches.TokenServiceGenerateMachineToMachineTokenCacheEntry.GetKey(clientId, clientSecret);

            if (tokenCacheEntryKey.TryGetValue(_openSettingsMemoryCache, out GenerateMachineToMachineTokenResponse response))
            {
                return HttpStatusCode.OK.ToSuccessResponseOf(response);
            }

            var expires = DateTimeOffset.UtcNow + OpenSettingsDefaults.TimeSpans.TokenExpiryTimeSpan;

            response = await InternalGenerateMachineToMachineTokenAsync(input, clientId, clientSecret, expires, cancellationToken);

            if (response == null)
            {
                return HttpStatusCode.Unauthorized.ToFailureResponse<GenerateMachineToMachineTokenResponse>();
            }

            tokenCacheEntryKey.Set(_openSettingsMemoryCache, response, cacheEntry =>
            {
                cacheEntry.AbsoluteExpiration = expires - OpenSettingsDefaults.TimeSpans.TokenExpirySafetyMargin;
            });

            return HttpStatusCode.OK.ToSuccessResponseOf(response);
        }

        private async Task<GenerateMachineToMachineTokenResponse> InternalGenerateMachineToMachineTokenAsync(GenerateMachineToMachineTokenInput input, string clientId, string clientSecret, DateTimeOffset expires, CancellationToken cancellationToken)
        {
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
                    return null;
                }

                //var refreshToken = Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
                //var hashedRefreshToken = SHA256.HashData(refreshToken);

                var claims = Helper.GetOpenSettingsClaims(clientId, registeredApp.ClientName, AuthType.Machine, AuthMethod.Jwt)
                    .Concat(new[]
                        { new Claim(OpenSettingsDefaults.ClaimTypes.JsonTokenId, $"{Guid.NewGuid()}") }
                    );

                var token = new JwtSecurityToken(
                    issuer: _openSettingsConfiguration.Client.Name,
                    audience: registeredApp.ClientName,
                    claims: claims,
                    expires: expires.UtcDateTime,
                    signingCredentials: _signingCredentials
                );

                var accessToken = WriteJwtToken(token);

                return new GenerateMachineToMachineTokenResponse(accessToken, expires, OpenSettingsDefaults.TimeSpans.TokenExpiryTimeSpan.TotalSeconds);
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