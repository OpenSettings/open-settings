using Ogu.Response.Json;
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
        Task<IJsonResponse> GetPaginatedGroupsAsync(GetPaginatedInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DeleteUnmappedGroupsAsync(CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetGroupsAsync(GetGroupsInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> CreateGroupAsync(CreateGroupInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetGroupByIdAsync(GetGroupInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetGroupBySlugAsync(GetGroupInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> UpdateGroupAsync(UpdateGroupInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DeleteGroupAsync(DeleteGroupInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> UpdateGroupSortOrderAsync(UpdateGroupSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DragGroupAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> ReorderAsync();

        Task<IJsonResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default);
    }
}