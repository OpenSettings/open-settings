using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Configurations;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route(OpenSettingsDefaults.Routes.V1.Token)]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;

        public TokenController(ITokenService tokenService, OpenSettingsConfiguration openSettingsConfiguration)
        {
            _tokenService = tokenService;
            _openSettingsConfiguration = openSettingsConfiguration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GenerateToken(GenerateTokenRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var response = await _tokenService.GenerateTokenAsync(new GenerateTokenInput
            {
                ClientId = request.Body.Client.Id,
                ClientSecret = request.Body.Client.Secret
            }, cancellationToken);

            return response.ToAction();
        }

        [HttpPost("refresh")]
        [Authorize(AuthenticationSchemes = OpenSettingsDefaults.AuthSchemes.OAuth2JwtBearer)]
        public async Task<IActionResult> RefreshToken(CancellationToken cancellationToken = default)
        {
            if (_openSettingsConfiguration.IsConsumerSelected)
            {
                return HttpStatusCode.InternalServerError.ToFailureResponse(Errors.RefreshTokenNotSupportedWhileRunningInConsumerMode).ToAction();
            }

            var authHeader = HttpContext.Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader();

            var response = await _tokenService.RefreshUserTokenAsync(authHeader.Parameter, cancellationToken);

            return response.ToAction();
        }
    }
}
