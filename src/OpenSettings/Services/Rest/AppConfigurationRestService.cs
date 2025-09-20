using Ogu.Response.Abstractions;
using OpenSettings.Extensions;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Rest.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public class AppConfigurationRestService : IAppConfigurationRestService
    {
        private HttpClient HttpClient => _httpClientFactory.CreateOpenSettingsProviderHttpClient();

        private readonly IHttpClientFactory _httpClientFactory;

        public AppConfigurationRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse> GetAppConfigurationByAppIdAndIdentifierIdAsync(GetConfigurationByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}/configuration";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> PatchAppConfigurationAsync(PatchConfigurationInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppId}/identifiers/{input.IdentifierId}/configuration";

            using (var jsonContent = JsonContent.Create(input.Body))
            {
#if NETSTANDARD2_0
                using (var response = await HttpClient.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), relativeUri) { Content = jsonContent }, cancellationToken))
#else
                using (var response = await HttpClient.PatchAsync(relativeUri, jsonContent, cancellationToken))
#endif
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }
    }
}