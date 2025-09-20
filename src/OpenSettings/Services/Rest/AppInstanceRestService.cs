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
    public sealed class AppInstanceRestService : IInstanceRestService
    {
        private HttpClient HttpClient => _httpClientFactory.CreateOpenSettingsProviderHttpClient();

        private readonly IHttpClientFactory _httpClientFactory;

        public AppInstanceRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse> CreateAppInstanceAsync(CreateInstanceInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.ClientId}/instances";

            var body = new
            {
                input.ClientId,
                input.ClientSecret,
                input.InstanceName,
                input.IdentifierName,
                input.DynamicId,
                input.Urls,
                input.Version,
                input.IsActive,
                input.MachineName,
                input.Environment,
                input.ReloadStrategies,
                input.ServiceType,
                input.DataAccessType
            };
            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await HttpClient.PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> UpdateAppInstanceAsync(UpdateInstanceInput input, CancellationToken cancellationToken)
        {
            var relativeUri = $"v1/apps/{input.ClientId}/instances";

            var body = new
            {
                input.ClientId,
                input.ClientSecret,
                input.InstanceName,
                input.IdentifierName,
                input.Urls,
                input.IsActive
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await HttpClient.PutAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> DeleteAppInstanceAsync(DeleteAppInstanceInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/instances/{input.AppInstanceId}";

            using (var response = await HttpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppInstancesByAppIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppIdOrSlug}/instances";

            var queryBuilder = new QueryBuilder();

            if (!string.IsNullOrWhiteSpace(input.IdentifierIdOrSlug))
            {
                queryBuilder.Append("IdentifierId", input.IdentifierIdOrSlug);
            }

            using (var response = await HttpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppInstancesByAppSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}/instances";

            var queryBuilder = new QueryBuilder();

            if (!string.IsNullOrWhiteSpace(input.IdentifierIdOrSlug))
            {
                queryBuilder.Append("IdentifierId", input.IdentifierIdOrSlug);
            }

            using (var response = await HttpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppInstancesByAppIdAndIdentifierIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}/instances";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppInstancesByAppSlugAndIdentifierSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}/instances";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }
    }
}