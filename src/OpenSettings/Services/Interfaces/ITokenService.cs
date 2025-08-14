using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using System.IdentityModel.Tokens.Jwt;
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
        /// Generates a new token based on the provided input parameters.
        /// </summary>
        /// <param name="input">The input parameters required to generate the token.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task of <see cref="IResponse{TData}"/> that used to generate the token.</returns>
        Task<IResponse<GenerateTokenResponse>> GenerateTokenForMachineAsync(GenerateTokenForMachineInput input, CancellationToken cancellationToken = default);

        /*
        /// <summary>
        /// Reads the specified access token and returns the corresponding <see cref="JwtSecurityToken"/>.
        /// </summary>
        /// <param name="accessToken">The access token to read.</param>
        /// <returns>The decoded <see cref="JwtSecurityToken"/>.</returns>
        JwtSecurityToken ReadJwtToken(string accessToken);

        /// <summary>
        /// Writes the jwt security token and returns the corresponding access token.
        /// </summary>
        /// <param name="jwtSecurityToken">The jwt security token.</param>
        /// <returns>The access token.</returns>
        string WriteJwtToken(JwtSecurityToken jwtSecurityToken);
        */

        Task<string> GetPublicJwksAsync(CancellationToken cancellationToken = default);
    }
}