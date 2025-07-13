using Ogu.Response.Abstractions;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public sealed class IdentifiersRestService : IIdentifiersRestService
    {
        private HttpClient HttpClient => _httpClientFactory.CreateOpenSettingsHttpClient();

        private readonly IHttpClientFactory _httpClientFactory;

        public IdentifiersRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse> GetPaginatedIdentifiersAsync(GetPaginatedInput input, CancellationToken cancellationToken = default)
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

            using (var response = await HttpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DeleteUnmappedIdentifiersAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteUnmappedIdentifiersAsync));

            const string relativeUri = "v1/identifiers/unmapped";

            using (var response = await HttpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }
        public async Task<IResponse> GetIdentifiersAsync(GetIdentifiersInput input, CancellationToken cancellationToken = default)
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

            using (var response = await HttpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> CreateIdentifierAsync(CreateIdentifierInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(CreateIdentifierAsync));

            const string relativeUri = "v1/identifiers";

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

        public async Task<IResponse> GetIdentifierByIdAsync(GetIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/identifiers/{input.IdentifierIdOrSlug}";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetIdentifierBySlugAsync(GetIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/identifiers/slug/{input.IdentifierIdOrSlug}";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateIdentifierAsync(UpdateIdentifierInput input, CancellationToken cancellationToken = default)
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

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await HttpClient.PutAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> DeleteIdentifierAsync(DeleteIdentifierInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteIdentifierAsync));

            var relativeUri = $"v1/identifiers/{input.IdentifierId}?rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            using (var response = await HttpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateIdentifierSortOrderAsync(UpdateIdentifierSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(UpdateIdentifierSortOrderAsync));

            var relativeUri = $"v1/identifiers/{input.IdentifierId}/sort-order?ascent={input.Ascent}&rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            using (var response = await HttpClient.PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DragIdentifierAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DragIdentifierAsync));

            var relativeUri = $"v1/identifiers/{input.SourceId}/drag/{input.TargetId}?ascent={input.Ascent}&sourceRowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.SourceRowVersion))}";

            using (var response = await HttpClient.PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public Task<IResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetOrCreateAsync));
        }

        public async Task<IResponse> ReorderAsync()
        {
            const string relativeUri = "v1/identifiers/reorder";

            using (var response = await HttpClient.PostAsync(relativeUri, null))
            {
                return await response.Content.ToResponseAsync();
            }
        }
    }
}