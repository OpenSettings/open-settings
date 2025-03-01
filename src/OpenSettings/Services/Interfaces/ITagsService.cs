using Ogu.Response.Json;
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
        Task<IJsonResponse> GetPaginatedTagsAsync(GetPaginatedInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DeleteUnmappedTagsAsync(CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetTagsAsync(GetTagsInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> CreateTagAsync(CreateTagInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetTagByIdAsync(GetTagInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetTagBySlugAsync(GetTagInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> UpdateTagAsync(UpdateTagInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DeleteTagAsync(DeleteTagInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> UpdateTagSortOrderAsync(UpdateTagSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DragTagAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> ReorderAsync();

        Task<IJsonResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default);
    }
}