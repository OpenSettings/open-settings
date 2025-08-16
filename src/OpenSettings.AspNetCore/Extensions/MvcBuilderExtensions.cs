using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Ogu.AspNetCore.Conventions;
using OpenSettings.AspNetCore.Controllers.v1;
using OpenSettings.AspNetCore.Handlers;
using OpenSettings.AspNetCore.Services;
using OpenSettings.Configurations;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Rest.Interfaces;
using OpenSettings.Services.Sql.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Extensions
{
    /// <summary>
    /// Provides extension methods for configuring MVC services in OpenSettings.
    /// This class contains methods to register OpenSettings-related services, configure HTTP clients, 
    /// and set up controllers with authorization mechanisms.
    /// </summary>
    public static class MvcBuilderExtensions
    {
        /// <summary>
        /// Registers the open settings controllers and configures authentication and services based on the provided <see cref="ServiceType"/>.
        /// This method sets up the controllers required for the OpenSettings library, including custom services
        /// depending on whether the service type is a provider or consumer.
        /// </summary>
        /// <param name="mvcBuilder">The <see cref="IMvcBuilder"/> used to configure MVC services.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> used to retrieve app settings and configuration values.</param>
        /// <returns>Returns the <see cref="IMvcBuilder"/> to allow further configuration of MVC services.</returns>
        public static IMvcBuilder AddOpenSettingsController(this IMvcBuilder mvcBuilder, IConfiguration configuration)
        {
            var authenticationBuilder = mvcBuilder.Services.AddAuthentication();

            authenticationBuilder.AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(OpenSettingsDefaults.AuthSchemes.Basic, null);

            var syncAppDataResponse = SyncAppDataResponse.Get(configuration);

            var providerInfo = syncAppDataResponse.ProviderInfo;
            var controllerConfiguration = syncAppDataResponse.Configuration.Controller;

            var authorize = syncAppDataResponse.Authorize;

            if (syncAppDataResponse.IsProvider)
            {
                RegisterProviderServices(mvcBuilder.Services, providerInfo, controllerConfiguration, authenticationBuilder);
            }
            else
            {
                RegisterConsumerServices(mvcBuilder.Services, providerInfo, syncAppDataResponse.Client, authenticationBuilder, authorize);
            }

            mvcBuilder.Services.AddSingleton<IInstanceUrlResolverService, InstanceUrlResolverService>();

            mvcBuilder.Services.AddHttpContextAccessor();

            mvcBuilder.Services.AddHttpClient();

            var providerControllerType = typeof(ProviderController);

            var controllerTypes = new Type[]
            {
                typeof(AppGroupsController),
                typeof(AppsController),
                typeof(AuthController),
                typeof(IdentifiersController),
                typeof(InstancesController),
                typeof(LicensesController),
                typeof(LocalSettingsController),
                typeof(NotificationsController),
                typeof(OpenSettingsController),
                providerControllerType,
                typeof(SettingHistoriesController),
                typeof(SettingsController),
                typeof(TagsController),
                typeof(UsersController),
                typeof(TokenController)
            };

            return mvcBuilder.AddApplicationPart(typeof(MvcBuilderExtensions).Assembly).AddMvcOptions(mvcOpts =>
            {
                mvcOpts.Conventions.AddControllerRoutePrefixConvention(controllerTypes, controllerConfiguration.Route,
                    opts =>
                    {
                        opts.ConventionStrategy = RoutePrefixConventionStrategy.Combine;
                    });

                if (!controllerConfiguration.AllowFromExploring)
                {
                    mvcOpts.Conventions.AddControllerHideFromExploringConvention(controllerTypes);
                }

                if (!syncAppDataResponse.IsProvider)
                {
                    mvcOpts.Conventions.AddControllerDisableConvention(providerControllerType);
                }

                if (authorize)
                {
                    mvcOpts.Conventions.AddControllerAuthorizeConvention(controllerTypes,
                        conventionOpts =>
                            ApplyConventionOptions(conventionOpts, providerInfo, syncAppDataResponse.IsProvider));
                }
            }).AddControllersAsServices();
        }

        private static void RegisterProviderServices(IServiceCollection services, ProviderInfo providerInfo, ConfigurationController controllerConfiguration, AuthenticationBuilder authenticationBuilder)
        {
            services.AddSingleton<IAuthService, AuthService>();

            authenticationBuilder.AddJwtBearerForProvider(providerInfo);

            if (providerInfo.Authorize && providerInfo.OAuth2.IsActive)
            {
                authenticationBuilder
                    .AddCookie(OpenSettingsDefaults.AuthSchemes.Cookie)
                    .AddOAuth2(controllerConfiguration);
            }
        }

        private static void RegisterConsumerServices(IServiceCollection services, ProviderInfo providerInfo, SyncAppDataResponseClient client, AuthenticationBuilder authenticationBuilder, bool authorize)
        {
            if (authorize)
            {
                authenticationBuilder.AddJwtBearerForConsumer(providerInfo, client);
            }

            services.AddTransient<UserConsumerToProviderRequestHandler>();

            services.AddHttpClient(OpenSettingsDefaults.Names.ProviderHttpClientName).AddHttpMessageHandler<UserConsumerToProviderRequestHandler>();

            services.AddSingleton<IAuthRestService, AuthRestService>();
            services.AddSingleton<IAuthService>(sp => sp.GetRequiredService<IAuthRestService>());
        }

        private static void AddJwtBearerForProvider(this AuthenticationBuilder authenticationBuilder, ProviderInfo providerInfo)
        {
            authenticationBuilder.AddJwtBearer(OpenSettingsDefaults.AuthSchemes.JwtBearer, opts =>
            {
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = providerInfo.Client.Name,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(new byte[32])
                };

                opts.Events = new JwtBearerEvents
                {
                    OnMessageReceived = async context =>
                    {
                        var tokenSqlService = context.HttpContext.RequestServices.GetRequiredService<ITokenSqlService>();

                        var providerTokenInfo = await tokenSqlService.GetProviderTokenInfoAsync(context.HttpContext.RequestAborted);

                        if (!ReferenceEquals(context.Options.TokenValidationParameters.IssuerSigningKeys, providerTokenInfo.SigningKeys))
                        {
                            context.Options.TokenValidationParameters.IssuerSigningKeys = providerTokenInfo.SigningKeys;
                        }
                    }
                };
            });
        }

        private static void AddJwtBearerForConsumer(this AuthenticationBuilder authenticationBuilder, ProviderInfo providerInfo, SyncAppDataResponseClient client)
        {
            authenticationBuilder.AddJwtBearer(OpenSettingsDefaults.AuthSchemes.JwtBearer, opts =>
            {
                opts.Authority = null; // -> not using discovery
                opts.MetadataAddress = $"{providerInfo.Url}{OpenSettingsDefaults.Routes.V1.Token}/{OpenSettingsDefaults.Routes.V1.TokenEndpoints.GetPublicJwks}";
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = providerInfo.Client.Name,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidAudience = $"{client.Id}"
                };
            });
        }

        private static AuthenticationBuilder AddOAuth2(this AuthenticationBuilder authenticationBuilder, ConfigurationController controllerConfiguration)
        {
            var apiLoginRoute = $"/{controllerConfiguration.Route}/v1/auth/login";

            ILogger oAuth2Logger = null;

            return authenticationBuilder.AddOpenIdConnect(OpenSettingsDefaults.AuthSchemes.OAuth2, opts =>
              {
                  opts.Authority = controllerConfiguration.OAuth2.Authority;
                  opts.SignInScheme = OpenSettingsDefaults.AuthSchemes.Cookie;
                  opts.SignedOutRedirectUri = controllerConfiguration.OAuth2.SignedOutRedirectUri;
                  opts.ClientId = controllerConfiguration.OAuth2.ClientId;
                  opts.ClientSecret = controllerConfiguration.OAuth2.ClientSecret;
                  opts.ResponseType = "code";
                  opts.SaveTokens = true;
                  opts.GetClaimsFromUserInfoEndpoint = true;
                  opts.SecurityTokenValidator = new JwtSecurityTokenHandler
                  {
                      MapInboundClaims = false
                  };
                  opts.Scope.Clear();
                  opts.Scope.Add("openid");
                  opts.Scope.Add("profile");

                  if (controllerConfiguration.OAuth2.AllowOfflineAccess)
                  {
                      opts.Scope.Add("offline_access");
                  }

                  var route = $"/{controllerConfiguration.Route}";

                  PathString routeAsPathString = route;

                  opts.Events = new OpenIdConnectEvents
                  {
                      OnRedirectToIdentityProvider = context =>
                      {
                          if (context.Request.Path.StartsWithSegments(routeAsPathString) && context.Request.Path.Value != apiLoginRoute)
                          {
                              context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                              context.HandleResponse();
                          }

                          return Task.CompletedTask;
                      },
                      OnTokenValidated = async context =>
                      {
                          var usersService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();

                          var user = await usersService.GetOrCreateUserAsync(new GetOrCreateUserInput(context.Principal, AuthType.OAuth2), CancellationToken.None);

                          if (user == null)
                          {
                              context.Fail("ExternalId couldn't be obtain.");
                              return;
                          }

                          if (!user.IsActive)
                          {
                              context.Fail("User access disabled.");
                              return;
                          }

                          if (context.Properties == null)
                          {
                              return;
                          }

                          _ = context.Properties.Items.TryGetValue(OpenSettingsDefaults.Keys.AuthService.ClientId, out var clientId);

                          var tokenService = context.HttpContext.RequestServices.GetRequiredService<ITokenSqlService>();

                          var tokenResponse = await tokenService.GenerateTokenForUserAsync(new GenerateTokenForUserInput
                          {
                              UserId = user.Id,
                              UserInitials = user.Initials,
                              DisplayName = user.DisplayName,
                              Audience = clientId,
                          }, context.HttpContext.RequestAborted);

                          context.Properties.Items.Add(OpenSettingsDefaults.Keys.AuthService.AccessToken, tokenResponse.AccessToken);

                          var claimsIdentity = (ClaimsIdentity)context.Principal.Identity;

                          foreach (var claim in claimsIdentity.Claims.ToArray())
                          {
                              claimsIdentity.RemoveClaim(claim);
                          }

                          context.Principal.AddIdentity(new ClaimsIdentity(tokenResponse.Claims));
                      },
                      OnRemoteFailure = context =>
                      {
                          if (oAuth2Logger == null)
                          {
                              var openSettingsConfiguration = context.HttpContext.RequestServices.GetService<OpenSettingsConfiguration>();

                              oAuth2Logger = openSettingsConfiguration.LoggerFactory.CreateLogger("OAuth2");
                          }

                          oAuth2Logger.LogError(context.Failure, "OIDC Error: {message}", context.Failure?.Message);

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
                  };
              });
        }

        /// <summary>
        /// Applies the convention options for the controller authorization convention.
        /// </summary>
        /// <param name="conventionOptions">The controller authorize convention options.</param>
        /// <param name="providerInfo">The provider info.</param>
        /// <param name="isServiceTypeProvider">Specifies whether the app running as provider.</param>
        /// <remarks>Only called if Authorize is true. (Line : 120)</remarks>
        private static void ApplyConventionOptions(ControllerAuthorizeConventionOptions conventionOptions, ProviderInfo providerInfo, bool isServiceTypeProvider)
        {
            var authSchemes = new List<string>(4) { OpenSettingsDefaults.AuthSchemes.Basic, OpenSettingsDefaults.AuthSchemes.JwtBearer };

            if (providerInfo.OAuth2.IsActive)
            {
                if (isServiceTypeProvider)
                {
                    authSchemes.Add(OpenSettingsDefaults.AuthSchemes.OAuth2);
                }
            }

            conventionOptions.AuthenticationSchemes = string.Join(OpenSettingsDefaults.Format.Comma, authSchemes);
        }
    }
}