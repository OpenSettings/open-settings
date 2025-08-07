using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route(OpenSettingsDefaults.Routes.V1.Provider)]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = OpenSettingsDefaults.AuthSchemes.Basic)]
        public async Task<IActionResult> GetProvider(CancellationToken cancellationToken)
        {
            var response = await _providerService.GetProviderAsync(cancellationToken);

            return response.ToAction();
        }

        [HttpGet("primary")]
        public async Task<IActionResult> GetPrimaryProvider(CancellationToken cancellationToken)
        {
            var response = await _providerService.GetPrimaryProviderAsync(cancellationToken);

            return response.ToAction();
        }
    }
}