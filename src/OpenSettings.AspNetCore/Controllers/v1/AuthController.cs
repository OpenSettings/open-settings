using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.AuthEndpoints.GetMe)]
        [AllowAnonymous]
        public async Task<IActionResult> GetMe(GetMeRequest request)
        {
            var response = await _authService.GetMeAsync(new GetMeInput
            {
                StateId = request.StateId,
                Includes = request.Includes
            });

            return response.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.AuthEndpoints.Login)]
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

        [HttpGet(OpenSettingsDefaults.Routes.V1.AuthEndpoints.Logout)]
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