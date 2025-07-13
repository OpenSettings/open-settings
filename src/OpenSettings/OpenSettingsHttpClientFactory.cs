using Ogu.Compressions;
using Ogu.Compressions.Abstractions;
using OpenSettings.Configurations;
using System;
using System.Net.Http;

namespace OpenSettings
{
    internal class OpenSettingsHttpClientFactory : IHttpClientFactory, IDisposable
    {
        private HttpClient _httpClient;
        private DecompressionHandler _decompressionHandler;
        private HttpClientHandler _httpClientHandler;

        private readonly OpenSettingsConfiguration _openSettingsConfiguration;

        public OpenSettingsHttpClientFactory(OpenSettingsConfiguration openSettingsConfiguration)
        {
            _openSettingsConfiguration = openSettingsConfiguration;
        }

        public HttpClient CreateClient(string name)
        {
            if (name != OpenSettingsDefaults.Names.HttpClientName)
            {
                throw new NotImplementedException();
            }

            if (_httpClient != null)
            {
                return _httpClient;
            }

            var compressionProvider = new CompressionProvider(new ICompression[]
            {
                new BrotliCompression(new BrotliCompressionOptions(_openSettingsConfiguration.Provider.CompressionLevel)),
                new DeflateCompression(new DeflateCompressionOptions(_openSettingsConfiguration.Provider.CompressionLevel)),
                new GzipCompression(new GzipCompressionOptions(_openSettingsConfiguration.Provider.CompressionLevel)),
                new SnappyCompression(new SnappyCompressionOptions(_openSettingsConfiguration.Provider.CompressionLevel)),
                new ZstdCompression(new ZstdCompressionOptions(_openSettingsConfiguration.Provider.CompressionLevel)),
                new NoneCompression(new NoneCompressionOptions(_openSettingsConfiguration.Provider.CompressionLevel))
            });

            _httpClientHandler = new HttpClientHandler();

            _decompressionHandler = new DecompressionHandler(compressionProvider)
            {
                InnerHandler = _httpClientHandler
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