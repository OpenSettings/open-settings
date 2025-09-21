using Ogu.Response.Abstractions;
using OpenSettings.Extensions;
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
        private HttpClient HttpClient => _httpClientFactory.CreateOpenSettingsProviderHttpClient();

        private readonly IHttpClientFactory _httpClientFactory;

        public AppTagRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse> GetAppTagsAsync(GetTagsInput input, CancellationToken cancellationToken = default)
        {
            const string relativeUri = "v1/tags";

            var queryBuilder = new QueryBuilder();

            if (!string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                queryBuilder.Append(nameof(input.SearchTerm), input.SearchTerm);
            }

            queryBuilder.Append(nameof(input.HasMappings), input.HasMappings);

            using (var response = await HttpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> CreateAppTagAsync(CreateTagInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(CreateAppTagAsync));

            const string relativeUri = "v1/tags";

            var body = new
            {
                input.Name,
                input.SortOrder,
                input.SetSortOrderPosition
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await HttpClient.PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> GetPaginatedAppTagsAsync(GetPaginatedInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetPaginatedAppTagsAsync));

            const string relativeUri = "v1/tags/paginated";

            var queryBuilder = new QueryBuilder()
                .Append("page", input.PageIndex)
                .Append("size", input.PageSize);

            if (!string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                queryBuilder.Append(nameof(input.SearchTerm), input.SearchTerm);
            }

            if (!string.IsNullOrWhiteSpace(input.SearchBy))
            {
                queryBuilder.Append(nameof(input.SearchBy), input.SearchBy);
            }

            if (!string.IsNullOrWhiteSpace(input.SortBy))
            {
                queryBuilder.Append(nameof(input.SortBy), input.SortBy);
            }

            queryBuilder.Append(nameof(input.SortDirection), input.SortDirection);

            using (var response = await HttpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DeleteUnmappedAppTagsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteUnmappedAppTagsAsync));

            const string relativeUri = "v1/tags/unmapped";

            using (var response = await HttpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppTagByIdAsync(GetTagInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/tags/{input.AppTagIdOrSlug}";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppTagBySlugAsync(GetTagInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/tags/slug/{input.AppTagIdOrSlug}";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateAppTagAsync(UpdateTagInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/tags/{input.AppTagId}";

            var body = new
            {
                input.Name,
                input.SortOrder,
                input.SetSortOrderPosition,
                input.RowVersion
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await HttpClient.PutAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);

                }
            }
        }

        public async Task<IResponse> DeleteAppTagAsync(DeleteAppTagInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteAppTagAsync));

            var relativeUri = $"v1/tags/{input.AppTagId}?rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            using (var response = await HttpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateAppTagSortOrderAsync(UpdateTagSortOrderInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/tags/{input.AppTagId}/sort-order";

            var queryBuilder = new QueryBuilder();

            if (input.Ascent)
            {
                queryBuilder.Append(nameof(input.Ascent), input.Ascent);
            }

            queryBuilder.Append(nameof(input.RowVersion), input.RowVersion);

            using (var response = await HttpClient.PostAsync(queryBuilder.ToString(relativeUri), null, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DragAppTagAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DragAppTagAsync));

            var relativeUri = $"v1/tags/{input.SourceId}/drag/{input.TargetId}?ascent={input.Ascent}&sourceRowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.SourceRowVersion))}";

            using (var response = await HttpClient.PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public Task<IResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetOrCreateAsync));
        }

        public async Task<IResponse> ReorderAppTagAsync()
        {
            const string relativeUri = "v1/tags/reorder";

            using (var response = await HttpClient.PostAsync(relativeUri, null))
            {
                return await response.Content.ToResponseAsync();
            }
        }
    }
}