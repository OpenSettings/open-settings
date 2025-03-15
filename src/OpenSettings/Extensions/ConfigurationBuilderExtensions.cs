using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ogu.Compressions;
using Ogu.Compressions.Abstractions;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Exceptions;
using OpenSettings.Helpers;
using OpenSettings.Models;
using OpenSettings.Models.Responses;
using OpenSettings.Services;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Rest;
using OpenSettings.Services.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
#if NETSTANDARD2_0
using OpenSettings.Extensions;
#endif

namespace OpenSettings.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="IConfigurationBuilder"/> to retrieve settings from the configuration 
    /// and build application settings asynchronously.
    /// </summary>
    public static class ConfigurationBuilderExtensions
    {
        /// <summary>
        /// Retrieves a setting from the configuration or returns the default value if not found.
        /// <para>
        /// The <see cref="GetSettingOrDefault{T}"/> method retrieves a setting of type <typeparamref name="T"/> from the configuration. 
        /// If the setting doesn't exist, it returns the default value for the type. The type <typeparamref name="T"/> must implement <see cref="ISettings"/>.
        /// </para>
        /// <para>
        /// The non-generic <see cref="GetSettingOrDefault"/> method retrieves a setting by the provided <paramref name="type"/>.
        /// If no setting is found, it returns <c>null</c> or the default value of the specified type.
        /// </para>
        /// </summary>
        /// <typeparam name="T">The type of setting to retrieve, which must implement <see cref="ISettings"/>.</typeparam>
        /// <param name="configuration">The <see cref="IConfiguration"/> used to retrieve the setting.</param>
        /// <returns>The setting of the specified type, or the default value if not found.</returns>
        public static T GetSettingOrDefault<T>(this IConfiguration configuration) where T : ISettings
        {
            var type = typeof(T);

            return (T)GetSettingOrDefault(configuration, type);
        }

        /// <summary>
        /// Retrieves a setting from the configuration or returns the default value if not found.
        /// <para>
        /// Retrieves a setting of the specified <paramref name="type"/> from the configuration. If no setting is found, it returns <c>null</c> or the default value of the type.
        /// </para>
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/> used to retrieve the setting.</param>
        /// <param name="type">The <see cref="Type"/> of the setting to retrieve.</param>
        /// <returns>The setting of the specified type, or <c>null</c> if not found.</returns>
        public static object GetSettingOrDefault(this IConfiguration configuration, Type type)
        {
            return configuration.GetSection(type.FullName).Get(type);
        }

        /// <summary>
        /// Builds and configures settings asynchronously for the application based on the specified service configuration.
        /// <para>
        /// The <see cref="BuildSettingsAsync"/> method handles the initial setup of settings for the application, with behavior 
        /// changing depending on whether the settings service configuration is set to "Provider" or "Consumer". This method is 
        /// responsible for syncing application data, generating settings-related files, and adding them to the configuration builder.
        /// </para>
        /// <para>
        /// The generated settings files are made available through the <see cref="IConfiguration"/> interface, allowing them to be 
        /// easily retrieved by the application. This method is typically used during application startup to ensure that settings 
        /// are properly loaded and integrated into the system.
        /// </para>
        /// <para>
        /// If the <paramref name="settingsTypes"/> parameter is specified, only the types inherited from <see cref="ISettings"/> will 
        /// be treated as settings and managed by the OpenSettings. If no types are provided or if the parameter is <c>null</c>, the library 
        /// uses reflection to identify and manage all classes inherited from <see cref="ISettings"/> within the current assembly.
        /// </para>
        /// <para>
        /// This method is asynchronous and supports cancellation via a <paramref name="cancellationToken"/>. It also accepts optional 
        /// parameters such as a logger, environment name, and a list of settings types to be configured.
        /// </para>
        /// </summary>
        /// <param name="configurationBuilder">The configuration builder used to add the settings to the application's configuration.</param>
        /// <param name="openSettingsConfiguration">The settings service configuration determining the behavior (Provider or Consumer).</param>
        /// <param name="environmentName">An optional environment name to customize settings per environment.</param>
        /// <param name="cancellationToken">A cancellation token to allow cancelling the operation if needed.</param>
        /// <param name="settingsTypes">The types of settings to build and configure. Only classes inheriting from <see cref="ISettings"/> will be treated as settings.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/></returns>
        public static async Task<IConfigurationBuilder> BuildSettingsAsync(
            this ConfigurationBuilder configurationBuilder,
            OpenSettingsConfiguration openSettingsConfiguration,
            string environmentName = null,
            CancellationToken cancellationToken = default,
            params Type[] settingsTypes)
        {
            if (string.IsNullOrWhiteSpace(environmentName))
            {
                environmentName = Helper.GetEnvironmentName();
            }

            return openSettingsConfiguration.IsConsumerSelected &&
                   openSettingsConfiguration.Consumer.SkipInitialSyncAppData && 
                   !ConsumerConfiguration.IsGeneratorModeEnabled
                ? await GenerateConfigurationSkippingInitialSyncAsync(configurationBuilder,
                    openSettingsConfiguration, settingsTypes, cancellationToken)
                : await GenerateConfigurationWithSyncAsync(configurationBuilder, environmentName,
                    openSettingsConfiguration, settingsTypes, cancellationToken);
        }

        private static async Task<ConfigurationBuilder> GenerateConfigurationWithSyncAsync(ConfigurationBuilder configurationBuilder, string environmentName, OpenSettingsConfiguration openSettingsConfiguration, Type[] settingsTypes, CancellationToken cancellationToken)
        {
            var localSettings = await Helper.CreateLocalSettingsFromFiles(environmentName, openSettingsConfiguration.RegistrationMode, openSettingsConfiguration.Operation, cancellationToken, settingsTypes);

            InitializeConstants(localSettings);

            await ExecuteWithLocalSettingsServiceAsync(async localSettingsService =>
            {
                await localSettingsService.SyncAppDataAsync(cancellationToken);

                foreach (var settingData in localSettings.DistinctBy(s => s.GeneratedFilePath))
                {
                    configurationBuilder.AddJsonFile(settingData.GeneratedFilePath, optional: true,
                        reloadOnChange: settingData.StoreInSeparateFile
                            ? !settingData.IgnoreOnFileChange ?? true
                            : !openSettingsConfiguration.IgnoreOnFileChange);
                }

                configurationBuilder.AddJsonFile(Constants.GeneratedOpenSettingsFilePath, false, reloadOnChange: false);

            }, openSettingsConfiguration, cancellationToken);

            return configurationBuilder;
        }

        private static async Task<ConfigurationBuilder> GenerateConfigurationSkippingInitialSyncAsync(ConfigurationBuilder configurationBuilder, OpenSettingsConfiguration openSettingsConfiguration, Type[] settingsTypes, CancellationToken cancellationToken)
        {
            var syncAppDataResponse = await SyncAppDataResponse.GetAsync(cancellationToken);

            if (syncAppDataResponse?.ProviderInfo == null || 
                syncAppDataResponse.Configuration == null)
            {
                throw new MissingConfigurationWhenSkipInitialSyncAppDataException();
            }

            openSettingsConfiguration.Update(syncAppDataResponse.Configuration);

            var localSettings = await Helper.CreateLocalSettingsFromGeneratedFilesAsync(
                openSettingsConfiguration.RegistrationMode, openSettingsConfiguration.Operation,
                cancellationToken, settingsTypes);

            InitializeConstants(localSettings);

            var logger = openSettingsConfiguration.LoggerFactory.CreateLogger("OpenSettings");

            var missingSettings = string.Join(",", localSettings.Where(s => !s.IsPreDataExists).Select(s => s.Type.FullName));

            if (!string.IsNullOrWhiteSpace(missingSettings))
            {
                logger.LogWarning("SkipInitialSyncAppData property is set to true, which triggered the injection of pre-generated setting files. However, the following settings were not found: {missingSettings}.", missingSettings);
            }

            await ExecuteWithLocalSettingsServiceAsync(
                localSettingsService =>
            {
                var fullPathToInstanceFullNameToObjectInstance = localSettingsService.UpdateLocalData();

                FileHelper.DeleteSettingsFiles();

#if NETSTANDARD2_0
                FileHelper.WriteToDisk(fullPathToInstanceFullNameToObjectInstance);

                return Task.CompletedTask;
#else
                return FileHelper.WriteToDiskAsync(fullPathToInstanceFullNameToObjectInstance, cancellationToken);
#endif
            }, openSettingsConfiguration, cancellationToken);

            foreach (var settingData in localSettings.DistinctBy(s => s.GeneratedFilePath))
            {
                configurationBuilder.AddJsonFile(settingData.GeneratedFilePath, optional: true, reloadOnChange: settingData.StoreInSeparateFile ? !settingData.IgnoreOnFileChange ?? true : !openSettingsConfiguration.IgnoreOnFileChange);
            }

            configurationBuilder.AddJsonFile(Constants.GeneratedOpenSettingsFilePath, false, reloadOnChange: false);

            return configurationBuilder;
        }

        private static void InitializeConstants(IEnumerable<LocalSetting> localSettings)
        {
            foreach (var localSetting in localSettings)
            {
                Constants.ComputedIdentifierToLocalSetting[localSetting.ComputedIdentifier] = localSetting;
                Constants.TypeIdToComputedIdentifier[localSetting.Type.GUID] = localSetting.ComputedIdentifier;
                Constants.FullNameToLocalSetting[localSetting.Type.FullName] = localSetting;
                Constants.ClassNameToCount[localSetting.Type.Name] = Constants.ClassNameToCount.GetValueOrDefault(localSetting.Type.Name, 0) + 1;
            }
        }

        private static async Task ExecuteWithLocalSettingsServiceAsync(Func<LocalSettingsService, Task> func,
         OpenSettingsConfiguration openSettingsConfiguration, CancellationToken cancellationToken)
        {
            var compressionFactory = new CompressionFactory(new CompressionOptions { Level = openSettingsConfiguration.Provider.CompressionLevel });

            if (openSettingsConfiguration.IsConsumerSelected)
            {
                var handler = new DecompressionHandler(compressionFactory)
                {
                    InnerHandler = new HttpClientHandler()
                };

                var httpClient = new HttpClient(handler);

                openSettingsConfiguration.Consumer.ConfigureHttpClient(httpClient, openSettingsConfiguration.Client);

                var appsService = new AppsRestService(httpClient, openSettingsConfiguration);
                var settingsService = new SettingsRestService(dataChangeService: null, httpClient, openSettingsConfiguration, providerInfo: null);

                var localSettingsService = new LocalSettingsService(openSettingsConfiguration, appsService, settingsService);

                await func(localSettingsService);

                httpClient.Dispose();
                handler.Dispose();
            }
            else
            {
                var context = OpenSettingsDbContext.GetInstance(openSettingsConfiguration.Provider);

                await openSettingsConfiguration.Provider.InitializeDbAsync(context, cancellationToken);

                var sortOrderSqlService = new SortOrderSqlService(new LocksSqlService(context), context, openSettingsConfiguration);
                var appGroupsSqlService = new AppGroupsSqlService(context, sortOrderSqlService);
                var tagsSqlService = new TagsSqlService(context, sortOrderSqlService);
                var identifiersSqlService = new IdentifiersSqlService(context, sortOrderSqlService);

                var passwordHasher = new PasswordHasher<AppSqlModel>();
                var appsService = new AppsSqlService(
                    openSettingsConfiguration.LoggerFactory.CreateLogger<AppsSqlService>(), identifiersSqlService,
                    appGroupsSqlService, tagsSqlService, compressionFactory, passwordHasher, context,
                    openSettingsConfiguration, null);
                var settingsService = new SettingsSqlService(dataChangeService: null, identifiersSqlService, compressionFactory, context, new DataValidationService(), openSettingsConfiguration);

                var localSettingsService = new LocalSettingsService(openSettingsConfiguration, appsService, settingsService);

                await func(localSettingsService);

                await context.DisposeAsync();
            }
        }
    }
}