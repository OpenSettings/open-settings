using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Configurations;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Net;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;

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

        [HttpPost("m2m")]
        [AllowAnonymous]
        public async Task<IActionResult> GenerateMachineToMachineToken(GenerateMachineToMachineTokenRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var response = await _tokenService.GenerateMachineToMachineTokenAsync(new GenerateMachineToMachineTokenInput
            {
                ClientId = request.Body.Client.Id,
                ClientSecret = request.Body.Client.Secret,
                CallerType = Request.Headers.GetCallerTypeHeaderValueOrDefault()
            }, cancellationToken);

            return response.ToAction();
        }

        [HttpPost("refresh/oauth2")]
        [Authorize(AuthenticationSchemes = OpenSettingsDefaults.AuthSchemes.OAuth2JwtBearer)]
        public async Task<IActionResult> RefreshOAuth2Token(CancellationToken cancellationToken = default)
        {
            if (_openSettingsConfiguration.IsConsumerSelected)
            {
                return HttpStatusCode.InternalServerError.ToFailureResponse(Errors.RefreshTokenNotSupportedWhileRunningInConsumerMode).ToAction();
            }

            var authHeader = HttpContext.Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader();

            var response = await _tokenService.RefreshOAuth2TokenAsync(authHeader.Parameter, cancellationToken);

            return response.ToAction();
        }

        [HttpGet("jwks")]
        public async Task<IActionResult> GetPublicJwks(CancellationToken cancellationToken = default)
        {
            var jwks = await _tokenService.GetPublicJwksAsync(cancellationToken);

            return Content(jwks, OpenSettingsDefaults.ContentTypes.ApplicationJson);
        }
    }
}