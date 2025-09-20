using Microsoft.AspNetCore.Mvc;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("")]
    public class OpenSettingsController : ControllerBase
    {
        private readonly IOpenSettingsService _openSettingsService;

        public OpenSettingsController(IOpenSettingsService openSettingsService)
        {
            _openSettingsService = openSettingsService;
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.OpenSettingsEndpoints.GetConfigs)]
        public async Task<IActionResult> GetConfigs(CancellationToken cancellationToken = default)
        {
            var configs = await _openSettingsService.GetConfigsAsync(cancellationToken);

            if (configs == null)
            {
                return NotFound();
            }

            ApplyHeaders(configs.CacheControl, configs.Expires, configs.Age);

            return Ok(configs.Data);
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.OpenSettingsEndpoints.GetConfigData)]
        public async Task<IActionResult> GetConfigData(GetConfigDataRequest request, CancellationToken cancellationToken = default)
        {
            var config = await _openSettingsService.GetConfigDataAsync(request.ConfigName, cancellationToken);

            if (config == null)
            {
                return NotFound();
            }

            ApplyHeaders(config.CacheControl, config.Expires, config.Age);

            return File(config.Data, OpenSettingsDefaults.ContentTypes.ApplicationOctetStream);
        }

        private void ApplyHeaders(string cacheControl, string expires, int age)
        {
            Response.Headers[OpenSettingsDefaults.Headers.CacheControl] = cacheControl;
            Response.Headers[OpenSettingsDefaults.Headers.Expires] = expires;
            Response.Headers[OpenSettingsDefaults.Headers.Age] = $"{age}";
        }
    }
}