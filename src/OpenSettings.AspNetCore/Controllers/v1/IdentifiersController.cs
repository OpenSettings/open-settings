using Microsoft.AspNetCore.Mvc;
using Ogu.AspNetCore.Response.Json;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1/identifiers")]
    public class IdentifiersController : ControllerBase
    {
        private readonly IIdentifiersService _identifiersService;

        public IdentifiersController(IIdentifiersService identifiersService)
        {
            _identifiersService = identifiersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetIdentifiers(GetIdentifiersRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _identifiersService.GetIdentifiersAsync(new GetIdentifiersInput
            {
                SearchTerm = request.SearchTerm,
                AppId = request.AppId,
                IsAppMapped = request.IsAppMapped
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost]
        public async Task<IActionResult> CreateIdentifier(CreateIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _identifiersService.CreateIdentifierAsync(new CreateIdentifierInput
            {
                Name = request.Body.Name,
                SortOrder = request.Body.SortOrder,
                SetSortOrderPosition = request.Body.SetSortOrderPosition,
                CreatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginatedIdentifiers(GetPaginatedRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _identifiersService.GetPaginatedIdentifiersAsync(new GetPaginatedInput(request.SearchTerm, request.SearchBy, request.PageIndex, request.PageSize, request.SortBy, request.SortDirection), cancellationToken);

            return result.ToAction();
        }

        [HttpDelete("unmapped")]
        public async Task<IActionResult> DeleteUnmappedIdentifiers(CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _identifiersService.DeleteUnmappedIdentifiersAsync(cancellationToken);

            return result.ToAction();
        }

        [HttpGet("{IdentifierIdOrSlug}")]
        public async Task<IActionResult> GetIdentifierById(GetIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _identifiersService.GetIdentifierByIdAsync(new GetIdentifierInput { IdentifierIdOrSlug = request.IdentifierIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{IdentifierIdOrSlug}")]
        public async Task<IActionResult> GetIdentifierBySlug(GetIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _identifiersService.GetIdentifierBySlugAsync(new GetIdentifierInput { IdentifierIdOrSlug = request.IdentifierIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpPut("{IdentifierId}")]
        public async Task<IActionResult> UpdateIdentifier(UpdateIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _identifiersService.UpdateIdentifierAsync(new UpdateIdentifierInput
            {
                IdentifierId = request.IdentifierId,
                Name = request.Body.Name,
                SortOrder = request.Body.SortOrder,
                SetSortOrderPosition = request.Body.SetSortOrderPosition,
                RowVersion = request.Body.RowVersion,
                UpdatedById = User.GetUserId(),
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpDelete("{IdentifierId}")]
        public async Task<IActionResult> DeleteIdentifier(DeleteIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _identifiersService.DeleteIdentifierAsync(new DeleteIdentifierInput { IdentifierId = request.IdentifierId, RowVersion = request.RowVersion }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("{IdentifierId}/sort-order")]
        public async Task<IActionResult> UpdateIdentifierSortOrder(UpdateIdentifierSortOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _identifiersService.UpdateIdentifierSortOrderAsync(new UpdateIdentifierSortOrderInput
            {
                IdentifierId = request.IdentifierId,
                Ascent = request.Ascent,
                RowVersion = request.RowVersion,
                UpdatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("{SourceId}/drag/{TargetId}")]
        public async Task<IActionResult> DragIdentifier(DragItemSortOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _identifiersService.DragIdentifierAsync(new DragItemSortOrderInput
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
        public async Task<IActionResult> ReorderIdentifiers()
        {
            var result = await _identifiersService.ReorderAsync();

            return result.ToAction();
        }
    }
}