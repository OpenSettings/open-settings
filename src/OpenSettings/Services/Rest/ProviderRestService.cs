using Ogu.Response.Json;
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
        private readonly HttpClient _httpClient;

        public ProviderRestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IJsonResponse<ProviderInfo>> GetProviderAsync(CancellationToken cancellationToken = default)
        {
            const string relativeUri = "v1/provider";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync<ProviderInfo>(cancellationToken: cancellationToken);
            }
        }
    }
}