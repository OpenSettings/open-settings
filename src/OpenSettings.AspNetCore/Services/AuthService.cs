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
using Microsoft.AspNetCore.Authentication.OAuth;

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

                    var loggedInTimeSafetyMargin = DateTime.UtcNow - TimeSpan.FromMinutes(5);

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

        public static async Task OnAuth2TicketReceivedAsync(TicketReceivedContext context)
        {
            var returnUrl = context.Properties.GetString(OpenSettingsDefaults.Keys.AuthService.ReturnUrl);
            //var apiUrl = context.Properties.GetString(OpenSettingsDefaults.Keys.AuthService.ApiUrl);
            //var stateId = context.Properties.GetString(OpenSettingsDefaults.Keys.AuthService.StateId);
            var clientId = context.Properties.GetString(OpenSettingsDefaults.Keys.AuthService.ClientId);

            var httpContext = context.HttpContext;
            var usersService = httpContext.RequestServices.GetRequiredService<IUserService>();

            var user = await usersService.GetOrCreateUserAsync(new GetOrCreateUserInput(context.Principal, AuthType.OAuth2), context.HttpContext.RequestAborted);

            if (user == null)
            {
                // ExternalId couldn't obtain.
                context.Fail("ExternalId couldn't obtain.");
                context.Response.Redirect(returnUrl);
                context.HandleResponse();
                return;
            }

            if (!user.IsActive)
            {
                // User access disabled.
                context.Fail("User access disabled.");
                context.Response.Redirect(returnUrl);
                context.HandleResponse();
                return;
            }

            var openSettingsDbContext = httpContext.RequestServices.GetRequiredService<OpenSettingsDbContext>();

            var clientIdAsGuid = Guid.Parse(clientId);

            var loginEntry = new LoginEntrySqlModel
            {
                Id = Guid.NewGuid(),
                ClientId = clientIdAsGuid,
                ClientIdLowercase = clientId.ToLowerInvariant(),
                InstanceId = ProviderCoordinationTimedService.InstanceId,
                UserId = user.Id,
                UserIdLowercase = $"{user.Id}".ToLowerInvariant(),
                RemoteIpAddress = httpContext.Connection.RemoteIpAddress?.ToString(),
                UserAgent = httpContext.Request.Headers["User-Agent"].ToString(),
                AuthType = AuthType.OAuth2,
                AuthMethod = AuthMethod.Unset,
                AccessToken = null,
                AccessTokenExpiryDate = null,
                RefreshToken = null,
                RefreshTokenExpiryDate = null,
                Scopes = string.Join(OpenSettingsDefaults.Format.Space,
                    httpContext.User.Claims
                        .Where(c => c.Type == "scope" || c.Type == "scp")
                        .SelectMany(c => c.Value.Split(OpenSettingsDefaults.Format.SpaceChar))
                        .Distinct()),
                IsSuccessful = true,
                Metadata = new Dictionary<string, object>(),
                CreatedOn = DateTime.UtcNow
            };

            List<Claim> claims;

            if (OpenSettingsDefaults.Caches.OpenSettingsConfiguration.Client.Id == clientIdAsGuid)
            {
                var openSettingsClaims = new OpenSettingsClaims
                {
                    UserId = user.Id,
                    DisplayName = user.DisplayName,
                    UserInitials = user.Initials,
                    AuthType = AuthType.OAuth2,
                    AuthMethod = AuthMethod.Cookie
                };

                loginEntry.AuthMethod = openSettingsClaims.AuthMethod;

                claims = openSettingsClaims.GenerateClaims();
            }
            else
            {
                loginEntry.AuthMethod = AuthMethod.Jwt;

                var tokenService = httpContext.RequestServices.GetRequiredService<ITokenSqlService>();

                var tokenResponse = await tokenService.GenerateTokenForUserAsync(new GenerateTokenForUserInput
                {
                    UserId = user.Id,
                    DisplayName = user.DisplayName,
                    UserInitials = user.Initials,
                    Audience = clientId
                }, httpContext.RequestAborted);

                claims = tokenResponse.Claims;

                loginEntry.AccessToken = tokenResponse.AccessToken.Value;
                loginEntry.AccessTokenExpiryDate = tokenResponse.AccessToken.ExpiryDate;
                loginEntry.RefreshToken = tokenResponse.RefreshToken?.Value;
                loginEntry.RefreshTokenExpiryDate = tokenResponse.RefreshToken?.ExpiryDate;
            }

            var loginEntityEntry = openSettingsDbContext.LoginEntries.Add(loginEntry);

            await openSettingsDbContext.SaveChangesAsync(httpContext.RequestAborted);

            loginEntityEntry.State = EntityState.Detached;

            var claimsIdentity = (ClaimsIdentity)context.Principal.Identity;

            foreach (var claim in claimsIdentity.Claims.ToArray())
            {
                claimsIdentity.RemoveClaim(claim);
            }

            claimsIdentity.AddClaims(claims);

            var newPrincipal = new ClaimsPrincipal(claimsIdentity);

            context.Principal = newPrincipal;
        }

        public async Task LoginAsync(LoginInput input, CancellationToken cancellationToken = default)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                throw new NotSupportedException();
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
                            { OpenSettingsDefaults.Keys.AuthService.StateId, $"{input.StateId }" },
                            { OpenSettingsDefaults.Keys.AuthService.ClientId, $"{input.ClientId} " }
                        }));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception occurred while '{authScheme}' login challenge.", OpenSettingsDefaults.AuthSchemes.OAuth2);
                    httpContext.Response.Redirect(input.ReturnUrl);
                }

                return;
            }

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