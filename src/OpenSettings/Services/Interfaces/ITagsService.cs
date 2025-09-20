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

        Task<IResponse> GetAppTagsAsync(GetTagsInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CreateAppTagAsync(CreateTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppTagByIdAsync(GetTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetAppTagBySlugAsync(GetTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateAppTagAsync(UpdateTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteAppTagAsync(DeleteAppTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateAppTagSortOrderAsync(UpdateTagSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DragAppTagAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IResponse> ReorderAppTagAsync();

        Task<IResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default);
    }
}