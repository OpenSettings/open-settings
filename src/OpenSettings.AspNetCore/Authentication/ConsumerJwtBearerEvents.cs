using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OpenSettings.Services.Interfaces;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Authentication
{
    /// <summary>
    /// Provides custom events for handling JWT Bearer authentication in OpenSettings for the consumer setup.
    /// </summary>
    internal class ConsumerJwtBearerEvents : JwtBearerEvents
    {
        private ITokenService _tokenService;

        public override async Task MessageReceived(MessageReceivedContext context)
        {
            if (_tokenService != null)
            {
                return;
            }

            _tokenService = context.HttpContext.RequestServices.GetRequiredService<ITokenService>();
                
            var jwks = await _tokenService.GetPublicJwksAsync(context.HttpContext.RequestAborted);

            context.Options.TokenValidationParameters.IssuerSigningKeys = new JsonWebKeySet(jwks).Keys;
        }
    }
}