using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogu.AspNetCore.Response.Json;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1")]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet("provider")]
        [Authorize(AuthenticationSchemes = OpenSettings.Constants.OpenSettingsBasicAuthScheme)]
        public async Task<IActionResult> GetProviderInfo(CancellationToken cancellationToken)
        {
            var response = await _providerService.GetProviderAsync(cancellationToken);

            return response.ToAction();
        }
    }
}