using Ogu.Response.Abstractions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IIdentifierService
    {
        Task<IResponse> GetPaginatedIdentifiersAsync(GetPaginatedInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteUnmappedIdentifiersAsync(CancellationToken cancellationToken = default);

        Task<IResponse> GetIdentifiersAsync(GetIdentifiersInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CreateIdentifierAsync(CreateIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetIdentifierByIdAsync(GetIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetIdentifierBySlugAsync(GetIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateIdentifierAsync(UpdateIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteIdentifierAsync(DeleteIdentifierInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateIdentifierSortOrderAsync(UpdateIdentifierSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DragIdentifierAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IResponse> ReorderIdentifiersAsync();

        Task<IResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default);
    }
}