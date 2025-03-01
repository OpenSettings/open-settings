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
    public sealed class TagsRestService : ITagsRestService
    {
        private readonly HttpClient _httpClient;

        public TagsRestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IJsonResponse> GetTagsAsync(GetTagsInput input, CancellationToken cancellationToken = default)
        {
            const string relativeUri = "v1/tags";

            var queryBuilder = new QueryBuilder();

            if (!string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                queryBuilder.Append(nameof(input.SearchTerm), input.SearchTerm);
            }

            queryBuilder.Append(nameof(input.HasMappings), input.HasMappings);

            using (var response = await _httpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> CreateTagAsync(CreateTagInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(CreateTagAsync));

            const string relativeUri = "v1/tags";

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

        public async Task<IJsonResponse> GetPaginatedTagsAsync(GetPaginatedInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetPaginatedTagsAsync));

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

            using (var response = await _httpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> DeleteUnmappedTagsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteUnmappedTagsAsync));

            const string relativeUri = "v1/tags/unmapped";

            using (var response = await _httpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetTagByIdAsync(GetTagInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/tags/{input.TagIdOrSlug}";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetTagBySlugAsync(GetTagInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/tags/slug/{input.TagIdOrSlug}";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> UpdateTagAsync(UpdateTagInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/tags/{input.TagId}";

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

        public async Task<IJsonResponse> DeleteTagAsync(DeleteTagInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteTagAsync));

            var relativeUri = $"v1/tags/{input.TagId}?rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            using (var response = await _httpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> UpdateTagSortOrderAsync(UpdateTagSortOrderInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/tags/{input.TagId}/sort-order";

            var queryBuilder = new QueryBuilder();

            if (input.Ascent)
            {
                queryBuilder.Append(nameof(input.Ascent), input.Ascent);
            }

            queryBuilder.Append(nameof(input.RowVersion), input.RowVersion);

            using (var response = await _httpClient.PostAsync(queryBuilder.ToString(relativeUri), null, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> DragTagAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DragTagAsync));

            var relativeUri = $"v1/tags/{input.SourceId}/drag/{input.TargetId}?ascent={input.Ascent}&sourceRowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.SourceRowVersion))}";

            using (var response = await _httpClient.PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public Task<IJsonResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetOrCreateAsync));
        }

        public async Task<IJsonResponse> ReorderAsync()
        {
            const string relativeUri = "v1/tags/reorder";

            using (var response = await _httpClient.PostAsync(relativeUri, null))
            {
                return await response.Content.ToJsonResponseAsync();

            }
        }
    }
}