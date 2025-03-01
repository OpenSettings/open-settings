using Microsoft.AspNetCore.Mvc;
using Ogu.AspNetCore.Response.Json;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1/app-groups")]
    public class AppGroupsController : ControllerBase
    {
        private readonly IAppGroupsService _appGroupsService;

        public AppGroupsController(IAppGroupsService appGroupsService)
        {
            _appGroupsService = appGroupsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups(GetAppGroupsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appGroupsService.GetGroupsAsync(new GetGroupsInput
            {
                SearchTerm = request.SearchTerm,
                HasMappings = request.HasMappings
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(CreateAppGroupRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appGroupsService.CreateGroupAsync(new CreateGroupInput
            {
                Name = request.Body.Name,
                SortOrder = request.Body.SortOrder,
                SetSortOrderPosition = request.Body.SetSortOrderPosition,
                CreatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginatedGroups(GetPaginatedRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appGroupsService.GetPaginatedGroupsAsync(new GetPaginatedInput(request.SearchTerm, request.SearchBy, request.PageIndex, request.PageSize, request.SortBy, request.SortDirection), cancellationToken);

            return result.ToAction();
        }

        [HttpDelete("unmapped")]
        public async Task<IActionResult> DeleteUnmappedGroups(CancellationToken cancellationToken = default)
        {
            var result = await _appGroupsService.DeleteUnmappedGroupsAsync(cancellationToken);

            return result.ToAction();
        }

        [HttpGet("{GroupIdOrSlug}")]
        public async Task<IActionResult> GetGroupById(GetAppGroupRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }
            
            var result = await _appGroupsService.GetGroupByIdAsync(new GetGroupInput { GroupIdOrSlug = request.GroupIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{GroupIdOrSlug}")]
        public async Task<IActionResult> GetGroupBySlug(GetAppGroupRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appGroupsService.GetGroupBySlugAsync(new GetGroupInput { GroupIdOrSlug = request.GroupIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpPut("{GroupId}")]
        public async Task<IActionResult> UpdateGroup(UpdateAppGroupRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appGroupsService.UpdateGroupAsync(new UpdateGroupInput
            {
                GroupId = request.GroupId,
                Name = request.Body.Name,
                SortOrder = request.Body.SortOrder,
                SetSortOrderPosition = request.Body.SetSortOrderPosition,
                RowVersion = request.Body.RowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpDelete("{GroupId}")]
        public async Task<IActionResult> DeleteGroup(DeleteAppGroupRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appGroupsService.DeleteGroupAsync(new DeleteGroupInput { GroupId = request.GroupId, RowVersion = request.RowVersion }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("{GroupId}/sort-order")]
        public async Task<IActionResult> UpdateGroupSortOrder(UpdateAppGroupSortOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appGroupsService.UpdateGroupSortOrderAsync(new UpdateGroupSortOrderInput
            {
                GroupId = request.GroupId,
                Ascent = request.Ascent,
                RowVersion = request.RowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("{SourceId}/drag/{TargetId}")]
        public async Task<IActionResult> DragGroup(DragItemSortOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _appGroupsService.DragGroupAsync(new DragItemSortOrderInput
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
        public async Task<IActionResult> ReorderGroups()
        {
            var result = await _appGroupsService.ReorderAsync();

            return result.ToAction();
        }
    }
}