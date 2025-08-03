using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ogu.AspNetCore.Conventions;
using OpenSettings.AspNetCore.Controllers.v1;
using OpenSettings.AspNetCore.Handlers;
using OpenSettings.AspNetCore.Services;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
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

            authenticationBuilder.AddScheme<AuthenticationSchemeOptions, OpenSettingsBasicAuthenticationHandler>(OpenSettingsDefaults.AuthSchemes.Basic, null);

            var syncAppDataResponse = SyncAppDataResponse.Get(configuration);

            var providerInfo = syncAppDataResponse.ProviderInfo;
            var controllerConfiguration = syncAppDataResponse.Configuration.Controller;

            if (syncAppDataResponse.IsProvider)
            {
                RegisterProviderServices(providerInfo, controllerConfiguration, authenticationBuilder);
            }
            else
            {
                mvcBuilder.Services.AddTransient<OpenSettingsRestServiceAuthHandler>();

                mvcBuilder.Services.AddHttpClient(OpenSettingsDefaults.Names.ProviderHttpClientName).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>();
            }

            mvcBuilder.Services.AddSingleton<IInstanceUrlResolverService, InstanceUrlResolverService>();

            mvcBuilder.Services.AddHttpContextAccessor();

            mvcBuilder.Services.AddHttpClient();

            var authorize = syncAppDataResponse.Authorize;

            if (authorize && providerInfo.OAuth2.IsActive)
            {
                authenticationBuilder
                    .AddJwtBearer(OpenSettingsDefaults.AuthSchemes.OAuth2JwtBearer, jwtBearerOpts =>
                    {
                        jwtBearerOpts.Authority = providerInfo.OAuth2.Authority;
                        jwtBearerOpts.SaveToken = true;
                        jwtBearerOpts.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = false
                        };
                    });
            }

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

        private static void RegisterProviderServices(ProviderInfo providerInfo, ConfigurationController controllerConfiguration, AuthenticationBuilder authenticationBuilder)
        {
            authenticationBuilder.AddMachineToMachineJwtBearer(providerInfo);

            if (!providerInfo.OAuth2.IsActive)
            {
                return;
            }

            authenticationBuilder
                .AddCookie(OpenSettingsDefaults.AuthSchemes.Cookie)
                .AddOAuth2(controllerConfiguration);
        }

        private static AuthenticationBuilder AddMachineToMachineJwtBearer(this AuthenticationBuilder authenticationBuilder, ProviderInfo providerInfo)
        {
            return authenticationBuilder.AddJwtBearer(OpenSettingsDefaults.AuthSchemes.MachineToMachineJwtBearer, opts =>
            {
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = providerInfo.Client.Name,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"{providerInfo.Client.Secret ?? Guid.Empty}"))
                };
            });
        }

        private static AuthenticationBuilder AddOAuth2(this AuthenticationBuilder authenticationBuilder, ConfigurationController controllerConfiguration)
        {
            var apiLoginRoute = $"/{controllerConfiguration.Route}/v1/auth/login";

            return authenticationBuilder.AddOpenIdConnect(OpenSettingsDefaults.AuthSchemes.OAuth2, opts =>
              {
                  opts.Authority = controllerConfiguration.OAuth2.Authority;
                  opts.SignInScheme = OpenSettingsDefaults.AuthSchemes.Cookie;
                  opts.SignedOutRedirectUri = controllerConfiguration.OAuth2.SignedOutRedirectUri;
                  opts.ClientId = controllerConfiguration.OAuth2.ClientId;
                  opts.ClientSecret = controllerConfiguration.OAuth2.ClientSecret;
                  opts.ResponseType = "code";
                  opts.Scope.Clear();
                  opts.Scope.Add("openid");
                  opts.Scope.Add("profile");

                  if (controllerConfiguration.OAuth2.AllowOfflineAccess)
                  {
                      opts.Scope.Add("offline_access");
                  }

                  opts.SaveTokens = true;
                  opts.GetClaimsFromUserInfoEndpoint = true;

                  var route = $"/{controllerConfiguration.Route}";

                  opts.Events = new OpenIdConnectEvents
                  {
                      OnRedirectToIdentityProvider = context =>
                      {
                          if (context.Request.Path.StartsWithSegments(route) && context.Request.Path.Value != apiLoginRoute)
                          {
                              context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                              context.HandleResponse();
                          }

                          return Task.CompletedTask;
                      },
                      OnTokenValidated = async context =>
                      {
                          var usersService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();

                          var user = await usersService.GetOrCreateUserAsync(new GetOrCreateUserInput(context.Principal, OpenSettingsDefaults.AuthSchemes.OAuth2), CancellationToken.None);

                          if (user == null)
                          {
                              context.Fail("ProviderId couldn't be obtain");
                              return;
                          }

                          if (!user.IsActive)
                          {
                              context.Fail("User access disabled");
                              return;
                          }

                          context.Principal?.AddIdentity(new ClaimsIdentity(new Claim[]
                          {
                            new Claim(OpenSettingsDefaults.ClaimTypes.DbUserId, $"{user.Id}"),
                            new Claim(OpenSettingsDefaults.ClaimTypes.DbUserDisplayName, user.DisplayName),
                            new Claim(OpenSettingsDefaults.ClaimTypes.DbUserInitials, user.Initials)
                          }));
                      },
                      OnRemoteFailure = context =>
                      {
                          Console.WriteLine($"OIDC Error: {context.Failure?.Message}");
                          return Task.CompletedTask;
                      }
                  };
              });
        }

        private static void ApplyConventionOptions(ControllerAuthorizeConventionOptions conventionOptions, ProviderInfo providerInfo, bool isServiceTypeProvider)
        {
            var authSchemes = new List<string>(4) { OpenSettingsDefaults.AuthSchemes.Basic, OpenSettingsDefaults.AuthSchemes.MachineToMachineJwtBearer };

            if (providerInfo.OAuth2.IsActive)
            {
                if (isServiceTypeProvider)
                {
                    authSchemes.Add(OpenSettingsDefaults.AuthSchemes.OAuth2);
                }

                authSchemes.Add(OpenSettingsDefaults.AuthSchemes.OAuth2JwtBearer);
            }

            conventionOptions.AuthenticationSchemes = string.Join(OpenSettingsDefaults.Format.Comma, authSchemes);
        }
    }
}