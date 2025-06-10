using Ogu.Response.Abstractions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IAppGroupsService
    {
        Task<IResponse> GetPaginatedGroupsAsync(GetPaginatedInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteUnmappedGroupsAsync(CancellationToken cancellationToken = default);

        Task<IResponse> GetGroupsAsync(GetGroupsInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CreateGroupAsync(CreateGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetGroupByIdAsync(GetGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetGroupBySlugAsync(GetGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateGroupAsync(UpdateGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteGroupAsync(DeleteGroupInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateGroupSortOrderAsync(UpdateGroupSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DragGroupAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IResponse> ReorderAsync();

        Task<IResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default);
    }
}