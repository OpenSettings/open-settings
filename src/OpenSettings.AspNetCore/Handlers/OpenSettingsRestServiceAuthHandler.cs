using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Handlers
{
    internal class OpenSettingsRestServiceAuthHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly ProviderInfo _providerInfo;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;

        public OpenSettingsRestServiceAuthHandler(IHttpContextAccessor httpContextAccessor, ITokenService tokenService, IOpenSettingsMemoryCache openSettingsMemoryCache, ProviderInfo providerInfo, OpenSettingsConfiguration openSettingsConfiguration)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _providerInfo = providerInfo;
            _openSettingsConfiguration = openSettingsConfiguration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext == null) // Machine To Machine
            {
                request.Headers.Authorization = await GetMachineToMachineTokenAsync(cancellationToken);

                return await base.SendAsync(request, cancellationToken);
            }

            var authHeader = _httpContextAccessor.HttpContext.Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader();

            if (authHeader == null)
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var isRefreshableOAuth2 = authHeader.Scheme == JwtBearerDefaults.AuthenticationScheme && _providerInfo.Authorize && _providerInfo.OAuth2.IsActive && _providerInfo.OAuth2.AllowOfflineAccess;

            if (isRefreshableOAuth2)
            {
                authHeader = await RefreshUserTokenAsync(authHeader, cancellationToken);
            }

            request.Headers.Authorization = authHeader;

            return await base.SendAsync(request, cancellationToken);
        }

        public async ValueTask<AuthenticationHeaderValue> GetMachineToMachineTokenAsync(CancellationToken cancellationToken)
        {
            // todo cache retrieval missing etc.
            var generateTokenResponse = await _tokenService.GenerateTokenAsync(new GenerateTokenInput
            {
                ClientId = _openSettingsConfiguration.Client.Id,
                ClientSecret = _openSettingsConfiguration.Client.Secret,
            }, cancellationToken);

            return !generateTokenResponse.Success
                ? null
                : new AuthenticationHeaderValue(OpenSettingsDefaults.Names.JwtBearerSchemaName, generateTokenResponse.Data.AccessToken);
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

            if (Helpers.Helper.IsTokenExpired(jwtSecurityToken, currentTime))
            {
                accessTokenCacheKey.Remove(_openSettingsMemoryCache);

                return authenticationHeaderValue;
            }

            if (!Helpers.Helper.IsTokenExpirationTimeLessThan(jwtSecurityToken, TimeSpan.FromMinutes(1), currentTime))
            {
                return authenticationHeaderValue;
            }

            var refreshUserTokenResponse = await _tokenService.RefreshUserTokenAsync(accessToken, cancellationToken);

            if (!refreshUserTokenResponse.Success)
            {
                return authenticationHeaderValue;
            }

            accessTokenCacheKey.Set(_openSettingsMemoryCache, refreshUserTokenResponse.Data.AccessToken, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = Helpers.Helper.GetExpiryTimeOffset(refreshUserTokenResponse.Data.Expires)
            });

            return new AuthenticationHeaderValue(OpenSettingsDefaults.Names.JwtBearerSchemaName, refreshUserTokenResponse.Data.AccessToken);
        }
    }
}