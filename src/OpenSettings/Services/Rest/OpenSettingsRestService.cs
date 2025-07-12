using OpenSettings.Extensions;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public class OpenSettingsRestService : IOpenSettingsRestService
    {
        private HttpClient HttpClient => _httpClientFactory.CreateOpenSettingsHttpClient();

        private readonly IHttpClientFactory _httpClientFactory;

        public OpenSettingsRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<GetConfigsResponse> GetConfigsAsync(CancellationToken cancellationToken = default)
        {
            const string relativeUri = "v1/open-settings/configs";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var cacheControl = response.Headers.CacheControl ?? new CacheControlHeaderValue();

                var expires = response.Headers.TryGetValues("Expires", out var expiresValues)
                    ? expiresValues.FirstOrDefault()
                    : DateTimeOffset.UtcNow.Add(cacheControl.MaxAge.GetValueOrDefault(TimeSpan.Zero)).ToString("R");

                var data = await response.Content.ReadAsByteArrayAsync(
#if NET5_0_OR_GREATER
                    cancellationToken
#endif
                );

                return new GetConfigsResponse
                {
                    CacheControl = $"{cacheControl}",
                    Expires = expires,
                    Data = data
                };
            }
        }

        public async Task<GetConfigsDataResponse> GetConfigsDataAsync(string configName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(configName))
            {
                throw new ArgumentNullException(nameof(configName));
            }

            var relativeUri = $"v1/open-settings/configs-data/{configName}";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var cacheControl = response.Headers.CacheControl ?? new CacheControlHeaderValue();

                var expires = response.Headers.TryGetValues("Expires", out var expiresValues)
                    ? expiresValues.FirstOrDefault()
                    : DateTimeOffset.UtcNow.Add(cacheControl.MaxAge.GetValueOrDefault(TimeSpan.Zero)).ToString("R");

                var data = await response.Content.ReadAsByteArrayAsync(
#if NET5_0_OR_GREATER
                    cancellationToken
#endif
                );

                return new GetConfigsDataResponse
                {
                    CacheControl = $"{cacheControl}",
                    Expires = expires,
                    Data = data
                };
            }
        }

        public Task<GetOpenSettingsNotificationsResponse> GetNotificationsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}