using Ogu.Response.Abstractions;
using OpenSettings.Extensions;
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
        private HttpClient HttpClient => _httpClientFactory.CreateOpenSettingsHttpClient();

        private readonly IHttpClientFactory _httpClientFactory;

        public AppGroupsRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse> GetPaginatedGroupsAsync(GetPaginatedInput input, CancellationToken cancellationToken = default)
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

            using (var response = await HttpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DeleteUnmappedGroupsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteUnmappedGroupsAsync));

            const string relativeUri = "v1/app-groups/unmapped";

            using (var response = await HttpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetGroupsAsync(GetGroupsInput input, CancellationToken cancellationToken = default)
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

            using (var response = await HttpClient.GetAsync(uriWithQuery, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> CreateGroupAsync(CreateGroupInput input, CancellationToken cancellationToken = default)
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
                using (var response = await HttpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> GetGroupByIdAsync(GetGroupInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/app-groups/{input.GroupIdOrSlug}";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetGroupBySlugAsync(GetGroupInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/app-groups/slug/{input.GroupIdOrSlug}";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DeleteGroupAsync(DeleteGroupInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteGroupAsync));

            var relativeUri = $"v1/app-groups/{input.GroupId}?rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            using (var response = await HttpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateGroupSortOrderAsync(UpdateGroupSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(UpdateGroupAsync));

            var relativeUri = $"v1/app-groups/{input.GroupId}/sort-order?ascent={input.Ascent}&rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            var content = JsonSerializer.Serialize(input);

            using (var stringContent = new StringContent(content, Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await HttpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> DragGroupAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DragGroupAsync));

            var relativeUri = $"v1/app-groups/{input.SourceId}/drag/{input.TargetId}?ascent={input.Ascent}&sourceRowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.SourceRowVersion))}";

            using (var response = await HttpClient.PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateGroupAsync(UpdateGroupInput input, CancellationToken cancellationToken = default)
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
                using (var response = await HttpClient.PutAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public Task<IResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetOrCreateAsync));
        }

        public async Task<IResponse> ReorderAsync()
        {
            const string relativeUri = "v1/app-groups/reorder";

            using (var response = await HttpClient.PostAsync(relativeUri, null))
            {
                return await response.Content.ToResponseAsync();
            }
        }
    }
}