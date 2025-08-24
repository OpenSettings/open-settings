using Ogu.Compressions.Abstractions;
using OpenSettings.Configurations;
using OpenSettings.Services;
using OpenSettings.Services.Rest;
using System;
using System.Net.Http;

namespace OpenSettings
{
    /// <summary>
    /// Factory for creating <see cref="HttpClient"/> instances configured for OpenSettings provider communication.
    /// </summary>
    internal class OpenSettingsHttpClientFactory : IHttpClientFactory, IDisposable
    {
        private HttpClient _httpClient;
        private DecompressionHandler _decompressionHandler;
        private ConsumerToProviderRequestHandler _consumerToProviderRequestHandler;
        private HttpClientHandler _httpClientHandler;

        private readonly OpenSettingsConfiguration _openSettingsConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenSettingsHttpClientFactory"/> class with the specified configuration.
        /// </summary>
        /// <param name="openSettingsConfiguration">The open settings configuration.</param>
        public OpenSettingsHttpClientFactory(OpenSettingsConfiguration openSettingsConfiguration)
        {
            _openSettingsConfiguration = openSettingsConfiguration;
        }

        public HttpClient CreateClient(string name)
        {
            if (name != OpenSettingsDefaults.Names.ProviderHttpClientName)
            {
                throw new NotImplementedException();
            }

            if (_httpClient != null)
            {
                return _httpClient;
            }

            var compressionProvider = _openSettingsConfiguration.Provider.CreateCompressionProvider();

            _httpClientHandler = new HttpClientHandler();

            _consumerToProviderRequestHandler = new ConsumerToProviderRequestHandler(OpenSettingsDefaults.Caches.GetOpenSettingsMemoryCache(_openSettingsConfiguration.LoggerFactory), new TokenRestService(this), _openSettingsConfiguration)
            {
                InnerHandler = _httpClientHandler
            };

            _decompressionHandler = new DecompressionHandler(compressionProvider)
            {
                InnerHandler = _consumerToProviderRequestHandler
            };

            _httpClient = new HttpClient(_decompressionHandler);

            _openSettingsConfiguration.Consumer.ConfigureHttpClient(_httpClient, _openSettingsConfiguration.Client);

            return _httpClient;
        }

        public void Dispose()
        {
            _httpClientHandler?.Dispose();
            _decompressionHandler?.Dispose();
            _httpClient?.Dispose();
        }
    }
}