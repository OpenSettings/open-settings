using System;

namespace OpenSettings.Models.Responses
{
    public class GenerateMachineToMachineTokenResponse
    {
        public GenerateMachineToMachineTokenResponse()
        {
        }

        public GenerateMachineToMachineTokenResponse(string accessToken, DateTimeOffset expires, double expiresInSeconds)
        {
            AccessToken = accessToken;
            Expires = expires.ToString("R"); // RFC1123 format
            ExpiresInSeconds = expiresInSeconds;
        }

        public string AccessToken { get; set; }

        /// <summary>
        /// Expiry time in RFC1123 format e.g. "Thu, 26 Jun 2025 14:14:56 GMT"
        /// </summary>
        public string Expires { get; set; }

        /// <summary>
        /// Expires in seconds -> e.g. "3600"
        /// </summary>
        public double ExpiresInSeconds { get; set; }
    }
}