using System;

namespace OpenSettings.Models.Responses
{
    public class GenerateTokenResponse
    {
        public GenerateTokenResponse()
        {
        }

        public GenerateTokenResponse(string accessToken, DateTimeOffset expires)
        {
            AccessToken = accessToken;
            Expires = expires.ToString("R"); // RFC1123 format
        }

        public string AccessToken { get; set; }

        /// <summary>
        /// e.g. "Thu, 26 Jun 2025 14:14:56 GMT"
        /// </summary>
        public string Expires { get; set; }
    }
}