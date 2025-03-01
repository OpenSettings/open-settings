using Microsoft.AspNetCore.Mvc;
using Ogu.AspNetCore.Response.Json;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1/instances")]
    public class InstancesController : ControllerBase
    {
        private readonly IInstancesService _instancesService;

        public InstancesController(IInstancesService instancesService)
        {
            _instancesService = instancesService;
        }

        [HttpDelete("{InstanceId}")]
        public async Task<IActionResult> DeleteInstance(DeleteInstanceRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _instancesService.DeleteInstanceAsync(new DeleteInstanceInput
            {
                InstanceId = request.InstanceId
            }, cancellationToken);

            return result.ToAction();
        }
    }
}