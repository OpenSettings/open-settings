using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ogu.AspNetCore.Conventions;
using Ogu.Compressions;
using OpenSettings.AspNetCore.Controllers.v1;
using OpenSettings.Configurations;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Rest;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore
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
        /// <param name="opts">An optional delegate to configure <see cref="ControllerOptions"/>.</param>
        /// <returns>Returns the <see cref="IMvcBuilder"/> to allow further configuration of MVC services.</returns>
        public static IMvcBuilder AddOpenSettingsController(this IMvcBuilder mvcBuilder, IConfiguration configuration, Action<ControllerOptions> opts = null)
        {
            var options = new ControllerOptions();
            opts?.Invoke(options);

            mvcBuilder.Services.AddSingleton(options);

            var authenticationBuilder = mvcBuilder.Services.AddAuthentication();

            authenticationBuilder.AddOpenSettingsBasicAuthenticationScheme();

            var providerInfo = configuration.GetSection(nameof(ProviderInfo)).Get<ProviderInfo>();

            var isProvider = providerInfo == null;

            if (isProvider)
            {
                var openSettingsAssemblyInfo = OpenSettingsAssemblyInfo.Instance;

                providerInfo = new ProviderInfo
                {
                    Authorize = options.Authorize,
                    PackVersion = openSettingsAssemblyInfo.Version,
                    PackVersionScore = openSettingsAssemblyInfo.VersionScore,
                    OAuth2 = new OAuth2Info
                    {
                        Authority = options.OAuth2Options.Authority,
                        AllowOfflineAccess = options.OAuth2Options.AllowOfflineAccess,
                        IsActive = options.OAuth2Options.IsActive
                    }
                };

                if (providerInfo.OAuth2.IsActive)
                {
                    var apiLoginRoute = $"/{options.Route}/v1/auth/login";

                    authenticationBuilder.AddCookie(OpenSettings.Constants.OpenSettingsCookieScheme).AddOpenIdConnect(OpenSettings.Constants.OpenSettingsOAuth2Scheme, openIdOpts =>
                    {
                        openIdOpts.Authority = options.OAuth2Options.Authority;
                        openIdOpts.SignInScheme = OpenSettings.Constants.OpenSettingsCookieScheme;
                        openIdOpts.SignedOutRedirectUri = options.OAuth2Options.SignedOutRedirectUri;
                        openIdOpts.ClientId = options.OAuth2Options.ClientId;
                        openIdOpts.ClientSecret = options.OAuth2Options.ClientSecret;
                        openIdOpts.ResponseType = "code";
                        openIdOpts.Scope.Clear();
                        openIdOpts.Scope.Add("openid");
                        openIdOpts.Scope.Add("profile");

                        if (options.OAuth2Options.AllowOfflineAccess)
                        {
                            openIdOpts.Scope.Add("offline_access");
                        }

                        openIdOpts.SaveTokens = true;
                        openIdOpts.GetClaimsFromUserInfoEndpoint = true;

                        var route = $"/{options.Route}";

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

                                var user = await usersService.GetOrCreateUserAsync(new GetOrCreateUserInput(context.Principal, OpenSettings.Constants.OpenSettingsOAuth2Scheme), CancellationToken.None);

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

                mvcBuilder.Services.AddSingleton<ProviderInfo>(sp =>
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
            }
            else
            {
                mvcBuilder.Services.AddTransient<OpenSettingsRestServiceAuthHandler>();
                mvcBuilder.Services.AddTransient<DecompressionHandler>();

                Action<IServiceProvider, HttpClient> configureHttpClient = (sp, httpClient) =>
                {
                    var openSettingsConfiguration = sp.GetRequiredService<OpenSettingsConfiguration>();

                    openSettingsConfiguration.Consumer.ConfigureHttpClient(httpClient, openSettingsConfiguration.Client);
                };

                mvcBuilder.Services.AddHttpClient<IAppGroupsRestService, AppGroupsRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<IAppIdentifierMappingsRestService, AppIdentifierMappingsRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<IAppsRestService, AppsRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<IAppTagMappingsRestService, AppTagMappingsRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<IConfigurationsRestService, ConfigurationsRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<IIdentifiersRestService, IdentifiersRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<IInstancesRestService, InstancesRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<ILicensesRestService, LicensesRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<INotificationsRestService, NotificationsRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<IOpenSettingsRestService, OpenSettingsRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<IProviderRestService, ProviderRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<ISettingClassesRestService, SettingClassesRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<ISettingHistoriesRestService, SettingHistoriesRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<ISettingsRestService, SettingsRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<ITagsRestService, TagsRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();
                mvcBuilder.Services.AddHttpClient<IUsersRestService, UsersRestService>(configureHttpClient).AddHttpMessageHandler<OpenSettingsRestServiceAuthHandler>().AddHttpMessageHandler<DecompressionHandler>();

                mvcBuilder.Services.AddSingleton<ProviderInfo>(providerInfo);
            }

            mvcBuilder.Services.AddSingleton<IOpenSettingsTokenService, OpenSettingsTokenService>();

            mvcBuilder.Services.AddHttpContextAccessor();

            mvcBuilder.Services.AddHttpClient();

            var authorize = providerInfo.Authorize || options.Authorize;

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
                mvcOpts.Conventions.AddControllerRoutePrefixConvention(controllerTypes, options.Route);

                if (!options.AllowFromExploring)
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

        private static AuthenticationBuilder AddOpenSettingsBasicAuthenticationScheme(this AuthenticationBuilder authenticationBuilder)
        {
            return authenticationBuilder.AddScheme<AuthenticationSchemeOptions, OpenSettingsBasicAuthenticationHandler>(OpenSettings.Constants.OpenSettingsBasicAuthScheme, null);
        }

        private static void ApplyConventionOpts(ControllerAuthorizeConventionOptions conventionOpts, ProviderInfo providerInfo, bool isServiceTypeProvider)
        {
            var authSchemes = new List<string> { OpenSettings.Constants.OpenSettingsBasicAuthScheme };

            if (providerInfo.OAuth2.IsActive)
            {
                if (isServiceTypeProvider)
                {
                    authSchemes.Add(OpenSettings.Constants.OpenSettingsOAuth2Scheme);
                }
                authSchemes.Add(Constants.OpenSettingsOAuth2JwtBearerScheme);
            }

            conventionOpts.AuthenticationSchemes = string.Join(",", authSchemes);
        }
    }
}