using Ogu.Response.Abstractions;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public sealed class IdentifierRestService : IIdentifierRestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IdentifierRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse> GetPaginatedIdentifiersAsync(GetPaginatedInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetPaginatedIdentifiersAsync));

            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.IdentifiersEndpoints.GetPaginatedIdentifiers,
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

        public async Task<IResponse> DeleteUnmappedIdentifiersAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteUnmappedIdentifiersAsync));

            const string relativeUri = OpenSettingsDefaults.Routes.V1.IdentifiersEndpoints.DeleteUnmappedIdentifiers;

            using (var response = await GetProviderHttpClient().DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }
        public async Task<IResponse> GetIdentifiersAsync(GetIdentifiersInput input, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string>
            {
                { nameof(input.SearchTerm), input.SearchTerm }
            };

            if (input.AppId.HasValue)
            {
                query[nameof(input.AppId)] = input.AppId?.ToString();
                query[nameof(input.IsAppMapped)] = $"{input.IsAppMapped}";
            }

            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.IdentifiersEndpoints.GetIdentifiers,
                null,
                query);

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> CreateIdentifierAsync(CreateIdentifierInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(CreateIdentifierAsync));

            const string relativeUri = OpenSettingsDefaults.Routes.V1.IdentifiersEndpoints.CreateIdentifier;

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

        public async Task<IResponse> GetIdentifierByIdAsync(GetIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.IdentifiersEndpoints.GetIdentifierById,
                new[] { input.IdentifierIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetIdentifierBySlugAsync(GetIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.IdentifiersEndpoints.GetIdentifierBySlug,
                new[] { input.IdentifierIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateIdentifierAsync(UpdateIdentifierInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(UpdateIdentifierAsync));

            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.IdentifiersEndpoints.UpdateIdentifier,
                new[] { $"{input.IdentifierId}" });

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

        public async Task<IResponse> DeleteIdentifierAsync(DeleteIdentifierInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DeleteIdentifierAsync));

            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.IdentifiersEndpoints.DeleteIdentifier,
                new[] { $"{input.IdentifierId}" },
                (nameof(input.RowVersion), Convert.ToBase64String(input.RowVersion)));

            using (var response = await GetProviderHttpClient().DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateIdentifierSortOrderAsync(UpdateIdentifierSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(UpdateIdentifierSortOrderAsync));

            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.IdentifiersEndpoints.UpdateIdentifierSortOrder,
                new[] { $"{input.IdentifierId}" });

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

        public async Task<IResponse> DragIdentifierAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(DragIdentifierAsync));

            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.IdentifiersEndpoints.DragIdentifier,
                new[] { $"{input.SourceId}, {input.TargetId}" });

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

        public async Task<IResponse> ReorderIdentifiersAsync(Guid? updatedById)
        {
            const string relativeUri = OpenSettingsDefaults.Routes.V1.IdentifiersEndpoints.ReorderIdentifiers;

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