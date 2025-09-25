using Ogu.Response.Abstractions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface IAppTagService
    {
        Task<IResponse> GetPaginatedAppTagsAsync(GetPaginatedInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteUnmappedAppTagsAsync(CancellationToken cancellationToken = default);

        Task<IResponse> GetAppTagsAsync(GetAppTagsInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CreateAppTagAsync(CreateAppTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppTagByIdAsync(GetAppTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppTagBySlugAsync(GetAppTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateAppTagAsync(UpdateAppTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteAppTagAsync(DeleteAppTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateAppTagSortOrderAsync(UpdateAppTagSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DragAppTagAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IResponse> ReorderAppTagAsync(Guid? updatedById);

        Task<IResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default);
    }
}