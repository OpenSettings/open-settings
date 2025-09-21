using Ogu.Response.Abstractions;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
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
        private readonly IHttpClientFactory _httpClientFactory;

        public AppInstanceRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse> CreateAppInstanceAsync(CreateInstanceInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.CreateAppInstance,
                new[] { $"{input.ClientId}" });

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
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> UpdateAppInstanceAsync(UpdateInstanceInput input, CancellationToken cancellationToken)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.UpdateAppInstance,
                new[] { $"{input.ClientId}" });

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
                using (var response = await GetProviderHttpClient().PutAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> DeleteAppInstanceAsync(DeleteAppInstanceInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppInstancesEndpoints.DeleteAppInstance,
                new[] { $"{input.AppInstanceId}" });

            using (var response = await GetProviderHttpClient().DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppInstancesByAppIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppInstancesByAppId,
                new[] { input.AppIdOrSlug },
                RouteHelper.Query(("IdentifierId", input.IdentifierIdOrSlug)));

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppInstancesByAppSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppInstancesByAppSlug,
                new[] { input.AppIdOrSlug },
                RouteHelper.Query(("IdentifierId", input.IdentifierIdOrSlug)));

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppInstancesByAppIdAndIdentifierIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppInstancesByAppIdAndIdentifierId,
                new[] { input.AppIdOrSlug, input.IdentifierIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppInstancesByAppSlugAndIdentifierSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppInstancesByAppSlugAndIdentifierSlug,
                new[] { input.AppIdOrSlug, input.IdentifierIdOrSlug });

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