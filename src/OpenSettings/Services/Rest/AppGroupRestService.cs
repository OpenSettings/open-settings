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
    public sealed class AppGroupRestService : IAppGroupRestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AppGroupRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse> GetPaginatedAppGroupsAsync(GetPaginatedInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetPaginatedAppGroupsAsync));

            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.GetPaginatedAppGroups,
                null,
                ("page", input.PageIndex),
                ("size", input.PageSize),
                (nameof(input.SearchTerm), input.SearchTerm),
                (nameof(input.SearchBy), input.SearchBy),
                (nameof(input.SortBy), input.SortBy),
                (nameof(input.SortDirection), input.SortDirection)); 

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DeleteUnmappedAppGroupsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteUnmappedAppGroupsAsync));

            const string relativeUri = OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.DeleteUnmappedAppGroups;

            using (var response = await GetProviderHttpClient().DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppGroupsAsync(GetGroupsInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.GetAppGroups,
                null,
                (nameof(input.SearchTerm), input.SearchTerm),
                (nameof(input.HasMappings), input.HasMappings));

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> CreateAppGroupAsync(CreateGroupInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(CreateAppGroupAsync));

            const string relativeUri = OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.CreateAppGroup;

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

        public async Task<IResponse> GetAppGroupByIdAsync(GetGroupInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.GetAppGroupById,
                new[] { input.GroupIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppGroupBySlugAsync(GetGroupInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.GetAppGroupBySlug,
                new[] { input.GroupIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DeleteAppGroupAsync(DeleteGroupInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteAppGroupAsync));

            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.DeleteAppGroup,
                new[] { $"{input.AppGroupId}" },
                (nameof(input.RowVersion), Convert.ToBase64String(input.RowVersion)));

            using (var response = await GetProviderHttpClient().DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateAppGroupSortOrderAsync(UpdateGroupSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(UpdateAppGroupAsync));

            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.UpdateAppGroupSortOrder,
                new[] { $"{input.AppGroupId}" },
                (nameof(input.Ascent), input.Ascent),
                    (nameof(input.RowVersion), Convert.ToBase64String(input.RowVersion)));

            using (var jsonContent = JsonContent.Create(input))
            {
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> DragAppGroupAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DragAppGroupAsync));

            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.DragAppGroup,
                new[] { $"{input.SourceId}", $"{input.TargetId}" },
                (nameof(input.Ascent), input.Ascent),
                    (nameof(input.SourceRowVersion), Convert.ToBase64String(input.SourceRowVersion)));

            using (var response = await GetProviderHttpClient().PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateAppGroupAsync(UpdateGroupInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.UpdateAppGroup,
                new[] { $"{input.AppGroupId}" });

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

        public Task<IResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetOrCreateAsync));
        }

        public async Task<IResponse> ReorderAppGroupsAsync()
        {
            const string relativeUri = OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.ReorderAppGroup;

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