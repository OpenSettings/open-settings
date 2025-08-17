using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Services
{
    internal sealed class AuthRestService : IAuthRestService
    {
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;

        public AuthRestService(IOpenSettingsMemoryCache openSettingsMemoryCache, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, OpenSettingsConfiguration openSettingsConfiguration)
        {
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _openSettingsConfiguration = openSettingsConfiguration;
        }

        public async Task<IResponse<GetMeResponse>> GetMeAsync(GetMeInput input, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new NotSupportedException(nameof(GetMeAsync));
            }

            if (httpContext.User.Identity?.IsAuthenticated != true)
            {
                var authHeader = httpContext.Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader();

                if (authHeader?.Parameter == null)
                {
                    if (input.StateId == null)
                    {
                        return HttpStatusCode.OK.ToSuccessResponseOf(new GetMeResponse
                        {
                            IsAuthenticated = false
                        });
                    }

                    var httpClient = GetProviderHttpClient();

                    using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{OpenSettingsDefaults.Routes.V1.Auth}/me"))
                    {
                        using (var response = await httpClient.SendAsync(httpRequestMessage, cancellationToken))
                        {
                            return await response.Content.ToResponseAsync<GetMeResponse>(cancellationToken: cancellationToken);
                        }
                    }
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
                        authenticateResult = null;
                        break;
                }

                if (authenticateResult == null || !authenticateResult.Succeeded)
                {
                    return HttpStatusCode.OK.ToSuccessResponseOf(new GetMeResponse
                    {
                        IsAuthenticated = false
                    });
                }

                return HttpStatusCode.OK.ToSuccessResponseOf(new GetMeResponse
                {
                    IsAuthenticated = true,
                    AccessToken = null,
                    Claims = GetClaimsByFiltering(authenticateResult.Principal.Claims, input.Includes, input.ClaimTypes)
                });
            }

            var claims = GetClaimsByFiltering(httpContext.User.Claims, input.Includes, input.ClaimTypes);

            return HttpStatusCode.OK.ToSuccessResponseOf(new GetMeResponse
            {
                IsAuthenticated = true,
                AccessToken = null,
                Claims = claims
            });

            Dictionary<string, string> GetClaimsByFiltering(IEnumerable<Claim> claimsInput, GetMeInputIncludes includes, string claimTypes)
            {
                if (!includes.HasFlag(GetMeInputIncludes.Claims))
                {
                    return null;
                }

                if (string.IsNullOrWhiteSpace(claimTypes))
                {
                    return claimsInput.GroupBy(c => c.Type)
                        .ToDictionary(c => c.Key, c => string.Join(OpenSettingsDefaults.Format.Comma, c.Select(claim => claim.Value)));
                }

                var claimArray = claimTypes
                    .Split(OpenSettingsDefaults.Separators.CommaSeparator, StringSplitOptions.RemoveEmptyEntries)
                    .Select(claimType => claimType.Trim())
                    .Where(claimType => claimType != string.Empty)
                    .Distinct()
                    .ToArray();

                return claimsInput
                    .GroupBy(c => c.Type)
                    .Select(c => new { Type = c.Key, Value = string.Join(OpenSettingsDefaults.Format.Comma, c.Select(claim => claim.Value)) })
                    .Where(claim => claimArray.Contains(claim.Type))
                    .OrderBy(claim => Array.IndexOf(claimArray, claim.Type))
                    .ToDictionary(c => c.Type, c => c.Value);
            }

        }

        public async Task LoginAsync(LoginInput input, CancellationToken cancellationToken = default)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new NotSupportedException();
            }

            var baseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            var spaLocation = $"{baseUrl}/{_openSettingsConfiguration.Spa.RoutePrefix}";

            if (string.IsNullOrWhiteSpace(input.ReturnUrl))
            {
                input.ReturnUrl = spaLocation;
            }
            else if(!input.ReturnUrl.StartsWith(baseUrl))
            {
                httpContext.Response.Redirect(spaLocation);
                return;
            }

            var authenticateResult = await httpContext.AuthenticateAsync(OpenSettingsDefaults.AuthSchemes.JwtBearer);

            if (!authenticateResult.Succeeded)
            {
                if (string.IsNullOrEmpty(input.ApiUrl))
                {
                    input.ApiUrl = $"{baseUrl}/{_openSettingsConfiguration.Controller.Route}";
                }

                var redirectLoginUrl = $"{_openSettingsConfiguration.Consumer.ProviderUrl}v1/auth/login?returnUrl={Uri.EscapeDataString(input.ReturnUrl)}&apiUrl={input.ApiUrl}&stateId={input.StateId}&clientId={_openSettingsConfiguration.Client.Id}";

                httpContext.Response.Redirect(redirectLoginUrl);
                return;
            }

            //if (authenticateResult.Properties != null)
            //{
            //    if (authenticateResult.Properties.Items.TryGetValue(OpenSettingsDefaults.Keys.AuthService.ReturnUrl, out var returnUrlFromItem) && string.IsNullOrWhiteSpace(input.ReturnUrl))
            //    {
            //        input.ReturnUrl = returnUrlFromItem ?? string.Empty;
            //    }

            //    if (authenticateResult.Properties.Items.TryGetValue(OpenSettingsDefaults.Keys.AuthService.ApiUrl, out var apiUrlFromItem) && string.IsNullOrWhiteSpace(input.ApiUrl))
            //    {
            //        input.ApiUrl = apiUrlFromItem ?? string.Empty;
            //    }

            //    if (authenticateResult.Properties.Items.TryGetValue(OpenSettingsDefaults.Keys.AuthService.StateId, out var stateIdFromItem) && string.IsNullOrWhiteSpace(input.StateId))
            //    {
            //        input.StateId = stateIdFromItem;
            //    }
            //}

            if (input.ApiUrl.StartsWith(baseUrl))
            {
                httpContext.Response.Redirect(input.ReturnUrl);
                return;
            }

            var accessToken = await httpContext.GetTokenAsync(OpenSettingsDefaults.AuthSchemes.Cookie, "access_token");

            var redirectReturnToUrl = $"{input.ApiUrl}/v1/auth/return-to?returnUrl={input.ReturnUrl}&apiUrl={input.ApiUrl}&accessToken={accessToken}&stateId={input.StateId}";

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