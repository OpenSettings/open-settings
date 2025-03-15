using Ogu.Response.Json;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public sealed class AppGroupsRestService : IAppGroupsRestService
    {
        private readonly HttpClient _httpClient;

        public AppGroupsRestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IJsonResponse> GetPaginatedGroupsAsync(GetPaginatedInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetPaginatedGroupsAsync));

            const string relativeUri = "v1/app-groups/paginated";

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

            using (var response = await _httpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> DeleteUnmappedGroupsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteUnmappedGroupsAsync));

            const string relativeUri = "v1/app-groups/unmapped";

            using (var response = await _httpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetGroupsAsync(GetGroupsInput input, CancellationToken cancellationToken = default)
        {
            const string relativeUri = "v1/app-groups";

            var queryBuilder = new QueryBuilder();

            if (!string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                queryBuilder.Append(nameof(input.SearchTerm), input.SearchTerm);
            }

            if (input.HasMappings.HasValue)
            {
                queryBuilder.Append(nameof(input.HasMappings), input.HasMappings);
            }

            var uriWithQuery = queryBuilder.ToString(relativeUri);

            using (var response = await _httpClient.GetAsync(uriWithQuery, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> CreateGroupAsync(CreateGroupInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(CreateGroupAsync));

            const string relativeUri = "v1/app-groups";

            var body = new
            {
                input.Name,
                input.SortOrder,
                input.SetSortOrderPosition
            };

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IJsonResponse> GetGroupByIdAsync(GetGroupInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/app-groups/{input.GroupIdOrSlug}";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetGroupBySlugAsync(GetGroupInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/app-groups/slug/{input.GroupIdOrSlug}";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> DeleteGroupAsync(DeleteGroupInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteGroupAsync));

            var relativeUri = $"v1/app-groups/{input.GroupId}?rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            using (var response = await _httpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> UpdateGroupSortOrderAsync(UpdateGroupSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(UpdateGroupAsync));

            var relativeUri = $"v1/app-groups/{input.GroupId}/sort-order?ascent={input.Ascent}&rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            var content = JsonSerializer.Serialize(input);

            using (var stringContent = new StringContent(content, Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IJsonResponse> DragGroupAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DragGroupAsync));

            var relativeUri = $"v1/app-groups/{input.SourceId}/drag/{input.TargetId}?ascent={input.Ascent}&sourceRowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.SourceRowVersion))}";

            using (var response = await _httpClient.PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> UpdateGroupAsync(UpdateGroupInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/app-groups/{input.GroupId}";

            var body = new
            {
                input.Name,
                input.SortOrder,
                input.SetSortOrderPosition,
                input.RowVersion
            };

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PutAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public Task<IJsonResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetOrCreateAsync));
        }

        public async Task<IJsonResponse> ReorderAsync()
        {
            const string relativeUri = "v1/app-groups/reorder";

            using (var response = await _httpClient.PostAsync(relativeUri, null))
            {
                return await response.Content.ToJsonResponseAsync();
            }
        }
    }
}