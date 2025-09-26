using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("")]
    public class AppInstancesController : ControllerBase
    {
        private readonly IAppInstanceService _instancesService;

        public AppInstancesController(IAppInstanceService instancesService)
        {
            _instancesService = instancesService;
        }

        [HttpDelete(OpenSettingsDefaults.Routes.V1.AppInstancesEndpoints.DeleteAppInstance)]
        public async Task<IActionResult> DeleteAppInstance(DeleteAppInstanceRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _instancesService.DeleteAppInstanceAsync(new DeleteAppInstanceInput
            {
                AppInstanceId = request.AppInstanceId
            }, cancellationToken);

            return result.ToAction();
        }
    }
}