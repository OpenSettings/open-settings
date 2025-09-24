using System;

namespace OpenSettings.Models.Responses
{
    public class GenerateTokenResponseToken
    {
        public string Value { get; set; }

        /// <summary>
        /// Expiry date in utc.
        /// </summary>
        public DateTimeOffset ExpiryDate { get; set; }

        /// <summary>
        /// Expires in seconds -> e.g. "3600"
        /// </summary>
        public double ExpiresInSeconds { get; set; }
    }
}