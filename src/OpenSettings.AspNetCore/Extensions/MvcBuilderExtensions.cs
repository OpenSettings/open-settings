using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ogu.AspNetCore.Conventions;
using OpenSettings.AspNetCore.Authentication;
using OpenSettings.AspNetCore.Controllers.v1;
using OpenSettings.AspNetCore.CustomDataProtection;
using OpenSettings.AspNetCore.Handlers;
using OpenSettings.AspNetCore.Services;
using OpenSettings.Models;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

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

            var requiresAuthentication = syncAppDataResponse.RequiresAuthentication;

            if (syncAppDataResponse.IsProvider)
            {
                RegisterProviderServices(mvcBuilder.Services, providerInfo, controllerConfiguration, authenticationBuilder);
            }
            else
            {
                RegisterConsumerServices(mvcBuilder.Services, providerInfo, syncAppDataResponse.Client, authenticationBuilder, requiresAuthentication);
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

                if (requiresAuthentication)
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
            if (providerInfo.RequiresAuthentication && providerInfo.OpenIdConnect.IsActive)
            {
                authenticationBuilder
                    .AddCookie(OpenSettingsDefaults.AuthSchemes.Cookie, opts =>
                    {
                        opts.DataProtectionProvider =
                            CustomDataProtectionExtensions.CreateOpenSettingsDataProtectionProvider(providerInfo.Client
                                .Name);
                    })
                    .AddOpenSettingsOpenIdConnect(controllerConfiguration);
            }
        }

        private static void RegisterConsumerServices(IServiceCollection services, ProviderInfo providerInfo, SyncAppDataResponseClient client, AuthenticationBuilder authenticationBuilder, bool authorize)
        {
            if (authorize)
            {
                authenticationBuilder.AddJwtBearerForConsumer(providerInfo);
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

                opts.Events = new ProviderJwtBearerEvents();
            });
        }

        private static void AddJwtBearerForConsumer(this AuthenticationBuilder authenticationBuilder, ProviderInfo providerInfo)
        {
            authenticationBuilder.AddJwtBearer(OpenSettingsDefaults.AuthSchemes.JwtBearer, opts =>
            {
                opts.Authority = null; // -> not using discovery
                opts.RequireHttpsMetadata = false;
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = providerInfo.Client.Name,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidAudience = $"{OpenSettingsDefaults.Caches.OpenSettingsConfiguration.Client.Id}",
                    IssuerSigningKey = new SymmetricSecurityKey(new byte[32])
                };

                opts.Events = new ConsumerJwtBearerEvents();
            });
        }

        private static AuthenticationBuilder AddOpenSettingsOpenIdConnect(this AuthenticationBuilder authenticationBuilder, ConfigurationController controllerConfiguration)
        {
            return authenticationBuilder.AddOpenIdConnect(OpenSettingsDefaults.AuthSchemes.OpenIdConnect, opts =>
            {
                opts.Authority = controllerConfiguration.OpenIdConnect.Authority;
                opts.SignInScheme = OpenSettingsDefaults.AuthSchemes.Cookie;
                opts.SignedOutRedirectUri = controllerConfiguration.OpenIdConnect.SignedOutRedirectUri;
                opts.ClientId = controllerConfiguration.OpenIdConnect.ClientId;
                opts.ClientSecret = controllerConfiguration.OpenIdConnect.ClientSecret;
                opts.ResponseType = "code";
                opts.SaveTokens = true;
                opts.GetClaimsFromUserInfoEndpoint = true;
                opts.Scope.Clear();
                opts.Scope.Add("openid");
                opts.Scope.Add("profile");

                if (controllerConfiguration.OpenIdConnect.AllowOfflineAccess)
                {
                    opts.Scope.Add("offline_access");
                }
                
                opts.Events = new ProviderOpenIdConnectEvents();
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

            if (providerInfo.OpenIdConnect.IsActive)
            {
                if (isServiceTypeProvider)
                {
                    authSchemes.Add(OpenSettingsDefaults.AuthSchemes.OpenIdConnect);
                }
            }

            conventionOptions.AuthenticationSchemes = string.Join(OpenSettingsDefaults.Format.Comma, authSchemes);
        }
    }
}