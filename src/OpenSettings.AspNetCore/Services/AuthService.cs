using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Configurations;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NotSupportedException = System.NotSupportedException;

namespace OpenSettings.AspNetCore.Services
{
    internal sealed class AuthService : IAuthService
    {
        private readonly ILogger _logger;
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly ProviderInfo _providerInfo;

        public AuthService(ILogger<AuthService> logger, IOpenSettingsMemoryCache openSettingsMemoryCache, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, ITokenService tokenService,  OpenSettingsConfiguration openSettingsConfiguration, ProviderInfo providerInfo)
        {
            _logger = logger;
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
            _openSettingsConfiguration = openSettingsConfiguration;
            _providerInfo = providerInfo;
        }

        public async Task<IResponse<IsAuthenticatedResponse>> IsAuthenticatedAsync(IsAuthenticatedInput input, CancellationToken cancellationToken = default)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new NotSupportedException();
            }

            if (httpContext.User.Identity?.IsAuthenticated ?? false)
            {
                return HttpStatusCode.OK.ToSuccessResponseOf(new IsAuthenticatedResponse
                {
                    IsAuthenticated = true,
                    AccessToken = null
                });
            }

            var authHeader = httpContext.Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader();

            if (authHeader?.Parameter != OpenSettingsDefaults.Names.BasicSchemeName)
            {
                return HttpStatusCode.OK.ToSuccessResponseOf(new IsAuthenticatedResponse
                {
                    IsAuthenticated = false,
                    AccessToken = null
                });
            }

            var authenticateResult = await httpContext.AuthenticateAsync(OpenSettingsDefaults.AuthSchemes.Basic);

            return HttpStatusCode.OK.ToSuccessResponseOf(new IsAuthenticatedResponse
            {
                IsAuthenticated = authenticateResult.Succeeded,
                AccessToken = null
            });
        }

        public void ReturnTo(ReturnToInput input)
        {
        }

        public Task<IResponse<WhoAmIResponse>> WhoAmIAsync(WhoAmIInput input, CancellationToken cancellationToken = default)
        {
            // previously it was using _openSettingsMemoryCache to get the claims, but now we are using HttpContext.User.Claims directly.
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new NotSupportedException();
            }

            var claims = httpContext.User.Claims;

            if (string.IsNullOrWhiteSpace(input.ClaimTypes))
            {
                var claimTypeToValue = claims.GroupBy(c => c.Type)
                    .ToDictionary(c => c.Key, c => string.Join(OpenSettingsDefaults.Format.Comma, c.Select(claim => claim.Value)));

                return Task.FromResult(HttpStatusCode.OK.ToSuccessResponseOf(new WhoAmIResponse
                {
                    Claims = claimTypeToValue
                }));
            }

            var claimArray = input.ClaimTypes
                .Split(OpenSettingsDefaults.Separators.CommaSeparator, StringSplitOptions.RemoveEmptyEntries)
                .Select(claimType => claimType.Trim())
                .Where(claimType => claimType != string.Empty)
                .Distinct()
                .ToArray();

            var filteredClaimTypeToValue = claims
                .GroupBy(c => c.Type)
                .Select(c => new { Type = c.Key, Value = string.Join(OpenSettingsDefaults.Format.Comma, c.Select(claim => claim.Value)) })
                .Where(claim => claimArray.Contains(claim.Type))
                .OrderBy(claim => Array.IndexOf(claimArray, claim.Type))
                .ToDictionary(c => c.Type, c => c.Value);

            return Task.FromResult(HttpStatusCode.OK.ToSuccessResponseOf(new WhoAmIResponse
            {
                Claims = filteredClaimTypeToValue
            }));
        }

        public async Task LoginAsync(LoginInput input, CancellationToken cancellationToken = default)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new NotSupportedException();
            }

            var authenticateResult = await httpContext.AuthenticateAsync(OpenSettingsDefaults.AuthSchemes.OAuth2);

            if (string.IsNullOrWhiteSpace(input.ReturnUrl))
            {
                input.ReturnUrl = httpContext.Request.Headers[OpenSettingsDefaults.Headers.Referer].ToString().TrimEnd(OpenSettingsDefaults.Format.SlashChar);
            }

            if (!authenticateResult.Succeeded)
            {
                if (string.IsNullOrWhiteSpace(input.ReturnUrl))
                {
                    input.ReturnUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/";
                }

                if (string.IsNullOrEmpty(input.ApiUrl))
                {
                    input.ApiUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/{_openSettingsConfiguration.Controller.Route}";
                }

                try
                {
                    await httpContext.ChallengeAsync(OpenSettingsDefaults.AuthSchemes.OAuth2,
                        new AuthenticationProperties(new Dictionary<string, string>
                        {
                            { Keys.ReturnUrl, input.ReturnUrl },
                            { Keys.ApiUrl, input.ApiUrl },
                            { Keys.Uuid, input.Uuid }
                        }));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception occurred while OAuth2 login challenge.");
                    httpContext.Response.Redirect(input.ReturnUrl);
                }

                return;
            }

            if (authenticateResult.Properties != null)
            {
                if (authenticateResult.Properties.Items.TryGetValue(Keys.ReturnUrl, out var returnUrlFromItem) && string.IsNullOrWhiteSpace(input.ReturnUrl))
                {
                    input.ReturnUrl = returnUrlFromItem ?? string.Empty;
                }

                if (authenticateResult.Properties.Items.TryGetValue(Keys.ApiUrl, out var apiUrlFromItem) && string.IsNullOrWhiteSpace(input.ApiUrl))
                {
                    input.ApiUrl = apiUrlFromItem ?? string.Empty;
                }

                if (authenticateResult.Properties.Items.TryGetValue(Keys.Uuid, out var uuidFromItem) && string.IsNullOrWhiteSpace(input.Uuid))
                {
                    input.Uuid = uuidFromItem;
                }
            }

            var baseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            if (input.ApiUrl.StartsWith(baseUrl))
            {
                httpContext.Response.Redirect(input.ReturnUrl);
                return;
            }

            var accessToken = await httpContext.GetTokenAsync(OpenSettingsDefaults.AuthSchemes.Cookie, "access_token");

            // previously claims were stored in here!

            var isUserTokenExpired = await _tokenService.IsUserTokenExpiredAsync(accessToken,
                () => httpContext.GetTokenAsync(OpenSettingsDefaults.AuthSchemes.Cookie,
                    OpenSettingsDefaults.ClaimTypes.RefreshToken));

            if (isUserTokenExpired)
            {
                await httpContext.SignOutAsync(OpenSettingsDefaults.AuthSchemes.Cookie);
                return;
            }

            var redirectReturnToUrl = $"{input.ApiUrl}/v1/auth/return-to?returnUrl={input.ReturnUrl}&accessToken={accessToken}&uuid={input.Uuid}";

            httpContext.Response.Redirect(redirectReturnToUrl);
        }

        public async Task LogoutAsync(LogoutInput input, CancellationToken cancellationToken = default)
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

            try
            {
                using (var response = await _httpClientFactory.CreateClient().GetAsync($"{_providerInfo.OAuth2.Authority.TrimEnd('/')}/.well-known/openid-configuration", cancellationToken))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        await httpContext.SignOutAsync(OpenSettingsDefaults.AuthSchemes.Cookie);
                        await httpContext.SignOutAsync(OpenSettingsDefaults.AuthSchemes.OAuth2);

                        return;
                    }

                    await httpContext.SignOutAsync(OpenSettingsDefaults.AuthSchemes.Cookie);

                    httpContext.Response.Redirect(input.ReturnUrl);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while trying to logout from OAuth2 provider.");

                await httpContext.SignOutAsync(OpenSettingsDefaults.AuthSchemes.Cookie);

                if (!string.IsNullOrWhiteSpace(input.ReturnUrl))
                {
                    httpContext.Response.Redirect(input.ReturnUrl);
                    return;
                }

                httpContext.Response.StatusCode = 500;

                await httpContext.Response.WriteAsync("Identity service isn't accessible at this moment!", cancellationToken);
            }
        }

        private static class Keys
        {
            public const string ReturnUrl = "ReturnUrl";
            public const string ApiUrl = "ApiUrl";
            public const string Uuid = "uuid";
        }
    }
}