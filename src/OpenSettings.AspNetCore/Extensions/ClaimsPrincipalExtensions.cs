using System;
using System.Linq;
using System.Security.Claims;

namespace OpenSettings.AspNetCore.Extensions
{
    internal static class ClaimsPrincipalExtensions
    {
        internal static Guid? GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.GetClaim(OpenSettingsDefaults.ClaimTypes.DbUserId);

            return Guid.TryParse(claim?.Value, out var userId)
                ? userId == Guid.Empty ? (Guid?)null : userId
                : null;
        }

        internal static string GetUserDisplayName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaim(OpenSettingsDefaults.ClaimTypes.DbUserDisplayName)?.Value;
        }

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