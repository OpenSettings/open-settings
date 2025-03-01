using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Ogu.Compressions;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Models;
using OpenSettings.Services.Rest;
using OpenSettings.Services.Sql;
using System;
using System.Net.Http;
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
        /// Gets or internally sets the currently active license.
        /// </summary>
        public License CurrentLicense { get; internal set; }

        /// <summary>
        /// Initializes the license provider unless it is already initialized by retrieving the current license // Todo check summary
        /// either from the provider's database or the consumer's API, depending on the configuration.
        /// </summary>
        /// <param name="openSettingsConfiguration">The configuration settings for OpenSettings.</param>
        /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        internal async Task InitializeAsync(OpenSettingsConfiguration openSettingsConfiguration, CancellationToken cancellationToken)
        {
            if (CurrentLicense != null)
            {
                return;
            }

            var logger = openSettingsConfiguration.LoggerFactory.CreateLogger(nameof(LicenseProvider));

            if (openSettingsConfiguration.IsConsumerSelected)
            {
                var compressionFactory = new CompressionFactory();

                var handler = new DecompressionHandler(compressionFactory)
                {
                    InnerHandler = new HttpClientHandler()
                };

                using (var httpClient = new HttpClient(handler))
                {
                    openSettingsConfiguration.Consumer.ConfigureHttpClient(httpClient, openSettingsConfiguration.Client);

                    var licensesRestService = new LicensesRestService(httpClient);

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
                        logger.LogError(ex, "Exception occurred while retrieving current license from provider '{providerUrl}'. The fallback license edition is Community.", openSettingsConfiguration.Consumer.ProviderUrl);

                        CurrentLicense = License.Community;
                        CurrentLicense.FailureReasons.Add(LicenseFailureReason.RestException);
                    }
                }

                return;
            }

            try
            {
                using (var context = OpenSettingsDbContext.GetInstance(openSettingsConfiguration.Provider))
                {
                    await openSettingsConfiguration.Provider.InitializeDbAsync(context, cancellationToken);

                    var licensesSqlService = new LicensesSqlService(new JsonWebTokenHandler(), openSettingsConfiguration, context, null);

                    var response = await licensesSqlService.GetCurrentLicenseAsync(cancellationToken);

                    CurrentLicense = (License)response.Data;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception occurred while license initialization. The fallback license edition is Community.");

                CurrentLicense = License.Community;
                CurrentLicense.FailureReasons.Add(LicenseFailureReason.SqlException);
            }
        }
    }
}