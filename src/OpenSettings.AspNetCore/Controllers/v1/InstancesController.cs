using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route(OpenSettingsDefaults.Routes.V1.Instances)]
    public class InstancesController : ControllerBase
    {
        private readonly IInstanceService _instancesService;

        public InstancesController(IInstanceService instancesService)
        {
            _instancesService = instancesService;
        }

        [HttpDelete("{InstanceId}")]
        public async Task<IActionResult> DeleteInstance(DeleteInstanceRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _instancesService.DeleteInstanceAsync(new DeleteInstanceInput
            {
                InstanceId = request.InstanceId
            }, cancellationToken);

            return result.ToAction();
        }
    }
}