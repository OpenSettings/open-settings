using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using System;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Handlers
{
    internal class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly ILogger _logger;
        private readonly IAppService _appsService;
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;

        public BasicAuthenticationHandler(
            IAppService appsService,
            IOpenSettingsMemoryCache openSettingsMemoryCache,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
#if !NET8_0_OR_GREATER
            ISystemClock clock,
#endif

            UrlEncoder encoder,
            OpenSettingsConfiguration openSettingsConfiguration) : base(options, openSettingsConfiguration.LoggerFactory, encoder
#if !NET8_0_OR_GREATER
            , clock
#endif
            )
        {
            _appsService = appsService;
            _logger = openSettingsConfiguration.LoggerFactory.CreateLogger<BasicAuthenticationHandler>();
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _openSettingsConfiguration = openSettingsConfiguration;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                var authHeader = Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader();

                if (authHeader?.Parameter == null || authHeader.Scheme != OpenSettingsDefaults.Names.BasicSchemeName)
                {
                    return AuthenticateResult.NoResult();
                }

                var authTicketCacheEntryKey = OpenSettingsDefaults.Caches.BasicAuthenticationHandlerAuthTicketCacheEntry.GetKey(authHeader.Parameter);

                if (authTicketCacheEntryKey.TryGetValue(_openSettingsMemoryCache, out AuthenticationTicket authTicket))
                {
                    return AuthenticateResult.Success(authTicket);
                }

                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(OpenSettingsDefaults.Separators.ColumnSeparator, 2);

                if (credentials.Length != 2)
                {
                    return AuthenticateResults.InvalidAuthorizationHeaderFormat;
                }

                var clientIdAsString = credentials[0];
                var clientSecretAsString = credentials[1];

                if (!(Guid.TryParse(clientIdAsString, out var clientId) &&
                      Guid.TryParse(clientSecretAsString, out var clientSecret)))
                {
                    return AuthenticateResults.InvalidCredentials;
                }

                var registeredApp = _openSettingsConfiguration.Client.Id == clientId &&
                                    _openSettingsConfiguration.Client.Secret == clientSecret
                    ? new GetRegisteredAppResponse
                    {
                        ClientName = _openSettingsConfiguration.Client.Name,
                        IsRegistered = true,
                        IsClientIdUnique = true,
                        IsClientSecretMatched = true
                    }
                    : (await _appsService.GetRegisteredAppAsync(new GetRegisteredAppInput
                    {
                        ClientId = clientId,
                        ClientSecret = clientSecret
                    }, Context.RequestAborted)).Data;

                if (!registeredApp.IsClientSecretMatched)
                {
                    if (!registeredApp.IsRegistered)
                    {
                        _logger.LogWarning("ClientId: '{clientId}' is not registered.", clientIdAsString);
                    }

                    return AuthenticateResults.InvalidCredentials;
                }

                var claims = Helper.GetOpenSettingsClaims(clientIdAsString, registeredApp.ClientName);

                var claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                authTicket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

                authTicketCacheEntryKey.Set(_openSettingsMemoryCache, authTicket);

                return AuthenticateResult.Success(authTicket);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling authentication.");

                return AuthenticateResults.InvalidAuthorizationHeaderFormat;
            }
        }

        private static class AuthenticateResults
        {
            public static AuthenticateResult InvalidAuthorizationHeaderFormat { get; } = AuthenticateResult.Fail("Invalid Authorization Header Format");
            public static AuthenticateResult InvalidCredentials { get; } = AuthenticateResult.Fail("Invalid ClientId or ClientSecret");
        }
    }
}