using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.IdentityModel.JsonWebTokens;
using Ogu.Compressions.Abstractions;
using Ogu.Extensions.Hosting.HostedServices;
using OpenSettings.Configurations;
using OpenSettings.Domains.Redis.DataContext;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Models;
using OpenSettings.Services;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.MemoryCache;
using OpenSettings.Services.Redis;
using OpenSettings.Services.Rest;
using OpenSettings.Services.Rest.Interfaces;
using OpenSettings.Services.Sql;
using OpenSettings.Services.Sql.Interfaces;
using StackExchange.Redis;
using System;
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
        public static IServiceCollection AddOpenSettings(this IServiceCollection services, OpenSettingsConfiguration openSettingsConfiguration, ProviderInfo providerInfo)
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
                var loggerFactory = sp.GetService<ILoggerFactory>();

                openSettingsConfiguration.LoggerFactory = loggerFactory ?? NullLoggerFactory.Instance;

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

                return new TaskQueueHostedService(sp.GetRequiredService<ILogger<TaskQueueHostedService>>(), "DataChangeQueueWorker", taskQueue);
            });

            services.AddSingleton<IDataChangeService, DataChangeService>();
            services.AddSingleton<IOpenSettingsMemoryCache, OpenSettingsMemoryCache>();

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

            services.AddOpenSettingsDbContext<OpenSettingsDbContext>(openSettingsConfiguration.Provider.Orm);

            services.AddSingleton<IHostedService>(sp =>
            {
                var taskQueueFactory = sp.GetRequiredService<ITaskQueueFactory>();

                var taskQueue = taskQueueFactory.GetNotificationQueue();

                return new TaskQueueHostedService(sp.GetRequiredService<ILogger<TaskQueueHostedService>>(), "NotificationQueueWorker", taskQueue);
            });

            services.AddScoped<JsonWebTokenHandler>();

            services.AddScoped<IAppGroupsSqlService, AppGroupSqlService>();
            services.AddScoped<IAppIdentifierMappingsSqlService, AppIdentifierMappingSqlService>();
            services.AddScoped<IAppsSqlService, AppsSqlService>();
            services.AddScoped<IAppTagMappingsSqlService, AppTagMappingSqlService>();
            services.AddScoped<IConfigurationsSqlService, ConfigurationSqlService>();
            services.AddScoped<IIdentifiersSqlService, IdentifierSqlService>();
            services.AddScoped<IInstancesSqlService, InstancesSqlService>();
            services.AddScoped<ILicensesSqlService, LicensesSqlService>();
            services.AddScoped<ILocksSqlService, LocksSqlService>();
            services.AddScoped<INotificationsSqlService, NotificationsSqlService>();
            services.AddScoped<IProviderSqlService, ProviderSqlService>();
            services.AddScoped<ISettingClassesSqlService, SettingClassSqlService>();
            services.AddScoped<ISettingHistoriesSqlService, SettingHistoriesSqlService>();
            services.AddScoped<ISettingsSqlService, SettingSqlService>();
            services.AddScoped<ISortOrderSqlService, SortOrderSqlService>();
            services.AddScoped<ITagsSqlService, TagSqlService>();
            services.AddScoped<IUserNotificationMappingsSqlService, UserNotificationMappingSqlService>();
            services.AddScoped<IUsersSqlService, UserSqlService>();
            services.AddSingleton<IOpenSettingsService, OpenSettingsService>();

            services.AddScoped<IAppGroupsService>(sp => sp.GetRequiredService<IAppGroupsSqlService>());
            services.AddScoped<IAppIdentifierMappingsService>(sp => sp.GetRequiredService<IAppIdentifierMappingsSqlService>());
            services.AddScoped<IAppsService>(sp => sp.GetRequiredService<IAppsSqlService>());
            services.AddScoped<IAppTagMappingsService>(sp => sp.GetRequiredService<IAppTagMappingsSqlService>());
            services.AddScoped<IConfigurationsService>(sp => sp.GetRequiredService<IConfigurationsSqlService>());
            services.AddScoped<IIdentifiersService>(sp => sp.GetRequiredService<IIdentifiersSqlService>());
            services.AddScoped<IInstancesService>(sp => sp.GetRequiredService<IInstancesSqlService>());
            services.AddScoped<ILicensesService>(sp => sp.GetRequiredService<ILicensesSqlService>());
            services.AddScoped<ILocksService>(sp => sp.GetRequiredService<ILocksSqlService>());
            services.AddScoped<INotificationsService>(sp => sp.GetRequiredService<INotificationsSqlService>());
            services.AddScoped<IProviderService>(sp => sp.GetRequiredService<IProviderSqlService>());
            services.AddScoped<ISettingClassesService>(sp => sp.GetRequiredService<ISettingClassesSqlService>());
            services.AddScoped<ISettingHistoriesService>(sp => sp.GetRequiredService<ISettingHistoriesSqlService>());
            services.AddScoped<ISettingsService>(sp => sp.GetRequiredService<ISettingsSqlService>());
            services.AddScoped<ITagsService>(sp => sp.GetRequiredService<ITagsSqlService>());
            services.AddScoped<IUserNotificationMappingsService>(sp => sp.GetRequiredService<IUserNotificationMappingsSqlService>());
            services.AddScoped<IUsersService>(sp => sp.GetRequiredService<IUsersSqlService>());

            services.AddScoped<ILocalSettingService, LocalSettingService>();

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

            services
                .AddHttpClient(OpenSettingsDefaults.Names.HttpClientName, (sp, httpClient) =>
                {
                    openSettingsConfiguration.Consumer.ConfigureHttpClient(httpClient, openSettingsConfiguration.Client);
                })
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

            services.AddSingleton<IAppGroupsService>(sp => sp.GetRequiredService<IAppGroupsRestService>());
            services.AddSingleton<IAppIdentifierMappingsService>(sp => sp.GetRequiredService<IAppIdentifierMappingsRestService>());
            services.AddSingleton<IAppsService>(sp => sp.GetRequiredService<IAppsRestService>());
            services.AddSingleton<IAppTagMappingsService>(sp => sp.GetRequiredService<IAppTagMappingsRestService>());
            services.AddSingleton<IConfigurationsService>(sp => sp.GetRequiredService<IConfigurationsRestService>());
            services.AddSingleton<IIdentifiersService>(sp => sp.GetRequiredService<IIdentifiersRestService>());
            services.AddSingleton<IInstancesService>(sp => sp.GetRequiredService<IInstancesRestService>());
            services.AddSingleton<ILicensesService>(sp => sp.GetRequiredService<ILicensesRestService>());
            services.AddSingleton<INotificationsService>(sp => sp.GetRequiredService<INotificationsRestService>());
            services.AddSingleton<IOpenSettingsService>(sp => sp.GetRequiredService<IOpenSettingsRestService>());
            services.AddSingleton<IProviderService>(sp => sp.GetRequiredService<IProviderRestService>());
            services.AddSingleton<ISettingClassesService>(sp => sp.GetRequiredService<ISettingClassesRestService>());
            services.AddSingleton<ISettingHistoriesService>(sp => sp.GetRequiredService<ISettingHistoriesRestService>());
            services.AddSingleton<ISettingsService>(sp => sp.GetRequiredService<ISettingsRestService>());
            services.AddSingleton<ITagsService>(sp => sp.GetRequiredService<ITagsRestService>());
            services.AddSingleton<IUsersService>(sp => sp.GetRequiredService<IUsersRestService>());

            services.AddSingleton<ILocalSettingService, LocalSettingService>();
        }

        private static IServiceCollection AddOpenSettingsDbContext<TContext>(this IServiceCollection services, OrmConfiguration orm) where TContext : DbContext
        {
            if (orm.EnablePooling)
            {
                services.AddDbContextPool<TContext>(
                    dbCtxBuilder =>
                    {
#if DEBUG
                        dbCtxBuilder.EnableSensitiveDataLogging();
#endif
                        dbCtxBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.AmbientTransactionWarning));

                        orm.ConfigureDbContext?.Invoke(dbCtxBuilder);
                    }, orm.PoolSize ?? 128);
            }
            else
            {
                services.AddDbContext<TContext>(dbCtxBuilder =>
                {
#if DEBUG
                    dbCtxBuilder.EnableSensitiveDataLogging();
#endif
                    dbCtxBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.AmbientTransactionWarning));

                    orm.ConfigureDbContext?.Invoke(dbCtxBuilder);
                });
            }

            services.AddScoped<OpenSettingsDbContext>();

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

        private static IServiceCollection ConfigureSetting(this IServiceCollection services, IConfiguration configuration, ILocalSetting localSetting)
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