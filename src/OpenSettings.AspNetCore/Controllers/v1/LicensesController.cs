using Microsoft.AspNetCore.Mvc;
using Ogu.AspNetCore.Response.Json;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1/licenses")]
    public class LicensesController : ControllerBase
    {
        private readonly ILicensesService _licenseService;

        public LicensesController(ILicensesService licenseService)
        {
            _licenseService = licenseService;
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginatedLicenses(GetPaginatedLicensesRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _licenseService.GetPaginatedLicensesAsync( new GetPaginatedLicensesInput
            {
                PaginatedInput = new GetPaginatedInput(request.SearchTerm, request.SearchBy, request.PageIndex, request.PageSize, request.SortBy, request.SortDirection)
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentLicense(CancellationToken cancellationToken)
        {
            var result = await _licenseService.GetCurrentLicenseAsync(cancellationToken);

            return result.ToAction();
        }

        [HttpPost]
        public async Task<IActionResult> SaveLicense(SaveLicenseRequest request, CancellationToken cancellationToken)
        {
            var result = await _licenseService.SaveLicenseAsync(request.LicenseKey, cancellationToken);

            return result.ToAction();
        }

        [HttpDelete("{ReferenceId}")]
        public async Task<IActionResult> DeleteLicense(DeleteLicenseRequest request, CancellationToken cancellationToken)
        {
            var result = await _licenseService.DeleteLicenseAsync(new DeleteLicenseInput
            {
                ReferenceId = Uri.UnescapeDataString(request.ReferenceId)
            }, cancellationToken);

            return result.ToAction();
        }
    }
}