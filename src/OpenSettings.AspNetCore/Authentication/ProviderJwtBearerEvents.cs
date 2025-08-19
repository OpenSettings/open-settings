using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using OpenSettings.Services.Sql.Interfaces;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Authentication
{
    internal class ProviderJwtBearerEvents : JwtBearerEvents
    {
        private ITokenSqlService _tokenSqlService;

        public override async Task MessageReceived(MessageReceivedContext context)
        {
            _tokenSqlService = _tokenSqlService ?? context.HttpContext.RequestServices.GetRequiredService<ITokenSqlService>();

            var providerTokenInfo = await _tokenSqlService.GetProviderTokenInfoAsync(context.HttpContext.RequestAborted);

            if (!ReferenceEquals(context.Options.TokenValidationParameters.IssuerSigningKeys, providerTokenInfo.SigningKeys))
            {
                context.Options.TokenValidationParameters.IssuerSigningKeys = providerTokenInfo.SigningKeys;
            }
        }
    }
}