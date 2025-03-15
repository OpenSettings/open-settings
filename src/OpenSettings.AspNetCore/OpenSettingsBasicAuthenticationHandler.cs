using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenSettings.Configurations;
using OpenSettings.Helpers;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore
{
    internal class OpenSettingsBasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IAppsService _appsService;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly ProviderInfo _providerInfo;

        public OpenSettingsBasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IAppsService appsService,
            OpenSettingsConfiguration openSettingsConfiguration,
            ProviderInfo providerInfo) : base(options, logger, encoder, clock)
        {
            _appsService = appsService;
            _openSettingsConfiguration = openSettingsConfiguration;
            _providerInfo = providerInfo;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                if (!Request.Headers.TryGetValue("Authorization", out var headerValue))
                {
                    return AuthenticateResult.NoResult();
                }

                var authHeader = AuthenticationHeaderValue.Parse(headerValue);

                var basicCredentials = authHeader.GetBasicCredentialsFromAuthHeader();

                if (!(Guid.TryParse(basicCredentials.username, out var clientId) && Guid.TryParse(basicCredentials.password, out var clientSecret)))
                {
                    return AuthenticateResult.Fail("Invalid ClientId or ClientSecret");
                }

                GetRegisteredAppResponse registeredApp;
                var roleType = RoleType.Unauthorized;

                if (_openSettingsConfiguration.Client.Id == clientId && _openSettingsConfiguration.Client.Secret == clientSecret)
                {
                    roleType = RoleType.Admin;
                    registeredApp = new GetRegisteredAppResponse { ClientName = _openSettingsConfiguration.Client.Name };
                }
                else
                {
                    var registeredAppJsonResponse = await _appsService.GetRegisteredAppAsync(new GetRegisteredAppInput { ClientId = clientId, ClientSecret = clientSecret }, Context.RequestAborted);

                    registeredApp = registeredAppJsonResponse.Data;

                    if (registeredApp.IsRegistered)
                    {
                        if (!registeredApp.IsClientSecretMatched)
                        {
                            roleType = RoleType.Unauthorized;
                        }
                        else if (_openSettingsConfiguration.IsProviderSelected)
                        {
                            roleType = RoleType.Basic;
                        }
                        else if (_providerInfo.Client.Id == clientId)
                        {
                            roleType = RoleType.Admin;
                        }
                    }
                }

                if (roleType == RoleType.Unauthorized)
                {
                    return AuthenticateResult.Fail("Invalid ClientId or ClientSecret");
                }

                var clientIdAsString = clientId.ToString();

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, clientIdAsString),
                    new Claim(ClaimTypes.Name, registeredApp.ClientName),
                    new Claim(ClaimTypes.Role, roleType.ToString()),
                    new Claim(Constants.DbUserIdClaim, clientIdAsString),
                    new Claim(Constants.DbUserDisplayNameClaim, registeredApp.ClientName),
                    new Claim(Constants.DbUserInitialsClaim, Helper.GetInitials(registeredApp.ClientName))
                };

                var identity = new ClaimsIdentity(claims, Scheme.Name);

                var principal = new ClaimsPrincipal(identity);

                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            catch (NullReferenceException)
            {
                return AuthenticateResult.Fail("Invalid ClientId or ClientSecret");
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
        }
    }
}