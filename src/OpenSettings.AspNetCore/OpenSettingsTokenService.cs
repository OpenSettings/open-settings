using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using OpenSettings.AspNetCore.Models.Responses;
using OpenSettings.Models;
using OpenSettings.Services.MemoryCache;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore
{
    internal sealed class OpenSettingsTokenService : IOpenSettingsTokenService
    {
        private readonly JwtSecurityTokenHandler _jwtHandler;
        private readonly OpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly ControllerOptions _controllerOptions;
        private readonly HttpClient _httpClient;

        public OpenSettingsTokenService(OpenSettingsMemoryCache openSettingsMemoryCache, ProviderInfo providerInfo, ControllerOptions controllerOptions, IHttpClientFactory httpClientFactory)
        {
            _jwtHandler = new JwtSecurityTokenHandler();
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _controllerOptions = controllerOptions;

            if (string.IsNullOrWhiteSpace(providerInfo.OAuth2.Authority))
            {
                return;
            }

            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(providerInfo.OAuth2.Authority);
        }

        public Task<bool> IsTokenExpiredAsync(HttpContext httpContext, string accessToken)
        {
            var jwtSecurityToken = ReadJwtToken(accessToken);

            return IsTokenExpiredAsync(httpContext, jwtSecurityToken);
        }

        public JwtSecurityToken ReadJwtToken(string accessToken)
        {
            return _jwtHandler.ReadJwtToken(accessToken);
        }

        public async Task<string> RefreshTokenAsync(HttpContext httpContext, CancellationToken cancellationToken = default)
        {
            var authHeaderValue = httpContext.Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader();

            if (authHeaderValue?.Scheme != JwtBearerDefaults.AuthenticationScheme)
            {
                return null;
            }

            var jwtSecurityToken = ReadJwtToken(authHeaderValue.Parameter);

            if (IsTokenExpired(jwtSecurityToken) || !IsTokenExpirationTimeLessThan(jwtSecurityToken, TimeSpan.FromMinutes(1)))
            {
                return null;
            }

            if (!_openSettingsMemoryCache.TryGetValue<string>(GetRefreshTokenKey(jwtSecurityToken), out var cachedRefreshToken) || string.IsNullOrWhiteSpace(cachedRefreshToken))
            {
                return null;
            }

            if (_httpClient == null)
            {
                throw new NotSupportedException(nameof(RefreshTokenAsync));
            }

            using (var request = new HttpRequestMessage(HttpMethod.Post, "connect/token"))
            {
                request.Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("refresh_token", cachedRefreshToken),
                    new KeyValuePair<string, string>("client_id", _controllerOptions.OAuth2Options.ClientId),
                    new KeyValuePair<string, string>("client_secret", _controllerOptions.OAuth2Options.ClientSecret)
                });

                using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }

                    var refreshTokenResponse = await response.Content.ReadFromJsonAsync<RefreshTokenResponse>(cancellationToken);

                    var refreshedJwtSecurityToken = ReadJwtToken(refreshTokenResponse.AccessToken);

                    _openSettingsMemoryCache.Set(GetRefreshTokenKey(refreshedJwtSecurityToken),
                        refreshTokenResponse.RefreshToken, new MemoryCacheEntryOptions
                        {
                            AbsoluteExpiration = refreshedJwtSecurityToken.ValidTo
                        });

                    return refreshTokenResponse.AccessToken;
                }
            }
        }

        public async Task<bool> IsTokenExpiredAsync(HttpContext httpContext, JwtSecurityToken jwtSecurityToken)
        {
            if (IsTokenExpired(jwtSecurityToken))
            {
                _openSettingsMemoryCache.Remove(GetRefreshTokenKey(jwtSecurityToken));

                return true;
            }

            await _openSettingsMemoryCache.GetOrCreateAsync(GetRefreshTokenKey(jwtSecurityToken), async cacheEntry =>
            {
                var refreshToken = await httpContext.GetTokenAsync(OpenSettings.Constants.OpenSettingsCookieScheme, "refresh_token");

                cacheEntry.AbsoluteExpiration = jwtSecurityToken.ValidTo;

                return refreshToken;
            });

            return false;

        }

        private static bool IsTokenExpired(SecurityToken securityToken)
        {
            return securityToken.ValidTo < DateTime.UtcNow;
        }

        private static bool IsTokenExpirationTimeLessThan(SecurityToken securityToken, TimeSpan timeSpan) => securityToken.ValidTo - DateTime.UtcNow < timeSpan;

        private static string GetRefreshTokenKey(SecurityToken securityToken) => $"{nameof(GetRefreshTokenKey)}:{securityToken.Id}";
    }
}