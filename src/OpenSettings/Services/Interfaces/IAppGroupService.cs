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

        Task<IResponse> GetGroupsAsync(GetGroupsInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CreateGroupAsync(CreateGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppGroupByIdAsync(GetGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppGroupBySlugAsync(GetGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateAppGroupAsync(UpdateGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteAppGroupAsync(DeleteGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateAppGroupSortOrderAsync(UpdateGroupSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DragAppGroupAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IResponse> ReorderAppGroupsAsync();

        Task<IResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default);
    }
}