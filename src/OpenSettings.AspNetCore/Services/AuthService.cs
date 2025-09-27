using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Sql.Interfaces;
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
    /// <summary>
    /// Provides authentication for the provider.
    /// </summary>
    internal sealed class AuthService : IAuthService
    {
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly ProviderInfo _providerInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The http client factory.</param>
        /// <param name="httpContextAccessor">The http context accessor.</param>
        /// <param name="openSettingsMemoryCache">The open settings memory cache.</param>
        /// <param name="openSettingsConfiguration">The open settings configuration.</param>
        /// <param name="providerInfo">The provider info.</param>
        public AuthService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IOpenSettingsMemoryCache openSettingsMemoryCache, OpenSettingsConfiguration openSettingsConfiguration, ProviderInfo providerInfo)
        {
            _logger = openSettingsConfiguration.LoggerFactory.CreateLogger<AuthService>();
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _openSettingsConfiguration = openSettingsConfiguration;
            _providerInfo = providerInfo;
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
                    if (input.StateId == null ||
                        httpContext.Request.Headers.GetClientIdHeaderValueOrDefault() == _openSettingsConfiguration.Client.Id)
                    {
                        return HttpStatusCode.OK.ToSuccessResponseOf(new GetMeResponse
                        {
                            IsAuthenticated = false
                        });
                    }

                    // todo: Potential improvement - store in the distributed cache and return it if found.

                    var openSettingsDbContext = httpContext.RequestServices.GetRequiredService<OpenSettingsDbContext>();

                    var loggedInTimeSafetyMargin = DateTime.UtcNow - TimeSpan.FromMinutes(15);

                    var loginEntry = await openSettingsDbContext.LoginEntries
                        .AsNoTracking()
                        .Where(l =>
                            l.IsSuccessful &&
                            l.CreatedOn > loggedInTimeSafetyMargin &&
                            l.AuthMethod == AuthMethod.Jwt &&
                            l.StateId == input.StateId)
                        .OrderBy(l => l.Id)
                        .Select(l => new
                        {
                            l.AccessToken
                        })
                        .FirstOrDefaultAsync(cancellationToken);

                    if (loginEntry == null)
                    {
                        return HttpStatusCode.OK.ToSuccessResponseOf(new GetMeResponse
                        {
                            IsAuthenticated = false
                        });
                    }

                    var tokenService = httpContext.RequestServices.GetRequiredService<ITokenService>();

                    var token = tokenService.ReadJwtToken(loginEntry.AccessToken);

                    return HttpStatusCode.OK.ToSuccessResponseOf(new GetMeResponse
                    {
                        IsAuthenticated = true,
                        AccessToken = loginEntry.AccessToken,
                        Claims = token.Claims.ToDictionary(c => c.Type, c => c.Value)
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
                throw new NotSupportedException(nameof(LoginAsync));
            }

            var currentServiceUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

            if (string.IsNullOrWhiteSpace(input.ReturnUrl) ||
                string.IsNullOrWhiteSpace(input.ApiUrl) ||
                !input.ClientId.HasValue)
            {
                input.ReturnUrl = $"{currentServiceUrl}/{_openSettingsConfiguration.Spa.RoutePrefix}";
                httpContext.Response.Redirect(input.ReturnUrl);
                return;
            }

            var authenticateResult = await httpContext.AuthenticateAsync(OpenSettingsDefaults.AuthSchemes.OpenIdConnect);

            if (!authenticateResult.Succeeded)
            {
                try
                {
                    await httpContext.ChallengeAsync(OpenSettingsDefaults.AuthSchemes.OpenIdConnect,
                        new AuthenticationProperties(new Dictionary<string, string>
                        {
                            { OpenSettingsDefaults.Keys.AuthService.ReturnUrl, input.ReturnUrl },
                            { OpenSettingsDefaults.Keys.AuthService.ApiUrl, input.ApiUrl },
                            { OpenSettingsDefaults.Keys.AuthService.StateId, $"{input.StateId}" },
                            { OpenSettingsDefaults.Keys.AuthService.ClientId, $"{input.ClientId}" },
                            { OpenSettingsDefaults.Keys.AuthService.TenantId, $"{input.TenantId}" }
                        }));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception occurred while '{authScheme}' login challenge.", OpenSettingsDefaults.AuthSchemes.OpenIdConnect);
                    httpContext.Response.Redirect(input.ReturnUrl);
                }

                return;
            }

            var stateId = authenticateResult.Properties.GetString(OpenSettingsDefaults.Keys.AuthService.StateId);

            if (input.StateId == stateId)
            {
                httpContext.Response.Redirect(input.ReturnUrl);
                return;
            }

            var openSettingsDbContext = httpContext.RequestServices.GetRequiredService<OpenSettingsDbContext>();

            var loginEntry = await openSettingsDbContext.LoginEntries.AsNoTracking()
                .Where(l => l.StateId == Guid.Parse(stateId)).Select(l => new { l.Scopes })
                .FirstOrDefaultAsync(cancellationToken);

            if (loginEntry == null) // Pretty impossible!
            {
                httpContext.Response.Redirect(input.ReturnUrl);
                return;
            }

            var currentTime = DateTimeOffset.Now;

            var timeUntilExpiry = authenticateResult.Properties.ExpiresUtc.GetValueOrDefault(DateTime.MaxValue) -
                                  currentTime;

            var tokenTimeToLive = timeUntilExpiry > OpenSettingsDefaults.TimeSpans.TokenExpiryTime
                ? OpenSettingsDefaults.TimeSpans.TokenExpiryTime
                : timeUntilExpiry;

            var tokenService = httpContext.RequestServices.GetRequiredService<ITokenSqlService>();

            var tokenResponse = await tokenService.GenerateTokenForUserAsync(new GenerateTokenForUserInput
            {
                UserId = Guid.Parse(authenticateResult.Principal.FindFirst(OpenSettingsDefaults.ClaimTypes.DbUserId).Value),
                TenantId = null, // todo tenantId
                DisplayName = authenticateResult.Principal.FindFirst(OpenSettingsDefaults.ClaimTypes.DbUserDisplayName).Value,
                UserInitials = authenticateResult.Principal.FindFirst(OpenSettingsDefaults.ClaimTypes.DbUserInitials).Value,
                Audience = $"{input.ClientId.Value}"
            }, tokenTimeToLive, httpContext.RequestAborted);

            var newLoginEntry = new LoginEntrySqlModel
            {
                Id = Guid.NewGuid(),
                StateId = Guid.Parse(input.StateId),
                Audience = input.ClientId.Value,
                Issuer = _openSettingsConfiguration.Client.Id,
                ProviderRegistryId = ProviderCoordinationTimedService.ProviderRegistryId,
                RemoteIpAddress = $"{httpContext.Connection.RemoteIpAddress}",
                UserAgent = httpContext.Request.Headers.GetUserAgentOrDefault(),
                AuthType = AuthType.OpenIdConnect,
                AuthMethod = AuthMethod.Jwt,
                AccessToken = tokenResponse.AccessToken.Value,
                AccessTokenExpiryDate = tokenResponse.AccessToken.ExpiryDate,
                RefreshToken = tokenResponse.RefreshToken?.Value,
                RefreshTokenExpiryDate = tokenResponse.RefreshToken?.ExpiryDate,
                Scopes = loginEntry.Scopes,
                IsSuccessful = true,
                Metadata = new Dictionary<string, object>(),
                CreatedOn = currentTime.UtcDateTime
            };

            var newLoginEntityEntry = openSettingsDbContext.LoginEntries.Add(newLoginEntry);

            await openSettingsDbContext.SaveChangesAsync(cancellationToken);

            newLoginEntityEntry.State = EntityState.Detached;

            httpContext.Response.Redirect(input.ReturnUrl);
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
                var currentServiceUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}";

                input.ReturnUrl = $"{currentServiceUrl}/{_openSettingsConfiguration.Spa.RoutePrefix}";
            }

            try
            {
                var isIdpOnline = true || await IsIdpOnlineAsync(cancellationToken);

                await httpContext.SignOutAsync(OpenSettingsDefaults.AuthSchemes.Cookie);

                if (isIdpOnline)
                {
                    await httpContext.SignOutAsync(OpenSettingsDefaults.AuthSchemes.OpenIdConnect, new AuthenticationProperties(new Dictionary<string, string>
                    {
                        { OpenSettingsDefaults.Keys.AuthService.ReturnUrl, input.ReturnUrl }
                    }));
                }
                else
                {
                    httpContext.Response.Redirect(input.ReturnUrl);

                    _logger.LogWarning("Failed to complete sign-out because the identity provider is not accessible.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while trying to sign-out from OpenIdConnect provider.");

                await httpContext.SignOutAsync(OpenSettingsDefaults.AuthSchemes.Cookie);

                httpContext.Response.Redirect(input.ReturnUrl);
            }
        }

        private async Task<bool> IsIdpOnlineAsync(CancellationToken cancellationToken = default)
        {
            if (OpenSettingsDefaults.Caches.AuthServiceIsIdpOnlineCheckCacheEntryKey.TryGetValue(_openSettingsMemoryCache, out bool isIdpOnline))
            {
                return isIdpOnline;
            }

            var client = _httpClientFactory.CreateClient();

            var requestUri = $"{_providerInfo.OpenIdConnect.Authority.TrimEnd('/')}/.well-known/openid-configuration";

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