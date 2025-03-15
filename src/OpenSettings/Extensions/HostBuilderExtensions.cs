using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OpenSettings.Configurations;
using OpenSettings.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Extensions
{
    /// <summary>
    /// Provides extension methods for configuring an <see cref="IHostBuilder"/>.
    /// </summary>
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// Configures the host builder to use OpenSettings with the specified configuration and application settings types.
        /// If <paramref name="settingsTypes"/> are provided, only these types (which must implement <see cref="Services.Interfaces.ISettings"/>) will be used.
        /// Otherwise, available types implementing <see cref="Services.Interfaces.ISettings"/> will be automatically discovered via reflection.
        /// </summary>
        /// <param name="hostBuilder">The host builder instance to configure.</param>
        /// <param name="openSettingsConfiguration">The OpenSettings configuration to be applied.</param>
        /// <param name="settingsTypes">
        /// An array of types representing the settings. Each type must implement <see cref="Services.Interfaces.ISettings"/>.
        /// If not provided, types will be discovered automatically.
        /// </param>
        /// <returns>A task that resolves to the configured <see cref="IHostBuilder"/>.</returns>
        public static Task<IHostBuilder> UseOpenSettingsAsync(
            this IHostBuilder hostBuilder, 
            OpenSettingsConfiguration openSettingsConfiguration, 
            params Type[] settingsTypes)
        {
            return InternalUseOpenSettingsAsync(hostBuilder, openSettingsConfiguration, null, settingsTypes);
        }

        /// <summary>
        /// Configures the host builder to use OpenSettings with the specified configuration, an additional configuration function, 
        /// and application settings types. 
        /// If <paramref name="settingsTypes"/> are provided, only these types (which must implement <see cref="Services.Interfaces.ISettings"/>) will be used.
        /// Otherwise, available types implementing <see cref="Services.Interfaces.ISettings"/> will be automatically discovered via reflection.
        /// </summary>
        /// <param name="hostBuilder">The host builder instance to configure.</param>
        /// <param name="openSettingsConfiguration">The OpenSettings configuration to be applied.</param>
        /// <param name="configureFunc">
        /// An optional asynchronous function to apply additional configuration using <see cref="IConfiguration"/>.
        /// </param>
        /// <param name="settingsTypes">
        /// An array of types representing the settings. Each type must implement <see cref="Services.Interfaces.ISettings"/>.
        /// If not provided, types will be discovered automatically.
        /// </param>
        /// <returns>A task that resolves to the configured <see cref="IHostBuilder"/>.</returns>
        public static Task<IHostBuilder> UseOpenSettingsAsync(
            this IHostBuilder hostBuilder,
            OpenSettingsConfiguration openSettingsConfiguration,
            Func<IConfiguration, Task> configureFunc,
            params Type[] settingsTypes)
        {
            return InternalUseOpenSettingsAsync(hostBuilder, openSettingsConfiguration, configureFunc, settingsTypes);
        }

        private static async Task<IHostBuilder> InternalUseOpenSettingsAsync(
            IHostBuilder hostBuilder,
            OpenSettingsConfiguration openSettingsConfiguration,
            Func<IConfiguration, Task> configureFunc,
            params Type[] settingsTypes)
        {
            openSettingsConfiguration.Client = openSettingsConfiguration.Client ?? new ClientInfo();

            await LicenseProvider.Instance.InitializeAsync(openSettingsConfiguration, CancellationToken.None);

            var configurationBuilder = await new ConfigurationBuilder().BuildSettingsAsync(openSettingsConfiguration, settingsTypes: settingsTypes);

            var configuration = configurationBuilder.Build();

            hostBuilder.ConfigureAppConfiguration((_, builder) => builder.AddConfiguration(configuration));

            hostBuilder.ConfigureServices((context, collection) =>
            {
                var providerInfo = context.Configuration.GetSection(nameof(ProviderInfo)).Get<ProviderInfo>();

                collection.ConfigureOpenSettings(context.Configuration);
                collection.AddOpenSettings(openSettingsConfiguration, providerInfo);
            });

            if (configureFunc != null)
            {
                await configureFunc(configuration);
            }

            return hostBuilder;
        }
    }
}