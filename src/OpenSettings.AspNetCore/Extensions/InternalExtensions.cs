using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace OpenSettings.AspNetCore.Extensions
{
    internal static class InternalExtensions
    {
        internal static (string username, string password) GetBasicCredentialsFromAuthHeader(this AuthenticationHeaderValue authenticationHeaderValue)
        {
            if (authenticationHeaderValue?.Scheme != OpenSettingsDefaults.Names.BasicSchemeName)
            {
                return default;
            }

            var credentialBytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(OpenSettingsDefaults.Separators.ColumnSeparator, 2);

            return (credentials[0], credentials[1]);
        }

        internal static string GetIpAddress(this HttpRequest httpRequest)
        {
            return httpRequest.HttpContext.Connection.RemoteIpAddress?.ToString();
        }
    }
}