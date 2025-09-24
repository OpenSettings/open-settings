using Ogu.Response.Abstractions;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Services.Rest.Interfaces;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public sealed class ProviderRestService : IProviderRestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProviderRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse<ProviderInfo>> GetProviderAsync(CancellationToken cancellationToken = default)
        {
            const string relativeUri = OpenSettingsDefaults.Routes.V1.ProviderEndpoints.GetProvider;

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync<ProviderInfo>(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetPrimaryProviderAsync(CancellationToken cancellationToken = default)
        {
            const string relativeUri = OpenSettingsDefaults.Routes.V1.ProviderEndpoints.GetPrimaryProvider;

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        private HttpClient GetProviderHttpClient()
        {
            return _httpClientFactory.CreateOpenSettingsProviderHttpClient();
        }
    }
}