using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore
{
    /// <summary>
    /// Defines methods for handling and managing OpenSettings token validation and refresh functionality.
    /// This service provides functionality for checking token expiration, reading JWT tokens, and refreshing tokens.
    /// </summary>
    public interface IOpenSettingsTokenService
    {
        /// <summary>
        /// Checks if the specified access token has expired.
        /// </summary>
        /// <param name="httpContext">The <see cref="HttpContext"/> instance for the current HTTP request.</param>
        /// <param name="accessToken">The access token to check for expiration.</param>
        /// <returns>A task that represents the asynchronous operation, with a result indicating whether the token is expired.</returns>
        Task<bool> IsTokenExpiredAsync(HttpContext httpContext, string accessToken);

        /// <summary>
        /// Checks if the specified JWT security token has expired.
        /// </summary>
        /// <param name="httpContext">The <see cref="HttpContext"/> instance for the current HTTP request.</param>
        /// <param name="jwtSecurityToken">The <see cref="JwtSecurityToken"/> to check for expiration.</param>
        /// <returns>A task that represents the asynchronous operation, with a result indicating whether the token is expired.</returns>
        Task<bool> IsTokenExpiredAsync(HttpContext httpContext, JwtSecurityToken jwtSecurityToken);

        /// <summary>
        /// Reads the specified access token and returns the corresponding <see cref="JwtSecurityToken"/>.
        /// </summary>
        /// <param name="accessToken">The access token to read.</param>
        /// <returns>The decoded <see cref="JwtSecurityToken"/>.</returns>
        JwtSecurityToken ReadJwtToken(string accessToken);

        /// <summary>
        /// Refreshes the access token asynchronously.
        /// </summary>
        /// <param name="httpContext">The <see cref="HttpContext"/> instance for the current HTTP request.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation (optional).</param>
        /// <returns>A task that represents the asynchronous operation, with a result of the refreshed access token.</returns>
        Task<string> RefreshTokenAsync(HttpContext httpContext, CancellationToken cancellationToken = default);
    }
}