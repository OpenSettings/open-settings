using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
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

        [HttpPost("me")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMe(GetMeRequest request)
        {
            var response = await _authService.GetMeAsync(new GetMeInput
            {
                Uuid = request.Uuid,
                Includes = request.Includes
            });

            return response.ToAction();
        }

        [HttpGet("return-to")]
        [AllowAnonymous]
        public IActionResult ReturnTo(ReturnToRequest request)
        {
            _authService.ReturnTo(new ReturnToInput
            {
                ReturnUrl = request.ReturnUrl,
                AccessToken = request.AccessToken,
                Uuid = request.Uuid
            });

            return Redirect(request.ReturnUrl);
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            await _authService.LoginAsync(new LoginInput
            {
                ReturnUrl = request.ReturnUrl,
                ApiUrl = request.ApiUrl,
                StateId = request.StateId,
                ClientId = request.ClientId
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

        [HttpGet("jwks")]
        public async Task<IActionResult> GetPublicJwks()
        {
            return new EmptyResult();
        }
    }
}