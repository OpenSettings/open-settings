using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace OpenSettings.AspNetCore.Extensions
{
    internal static class InternalExtensions
    {
        internal static AuthenticationHeaderValue GetAuthenticationHeaderValueFromAuthorizationHeader(this IHeaderDictionary headerDictionary)
        {
            var authorizationHeader = headerDictionary[OpenSettingsDefaults.Headers.Authorization];

            return AuthenticationHeaderValue.TryParse(authorizationHeader, out var authorizationHeaderValue) ? authorizationHeaderValue : null;
        }

        internal static string GetPackVersionHeaderValueOrDefault(this IHeaderDictionary headerDictionary)
        {
            return headerDictionary.TryGetValue(OpenSettingsDefaults.Headers.PackVersion, out var values) ? values.ToString() : null;
        }

        internal static (string username, string password) GetBasicCredentialsFromAuthHeader(this AuthenticationHeaderValue authenticationHeaderValue)
        {
            if (authenticationHeaderValue?.Scheme != OpenSettingsDefaults.Names.BasicSchemeName)
            {
                return default;
            }

            var credentialBytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);

            return (credentials[0], credentials[1]);
        }

        internal static Guid? GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.GetClaim(OpenSettingsDefaults.Claims.DbUserId);

            return Guid.TryParse(claim?.Value, out var userId)
                ? userId == Guid.Empty ? (Guid?)null : userId
                : null;
        }

        internal static string GetIpAddress(this HttpRequest httpRequest)
        {
            return httpRequest.HttpContext.Connection.RemoteIpAddress?.ToString();
        }

        internal static string GetUserDisplayName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaim(OpenSettingsDefaults.Claims.DbUserDisplayName)?.Value;
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