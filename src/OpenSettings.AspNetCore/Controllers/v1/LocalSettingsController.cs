using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route(OpenSettingsDefaults.Routes.V1.LocalSettings)]
    public class LocalSettingsController : ControllerBase
    {
        private readonly ILocalSettingService _localSettingService;
        public LocalSettingsController(ILocalSettingService localSettingService)
        {
            _localSettingService = localSettingService;
        }

        [HttpGet("{ComputedIdentifier:guid}")]
        public async Task<IActionResult> GetLocalSetting(GetLocalSettingRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _localSettingService.GetLocalSettingAsync(HttpContext.RequestServices, request.ComputedIdentifier, request.ConfigSource, cancellationToken);

            return result.ToAction();
        }
    }
}