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
        private HttpClient HttpClient => _httpClientFactory.CreateOpenSettingsHttpClient();

        private readonly IHttpClientFactory _httpClientFactory;

        public ProviderRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse<ProviderInfo>> GetProviderAsync(CancellationToken cancellationToken = default)
        {
            const string relativeUri = "v1/provider";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync<ProviderInfo>(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetPrimaryProviderAsync(CancellationToken cancellationToken = default)
        {
            const string relativeUri = "v1/provider/primary";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }
    }
}