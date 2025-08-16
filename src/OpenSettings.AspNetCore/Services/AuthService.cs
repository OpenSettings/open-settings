using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Ogu.Response;
using Ogu.Response.Abstractions;
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
using OpenSettings.Extensions;

namespace OpenSettings.AspNetCore.Services
{
    internal sealed class AuthService : IAuthService
    {
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly ProviderInfo _providerInfo;

        public AuthService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IOpenSettingsMemoryCache openSettingsMemoryCache, OpenSettingsConfiguration openSettingsConfiguration, ProviderInfo providerInfo)
        {
            _logger = openSettingsConfiguration.LoggerFactory.CreateLogger<AuthService>();
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _openSettingsConfiguration = openSettingsConfiguration;
            _providerInfo = providerInfo;
        }

        public Task<IResponse<GetMeResponse>> GetMeAsync(GetMeInput input, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new NotSupportedException(nameof(GetMeAsync));
            }

            if (!httpContext.User.Identity?.IsAuthenticated ?? true)
            {
                return Task.FromResult(HttpStatusCode.OK.ToSuccessResponseOf(new GetMeResponse
                {
                    IsAuthenticated = false
                }));
            }

            Dictionary<string, string> claimTypeToValue;

            if (input.Includes.HasFlag(GetMeInputIncludes.Claims))
            {
                var claims = httpContext.User.Claims;

                if (string.IsNullOrWhiteSpace(input.ClaimTypes))
                {
                    claimTypeToValue = claims.GroupBy(c => c.Type)
                        .ToDictionary(c => c.Key, c => string.Join(OpenSettingsDefaults.Format.Comma, c.Select(claim => claim.Value)));
                }
                else
                {
                    var claimArray = input.ClaimTypes
                        .Split(OpenSettingsDefaults.Separators.CommaSeparator, StringSplitOptions.RemoveEmptyEntries)
                        .Select(claimType => claimType.Trim())
                        .Where(claimType => claimType != string.Empty)
                        .Distinct()
                        .ToArray();

                    claimTypeToValue = claims
                        .GroupBy(c => c.Type)
                        .Select(c => new { Type = c.Key, Value = string.Join(OpenSettingsDefaults.Format.Comma, c.Select(claim => claim.Value)) })
                        .Where(claim => claimArray.Contains(claim.Type))
                        .OrderBy(claim => Array.IndexOf(claimArray, claim.Type))
                        .ToDictionary(c => c.Type, c => c.Value);
                }
            }
            else
            {
                claimTypeToValue = null;
            }

            return Task.FromResult(HttpStatusCode.OK.ToSuccessResponseOf(new GetMeResponse
            {
                IsAuthenticated = true,
                AccessToken = null,
                Claims = claimTypeToValue
            }));
        }

        public void ReturnTo(ReturnToInput input)
        {
            // Redundant while running in the provider mode.
        }

        public async Task LoginAsync(LoginInput input, CancellationToken cancellationToken = default)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new NotSupportedException();
            }

            var baseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            if (string.IsNullOrWhiteSpace(input.ReturnUrl) || 
                string.IsNullOrWhiteSpace(input.ApiUrl) || 
                !input.ClientId.HasValue)
            {
                input.ReturnUrl = $"{baseUrl}/{_openSettingsConfiguration.Spa.RoutePrefix}";
                httpContext.Response.Redirect(input.ReturnUrl);
                return;
            }

            var authenticateResult = await httpContext.AuthenticateAsync(OpenSettingsDefaults.AuthSchemes.OAuth2);

            if (!authenticateResult.Succeeded)
            {
                try
                {
                    await httpContext.ChallengeAsync(OpenSettingsDefaults.AuthSchemes.OAuth2,
                        new AuthenticationProperties(new Dictionary<string, string>
                        {
                            { OpenSettingsDefaults.Keys.AuthService.ReturnUrl, input.ReturnUrl },
                            { OpenSettingsDefaults.Keys.AuthService.ApiUrl, input.ApiUrl },
                            { OpenSettingsDefaults.Keys.AuthService.StateId, input.StateId },
                            { OpenSettingsDefaults.Keys.AuthService.ClientId, $"{input.ClientId}" },
                        }));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception occurred while OAuth2 login challenge.");
                    httpContext.Response.Redirect(input.ReturnUrl);
                }

                return;
            }

            if (authenticateResult.Properties.Items.TryGetValue(OpenSettingsDefaults.Keys.AuthService.ReturnUrl, out var returnUrlFromItem) && string.IsNullOrWhiteSpace(input.ReturnUrl))
            {
                input.ReturnUrl = returnUrlFromItem ?? string.Empty;
            }

            if (authenticateResult.Properties.Items.TryGetValue(OpenSettingsDefaults.Keys.AuthService.ApiUrl, out var apiUrlFromItem) && string.IsNullOrWhiteSpace(input.ApiUrl))
            {
                input.ApiUrl = apiUrlFromItem ?? string.Empty;
            }

            if (authenticateResult.Properties.Items.TryGetValue(OpenSettingsDefaults.Keys.AuthService.StateId, out var stateIdFromItem) && string.IsNullOrWhiteSpace(input.StateId))
            {
                input.StateId = stateIdFromItem;
            }

            _ = authenticateResult.Properties.Items.TryGetValue(OpenSettingsDefaults.Keys.AuthService.ClientId, out var clientId);

            _ = authenticateResult.Properties.Items.TryGetValue(OpenSettingsDefaults.Keys.AuthService.AccessToken, out var accessToken);

            var redirectReturnToUrl = $"{input.ApiUrl}/v1/auth/return-to?returnUrl={Uri.EscapeDataString(input.ReturnUrl)}&accessToken={accessToken}&stateId={input.StateId}";

            httpContext.Response.Redirect(redirectReturnToUrl);
        }

        public async Task LogoutAsync(LogoutInput input, CancellationToken cancellationToken = default)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new NotSupportedException(nameof(LogoutAsync));
            }

            if (string.IsNullOrWhiteSpace(input.ReturnUrl))
            {
                input.ReturnUrl = httpContext.Request.Headers[OpenSettingsDefaults.Headers.Referer].ToString().TrimEnd(OpenSettingsDefaults.Format.SlashChar);
            }

            try
            {
                var isIdpOnline = await IsIdpOnlineAsync(cancellationToken);

                await httpContext.SignOutAsync(OpenSettingsDefaults.AuthSchemes.Cookie);

                if (isIdpOnline)
                {
                    await httpContext.SignOutAsync(OpenSettingsDefaults.AuthSchemes.OAuth2);
                }
                else
                {
                    httpContext.Response.Redirect(input.ReturnUrl);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while trying to logout from OAuth2 provider.");

                await httpContext.SignOutAsync(OpenSettingsDefaults.AuthSchemes.Cookie);

                if (!string.IsNullOrWhiteSpace(input.ReturnUrl))
                {
                    httpContext.Response.Redirect(input.ReturnUrl);
                    return;
                }

                httpContext.Response.StatusCode = 500;

                await httpContext.Response.WriteAsync("Identity service isn't accessible at this moment!.", cancellationToken);
            }
        }

        private async Task<bool> IsIdpOnlineAsync(CancellationToken cancellationToken = default)
        {
            if (OpenSettingsDefaults.Caches.AuthServiceIsIdpOnlineCheckCacheEntryKey.TryGetValue(_openSettingsMemoryCache, out bool isIdpOnline))
            {
                return isIdpOnline;
            }

            var client = _httpClientFactory.CreateClient();

            var requestUri = $"{_providerInfo.OAuth2.Authority.TrimEnd('/')}/.well-known/openid-configuration";

            using (var response = await client.GetAsync(
                       requestUri,
                       HttpCompletionOption.ResponseHeadersRead,
                       cancellationToken))
            {
                isIdpOnline = response.IsSuccessStatusCode;

                OpenSettingsDefaults.Caches.AuthServiceIsIdpOnlineCheckCacheEntryKey.Set(_openSettingsMemoryCache, isIdpOnline);

                return isIdpOnline;
            }
        }
    }
}