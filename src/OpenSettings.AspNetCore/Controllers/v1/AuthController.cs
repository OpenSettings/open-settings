using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route(OpenSettingsDefaults.Routes.V1.Auth)]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("authenticated")]
        [AllowAnonymous]
        public async Task<IActionResult> IsAuthenticated(string uuid)
        {
            var response = await _authService.IsAuthenticatedAsync(new IsAuthenticatedInput
            {
                Uuid = uuid
            });

            return response.ToAction();
        }

        [HttpGet("who-am-i")]
        public async Task<IActionResult> WhoAmI([FromQuery] string claimTypes, CancellationToken cancellationToken)
        {
            if (!User.Identity?.IsAuthenticated ?? false)
            {
                return Unauthorized();
            }

            var response = await _authService.WhoAmIAsync(new WhoAmIInput
            {
                ClaimTypes = claimTypes
            }, cancellationToken);

            return response.ToAction();
        }

        [HttpGet("return-to")]
        [AllowAnonymous]
        public IActionResult ReturnTo([FromQuery] string returnUrl, [FromQuery] string accessToken, [FromQuery] string uuid)
        {
            _authService.ReturnTo(new ReturnToInput
            {
                ReturnUrl = returnUrl,
                AccessToken = accessToken,
                Uuid = uuid
            });

            return Redirect(returnUrl);
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromQuery] string returnUrl, [FromQuery] string apiUrl, [FromQuery] string uuid)
        {
            await _authService.LoginAsync(new LoginInput
            {
                ReturnUrl = returnUrl,
                ApiUrl = apiUrl,
                Uuid = uuid
            });

            return new EmptyResult();
        }

        [HttpGet("logout")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout(LogoutRequest request)
        {
            await _authService.LogoutAsync(new LogoutInput
            {
                ReturnUrl = request.ReturnUrl,
                ApiUrl = request.ApiUrl
            });

            return new EmptyResult();
        }
    }
}