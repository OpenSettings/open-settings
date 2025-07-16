using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Models;
using OpenSettings.Services.Rest;
using OpenSettings.Services.Sql;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings
{
    /// <summary>
    /// Provides functionality to initialize and manage the current license for the application.
    /// </summary>
    public class LicenseProvider
    {
        /// <summary>
        /// Singleton instance of the <see cref="LicenseProvider"/> class.
        /// </summary>
        public static readonly LicenseProvider Instance = new LicenseProvider();

        /// <summary>
        /// Initializes a new instance of the <see cref="LicenseProvider"/> class.
        /// </summary>
        private LicenseProvider() { }

        /// <summary>
        /// Gets the currently active license, which is assigned internally during a call to 
        /// <see cref="Extensions.HostBuilderExtensions.UseOpenSettingsAsync(IHostBuilder, OpenSettingsConfiguration, Type[])"/> or
        /// <see cref="Extensions.HostBuilderExtensions.UseOpenSettingsAsync(IHostBuilder, OpenSettingsConfiguration, Func{IConfiguration, Task}, Type[])"/>.
        /// </summary>
        public License CurrentLicense { get; internal set; }

        /// <summary>
        /// Initializes the license provider if it has not already been initialized. 
        /// Retrieves the current license from either the provider's database or rest api call, 
        /// based on the configuration settings.
        /// </summary>
        /// <param name="openSettingsConfiguration">The configuration settings for OpenSettings.</param>
        /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        internal Task InitializeAsync(OpenSettingsConfiguration openSettingsConfiguration, CancellationToken cancellationToken)
        {
            if (CurrentLicense != null)
            {
                return Task.CompletedTask;
            }

            var logger = openSettingsConfiguration.LoggerFactory.CreateLogger(nameof(LicenseProvider));

            return openSettingsConfiguration.IsConsumerSelected
                ? InitializeConsumerLicenseAsync(logger, openSettingsConfiguration, cancellationToken)
                : InitializeProviderLicenseAsync(logger, openSettingsConfiguration, cancellationToken);
        }

        private async Task InitializeConsumerLicenseAsync(ILogger logger, OpenSettingsConfiguration openSettingsConfiguration, CancellationToken cancellationToken)
        {
            using (var openSettingsHttpClientFactory = new OpenSettingsHttpClientFactory(openSettingsConfiguration))
            {
                var licensesRestService = new LicenseRestService(openSettingsHttpClientFactory);

                try
                {
                    var response = await licensesRestService.GetCurrentLicenseAsync(cancellationToken);

                    if (response.Success)
                    {
                        CurrentLicense = response.Data;
                    }
                    else
                    {
                        CurrentLicense = License.Community;
                        CurrentLicense.FailureReasons.Add(LicenseFailureReason.RestFailure);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An exception occurred while license initialization for consumer. ProviderUrl: '{providerUrl}'. The fallback license edition is '{license}'.", openSettingsConfiguration.Consumer.ProviderUrl, nameof(License.Community));

                    CurrentLicense = License.Community;
                    CurrentLicense.FailureReasons.Add(LicenseFailureReason.RestException);
                }
            }
        }

        private async Task InitializeProviderLicenseAsync(ILogger logger, OpenSettingsConfiguration openSettingsConfiguration, CancellationToken cancellationToken)
        {
            try
            {
                using (var context = OpenSettingsDbContext.GetInstance(openSettingsConfiguration.Provider))
                {
                    await openSettingsConfiguration.Provider.InitializeDbAsync(context, cancellationToken);

                    var licensesSqlService = new LicenseSqlService(new JsonWebTokenHandler(), openSettingsConfiguration, context, null);

                    var response = await licensesSqlService.GetCurrentLicenseAsync(cancellationToken);

                    CurrentLicense = response.Data;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An exception occurred while license initialization for provider. The fallback license edition is '{license}'.", nameof(License.Community));

                CurrentLicense = License.Community;
                CurrentLicense.FailureReasons.Add(LicenseFailureReason.SqlException);
            }
        }
    }
}