using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.TokenEndpoints.GenerateTokenForMachine)]
        [AllowAnonymous]
        public async Task<IActionResult> GenerateTokenForMachine(GenerateMachineToMachineTokenRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var response = await _tokenService.GenerateTokenForMachineAsync(new GenerateTokenForMachineInput
            {
                ClientId = request.Body.Client.Id,
                ClientSecret = request.Body.Client.Secret,
                CallerType = Request.Headers.GetCallerTypeHeaderValueOrDefault()
            }, cancellationToken);

            return response.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.TokenEndpoints.GetPublicJwks)]
        [AllowAnonymous]
        public async Task<IActionResult> GetPublicJwks(CancellationToken cancellationToken = default)
        {
            var jwks = await _tokenService.GetPublicJwksAsync(cancellationToken);

            return Content(jwks, OpenSettingsDefaults.ContentTypes.ApplicationJson);
        }
    }
}