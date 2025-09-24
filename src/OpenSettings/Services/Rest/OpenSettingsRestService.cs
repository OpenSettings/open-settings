using OpenSettings.Extensions;
using OpenSettings.Helpers;
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
        private readonly IHttpClientFactory _httpClientFactory;

        public OpenSettingsRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<GetConfigsResponse> GetConfigsAsync(CancellationToken cancellationToken = default)
        {
            const string relativeUri = OpenSettingsDefaults.Routes.V1.OpenSettingsEndpoints.GetConfigs;

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var cacheControl = response.Headers.CacheControl ?? new CacheControlHeaderValue();

                var expires = response.Headers.TryGetValues(OpenSettingsDefaults.Headers.Expires, out var expiresValues)
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

        public async Task<GetConfigsDataResponse> GetConfigDataAsync(string configName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(configName))
            {
                throw new ArgumentNullException(nameof(configName));
            }

            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.OpenSettingsEndpoints.GetConfigData,
                new[] { configName });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var cacheControl = response.Headers.CacheControl ?? new CacheControlHeaderValue();

                DateTimeOffset? utcNow = null;

                var expires = response.Headers.TryGetValues(OpenSettingsDefaults.Headers.Expires, out var expiresValues)
                    ? expiresValues.FirstOrDefault()
                    : (utcNow = DateTimeOffset.UtcNow).Value.Add(cacheControl.MaxAge.GetValueOrDefault(TimeSpan.Zero)).ToString("R");

                var age = 0;

                if (response.Headers.TryGetValues(OpenSettingsDefaults.Headers.Age, out var ageValues) && int.TryParse(ageValues.FirstOrDefault(), out var parsedAge))
                {
                    age = parsedAge;
                }
                else if (response.Headers.Date.HasValue)
                {
                    var responseDate = response.Headers.Date.Value;

                    age = (int)Math.Max(0, ((utcNow = utcNow ?? DateTimeOffset.UtcNow).Value - responseDate).TotalSeconds);
                }

                var data = await response.Content.ReadAsByteArrayAsync(
#if NET5_0_OR_GREATER
                    cancellationToken
#endif
                );

                return new GetConfigsDataResponse
                {
                    CacheControl = $"{cacheControl}",
                    Expires = expires,
                    Age = age,
                    Data = data
                };
            }
        }

        public Task<GetOpenSettingsNotificationsResponse> GetNotificationsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        private HttpClient GetProviderHttpClient()
        {
            return _httpClientFactory.CreateOpenSettingsProviderHttpClient();
        }
    }
}