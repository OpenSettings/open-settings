using Ogu.Response.Abstractions;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public sealed class AppTagRestService : IAppTagRestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AppTagRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse> GetAppTagsAsync(GetAppTagsInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.GetAppTags, null,
                (nameof(input.SearchTerm), input.SearchTerm), (nameof(input.HasMappings), input.HasMappings));

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> CreateAppTagAsync(CreateAppTagInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(CreateAppTagAsync));

            const string relativeUri = OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.CreateAppTag;

            var body = new
            {
                input.Name,
                input.SortOrder,
                input.SetSortOrderPosition
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> GetPaginatedAppTagsAsync(GetPaginatedInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetPaginatedAppTagsAsync));

            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.GetPaginatedAppTags,
                null,
                ("page", input.PageSize), 
                ("size", input.PageSize), 
                (nameof(input.SearchTerm), input.SearchTerm),
                (nameof(input.SearchBy), input.SearchBy), (nameof(input.SortBy), input.SortBy),
                (nameof(input.SortDirection), input.SortDirection));

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DeleteUnmappedAppTagsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteUnmappedAppTagsAsync));

            const string relativeUri = OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.DeleteUnmappedAppTags;

            using (var response = await GetProviderHttpClient().DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppTagByIdAsync(GetAppTagInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.GetAppTagById,
                new[] { input.AppTagIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppTagBySlugAsync(GetAppTagInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.GetAppTagBySlug,
                new[] { input.AppTagIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateAppTagAsync(UpdateAppTagInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.UpdateAppTag,
                new[] { $"{input.AppTagId}" });

            var body = new
            {
                input.Name,
                input.SortOrder,
                input.SetSortOrderPosition,
                input.RowVersion
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PutAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> DeleteAppTagAsync(DeleteAppTagInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteAppTagAsync));

            var relativeUri = $"v1/tags/{input.AppTagId}?rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            using (var response = await GetProviderHttpClient().DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateAppTagSortOrderAsync(UpdateAppTagSortOrderInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.UpdateAppTagSortOrder,
                new[] { $"{input.AppTagId}" });

            var body = new
            {
                Direction = input.Direction,
                RowVersion = input.RowVersion
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> DragAppTagAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DragAppTagAsync));

            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.DragAppTag,
                new[] { $"{input.SourceId}", $"{input.TargetId}" });

            var body = new
            {
                Direction = input.Direction,
                SourceRowVersion = input.SourceRowVersion
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public Task<IResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetOrCreateAsync));
        }

        public async Task<IResponse> ReorderAppTagAsync(Guid? updatedById)
        {
            const string relativeUri = OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.ReorderAppTag;

            using (var response = await GetProviderHttpClient().PostAsync(relativeUri, null))
            {
                return await response.Content.ToResponseAsync();
            }
        }

        private HttpClient GetProviderHttpClient()
        {
            return _httpClientFactory.CreateOpenSettingsProviderHttpClient();
        }
    }
}