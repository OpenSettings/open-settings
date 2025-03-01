using Ogu.Response.Json;
using OpenSettings.Extensions;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Rest.Interfaces;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public class ConfigurationsRestService : IConfigurationsRestService
    {
        private readonly HttpClient _httpClient;

        public ConfigurationsRestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IJsonResponse> GetConfigurationByAppIdAndIdentifierIdAsync(GetConfigurationByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}/configuration";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> PatchConfigurationAsync(PatchConfigurationInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppId}/identifiers/{input.IdentifierId}/configuration";

            using (var stringContent = new StringContent(JsonSerializer.Serialize(input.Body), Encoding.UTF8, Constants.ApplicationJson))
            {
#if NETSTANDARD2_0
                using (var response = await _httpClient.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), relativeUri) { Content = stringContent }, cancellationToken))
#else
                using (var response = await _httpClient.PatchAsync(relativeUri, stringContent, cancellationToken))
#endif
                {
                    return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }
    }
}