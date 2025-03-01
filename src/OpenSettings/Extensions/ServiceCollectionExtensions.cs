using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
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
using System.Net.Http;
using System.Threading.Channels;

namespace OpenSettings.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureOpenSettings(this IServiceCollection services, IConfiguration configuration)
        {
            foreach (var kvp in Constants.FullNameToLocalSetting)
            {
                services.ConfigureSetting(configuration, kvp.Value);
            }

            return services;
        }

        public static IServiceCollection AddOpenSettings(this IServiceCollection services, OpenSettingsConfiguration openSettingsConfiguration, ProviderInfo providerInfo)
        {
            if (openSettingsConfiguration == null)
            {
                throw new ArgumentNullException(nameof(openSettingsConfiguration));
            }

            services.AddOptions();

            services.AddSingleton<OpenSettingsConfiguration>(sp =>
            {
                var loggerFactory = sp.GetRequiredService<ILoggerFactory>();

                openSettingsConfiguration.LoggerFactory = loggerFactory;

                return openSettingsConfiguration;
            });

            services.AddCompressions(opts => opts.Level = openSettingsConfiguration.Provider.CompressionLevel);

            if (openSettingsConfiguration.IsConsumerSelected)
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
                    services.AddSingleton<IHostedService>(sp =>
                    {
                        var logger = sp.GetRequiredService<ILogger<TimedHostedService>>();
                        var localSettingsService = sp.GetRequiredService<ILocalSettingsService>();

                        return new TimedHostedService(logger, "PollingSettingsWorker", async (cancellationToken) =>
                        {
                            await localSettingsService.ReloadSettingsAsync(cancellationToken);
                        }, opts =>
                        {
                            opts.StartsIn = openSettingsConfiguration.Consumer.PollingSettingsWorker.StartsIn;
                            opts.Period = openSettingsConfiguration.Consumer.PollingSettingsWorker.Period;
                        });
                    });
                }

                Action<HttpClient> configureHttpClient = httpClient =>
                {
                    httpClient.BaseAddress = new Uri(openSettingsConfiguration.Consumer.ProviderUrl);

                    httpClient.DefaultRequestHeaders.Authorization = openSettingsConfiguration.Client.CreateBasicAuthenticationHeaderValue();
                };

                services.AddHttpClient<IAppGroupsRestService, AppGroupsRestService>(configureHttpClient);
                services.AddHttpClient<IAppIdentifierMappingsRestService, AppIdentifierMappingsRestService>(configureHttpClient);
                services.AddHttpClient<IAppsRestService, AppsRestService>(configureHttpClient);
                services.AddHttpClient<IAppTagMappingsRestService, AppTagMappingsRestService>(configureHttpClient);
                services.AddHttpClient<IConfigurationsRestService, ConfigurationsRestService>(configureHttpClient);
                services.AddHttpClient<IIdentifiersRestService, IdentifiersRestService>(configureHttpClient);
                services.AddHttpClient<IInstancesRestService, InstancesRestService>(configureHttpClient);
                services.AddHttpClient<ILicensesRestService, LicensesRestService>(configureHttpClient);
                services.AddHttpClient<INotificationsRestService, NotificationsRestService>(configureHttpClient);
                services.AddHttpClient<IOpenSettingsRestService, OpenSettingsRestService>(configureHttpClient);
                services.AddHttpClient<IProviderRestService, ProviderRestService>(configureHttpClient);
                services.AddHttpClient<ISettingClassesRestService, SettingClassesRestService>(configureHttpClient);
                services.AddHttpClient<ISettingHistoriesRestService, SettingHistoriesRestService>(configureHttpClient);
                services.AddHttpClient<ISettingsRestService, SettingsRestService>(configureHttpClient);
                services.AddHttpClient<ITagsRestService, TagsRestService>(configureHttpClient);
                services.AddHttpClient<IUsersRestService, UsersRestService>(configureHttpClient);

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

                services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
            }
            else
            {
                if (openSettingsConfiguration.Provider.Redis.IsActive)
                {
                    services.RegisterRedisServiceCollection(openSettingsConfiguration.Provider.Redis.Configuration);
                }

                services.AddSingleton<DataValidationService>();

                services.AddSingleton<IPasswordHasher<AppSqlModel>, PasswordHasher<AppSqlModel>>();

                services.AddOpenSettingsDbContext<OpenSettingsDbContext>(openSettingsConfiguration.Provider.Orm);

                services.AddSingleton<IHostedService>(sp =>
                {
                    var taskQueueFactory = sp.GetRequiredService<ITaskQueueFactory>();

                    var taskQueue = taskQueueFactory.Get(Constants.TaskQueues.Notification);

                    return new TaskQueueHostedService(sp.GetRequiredService<ILogger<TaskQueueHostedService>>(), "NotificationQueueWorker", taskQueue);
                });

                services.AddSingleton<IHostedService>(sp =>
                {
                    return new TimedHostedService(sp.GetRequiredService<ILogger<TimedHostedService>>(), "NotificationTimedWorker",
                        async cancellationToken =>
                        {
                            using (var scope = sp.CreateScope())
                            {
                                var notificationsService = scope.ServiceProvider.GetRequiredService<INotificationsSqlService>();

                                await notificationsService.SyncOpenSettingsNotificationsAsync(cancellationToken);
                            }
                        }, opts =>
                        {
                            opts.StartsIn = TimeSpan.Zero;
                            opts.Period = TimeSpan.FromMinutes(5);
                            opts.TaskTimeout = TimeSpan.FromMinutes(2);
                        });
                });

                services.AddScoped<JsonWebTokenHandler>();

                services.AddScoped<IAppGroupsSqlService, AppGroupsSqlService>();
                services.AddScoped<IAppIdentifierMappingsSqlService, AppIdentifierMappingsSqlService>();
                services.AddScoped<IAppsSqlService, AppsSqlService>();
                services.AddScoped<IAppTagMappingsSqlService, AppTagMappingsSqlService>();
                services.AddScoped<IConfigurationsSqlService, ConfigurationsSqlService>();
                services.AddScoped<IIdentifiersSqlService, IdentifiersSqlService>();
                services.AddScoped<IInstancesSqlService, InstancesSqlService>();
                services.AddScoped<ILicensesSqlService, LicensesSqlService>();
                services.AddScoped<ILocksSqlService, LocksSqlService>();
                services.AddScoped<INotificationsSqlService, NotificationsSqlService>();
                services.AddScoped<IProviderSqlService, ProviderSqlService>();
                services.AddScoped<ISettingClassesSqlService, SettingClassesSqlService>();
                services.AddScoped<ISettingHistoriesSqlService, SettingHistoriesSqlService>();
                services.AddScoped<ISettingsSqlService, SettingsSqlService>();
                services.AddScoped<ISortOrderSqlService, SortOrderSqlService>();
                services.AddScoped<ITagsSqlService, TagsSqlService>();
                services.AddScoped<IUserNotificationMappingsSqlService, UserNotificationMappingsSqlService>();
                services.AddScoped<IUsersSqlService, UsersSqlService>();
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

                services.AddScoped<ILocalSettingsService, LocalSettingsService>();
            }

            services.AddSingleton<ITaskQueueFactory>(sp =>
            {
                var taskQueueFactory = new TaskQueueFactory();

                taskQueueFactory.TryAdd(Constants.TaskQueues.Notification, new BoundedChannelOptions(25));
                taskQueueFactory.TryAdd(Constants.TaskQueues.DataChange, new BoundedChannelOptions(1000));

                return taskQueueFactory;
            });

            services.AddSingleton<IHostedService>(sp =>
            {
                var taskQueueFactory = sp.GetRequiredService<ITaskQueueFactory>();

                var taskQueue = taskQueueFactory.Get(Constants.TaskQueues.DataChange);

                return new TaskQueueHostedService(sp.GetRequiredService<ILogger<TaskQueueHostedService>>(), "DataChangeQueueWorker", taskQueue);
            });

            services.AddSingleton<IDataChangeService, DataChangeService>();

            services.AddSingleton<OpenSettingsMemoryCache>();

            return services;
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

        public static IServiceCollection Configure(this IServiceCollection services, IConfigurationSection section, Type optionsType)
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