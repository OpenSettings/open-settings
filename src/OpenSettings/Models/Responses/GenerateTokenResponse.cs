using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace OpenSettings.Models.Responses
{
    public class GenerateTokenResponse
    {
        public GenerateTokenResponse()
        {
        }

        public GenerateTokenResponse(string accessToken, DateTimeOffset expires, double expiresInSeconds, List<Claim> claims)
        {
            AccessToken = accessToken;
            Expires = expires.ToString("R"); // RFC1123 format
            ExpiresInSeconds = expiresInSeconds;
            Claims = claims;
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

        [JsonIgnore]
        public List<Claim> Claims { get; } = new List<Claim>(0);
    }
}