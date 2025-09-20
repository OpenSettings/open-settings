using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("")]
    public class LicensesController : ControllerBase
    {
        private readonly ILicenseService _licenseService;

        public LicensesController(ILicenseService licenseService)
        {
            _licenseService = licenseService;
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.LicensesEndpoints.GetPaginatedLicenses)]
        public async Task<IActionResult> GetPaginatedLicenses(GetPaginatedLicensesRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _licenseService.GetPaginatedLicensesAsync( new GetPaginatedLicensesInput
            {
                PaginatedInput = new GetPaginatedInput(request.SearchTerm, request.SearchBy, request.PageIndex, request.PageSize, request.SortBy, request.SortDirection)
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.LicensesEndpoints.GetCurrentLicense)]
        public async Task<IActionResult> GetCurrentLicense(CancellationToken cancellationToken)
        {
            var result = await _licenseService.GetCurrentLicenseAsync(cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.LicensesEndpoints.SaveLicense)]
        public async Task<IActionResult> SaveLicense(SaveLicenseRequest request, CancellationToken cancellationToken)
        {
            var result = await _licenseService.SaveLicenseAsync(request.LicenseKey, cancellationToken);

            return result.ToAction();
        }

        [HttpDelete(OpenSettingsDefaults.Routes.V1.LicensesEndpoints.DeleteLicense)]
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