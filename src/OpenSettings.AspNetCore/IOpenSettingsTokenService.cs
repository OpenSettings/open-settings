using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore
{
    public interface IOpenSettingsTokenService
    {
        Task<bool> IsTokenExpiredAsync(HttpContext httpContext, string accessToken);

        Task<bool> IsTokenExpiredAsync(HttpContext httpContext, JwtSecurityToken jwtSecurityToken);

        JwtSecurityToken ReadJwtToken(string accessToken);

        Task<string> RefreshTokenAsync(HttpContext httpContext, CancellationToken cancellationToken = default);
    }
}