using System;

namespace OpenSettings.Models
{
    public class TokenKeySet
    {
        public TokenKeySetSigningKey[] Keys { get; set; } = Array.Empty<TokenKeySetSigningKey>();

        /// <summary>
        /// Json representation of the public JWKS (read-only for consumers).
        /// </summary>
        public string PublicJwksJson { get; set; }
    }
}