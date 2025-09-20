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
    public class AppTagsController : ControllerBase
    {
        private readonly IAppTagService _appTagService;

        public AppTagsController(IAppTagService appTagService)
        {
            _appTagService = appTagService;
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.GetAppTags)]
        public async Task<IActionResult> GetAppTags(GetTagsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appTagService.GetAppTagsAsync(new GetTagsInput { SearchTerm = request.SearchTerm, HasMappings = request.HasMappings}, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.CreateAppTag)]
        public async Task<IActionResult> CreateAppTag(CreateAppTagRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appTagService.CreateAppTagAsync(new CreateTagInput
            {
                Name = request.Body.Name,
                SortOrder = request.Body.SortOrder,
                SetSortOrderPosition = request.Body.SetSortOrderPosition,
                CreatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.GetPaginatedAppTags)]
        public async Task<IActionResult> GetPaginatedAppTags(GetPaginatedRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appTagService.GetPaginatedAppTagsAsync(new GetPaginatedInput(request.SearchTerm, request.SearchBy, request.PageIndex, request.PageSize, request.SortBy, request.SortDirection), cancellationToken);

            return result.ToAction();
        }

        [HttpDelete(OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.DeleteUnmappedAppTags)]
        public async Task<IActionResult> DeleteUnmappedAppTags(CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appTagService.DeleteUnmappedAppTagsAsync(cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.GetAppTagById)]
        public async Task<IActionResult> GetAppTagById(GetAppTagByIdRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appTagService.GetAppTagByIdAsync(new GetTagInput { AppTagIdOrSlug = request.AppTagId }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.GetAppTagBySlug)]
        public async Task<IActionResult> GetAppTagBySlug(GetAppTagBySlugRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appTagService.GetAppTagBySlugAsync(new GetTagInput { AppTagIdOrSlug = request.Slug }, cancellationToken);

            return result.ToAction();
        }

        [HttpPut(OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.UpdateAppTag)]
        public async Task<IActionResult> UpdateAppTag(UpdateAppTagRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appTagService.UpdateAppTagAsync(new UpdateTagInput
            {
                AppTagId = request.AppTagId,
                Name = request.Body.Name,
                SortOrder = request.Body.SortOrder,
                SetSortOrderPosition = request.Body.SetSortOrderPosition,
                RowVersion = request.Body.RowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpDelete(OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.DeleteAppTag)]
        public async Task<IActionResult> DeleteAppTag(DeleteAppTagRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appTagService.DeleteAppTagAsync(new DeleteAppTagInput
            {
                AppTagId = request.AppTagId, 
                RowVersion = request.RowVersion
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.UpdateAppTagSortOrder)]
        public async Task<IActionResult> UpdateAppTagSortOrder(UpdateTagSortOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appTagService.UpdateAppTagSortOrderAsync(new UpdateTagSortOrderInput
            {
                AppTagId = request.AppTagId,
                Ascent = request.Ascent,
                RowVersion = request.RowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.DragAppTag)]
        public async Task<IActionResult> DragAppTag(DragItemSortOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _appTagService.DragAppTagAsync(new DragItemSortOrderInput
            {
                SourceId = request.SourceId,
                TargetId = request.TargetId,
                Ascent = request.Ascent,
                SourceRowVersion = request.SourceRowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AppTagsEndpoints.ReorderAppTag)]
        public async Task<IActionResult> ReorderAppTag()
        {
            var result = await _appTagService.ReorderAppTagAsync();

            return result.ToAction();
        }
    }
}