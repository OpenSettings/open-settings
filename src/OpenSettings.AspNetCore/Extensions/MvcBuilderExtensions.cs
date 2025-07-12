using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ogu.AspNetCore.Conventions;
using Ogu.Compressions.Abstractions;
using OpenSettings.AspNetCore.Controllers.v1;
using OpenSettings.AspNetCore.Handlers;
using OpenSettings.AspNetCore.Services;
using OpenSettings.AspNetCore.Services.Interfaces;
using OpenSettings.Configurations;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Rest;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Collections.Generic;
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

            authenticationBuilder.AddOpenSettingsBasicAuthenticationScheme();

            var syncAppDataResponse = SyncAppDataResponse.Get(configuration);

            var providerInfo = syncAppDataResponse.ProviderInfo;
            var controllerConfiguration = syncAppDataResponse.Configuration.Controller;

            var isProvider = providerInfo == null;

            if (isProvider)
            {
                var openSettingsAssemblyInfo = OpenSettingsAssemblyInfo.Instance;

                providerInfo = new ProviderInfo
                {
                    Authorize = controllerConfiguration.Authorize,
                    PackVersion = openSettingsAssemblyInfo.PackVersion,
                    PackVersionScore = openSettingsAssemblyInfo.PackVersionScore,
                    IsPreviewVersion = openSettingsAssemblyInfo.IsPreviewVersion,
                    OAuth2 = new OAuth2Info
                    {
                        Authority = controllerConfiguration.OAuth2.Authority,
                        AllowOfflineAccess = controllerConfiguration.OAuth2.AllowOfflineAccess,
                        IsActive = controllerConfiguration.OAuth2.IsActive
                    }
                };

                mvcBuilder.Services.RegisterProviderServices(providerInfo, controllerConfiguration, authenticationBuilder);
            }
            else
            {
                mvcBuilder.Services.RegisterConsumerServices(providerInfo);
            }

            mvcBuilder.Services.AddSingleton<IOpenSettingsTokenService, OpenSettingsTokenService>();
            mvcBuilder.Services.AddSingleton<IInstanceUrlResolverService, InstanceUrlResolverService>();

            mvcBuilder.Services.AddHttpContextAccessor();

            mvcBuilder.Services.AddHttpClient();

            var authorize = providerInfo.Authorize || controllerConfiguration.Authorize;

            if (authorize && providerInfo.OAuth2.IsActive)
            {
                authenticationBuilder
                    .AddJwtBearer(Constants.OpenSettingsOAuth2JwtBearerScheme, jwtBearerOpts =>
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

            return mvcBuilder.AddApplicationPart(typeof(Constants).Assembly).AddMvcOptions(mvcOpts =>
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

                if (!isProvider)
                {
                    mvcOpts.Conventions.AddControllerDisableConvention(providerControllerType);
                }

                if (authorize)
                {
                    mvcOpts.Conventions.AddControllerAuthorizeConvention(controllerTypes,
                        conventionOpts =>
                            ApplyConventionOpts(conventionOpts, providerInfo, isProvider));
                }

            }).AddControllersAsServices();
        }

        private static void RegisterProviderServices(this IServiceCollection services, ProviderInfo providerInfo, ConfigurationController controllerConfiguration, AuthenticationBuilder authenticationBuilder)
        {
            if (providerInfo.OAuth2.IsActive)
            {
                var apiLoginRoute = $"/{controllerConfiguration.Route}/v1/auth/login";

                authenticationBuilder.AddCookie(OpenSettingsDefaults.AuthSchemes.Cookie).AddOpenIdConnect(OpenSettingsDefaults.AuthSchemes.OAuth2, openIdOpts =>
                {
                    openIdOpts.Authority = controllerConfiguration.OAuth2.Authority;
                    openIdOpts.SignInScheme = OpenSettingsDefaults.AuthSchemes.Cookie;
                    openIdOpts.SignedOutRedirectUri = controllerConfiguration.OAuth2.SignedOutRedirectUri;
                    openIdOpts.ClientId = controllerConfiguration.OAuth2.ClientId;
                    openIdOpts.ClientSecret = controllerConfiguration.OAuth2.ClientSecret;
                    openIdOpts.ResponseType = "code";
                    openIdOpts.Scope.Clear();
                    openIdOpts.Scope.Add("openid");
                    openIdOpts.Scope.Add("profile");

                    if (controllerConfiguration.OAuth2.AllowOfflineAccess)
                    {
                        openIdOpts.Scope.Add("offline_access");
                    }

                    openIdOpts.SaveTokens = true;
                    openIdOpts.GetClaimsFromUserInfoEndpoint = true;

                    var route = $"/{controllerConfiguration.Route}";

                    openIdOpts.Events = new OpenIdConnectEvents
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
                            var usersService = context.HttpContext.RequestServices.GetRequiredService<IUsersService>();

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
                                new Claim(Constants.DbUserIdClaim, user.Id.ToString()),
                                new Claim(Constants.DbUserDisplayNameClaim, user.DisplayName),
                                new Claim(Constants.DbUserInitialsClaim, user.Initials)
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

            services.AddSingleton<ProviderInfo>(sp =>
            {
                var settingsConfiguration = sp.GetService<OpenSettingsConfiguration>();

                providerInfo.Client.Id = settingsConfiguration.Client.Id;
                providerInfo.Client.Name = settingsConfiguration.Client.Name;
                providerInfo.Version = settingsConfiguration.Client.Version;
                providerInfo.Redis.Channel = settingsConfiguration.Provider.Redis.Channel;
                providerInfo.Redis.IsActive = settingsConfiguration.Provider.Redis.IsActive;
                providerInfo.Redis.Configuration = settingsConfiguration.Provider.Redis.Configuration;

                return providerInfo;
            });

            services.AddSingleton<ProviderCoordinationTimedService>();
            services.AddSingleton<IOpenSettingsNotificationSyncTimedService, OpenSettingsNotificationSyncTimedService>();
            services.AddSingleton<IProviderRegistryCleanupTimedService, ProviderRegistryCleanupTimedService>();

            services.AddSingleton<IHostedService>(sp => sp.GetRequiredService<ProviderCoordinationTimedService>());
        }

        private static void RegisterConsumerServices(this IServiceCollection services, ProviderInfo providerInfo)
        {
            services.AddTransient<OpenSettingsRestServiceAuthHandler>();
            services.AddTransient<DecompressionHandler>();

            services
                .AddHttpClient(OpenSettings.Constants.OpenSettingsHttpClientName, (sp, httpClient) =>
                {
                    var openSettingsConfiguration = sp.GetRequiredService<OpenSettingsConfiguration>();

                    openSettingsConfiguration.Consumer.ConfigureHttpClient(httpClient, openSettingsConfiguration.Client);
                })
                .AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>()
                .AddHttpMessageHandler<DecompressionHandler>();
            
            services.AddSingleton<IAppGroupsRestService, AppGroupsRestService>();
            services.AddSingleton<IAppIdentifierMappingsRestService, AppIdentifierMappingsRestService>();
            services.AddSingleton<IAppsRestService, AppsRestService>();
            services.AddSingleton<IAppTagMappingsRestService, AppTagMappingsRestService>();
            services.AddSingleton<IConfigurationsRestService, ConfigurationsRestService>();
            services.AddSingleton<IIdentifiersRestService, IdentifiersRestService>();
            services.AddSingleton<IInstancesRestService, InstancesRestService>();
            services.AddSingleton<ILicensesRestService, LicensesRestService>();
            services.AddSingleton<INotificationsRestService, NotificationsRestService>();
            services.AddSingleton<IOpenSettingsRestService, OpenSettingsRestService>();
            services.AddSingleton<IProviderRestService, ProviderRestService>();
            services.AddSingleton<ISettingClassesRestService, SettingClassesRestService>();
            services.AddSingleton<ISettingHistoriesRestService, SettingHistoriesRestService>();
            services.AddSingleton<ISettingsRestService, SettingsRestService>();
            services.AddSingleton<ITagsRestService, TagsRestService>();
            services.AddSingleton<IUsersRestService, UsersRestService>();

            services.AddSingleton<ProviderInfo>(providerInfo);
        }

        private static AuthenticationBuilder AddOpenSettingsBasicAuthenticationScheme(this AuthenticationBuilder authenticationBuilder)
        {
            return authenticationBuilder.AddScheme<AuthenticationSchemeOptions, OpenSettingsBasicAuthenticationHandler>(OpenSettingsDefaults.AuthSchemes.Basic, null);
        }

        private static void ApplyConventionOpts(ControllerAuthorizeConventionOptions conventionOpts, ProviderInfo providerInfo, bool isServiceTypeProvider)
        {
            var authSchemes = new List<string> { OpenSettingsDefaults.AuthSchemes.Basic };

            if (providerInfo.OAuth2.IsActive)
            {
                if (isServiceTypeProvider)
                {
                    authSchemes.Add(OpenSettingsDefaults.AuthSchemes.OAuth2);
                }
                authSchemes.Add(Constants.OpenSettingsOAuth2JwtBearerScheme);
            }

            conventionOpts.AuthenticationSchemes = string.Join(",", authSchemes);
        }
    }
}