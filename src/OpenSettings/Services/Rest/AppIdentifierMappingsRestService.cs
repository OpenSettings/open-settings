using Ogu.Response.Abstractions;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public class AppIdentifierMappingsRestService : IAppIdentifierMappingRestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AppIdentifierMappingsRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse> GetAppIdentifierMappingsByAppIdAsync(GetAppIdentifierMappingsInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppIdentifierMappingsByAppId,
                new[] { input.AppIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppIdentifierMappingsByAppSlugAsync(GetAppIdentifierMappingsInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppIdentifierMappingsByAppSlug,
                new[] { input.AppIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> CreateAppIdentifierMappingAsync(CreateAppIdentifierMappingInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.CreateAppIdentifierMapping,
                new[] { $"{input.AppId}" });

            var body = new
            {
                input.SetSortOrderPosition,
                Identifier = new
                {
                    input.Identifier.Id,
                    input.Identifier.Name
                }
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> GetAppIdentifierMappingByAppIdAndIdentifierIdAsync(GetAppIdentifierMappingByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppIdentifierMappingByAppIdAndIdentifierId,
                new[] { input.AppIdOrSlug, input.IdentifierIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppIdentifierMappingByAppSlugAndIdentifierSlugAsync(GetAppIdentifierMappingByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppIdentifierMappingByAppSlugAndIdentifierSlug,
                new[] { input.AppIdOrSlug, input.IdentifierIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DeleteAppIdentifierMappingAsync(DeleteAppIdentifierMappingInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.DeleteAppIdentifierMapping,
                new[] { $"{input.AppId}", $"{input.IdentifierId}" },
                (nameof(input.RowVersion), Convert.ToBase64String(input.RowVersion)));

            using (var response = await GetProviderHttpClient().DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateAppIdentifierMappingSortOrderAsync(UpdateAppIdentifierMappingSortOrderInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.UpdateAppIdentifierMappingSortOrder,
                new[] { $"{input.AppId}", $"{input.IdentifierId}" });

            var body = new
            {
                input.Ascent,
                input.RowVersion,
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        private HttpClient GetProviderHttpClient()
        {
            return _httpClientFactory.CreateOpenSettingsProviderHttpClient();
        }
    }
}