using Microsoft.AspNetCore.Mvc;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1/open-settings")]
    public class OpenSettingsController : ControllerBase
    {
        private const string OctetStreamContentType = "application/octet-stream";

        private readonly IOpenSettingsService _openSettingsService;

        public OpenSettingsController(IOpenSettingsService openSettingsService)
        {
            _openSettingsService = openSettingsService;
        }

        [HttpGet("configs")]
        public async Task<IActionResult> GetConfigs(CancellationToken cancellationToken = default)
        {
            var configs = await _openSettingsService.GetConfigsAsync(cancellationToken);

            if (configs == null)
            {
                return NotFound();
            }

            Response.Headers["Cache-Control"] = configs.CacheControl;
            Response.Headers["Expires"] = configs.Expires;

            return Ok(configs.Data);
        }

        [HttpGet("configs-data/{configName}")]
        public async Task<IActionResult> GetConfigsData([FromRoute] string configName, CancellationToken cancellationToken = default)
        {
            var config = await _openSettingsService.GetConfigsDataAsync(configName, cancellationToken);

            if (config == null)
            {
                return NotFound();
            }

            Response.Headers["Cache-Control"] = config.CacheControl;
            Response.Headers["Expires"] = config.Expires;

            return File(config.Data, OctetStreamContentType);
        }
    }
}