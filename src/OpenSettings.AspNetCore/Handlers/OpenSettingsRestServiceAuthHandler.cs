using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using OpenSettings.AspNetCore.Services.Interfaces;
using OpenSettings.Configurations;
using OpenSettings.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using OpenSettings.Services.Interfaces;

namespace OpenSettings.AspNetCore.Handlers
{
    internal class OpenSettingsRestServiceAuthHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOpenSettingsTokenService _openSettingsTokenService;
        private readonly ProviderInfo _providerInfo;
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;

        public OpenSettingsRestServiceAuthHandler(IHttpContextAccessor httpContextAccessor, IOpenSettingsTokenService openSettingsTokenService, ProviderInfo providerInfo, IOpenSettingsMemoryCache openSettingsMemoryCache, OpenSettingsConfiguration openSettingsConfiguration)
        {
            _httpContextAccessor = httpContextAccessor;
            _openSettingsTokenService = openSettingsTokenService;
            _providerInfo = providerInfo;
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _openSettingsConfiguration = openSettingsConfiguration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authHeader = _httpContextAccessor.HttpContext?.Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader();

            if (authHeader == null)
            {
                return await base.SendAsync(request, cancellationToken);
            }

            if (authHeader.Scheme == JwtBearerDefaults.AuthenticationScheme && _providerInfo.OAuth2.IsActive && _providerInfo.OAuth2.AllowOfflineAccess)
            {
                var receivedAuthParameter = authHeader.Parameter;

                if (_openSettingsMemoryCache.TryGetValue<string>(GetAccessTokenKey(receivedAuthParameter), out var accessToken))
                {
                    authHeader = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, accessToken);
                }

                var jwtSecurityToken = _openSettingsTokenService.ReadJwtToken(authHeader.Parameter);

                var validTo = jwtSecurityToken.ValidTo;

                var currentUtcTime = DateTime.UtcNow;
                var timeToExpiration = validTo - currentUtcTime;

                if (validTo > currentUtcTime && timeToExpiration.TotalMinutes <= 1)
                {
                    var refreshTokenRequest =
                        new HttpRequestMessage(HttpMethod.Post, $"{_openSettingsConfiguration.Consumer.ProviderUrl}/refresh-token");

                    refreshTokenRequest.Headers.Authorization = authHeader;

                    var refreshTokenResponse = await base.SendAsync(refreshTokenRequest, cancellationToken);

                    if (refreshTokenResponse.IsSuccessStatusCode)
                    {
                        var newAccessToken =
#if NET5_0_OR_GREATER
                            await refreshTokenResponse.Content.ReadAsStringAsync(cancellationToken);
#else
                            await refreshTokenResponse.Content.ReadAsStringAsync();
#endif

                        _openSettingsMemoryCache.Set(GetAccessTokenKey(receivedAuthParameter), newAccessToken);

                        authHeader = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, newAccessToken);
                    }
                }
            }

            request.Headers.Authorization = authHeader;

            return await base.SendAsync(request, cancellationToken);
        }

        private static string GetAccessTokenKey(string accessToken) => $"{nameof(GetAccessTokenKey)}:{accessToken}";
    }
}