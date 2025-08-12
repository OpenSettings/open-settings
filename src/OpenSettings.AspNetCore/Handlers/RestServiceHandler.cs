using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models;
using OpenSettings.Services.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Handlers
{
    internal class RestServiceHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly ProviderInfo _providerInfo;

        public RestServiceHandler(IHttpContextAccessor httpContextAccessor, ITokenService tokenService, IOpenSettingsMemoryCache openSettingsMemoryCache, ProviderInfo providerInfo)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _providerInfo = providerInfo;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext == null) // Machine To Machine
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var callerType = _httpContextAccessor.HttpContext.Request.Headers.GetCallerTypeHeaderValueOrDefault();

            request.Headers.TryAddWithoutValidation(OpenSettingsDefaults.Headers.CallerType, $"{callerType}");

            var authHeader = _httpContextAccessor.HttpContext.Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader();

            if (authHeader == null)
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var authType = _httpContextAccessor.HttpContext.Request.Headers.GetAuthTypeHeaderValueOrDefault();

            request.Headers.TryAddWithoutValidation(OpenSettingsDefaults.Headers.AuthType, $"{authType}");

            var isRefreshableOAuth2 = authType == AuthType.OAuth2 && 
                                      authHeader.Scheme == JwtBearerDefaults.AuthenticationScheme && 
                                      _providerInfo.Authorize && _providerInfo.OAuth2.IsActive && 
                                      _providerInfo.OAuth2.AllowOfflineAccess;

            if (isRefreshableOAuth2)
            {
                authHeader = await RefreshUserTokenAsync(authHeader, cancellationToken);
            }

            request.Headers.Authorization = authHeader;

            return await base.SendAsync(request, cancellationToken);
        }

        public async ValueTask<AuthenticationHeaderValue> RefreshUserTokenAsync(AuthenticationHeaderValue authenticationHeaderValue, CancellationToken cancellationToken)
        {
            var jwtSecurityToken = _tokenService.ReadJwtToken(authenticationHeaderValue.Parameter);

            var accessTokenCacheKey = OpenSettingsDefaults.Caches.RestServiceAuthHandlerAccessTokenCacheEntry.GetKey(jwtSecurityToken.Id);

            if (accessTokenCacheKey.TryGetValue<string>(_openSettingsMemoryCache, out var cachedAccessToken))
            {
                jwtSecurityToken = _tokenService.ReadJwtToken(cachedAccessToken);
            }

            var accessToken = string.IsNullOrWhiteSpace(jwtSecurityToken.RawData)
                ? _tokenService.WriteJwtToken(jwtSecurityToken)
                : jwtSecurityToken.RawData;

            var currentTime = DateTime.UtcNow;

            if (TokenHelper.IsTokenExpired(jwtSecurityToken, currentTime))
            {
                accessTokenCacheKey.Remove(_openSettingsMemoryCache);

                return authenticationHeaderValue;
            }

            if (!TokenHelper.IsTokenExpirationTimeLessThan(jwtSecurityToken, TimeSpan.FromMinutes(1), currentTime))
            {
                return authenticationHeaderValue;
            }

            var refreshUserTokenResponse = await _tokenService.RefreshOAuth2TokenAsync(accessToken, cancellationToken);

            if (!refreshUserTokenResponse.Success)
            {
                return authenticationHeaderValue;
            }

            accessTokenCacheKey.Set(_openSettingsMemoryCache, refreshUserTokenResponse.Data.AccessToken, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = Helper.GetExpiryTimeOffset(refreshUserTokenResponse.Data.Expires)
            });

            return new AuthenticationHeaderValue(OpenSettingsDefaults.Names.JwtBearerSchemaName, refreshUserTokenResponse.Data.AccessToken);
        }
    }
}