using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Ogu.Compressions.Abstractions;
using Ogu.Extensions.Hosting.HostedServices;
using OpenSettings.Configurations;
using OpenSettings.Domains.Redis.DataContext;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Models;
using OpenSettings.Services;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Redis;
using OpenSettings.Services.Rest;
using OpenSettings.Services.Rest.Interfaces;
using OpenSettings.Services.Sql;
using OpenSettings.Services.Sql.Interfaces;
using StackExchange.Redis;
using System;
using System.Diagnostics;
using System.Threading.Channels;

namespace OpenSettings.Extensions
{
    /// <summary>
    /// Provides extension methods to configure and add OpenSettings services to an <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures OpenSettings for the application by iterating over the <see cref="OpenSettingsDefaults.Caches.FullNameToLocalSetting"/>
        /// and registering each setting type in the <see cref="IServiceCollection"/> based on the configuration.
        /// <para>
        /// This method is typically called during the <see cref="HostBuilderExtensions.UseOpenSettingsAsync(IHostBuilder, OpenSettingsConfiguration, Type[])"/> extension to initialize
        /// OpenSettings configuration.
        /// </para>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which the OpenSettings services will be added.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> instance used to configure the settings.</param>
        /// <returns>The <see cref="IServiceCollection"/> with OpenSettings services configured.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="services" /> is null.</exception>
        public static IServiceCollection ConfigureOpenSettings(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            foreach (var kvp in OpenSettingsDefaults.Caches.FullNameToLocalSetting)
            {
                services.ConfigureSetting(configuration, kvp.Value);
            }

            return services;
        }

        /// <summary>
        /// Adds OpenSettings services to the application's <see cref="IServiceCollection"/>. This registers services
        /// necessary to run OpenSettings, based on the inherited <see cref="ISettings"/> types and the registration type.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which OpenSettings services will be added.</param>
        /// <param name="openSettingsConfiguration">The configuration that governs the behavior of OpenSettings (such as the service type: Provider or Consumer).</param>
        /// <param name="providerInfo">Information about the provider being registered.</param>
        /// <returns>The <see cref="IServiceCollection"/> with OpenSettings services registered.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="services" /> or <paramref name="openSettingsConfiguration"/> is null.</exception>
        internal static IServiceCollection AddOpenSettings(this IServiceCollection services, OpenSettingsConfiguration openSettingsConfiguration, ProviderInfo providerInfo)
        {
            if(services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (openSettingsConfiguration == null)
            {
                throw new ArgumentNullException(nameof(openSettingsConfiguration));
            }

            services.AddOptions();

            services.AddSingleton<OpenSettingsConfiguration>(sp =>
            {
                if (openSettingsConfiguration.InternalLoggerFactory == null)
                {
                    openSettingsConfiguration.LoggerFactory = sp.GetService<ILoggerFactory>() ?? NullLoggerFactory.Instance;
                }
                
                return openSettingsConfiguration;
            });

            services.AddCompressions(opts => opts.CompressionOptions = compressionOpts => compressionOpts.Level = openSettingsConfiguration.Provider.CompressionLevel);

            if (openSettingsConfiguration.IsConsumerSelected)
            {
                services.RegisterConsumerServices(openSettingsConfiguration, providerInfo);
            }
            else
            {
                services.RegisterProviderServices(openSettingsConfiguration);
            }

            services.AddSingleton<ProviderInfo>(providerInfo);

            services.AddSingleton<ITaskQueueFactory>(sp =>
            {
                var taskQueueFactory = new TaskQueueFactory();

                taskQueueFactory.TryAdd(OpenSettingsDefaults.TaskQueues.Notification, new BoundedChannelOptions(25));
                taskQueueFactory.TryAdd(OpenSettingsDefaults.TaskQueues.DataChange, new BoundedChannelOptions(1000));

                return taskQueueFactory;
            });

            services.AddSingleton<IHostedService>(sp =>
            {
                var taskQueueFactory = sp.GetRequiredService<ITaskQueueFactory>();

                var taskQueue = taskQueueFactory.GetDataChangeQueue();

                var logger = sp.GetRequiredService<OpenSettingsConfiguration>().LoggerFactory.CreateLogger<TaskQueueHostedService>();

                return new TaskQueueHostedService(logger, "DataChangeQueueWorker", taskQueue);
            });

            services.AddSingleton<IDataChangeService, DataChangeService>();
            services.AddSingleton<IOpenSettingsMemoryCache>(sp => OpenSettingsDefaults.Caches.GetOpenSettingsMemoryCache(openSettingsConfiguration.LoggerFactory));

            return services;
        }

        private static void RegisterProviderServices(this IServiceCollection services, OpenSettingsConfiguration openSettingsConfiguration)
        {
            if (openSettingsConfiguration.Provider.Redis.IsActive)
            {
                services.RegisterRedisServiceCollection(openSettingsConfiguration.Provider.Redis.Configuration);
            }

            services.AddSingleton<IDataValidationService, DataValidationService>();

            services.AddSingleton<IPasswordHasher<AppSqlModel>, PasswordHasher<AppSqlModel>>();

            services.AddOpenSettingsDbContext(openSettingsConfiguration.Provider.Orm);

            services.AddSingleton<IHostedService>(sp =>
            {
                var taskQueueFactory = sp.GetRequiredService<ITaskQueueFactory>();

                var taskQueue = taskQueueFactory.GetNotificationQueue();

                var logger = sp.GetRequiredService<OpenSettingsConfiguration>().LoggerFactory.CreateLogger<TaskQueueHostedService>();

                return new TaskQueueHostedService(logger, "NotificationQueueWorker", taskQueue);
            });

            services.AddScoped<IAppGroupSqlService, AppGroupSqlService>();
            services.AddScoped<IAppIdentifierMappingSqlService, AppIdentifierMappingSqlService>();
            services.AddScoped<IAppSqlService, AppsSqlService>();
            services.AddScoped<IAppTagMappingSqlService, AppTagMappingSqlService>();
            services.AddScoped<IConfigurationSqlService, AppConfigurationSqlService>();
            services.AddScoped<IIdentifierSqlService, IdentifierSqlService>();
            services.AddScoped<IInstanceSqlService, InstanceSqlService>();
            services.AddScoped<ILicenseSqlService, LicenseSqlService>();
            services.AddScoped<ILockSqlService, LockSqlService>();
            services.AddScoped<INotificationSqlService, NotificationSqlService>();
            services.AddScoped<IProviderSqlService, ProviderSqlService>();
            services.AddScoped<ISettingClassSqlService, AppSettingClassSqlService>();
            services.AddScoped<ISettingHistorySqlService, AppSettingHistorySqlService>();
            services.AddScoped<ISettingsSqlService, AppSettingsSqlService>();
            services.AddScoped<ISortOrderSqlService, SortOrderSqlService>();
            services.AddScoped<ITagSqlService, AppTagSqlService>();
            services.AddScoped<IUserNotificationMappingSqlService, UserNotificationMappingSqlService>();
            services.AddScoped<IUserSqlService, UserSqlService>();
            services.AddScoped<IGlobalConfigurationSqlService, GlobalConfigurationSqlService>();
            services.AddSingleton<IOpenSettingsService, OpenSettingsService>();
            services.AddSingleton<ITokenSqlService, TokenSqlService>();

            services.AddScoped<IAppGroupService>(sp => sp.GetRequiredService<IAppGroupSqlService>());
            services.AddScoped<IAppIdentifierMappingService>(sp => sp.GetRequiredService<IAppIdentifierMappingSqlService>());
            services.AddScoped<IAppService>(sp => sp.GetRequiredService<IAppSqlService>());
            services.AddScoped<IAppTagMappingService>(sp => sp.GetRequiredService<IAppTagMappingSqlService>());
            services.AddScoped<IConfigurationService>(sp => sp.GetRequiredService<IConfigurationSqlService>());
            services.AddScoped<IIdentifierService>(sp => sp.GetRequiredService<IIdentifierSqlService>());
            services.AddScoped<IInstanceService>(sp => sp.GetRequiredService<IInstanceSqlService>());
            services.AddScoped<ILicenseService>(sp => sp.GetRequiredService<ILicenseSqlService>());
            services.AddScoped<ILockService>(sp => sp.GetRequiredService<ILockSqlService>());
            services.AddScoped<INotificationService>(sp => sp.GetRequiredService<INotificationSqlService>());
            services.AddScoped<IProviderService>(sp => sp.GetRequiredService<IProviderSqlService>());
            services.AddScoped<ISettingClassService>(sp => sp.GetRequiredService<ISettingClassSqlService>());
            services.AddScoped<ISettingHistoryService>(sp => sp.GetRequiredService<ISettingHistorySqlService>());
            services.AddScoped<ISettingsService>(sp => sp.GetRequiredService<ISettingsSqlService>());
            services.AddScoped<ITagsService>(sp => sp.GetRequiredService<ITagSqlService>());
            services.AddScoped<IUserNotificationMappingService>(sp => sp.GetRequiredService<IUserNotificationMappingSqlService>());
            services.AddScoped<IUserService>(sp => sp.GetRequiredService<IUserSqlService>());
            services.AddScoped<IGlobalConfigurationService>(sp => sp.GetRequiredService<IGlobalConfigurationSqlService>());
            services.AddSingleton<ITokenService>(sp => sp.GetRequiredService<ITokenSqlService>());

            services.AddScoped<ILocalSettingsService, LocalSettingsService>();

            services.AddSingleton<IProviderCoordinationTimedService, ProviderCoordinationTimedService>();
            services.AddSingleton<IOpenSettingsNotificationSyncTimedService, OpenSettingsNotificationSyncTimedService>();
            services.AddSingleton<IProviderRegistryCleanupTimedService, ProviderRegistryCleanupTimedService>();

            services.AddSingleton<IHostedService>(sp => sp.GetRequiredService<IProviderCoordinationTimedService>());
        }

        private static void RegisterConsumerServices(this IServiceCollection services, OpenSettingsConfiguration openSettingsConfiguration, ProviderInfo providerInfo)
        {
            if (openSettingsConfiguration.Consumer.IsRedisActive && providerInfo.Redis.IsActive)
            {
                var configuration = ConfigurationOptions.Parse(providerInfo.Redis.Configuration, true);

                configuration.ClientName = openSettingsConfiguration.Client.Name;
                configuration.AllowAdmin = false;

                providerInfo.Redis.Configuration = configuration.ToString();

                services.RegisterRedisServiceCollection(providerInfo.Redis.Configuration);
            }

            if (openSettingsConfiguration.Consumer.PollingSettingsWorker.IsActive)
            {
                services.AddSingleton<IPollingSettingTimedService, PollingSettingTimedService>();

                services.AddSingleton<IHostedService>(sp => sp.GetRequiredService<IPollingSettingTimedService>());
            }

            services.AddTransient<DecompressionHandler>();
            services.AddTransient<ConsumerToProviderRequestHandler>();

            services
                .AddHttpClient(OpenSettingsDefaults.Names.ProviderHttpClientName, (sp, httpClient) =>
                {
                    openSettingsConfiguration.Consumer.ConfigureHttpClient(httpClient, openSettingsConfiguration.Client);
                })
                .AddHttpMessageHandler<DecompressionHandler>()
                .AddHttpMessageHandler<ConsumerToProviderRequestHandler>();

            services.AddSingleton<IAppGroupRestService, AppGroupRestService>();
            services.AddSingleton<IAppIdentifierMappingRestService, AppIdentifierMappingsRestService>();
            services.AddSingleton<IAppRestService, AppRestService>();
            services.AddSingleton<IAppTagMappingRestService, AppTagMappingRestService>();
            services.AddSingleton<IConfigurationRestService, ConfigurationRestService>();
            services.AddSingleton<IIdentifierRestService, IdentifierRestService>();
            services.AddSingleton<IInstanceRestService, InstanceRestService>();
            services.AddSingleton<ILicenseRestService, LicenseRestService>();
            services.AddSingleton<INotificationRestService, NotificationRestService>();
            services.AddSingleton<IOpenSettingsRestService, OpenSettingsRestService>();
            services.AddSingleton<IProviderRestService, ProviderRestService>();
            services.AddSingleton<ISettingClassRestService, SettingClassRestService>();
            services.AddSingleton<ISettingHistoryRestService, SettingHistoryRestService>();
            services.AddSingleton<ISettingsRestService, SettingsRestService>();
            services.AddSingleton<ITagRestService, TagRestService>();
            services.AddSingleton<IUserRestService, UsersRestService>();
            services.AddSingleton<ITokenRestService, TokenRestService>();

            services.AddSingleton<IAppGroupService>(sp => sp.GetRequiredService<IAppGroupRestService>());
            services.AddSingleton<IAppIdentifierMappingService>(sp => sp.GetRequiredService<IAppIdentifierMappingRestService>());
            services.AddSingleton<IAppService>(sp => sp.GetRequiredService<IAppRestService>());
            services.AddSingleton<IAppTagMappingService>(sp => sp.GetRequiredService<IAppTagMappingRestService>());
            services.AddSingleton<IConfigurationService>(sp => sp.GetRequiredService<IConfigurationRestService>());
            services.AddSingleton<IIdentifierService>(sp => sp.GetRequiredService<IIdentifierRestService>());
            services.AddSingleton<IInstanceService>(sp => sp.GetRequiredService<IInstanceRestService>());
            services.AddSingleton<ILicenseService>(sp => sp.GetRequiredService<ILicenseRestService>());
            services.AddSingleton<INotificationService>(sp => sp.GetRequiredService<INotificationRestService>());
            services.AddSingleton<IOpenSettingsService>(sp => sp.GetRequiredService<IOpenSettingsRestService>());
            services.AddSingleton<IProviderService>(sp => sp.GetRequiredService<IProviderRestService>());
            services.AddSingleton<ISettingClassService>(sp => sp.GetRequiredService<ISettingClassRestService>());
            services.AddSingleton<ISettingHistoryService>(sp => sp.GetRequiredService<ISettingHistoryRestService>());
            services.AddSingleton<ISettingsService>(sp => sp.GetRequiredService<ISettingsRestService>());
            services.AddSingleton<ITagsService>(sp => sp.GetRequiredService<ITagRestService>());
            services.AddSingleton<IUserService>(sp => sp.GetRequiredService<IUserRestService>());
            services.AddSingleton<ITokenService>(sp => sp.GetRequiredService<ITokenRestService>());

            services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
        }

        private static IServiceCollection AddOpenSettingsDbContext(this IServiceCollection services, OrmConfiguration orm)
        {
            if (orm.EnablePooling)
            {
                services.AddDbContextPool<OpenSettingsDbContext>(
                    dbCtxBuilder =>
                    {
                        if (!OpenSettingsDefaults.Flags.IsDbLogEnabled)
                        {
                            dbCtxBuilder.UseLoggerFactory(NullLoggerFactory.Instance);
                        }
#if DEBUG
                        if (Debugger.IsAttached)
                        {
                            dbCtxBuilder.EnableSensitiveDataLogging(OpenSettingsDefaults.Flags.IsSensitiveDataLoggingEnabled);
                        }
#endif
                        dbCtxBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.AmbientTransactionWarning));

                        orm.ConfigureDbContext?.Invoke(dbCtxBuilder);
                    }, orm.PoolSize ?? 128);
            }
            else
            {
                services.AddDbContext<OpenSettingsDbContext>(dbCtxBuilder =>
                {
                    if (!OpenSettingsDefaults.Flags.IsDbLogEnabled)
                    {
                        dbCtxBuilder.UseLoggerFactory(NullLoggerFactory.Instance);
                    }
#if DEBUG
                    if (Debugger.IsAttached)
                    {
                        dbCtxBuilder.EnableSensitiveDataLogging(OpenSettingsDefaults.Flags.IsSensitiveDataLoggingEnabled);
                    }
#endif
                    dbCtxBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.AmbientTransactionWarning));

                    orm.ConfigureDbContext?.Invoke(dbCtxBuilder);
                });
            }

            return services;
        }

        private static IServiceCollection Configure(this IServiceCollection services, IConfigurationSection section, Type optionsType)
        {
            var configureMethod = typeof(ServiceCollectionExtensions)
                .GetMethod(nameof(ConfigureDynamic), System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)
                .MakeGenericMethod(optionsType);

            configureMethod.Invoke(null, new object[] { services, section });

            return services;
        }

        private static void ConfigureDynamic<TOptions>(IServiceCollection services, IConfigurationSection section) where TOptions : class, new()
        {
            services.Configure<TOptions>(section);
        }

        private static IServiceCollection ConfigureSetting(this IServiceCollection services, IConfiguration configuration, LocalSetting localSetting)
        {
            IConfigurationSection dataSection;

            switch (localSetting.RegistrationMode)
            {
                case RegistrationMode.Configure:

                    dataSection = configuration.GetSection(localSetting.Type.FullName);

                    services.Configure(dataSection, localSetting.Type);

                    break;

                case RegistrationMode.Singleton:

                    services.AddSingleton(localSetting.Type, localSetting.Instance);

                    break;

                case RegistrationMode.Both:

                    dataSection = configuration.GetSection(localSetting.Type.FullName);

                    services.AddSingleton(localSetting.Type, localSetting.Instance);

                    services.Configure(dataSection, localSetting.Type);

                    break;
            }

            return services;
        }

        private static IServiceCollection RegisterRedisServiceCollection(this IServiceCollection services, string configuration)
        {
            services.AddRedisContext<OpenSettings.Domains.Redis.DataContext.Context>(configuration);
            services.AddHostedService<OpenSettingsRedisHostedService>();

            return services;
        }

        private static IServiceCollection AddRedisContext<TContext>(this IServiceCollection services,
            string configuration, Action<RedisContextOptions> redisContextOpts = null) where TContext : RedisContext
        {
            services = services ?? throw new ArgumentNullException(nameof(services));

            var configurationOptions = ConfigurationOptions.Parse(configuration, true);

            var redisContextOptions = new RedisContextOptions();

            redisContextOpts?.Invoke(redisContextOptions);

            services.AddSingleton(configurationOptions);
            services.AddSingleton(redisContextOptions);
            services.AddSingleton<TContext>();

            return services;
        }
    }
}