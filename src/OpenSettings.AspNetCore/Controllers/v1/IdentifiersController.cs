using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using OpenSettings.AspNetCore.Extensions;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route(OpenSettingsDefaults.Routes.V1.Identifiers)]
    public class IdentifiersController : ControllerBase
    {
        private readonly IIdentifierService _identifierService;

        public IdentifiersController(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetIdentifiers(GetIdentifiersRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _identifierService.GetIdentifiersAsync(new GetIdentifiersInput
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
                return ModelState.ToAction();
            }

            var result = await _identifierService.CreateIdentifierAsync(new CreateIdentifierInput
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
                return ModelState.ToAction();
            }

            var result = await _identifierService.GetPaginatedIdentifiersAsync(new GetPaginatedInput(request.SearchTerm, request.SearchBy, request.PageIndex, request.PageSize, request.SortBy, request.SortDirection), cancellationToken);

            return result.ToAction();
        }

        [HttpDelete("unmapped")]
        public async Task<IActionResult> DeleteUnmappedIdentifiers(CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _identifierService.DeleteUnmappedIdentifiersAsync(cancellationToken);

            return result.ToAction();
        }

        [HttpGet("{IdentifierIdOrSlug}")]
        public async Task<IActionResult> GetIdentifierById(GetIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _identifierService.GetIdentifierByIdAsync(new GetIdentifierInput { IdentifierIdOrSlug = request.IdentifierIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{IdentifierIdOrSlug}")]
        public async Task<IActionResult> GetIdentifierBySlug(GetIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _identifierService.GetIdentifierBySlugAsync(new GetIdentifierInput { IdentifierIdOrSlug = request.IdentifierIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpPut("{IdentifierId}")]
        public async Task<IActionResult> UpdateIdentifier(UpdateIdentifierRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _identifierService.UpdateIdentifierAsync(new UpdateIdentifierInput
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
                return ModelState.ToAction();
            }

            var result = await _identifierService.DeleteIdentifierAsync(new DeleteIdentifierInput
            {
                IdentifierId = request.IdentifierId,
                RowVersion = request.RowVersion
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("{IdentifierId}/sort-order")]
        public async Task<IActionResult> UpdateIdentifierSortOrder(UpdateIdentifierSortOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _identifierService.UpdateIdentifierSortOrderAsync(new UpdateIdentifierSortOrderInput
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
                return ModelState.ToAction();
            }

            var result = await _identifierService.DragIdentifierAsync(new DragItemSortOrderInput
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
            var result = await _identifierService.ReorderAsync();

            return result.ToAction();
        }
    }
}