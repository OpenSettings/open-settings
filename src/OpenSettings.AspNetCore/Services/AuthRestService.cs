using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Services
{
    internal sealed class AuthRestService : IAuthRestService
    {
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;

        public AuthRestService(IOpenSettingsMemoryCache openSettingsMemoryCache, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, ITokenService tokenService, OpenSettingsConfiguration openSettingsConfiguration)
        {
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
            _openSettingsConfiguration = openSettingsConfiguration;
        }

        public async Task<IResponse<GetAuthStatusResponse>> GetAuthStatusAsync(GetAuthStatusInput input, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new NotSupportedException();
            }

            if (!string.IsNullOrWhiteSpace(input.Uuid) && OpenSettingsDefaults.Caches.AuthServiceUuidCacheEntry.GetKey(input.Uuid).TryGetValue<string>(_openSettingsMemoryCache, out var accessToken))
            {
                return HttpStatusCode.OK.ToSuccessResponseOf(new GetAuthStatusResponse
                {
                    IsAuthenticated = true,
                    AccessToken = accessToken
                });
            }

            if (httpContext.User.Identity?.IsAuthenticated ?? false)
            {
                return HttpStatusCode.OK.ToSuccessResponseOf(new GetAuthStatusResponse
                {
                    IsAuthenticated = true,
                    AccessToken = null
                });
            }

            var authHeader = httpContext.Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader();

            if (authHeader?.Parameter == null)
            {
                return HttpStatusCode.OK.ToSuccessResponseOf(new GetAuthStatusResponse
                {
                    IsAuthenticated = false,
                    AccessToken = null
                });
            }

            AuthenticateResult authenticateResult;

            switch (authHeader.Scheme)
            {
                case OpenSettingsDefaults.Names.JwtBearerSchemaName:
                    authenticateResult = await httpContext.AuthenticateAsync(OpenSettingsDefaults.AuthSchemes.JwtBearer);
                    break;

                case OpenSettingsDefaults.Names.BasicSchemeName:
                    authenticateResult = await httpContext.AuthenticateAsync(OpenSettingsDefaults.AuthSchemes.Basic);
                    break;

                default:
                    return HttpStatusCode.OK.ToSuccessResponseOf(new GetAuthStatusResponse
                    {
                        IsAuthenticated = false,
                        AccessToken = null
                    });
            }

            return HttpStatusCode.OK.ToSuccessResponseOf(new GetAuthStatusResponse
            {
                IsAuthenticated = authenticateResult.Succeeded,
                AccessToken = null
            });
        }

        public void ReturnTo(ReturnToInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Uuid) || string.IsNullOrWhiteSpace(input.AccessToken))
            {
                return;
            }

            var cacheKey = OpenSettingsDefaults.Caches.AuthServiceUuidCacheEntry.GetKey(input.Uuid);

            cacheKey.Set(_openSettingsMemoryCache, input.AccessToken);
        }

        public async Task<IResponse<GetIdentityResponse>> GetIdentityAsync(GetIdentityInput input, CancellationToken cancellationToken = default)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new NotSupportedException();
            }

            var httpClient = GetProviderHttpClient();

            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{OpenSettingsDefaults.Routes.V1.Auth}/identity"))
            {
                httpRequestMessage.Headers.Authorization = httpContext.Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader();

                using (var response = await httpClient.SendAsync(httpRequestMessage, cancellationToken))
                {
                    return await response.Content.ToResponseAsync<GetIdentityResponse>(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task LoginAsync(LoginInput input, CancellationToken cancellationToken = default)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new NotSupportedException();
            }

            if (string.IsNullOrWhiteSpace(input.ReturnUrl))
            {
                input.ReturnUrl = httpContext.Request.Headers[OpenSettingsDefaults.Headers.Referer].ToString().TrimEnd(OpenSettingsDefaults.Format.SlashChar);
            }

            var baseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            var authenticateResult = await httpContext.AuthenticateAsync(OpenSettingsDefaults.AuthSchemes.JwtBearer);

            if (!authenticateResult.Succeeded)
            {
                if (string.IsNullOrWhiteSpace(input.ReturnUrl))
                {
                    input.ReturnUrl = $"{baseUrl}/";
                }

                if (string.IsNullOrEmpty(input.ApiUrl))
                {
                    input.ApiUrl = $"{baseUrl}/{_openSettingsConfiguration.Controller.Route}";
                }

                var redirectLoginUrl = $"{_openSettingsConfiguration.Consumer.ProviderUrl}v1/auth/login?returnUrl={input.ReturnUrl}&apiUrl={input.ApiUrl}&uuid={input.Uuid}";

                httpContext.Response.Redirect(redirectLoginUrl);
                return;
            }

            if (authenticateResult.Properties != null)
            {
                if (authenticateResult.Properties.Items.TryGetValue(OpenSettingsDefaults.Keys.AuthService.ReturnUrl, out var returnUrlFromItem) && string.IsNullOrWhiteSpace(input.ReturnUrl))
                {
                    input.ReturnUrl = returnUrlFromItem ?? string.Empty;
                }

                if (authenticateResult.Properties.Items.TryGetValue(OpenSettingsDefaults.Keys.AuthService.ApiUrl, out var apiUrlFromItem) && string.IsNullOrWhiteSpace(input.ApiUrl))
                {
                    input.ApiUrl = apiUrlFromItem ?? string.Empty;
                }

                if (authenticateResult.Properties.Items.TryGetValue(OpenSettingsDefaults.Keys.AuthService.Uuid, out var uuidFromItem) && string.IsNullOrWhiteSpace(input.Uuid))
                {
                    input.Uuid = uuidFromItem;
                }
            }

            if (input.ApiUrl.StartsWith(baseUrl))
            {
                httpContext.Response.Redirect(input.ReturnUrl);
                return;
            }

            var accessToken = await httpContext.GetTokenAsync(OpenSettingsDefaults.AuthSchemes.Cookie, "access_token");

            // previously claims were stored in here!

            //var isUserTokenExpired = await _tokenService.IsOAuth2TokenExpiredAsync(accessToken,
            //    () => httpContext.GetTokenAsync(OpenSettingsDefaults.AuthSchemes.Cookie,
            //        OpenSettingsDefaults.ClaimTypes.RefreshToken));

            //if (isUserTokenExpired)
            //{
            //    await httpContext.SignOutAsync(OpenSettingsDefaults.AuthSchemes.Cookie);
            //    return;
            //}

            var redirectReturnToUrl = $"{input.ApiUrl}/v1/auth/return-to?returnUrl={input.ReturnUrl}&accessToken={accessToken}&uuid={input.Uuid}";

            httpContext.Response.Redirect(redirectReturnToUrl);
        }

        public Task LogoutAsync(LogoutInput input, CancellationToken cancellationToken = default)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new NotSupportedException();
            }

            var baseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            if (string.IsNullOrWhiteSpace(input.ReturnUrl))
            {
                input.ReturnUrl = httpContext.Request.Headers[OpenSettingsDefaults.Headers.Referer].ToString().TrimEnd(OpenSettingsDefaults.Format.SlashChar);

                if (string.IsNullOrWhiteSpace(input.ReturnUrl))
                {
                    input.ReturnUrl = $"{baseUrl}/"; ;
                }
            }

            if (string.IsNullOrEmpty(input.ApiUrl))
            {
                input.ApiUrl = $"{baseUrl}/{_openSettingsConfiguration.Controller.Route}";
            }

            var redirectLogoutUrl = $"{_openSettingsConfiguration.Consumer.ProviderUrl}v1/auth/logout?returnUrl={input.ReturnUrl}&apiUrl={input.ApiUrl}";

            httpContext.Response.Redirect(redirectLogoutUrl);

            return Task.CompletedTask;
        }

        private HttpClient GetProviderHttpClient()
        {
            return _httpClientFactory.CreateOpenSettingsProviderHttpClient();
        }
    }
}