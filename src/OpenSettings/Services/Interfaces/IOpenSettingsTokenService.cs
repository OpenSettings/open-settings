using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    /// <summary>
    /// Defines methods for handling and managing OpenSettings token validation and refresh functionality.
    /// This service provides functionality for checking token expiration, reading JWT tokens, and refreshing tokens.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Reads the specified access token and returns the corresponding <see cref="JwtSecurityToken"/>.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns></returns>
        JwtSecurityToken ReadJwtToken(string accessToken);

        /// <summary>
        /// Writes the specified JWT security token and returns the corresponding access token.
        /// </summary>
        /// <param name="jwtSecurityToken">The jwt security token.</param>
        /// <returns></returns>
        string WriteJwtToken(JwtSecurityToken jwtSecurityToken);

        /// <summary>
        /// Checks if the specified JWT security token has expired.
        /// </summary>
        /// <param name="accessToken">The access token to check for expiration.</param>
        /// <param name="refreshTokenRetrieveFunc">The func to retrieve refresh token.</param>
        /// <returns>A task that represents the asynchronous operation, with a result indicating whether the token is expired.</returns>
        ValueTask<bool> IsUserTokenExpiredAsync(string accessToken, Func<Task<string>> refreshTokenRetrieveFunc);

        /// <summary>
        /// Checks if the specified JWT security token has expired.
        /// </summary>
        /// <param name="jwtSecurityToken">The <see cref="JwtSecurityToken"/> to check for expiration.</param>
        /// <param name="refreshTokenRetrieveFunc">The func to retrieve refresh token.</param>
        /// <returns>A task that represents the asynchronous operation, with a result indicating whether the token is expired.</returns>
        ValueTask<bool> IsUserTokenExpiredAsync(JwtSecurityToken jwtSecurityToken, Func<Task<string>> refreshTokenRetrieveFunc);

        /// <summary>
        /// Reads the specified access token and returns the corresponding <see cref="JwtSecurityToken"/>.
        /// </summary>
        /// <param name="accessToken">The access token to read.</param>
        /// <returns>The decoded <see cref="JwtSecurityToken"/>.</returns>
        //JwtSecurityToken ReadJwtToken(string accessToken);

        /// <summary>
        /// Writes the jwt security token and returns the corresponding access token.
        /// </summary>
        /// <param name="jwtSecurityToken">The jwt security token.</param>
        /// <returns>The access token.</returns>
        //string WriteJwtToken(JwtSecurityToken jwtSecurityToken);

        /// <summary>
        /// Refreshes the access token asynchronously.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation (optional).</param>
        /// <returns>A task of <see cref="IResponse{TData}"/> that represents the asynchronous operation, with a result of the refreshed <c>access token</c>.</returns>
        /// <exception cref="NotSupportedException">Thrown when OAuth2 Authority is missing.</exception>
        Task<IResponse<RefreshUserTokenResponse>> RefreshUserTokenAsync(string accessToken, CancellationToken cancellationToken = default);

        /// <summary>
        /// Generates a new token based on the provided input parameters.
        /// </summary>
        /// <param name="input">The input parameters required to generate the token.</param>
        /// <returns>A task of <see cref="IResponse{TData}"/> that used to generate the token.</returns>
        Task<IResponse<GenerateTokenResponse>> GenerateTokenAsync(GenerateTokenInput input, CancellationToken cancellationToken);
    }
}