using Ogu.Response.Abstractions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IAppGroupService
    {
        Task<IResponse> GetPaginatedAppGroupsAsync(GetPaginatedInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteUnmappedAppGroupsAsync(CancellationToken cancellationToken = default);

        Task<IResponse> GetAppGroupsAsync(GetAppGroupsInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CreateAppGroupAsync(CreateAppGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppGroupByIdAsync(GetAppGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppGroupBySlugAsync(GetAppGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateAppGroupAsync(UpdateAppGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteAppGroupAsync(DeleteAppGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateAppGroupSortOrderAsync(UpdateAppGroupSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DragAppGroupAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IResponse> ReorderAppGroupsAsync(Guid? updatedById);

        Task<IResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default);
    }
}