using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("")]
    public class AppGroupsController : ControllerBase
    {
        private readonly IAppGroupService _appGroupsService;

        public AppGroupsController(IAppGroupService appGroupsService)
        {
            _appGroupsService = appGroupsService;
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.GetAppGroups)]
        public async Task<IActionResult> GetAppGroups(GetAppGroupsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appGroupsService.GetAppGroupsAsync(new GetGroupsInput
            {
                SearchTerm = request.SearchTerm,
                HasMappings = request.HasMappings
            }, cancellationToken);

            return result.ToAction();
        }


        [HttpPost(OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.CreateAppGroup)]
        public async Task<IActionResult> CreateGroup(CreateAppGroupRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appGroupsService.CreateAppGroupAsync(new CreateGroupInput
            {
                Name = request.Body.Name,
                SortOrder = request.Body.SortOrder,
                SetSortOrderPosition = request.Body.SetSortOrderPosition,
                CreatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.GetPaginatedAppGroups)]
        public async Task<IActionResult> GetPaginatedAppGroups(GetPaginatedRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appGroupsService.GetPaginatedAppGroupsAsync(new GetPaginatedInput(request.SearchTerm, request.SearchBy, request.PageIndex, request.PageSize, request.SortBy, request.SortDirection), cancellationToken);

            return result.ToAction();
        }
 

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.GetAppGroupById)]
        public async Task<IActionResult> GetAppGroupById(GetAppGroupByIdRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }
            
            var result = await _appGroupsService.GetAppGroupByIdAsync(new GetGroupInput { GroupIdOrSlug = request.AppGroupId }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.GetAppGroupBySlug)]
        public async Task<IActionResult> GetAppGroupBySlug(GetAppGroupBySlug request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appGroupsService.GetAppGroupBySlugAsync(new GetGroupInput { GroupIdOrSlug = request.AppGroupSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpPut(OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.UpdateAppGroup)]
        public async Task<IActionResult> UpdateAppGroup(UpdateAppGroupRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appGroupsService.UpdateAppGroupAsync(new UpdateGroupInput
            {
                AppGroupId = request.AppGroupId,
                Name = request.Body.Name,
                SortOrder = request.Body.SortOrder,
                SetSortOrderPosition = request.Body.SetSortOrderPosition,
                RowVersion = request.Body.RowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.UpdateAppGroupSortOrder)]
        public async Task<IActionResult> UpdateAppGroupSortOrder(UpdateAppGroupSortOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appGroupsService.UpdateAppGroupSortOrderAsync(new UpdateGroupSortOrderInput
            {
                AppGroupId = request.AppGroupId,
                Ascent = request.Ascent,
                RowVersion = request.RowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.DragAppGroup)]
        public async Task<IActionResult> DragAppGroup(DragItemSortOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appGroupsService.DragAppGroupAsync(new DragItemSortOrderInput
            {
                SourceId = request.SourceId,
                TargetId = request.TargetId,
                Ascent = request.Ascent,
                SourceRowVersion = request.SourceRowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.ReorderAppGroup)]
        public async Task<IActionResult> ReorderGroups()
        {
            var result = await _appGroupsService.ReorderAppGroupsAsync();

            return result.ToAction();
        }

        [HttpDelete(OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.DeleteAppGroup)]
        public async Task<IActionResult> DeleteAppGroup(DeleteAppGroupRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appGroupsService.DeleteAppGroupAsync(new DeleteGroupInput { AppGroupId = request.AppGroupId, RowVersion = request.RowVersion }, cancellationToken);

            return result.ToAction();
        }

        [HttpDelete(OpenSettingsDefaults.Routes.V1.AppGroupsEndpoints.DeleteUnmappedAppGroups)]
        public async Task<IActionResult> DeleteUnmappedAppGroups(CancellationToken cancellationToken = default)
        {
            var result = await _appGroupsService.DeleteUnmappedAppGroupsAsync(cancellationToken);

            return result.ToAction();
        }
    }
}