using Ogu.Response.Abstractions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface ITagsService
    {
        Task<IResponse> GetPaginatedTagsAsync(GetPaginatedInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteUnmappedTagsAsync(CancellationToken cancellationToken = default);

        Task<IResponse> GetTagsAsync(GetTagsInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CreateTagAsync(CreateTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetTagByIdAsync(GetTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetTagBySlugAsync(GetTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateTagAsync(UpdateTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteTagAsync(DeleteTagInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateTagSortOrderAsync(UpdateTagSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DragTagAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IResponse> ReorderAsync();

        Task<IResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default);
    }
}