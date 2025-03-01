using Ogu.Response.Json;
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
    public sealed class IdentifiersRestService : IIdentifiersRestService
    {
        private readonly HttpClient _httpClient;

        public IdentifiersRestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IJsonResponse> GetPaginatedIdentifiersAsync(GetPaginatedInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetPaginatedIdentifiersAsync));

            const string relativeUri = "v1/identifiers/paginated";

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

        public async Task<IJsonResponse> DeleteUnmappedIdentifiersAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteUnmappedIdentifiersAsync));

            const string relativeUri = "v1/identifiers/unmapped";

            using (var response = await _httpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }
        public async Task<IJsonResponse> GetIdentifiersAsync(GetIdentifiersInput input, CancellationToken cancellationToken = default)
        {
            const string relativeUri = "v1/identifiers";

            var queryBuilder = new QueryBuilder();

            if (!string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                queryBuilder.Append(nameof(input.SearchTerm), input.SearchTerm);
            }

            if (!string.IsNullOrWhiteSpace(input.AppId))
            {
                queryBuilder
                    .Append(nameof(input.AppId), input.AppId)
                    .Append(nameof(input.IsAppMapped), input.IsAppMapped);
            }

            using (var response = await _httpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> CreateIdentifierAsync(CreateIdentifierInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(CreateIdentifierAsync));

            const string relativeUri = "v1/identifiers";

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

        public async Task<IJsonResponse> GetIdentifierByIdAsync(GetIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/identifiers/{input.IdentifierIdOrSlug}";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetIdentifierBySlugAsync(GetIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/identifiers/slug/{input.IdentifierIdOrSlug}";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> UpdateIdentifierAsync(UpdateIdentifierInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(UpdateIdentifierAsync));

            var relativeUri = $"v1/identifiers/{input.IdentifierId}";

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

        public async Task<IJsonResponse> DeleteIdentifierAsync(DeleteIdentifierInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteIdentifierAsync));

            var relativeUri = $"v1/identifiers/{input.IdentifierId}?rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            using (var response = await _httpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> UpdateIdentifierSortOrderAsync(UpdateIdentifierSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(UpdateIdentifierSortOrderAsync));

            var relativeUri = $"v1/identifiers/{input.IdentifierId}/sort-order?ascent={input.Ascent}&rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            using (var response = await _httpClient.PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> DragIdentifierAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DragIdentifierAsync));

            var relativeUri = $"v1/identifiers/{input.SourceId}/drag/{input.TargetId}?ascent={input.Ascent}&sourceRowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.SourceRowVersion))}";

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
            const string relativeUri = "v1/identifiers/reorder";

            using (var response = await _httpClient.PostAsync(relativeUri, null))
            {
                return await response.Content.ToJsonResponseAsync();
            }
        }
    }
}