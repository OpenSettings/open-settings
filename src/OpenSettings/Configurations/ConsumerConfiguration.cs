using Ogu.Compressions.Abstractions;
using OpenSettings.Extensions;
using OpenSettings.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace OpenSettings.Configurations
{
    /// <summary>
    /// Represents the configuration settings for the consumer service.
    /// </summary>
    public class ConsumerConfiguration
    {
        private string _providerUrl;

        /// <summary>
        /// Gets or sets the Url of the provider for fetching and syncing data.
        /// This Url is required by the consumer to connect to the provider and retrieve data.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> representing the Url of the settings provider service. 
        /// Any trailing slashes will be trimmed automatically when setting the value.
        /// </value>
        /// <remarks>This Url should point to the endpoint for the api. e.g. 'https://.../api/settings'</remarks>
        public string ProviderUrl
        {
            get => _providerUrl;
            set => _providerUrl = value.EndsWith("/") ? value : $"{value}/";
        }

        /// <summary>
        /// Gets the set of encodings requested from the provider service. 
        /// These encodings are specified in the HTTP header for <c>Accept-Encoding</c>.
        /// However, the final decision on which encoding to use is made by the provider.
        /// </summary>
        /// <value>
        /// A <see cref="HashSet{CompressionType}"/> representing the encodings that the consumer requests 
        /// from the provider service. This collection is initialized with a default size (6)
        /// </value>
        public HashSet<CompressionType> RequestEncodings { get; internal set; } = new
#if !NETSTANDARD2_0
            HashSet<CompressionType>(6);
#else
            HashSet<CompressionType>();
#endif

        /// <summary>
        /// Gets or sets a flag indicating whether Redis is active for the consumer configuration.
        /// </summary>
        /// <value>
        /// A <see cref="bool"/> indicating whether Redis is active. The default value is <c>false</c>.
        /// </value>
        /// <remarks>
        /// Redis connection details and status are sent by the provider. The truthfulness of this value depends on the provider.
        /// </remarks>
        public bool IsRedisActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the initial sync of app data should be skipped.
        /// </summary>
        /// <remarks>
        /// When set to <c>true</c>, the initial sync of data will not occur. 
        /// If set to <c>false</c>, the sync will take place as part of the application's initial setup.
        /// This property can be used to control whether the app should skip syncing data during the initial run.
        /// </remarks>
        /// <value>
        /// <c>true</c> to skip the initial sync; otherwise, <c>false</c>.
        /// </value>
        public bool SkipInitialSyncAppData { get; set; }

        /// <summary>
        /// Gets or sets the configuration for the polling settings worker.
        /// </summary>
        /// <value>
        /// A <see cref="PollingSettingsWorkerConfiguration"/> object that defines the polling settings for the worker.
        /// </value>
        public PollingSettingsWorkerConfiguration PollingSettingsWorker { get; set; } = new PollingSettingsWorkerConfiguration();

        /// <summary>
        /// Configures the provided <paramref name="httpClient"/> with the settings for the consumer.
        /// This method sets the base address, authorization headers, and encodings for the HTTP client.
        /// </summary>
        /// <param name="httpClient">
        /// The <see cref="HttpClient"/> to configure with the consumer's settings.
        /// </param>
        /// <param name="clientInfo">
        /// The <see cref="ClientInfo"/> object containing the information for creating authentication headers.
        /// </param>
        public void ConfigureHttpClient(HttpClient httpClient, ClientInfo clientInfo)
        {
            httpClient.BaseAddress = new Uri(ProviderUrl);

            httpClient.DefaultRequestHeaders.Authorization = clientInfo.CreateBasicAuthenticationHeaderValue();

            httpClient.DefaultRequestHeaders.TryAddWithoutValidation(Constants.PackVersionName, OpenSettingsAssemblyInfo.Instance.Version);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation(Constants.PackVersionScoreName, $"{OpenSettingsAssemblyInfo.Instance.VersionScore}");

            RequestEncodings.AddToRequestHeaders(httpClient.DefaultRequestHeaders);
        }

        [JsonIgnore]
        internal static bool IsGeneratorModeEnabled
        {
            get
            {
                var openSettingsGeneratorMode = Environment.GetEnvironmentVariable("OPENSETTINGS_GENERATOR_MODE");

                return string.Equals(openSettingsGeneratorMode, "1", StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(openSettingsGeneratorMode, "TRUE", StringComparison.OrdinalIgnoreCase);
            }
        } 
    }
}