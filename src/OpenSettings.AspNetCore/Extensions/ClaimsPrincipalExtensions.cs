using System;
using System.Linq;
using System.Security.Claims;

namespace OpenSettings.AspNetCore.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="ClaimsPrincipal"/> to retrieve user-specific claims.
    /// </summary>
    internal static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Retrieves the user id from the claims principal.
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal.</param>
        /// <returns></returns>
        internal static Guid? GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.GetClaim(OpenSettingsDefaults.ClaimTypes.DbUserId);

            return Guid.TryParse(claim?.Value, out var userId)
                ? userId == Guid.Empty ? (Guid?)null : userId
                : null;
        }

        /// <summary>
        /// Retrieves the user display name from the claims principal.
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal.</param>
        /// <returns></returns>
        internal static string GetUserDisplayName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaim(OpenSettingsDefaults.ClaimTypes.DbUserDisplayName)?.Value;
        }

        /// <summary>
        /// Retrieves the claim from the claims principal.
        /// </summary>
        /// <param name="claimsPrincipal">The claims principal.</param>
        /// <param name="claimType">The claim type.</param>
        /// <returns></returns>
        private static Claim GetClaim(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            if (claimsPrincipal?.Identity == null)
            {
                return null;
            }

            var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimType);

            return claim;
        }
    }
}