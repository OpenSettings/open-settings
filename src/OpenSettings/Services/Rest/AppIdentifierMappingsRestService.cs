using Ogu.Response.Json;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public class AppIdentifierMappingsRestService : IAppIdentifierMappingsRestService
    {
        private readonly HttpClient _httpClient;

        public AppIdentifierMappingsRestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IJsonResponse> GetAppIdentifierMappingsByAppIdAsync(GetAppIdentifierMappingsInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppIdOrSlug}/identifiers";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetAppIdentifierMappingsByAppSlugAsync(GetAppIdentifierMappingsInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}/identifiers";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> CreateAppIdentifierMappingAsync(CreateAppIdentifierMappingInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppId}/identifiers";

            var body = new
            {
                input.SetSortOrderPosition,
                Identifier = new
                {
                    input.Identifier.Id,
                    input.Identifier.Name
                }
            };

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IJsonResponse> GetAppIdentifierMappingByAppIdAndIdentifierIdAsync(GetAppIdentifierMappingByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetAppIdentifierMappingByAppSlugAndIdentifierSlugAsync(GetAppIdentifierMappingByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> DeleteAppIdentifierMappingAsync(DeleteAppIdentifierMappingInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppId}/identifiers/{input.IdentifierId}?rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            using (var response = await _httpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> UpdateAppIdentifierMappingSortOrderAsync(UpdateAppIdentifierMappingSortOrderInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppId}/identifiers/{input.IdentifierId}/sort-order";

            var body = new
            {
                input.Ascent,
                input.RowVersion,
            };

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }
    }
}