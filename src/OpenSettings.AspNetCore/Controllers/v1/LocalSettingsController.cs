using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("")]
    public class LocalSettingsController : ControllerBase
    {
        private readonly ILocalSettingService _localSettingService;
        public LocalSettingsController(ILocalSettingService localSettingService)
        {
            _localSettingService = localSettingService;
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.LocalSettingsEndpoints.GetLocalSettings)]
        public async Task<IActionResult> GetLocalSettings(GetLocalSettingsRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _localSettingService.GetLocalSettingsAsync(HttpContext.RequestServices, request.ComputedIdentifier, request.ConfigSource, cancellationToken);

            return result.ToAction();
        }
    }
}