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
    public sealed class InstancesRestService : IInstancesRestService
    {
        private readonly HttpClient _httpClient;

        public InstancesRestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IJsonResponse> UpdateInstanceAsync(UpdateInstanceInput input, CancellationToken cancellationToken)
        {
            var relativeUri = $"v1/apps/{input.ClientId}/instances";

            var body = new
            {
                input.InstanceName,
                input.IdentifierName,
                input.Urls,
                input.IsActive
            };

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PutAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IJsonResponse> DeleteInstanceAsync(DeleteInstanceInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/instances/{input.InstanceId}";

            using (var response = await _httpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetInstancesByAppIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppIdOrSlug}/instances";

            var queryBuilder = new QueryBuilder();

            if (!string.IsNullOrWhiteSpace(input.IdentifierIdOrSlug))
            {
                queryBuilder.Append("IdentifierId", input.IdentifierIdOrSlug);
            }

            using (var response = await _httpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetInstancesByAppSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}/instances";

            var queryBuilder = new QueryBuilder();

            if (!string.IsNullOrWhiteSpace(input.IdentifierIdOrSlug))
            {
                queryBuilder.Append("IdentifierId", input.IdentifierIdOrSlug);
            }

            using (var response = await _httpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetInstancesByAppIdAndIdentifierIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}/instances";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetInstancesByAppSlugAndIdentifierSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}/instances";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }
    }
}