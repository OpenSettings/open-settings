using Microsoft.AspNetCore.Mvc;
using Ogu.AspNetCore.Response.Json;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1/tags")]
    public class TagsController : ControllerBase
    {
        private readonly ITagsService _tagsService;

        public TagsController(ITagsService tagsService)
        {
            _tagsService = tagsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTags(GetTagsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _tagsService.GetTagsAsync(new GetTagsInput { SearchTerm = request.SearchTerm, HasMappings = request.HasMappings}, cancellationToken);

            return result.ToAction();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _tagsService.CreateTagAsync(new CreateTagInput
            {
                Name = request.Body.Name,
                SortOrder = request.Body.SortOrder,
                SetSortOrderPosition = request.Body.SetSortOrderPosition,
                CreatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginatedTags(GetPaginatedRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _tagsService.GetPaginatedTagsAsync(new GetPaginatedInput(request.SearchTerm, request.SearchBy, request.PageIndex, request.PageSize, request.SortBy, request.SortDirection), cancellationToken);

            return result.ToAction();
        }

        [HttpDelete("unmapped")]
        public async Task<IActionResult> DeleteUnmappedTags(CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _tagsService.DeleteUnmappedTagsAsync(cancellationToken);

            return result.ToAction();
        }

        [HttpGet("{TagIdOrSlug}")]
        public async Task<IActionResult> GetTagById(GetTagRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _tagsService.GetTagByIdAsync(new GetTagInput { TagIdOrSlug = request.TagIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{TagIdOrSlug}")]
        public async Task<IActionResult> GetTagBySlug(GetTagRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _tagsService.GetTagBySlugAsync(new GetTagInput { TagIdOrSlug = request.TagIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpPut("{TagId}")]
        public async Task<IActionResult> UpdateTag(UpdateTagRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _tagsService.UpdateTagAsync(new UpdateTagInput
            {
                TagId = request.TagId,
                Name = request.Body.Name,
                SortOrder = request.Body.SortOrder,
                SetSortOrderPosition = request.Body.SetSortOrderPosition,
                RowVersion = request.Body.RowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpDelete("{TagId}")]
        public async Task<IActionResult> DeleteTag(DeleteTagRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _tagsService.DeleteTagAsync(new DeleteTagInput
            {
                TagId = request.TagId, 
                RowVersion = request.RowVersion
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("{TagId}/sort-order")]
        public async Task<IActionResult> UpdateTagSortOrder(UpdateTagSortOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _tagsService.UpdateTagSortOrderAsync(new UpdateTagSortOrderInput
            {
                TagId = request.TagId,
                Ascent = request.Ascent,
                RowVersion = request.RowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("{SourceId}/drag/{TargetId}")]
        public async Task<IActionResult> DragTag(DragItemSortOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _tagsService.DragTagAsync(new DragItemSortOrderInput
            {
                SourceId = request.SourceId,
                TargetId = request.TargetId,
                Ascent = request.Ascent,
                SourceRowVersion = request.SourceRowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("reorder")]
        public async Task<IActionResult> ReorderTag()
        {
            var result = await _tagsService.ReorderAsync();

            return result.ToAction();
        }
    }
}