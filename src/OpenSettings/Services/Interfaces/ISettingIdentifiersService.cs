using Ogu.Response.Json;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IIdentifiersService
    {
        Task<IJsonResponse> GetPaginatedIdentifiersAsync(GetPaginatedInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DeleteUnmappedIdentifiersAsync(CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetIdentifiersAsync(GetIdentifiersInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> CreateIdentifierAsync(CreateIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetIdentifierByIdAsync(GetIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetIdentifierBySlugAsync(GetIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> UpdateIdentifierAsync(UpdateIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DeleteIdentifierAsync(DeleteIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> UpdateIdentifierSortOrderAsync(UpdateIdentifierSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DragIdentifierAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> ReorderAsync();

        Task<IJsonResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default);
    }
}