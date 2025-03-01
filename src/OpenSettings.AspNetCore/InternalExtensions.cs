using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace OpenSettings.AspNetCore
{
    internal static class InternalExtensions
    {
        internal static (Guid clientId, Guid clientSecret) GetClientCredentials(this HttpContext httpContext)
        {
            var (username, password) = httpContext.Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader()
                .GetBasicCredentialsFromAuthHeader();

            return (Guid.Parse(username), Guid.Parse(password));
        }

        internal static bool IsAdmin(this HttpContext httpContext)
        {
            return httpContext.GetRole() == RoleType.Admin;
        }

        internal static bool IsSameAppOrAdmin(this HttpContext httpContext, Guid clientId)
        {
            if (httpContext.IsAdmin())
            {
                return true;
            }

            var clientCredentials = httpContext.GetClientCredentials();

            return clientCredentials.clientId == clientId;

        }

        internal static RoleType GetRole(this HttpContext httpContext)
        {
            _ = Enum.TryParse(httpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value, out RoleType role);

            return role;
        }

        internal static AuthenticationHeaderValue GetAuthenticationHeaderValueFromAuthorizationHeader(this IHeaderDictionary headerDictionary)
        {
            var authorizationHeader = headerDictionary["Authorization"];

            _ = AuthenticationHeaderValue.TryParse(authorizationHeader, out var authorizationHeaderValue);

            return authorizationHeaderValue;
        }

        internal static string GetPackVersionHeaderValueOrDefault(this IHeaderDictionary headerDictionary)
        {
            return headerDictionary.TryGetValue(OpenSettings.Constants.PackVersionName, out var values) ? values.ToString() : null;
        }

        internal static (string username, string password) GetBasicCredentialsFromAuthHeader(this AuthenticationHeaderValue authenticationHeaderValue)
        {
            if (authenticationHeaderValue?.Scheme != "Basic")
            {
                return default;
            }

            var credentialBytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);

            return (credentials[0], credentials[1]);
        }

        internal static Guid? GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.GetClaim(Constants.DbUserIdClaim);

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
            var claim = claimsPrincipal.GetClaim(Constants.DbUserDisplayNameClaim);

            return claim?.Value;
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