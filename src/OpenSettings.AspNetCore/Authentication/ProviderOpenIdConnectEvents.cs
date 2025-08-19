using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Services;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Sql.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using OpenSettings.AspNetCore.Extensions;

namespace OpenSettings.AspNetCore.Authentication
{
    internal class ProviderOpenIdConnectEvents : OpenIdConnectEvents
    {
        public override Task SignedOutCallbackRedirect(RemoteSignOutContext context)
        {
            var returnUrl = string.IsNullOrWhiteSpace(context.Options.SignedOutRedirectUri)
                ? context.Properties.GetString(OpenSettingsDefaults.Keys.AuthService.ReturnUrl)
                : context.Options.SignedOutRedirectUri;

            context.Response.Redirect(returnUrl);
            context.HandleResponse();

            return Task.CompletedTask;
        }

        public override Task RedirectToIdentityProvider(RedirectContext context)
        {
            var eventsContext = ProviderOpenIdConnectEventsContext.GetContext(context.HttpContext);

            if (context.Request.Path.Value == eventsContext.ApiLoginRelativePath)
            {
                return base.RedirectToIdentityProvider(context);
            }

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.HandleResponse();

            return Task.CompletedTask;
        }

        public override async Task TicketReceived(TicketReceivedContext context)
        {
            var eventsContext = ProviderOpenIdConnectEventsContext.GetContext(context.HttpContext);

            var returnUrl = context.Properties.GetString(OpenSettingsDefaults.Keys.AuthService.ReturnUrl);
            //var apiUrl = context.Properties.GetString(OpenSettingsDefaults.Keys.AuthService.ApiUrl);
            var stateId = context.Properties.GetString(OpenSettingsDefaults.Keys.AuthService.StateId);
            var clientId = context.Properties.GetString(OpenSettingsDefaults.Keys.AuthService.ClientId);

            var httpContext = context.HttpContext;
            var usersService = httpContext.RequestServices.GetRequiredService<IUserService>();

            var user = await usersService.GetOrCreateUserAsync(new GetOrCreateUserInput(context.Principal, AuthType.OpenIdConnect), context.HttpContext.RequestAborted);

            if (user == null)
            {
                eventsContext.Logger.LogWarning("Login failed: unable to obtain user external id.");
                context.Fail("Unable to obtain user external id.");
                context.Response.Redirect(returnUrl);
                context.HandleResponse();
                return;
            }

            if (!user.IsActive)
            {
                eventsContext.Logger.LogWarning("Login failed: user is disabled.");
                context.Fail("User is disabled.");
                context.Response.Redirect(returnUrl);
                context.HandleResponse();
                return;
            }

            var openSettingsDbContext = httpContext.RequestServices.GetRequiredService<OpenSettingsDbContext>();

            var clientIdAsGuid = Guid.Parse(clientId);

            var loginEntry = new LoginEntrySqlModel
            {
                Id = Guid.NewGuid(),
                StateId = Guid.Parse(stateId),
                Audience = clientIdAsGuid,
                Issuer = OpenSettingsDefaults.Caches.OpenSettingsConfiguration.Client.Id,
                ProviderRegistryId = ProviderCoordinationTimedService.InstanceId,
                UserId = user.Id,
                RemoteIpAddress = $"{httpContext.Connection.RemoteIpAddress}",
                UserAgent = httpContext.Request.Headers.GetUserAgentOrDefault(),
                AuthType = AuthType.OpenIdConnect,
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
                    AuthType = AuthType.OpenIdConnect,
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
                }, OpenSettingsDefaults.TimeSpans.TokenExpiryTime, httpContext.RequestAborted);

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

        public override Task RemoteFailure(RemoteFailureContext context)
        {
            var eventsContext = ProviderOpenIdConnectEventsContext.GetContext(context.HttpContext);

            eventsContext.Logger.LogError(context.Failure, "OpenIdConnect Error: {failureMessage}", context.Failure?.Message);

            if ((string)context.Failure?.Data["error"] != "access_denied")
            {
                return Task.CompletedTask;
            }

            if (context.Properties?.Items.TryGetValue(OpenSettingsDefaults.Keys.AuthService.ReturnUrl, out var returnUrl) != true ||
                string.IsNullOrWhiteSpace(returnUrl))
            {
                return Task.CompletedTask;
            }

            context.Response.Redirect(returnUrl);
            context.HandleResponse();

            return Task.CompletedTask;
        }

        private class ProviderOpenIdConnectEventsContext
        {
            private static ProviderOpenIdConnectEventsContext _instance;

            private ProviderOpenIdConnectEventsContext(ILogger logger, string apiLoginRelativePath)
            {
                Logger = logger;
                ApiLoginRelativePath = apiLoginRelativePath;
            }

            public ILogger Logger { get; }

            public string ApiLoginRelativePath { get; }

            public static ProviderOpenIdConnectEventsContext GetContext(HttpContext httpContext)
            {
                if (_instance != null)
                {
                    return _instance;
                }

                var openSettingsConfiguration = httpContext.RequestServices.GetRequiredService<OpenSettingsConfiguration>();

                var apiLoginRelativeRoute = $"/{openSettingsConfiguration.Controller.Route}/{OpenSettingsDefaults.Routes.V1.Auth}/{OpenSettingsDefaults.Routes.V1.AuthEndpoints.Login}";

                _instance = new ProviderOpenIdConnectEventsContext(
                    openSettingsConfiguration.LoggerFactory.CreateLogger<ProviderOpenIdConnectEvents>(),
                    apiLoginRelativeRoute);

                return _instance;
            }
        }
    }
}