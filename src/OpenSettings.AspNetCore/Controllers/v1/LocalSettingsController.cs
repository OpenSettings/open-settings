using Microsoft.AspNetCore.Mvc;
using Ogu.AspNetCore.Response.Json;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1/local-settings")]
    public class LocalSettingsController : ControllerBase
    {
        private readonly ILocalSettingsService _localSettingsService;
        public LocalSettingsController(ILocalSettingsService localSettingsService)
        {
            _localSettingsService = localSettingsService;
        }

        [HttpGet("{ComputedIdentifier:guid}")]
        public async Task<IActionResult> GetLocalSetting(GetLocalSettingRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _localSettingsService.GetLocalSettingAsync(HttpContext.RequestServices, request.ComputedIdentifier, request.ConfigSource, cancellationToken);

            return result.ToAction();
        }
    }
}