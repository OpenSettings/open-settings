using Microsoft.AspNetCore.Mvc;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route(OpenSettingsDefaults.Routes.V1.OpenSettings)]
    public class OpenSettingsController : ControllerBase
    {
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

            ApplyHeaders(configs.CacheControl, configs.Expires);

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

            ApplyHeaders(config.CacheControl, config.Expires);

            return File(config.Data, OpenSettingsDefaults.ContentTypes.ApplicationOctetStream);
        }

        private void ApplyHeaders(string cacheControl, string expires)
        {
            Response.Headers[OpenSettingsDefaults.Headers.CacheControl] = cacheControl;
            Response.Headers[OpenSettingsDefaults.Headers.Expires] = expires;
        }
    }
}