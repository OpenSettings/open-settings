using Microsoft.IdentityModel.Tokens;
using System;

namespace OpenSettings.Models
{
    public class TokenKeySetSigningKey
    {
        /// <summary>
        /// The Key ID (kid) used in JWKS and JWT headers to identify this key (e.g. opensettings/4b975f16e6ea49379fa41a9a4e1251ae ).
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        /// The type of cryptographic key (e.g. "RSA").
        /// </summary>
        public string KeyType { get; set; }

        /// <summary>
        /// The cryptographic algorithm used for signing (e.g. "RS256").
        /// </summary>
        public string Algorithm { get; set; }

        /// <summary>
        /// The size of the key in bits (e.g. 2048, 4096).
        /// </summary>
        public int KeySizeInBits { get; set; }

        /// <summary>
        /// The private key bytes in a serialized format (e.g. PKCS#8).
        /// </summary>
        public byte[] PrivateKey { get; set; }

        /// <summary>
        /// The Json Web Key (JWK) representation of this signing key, used for public key distribution.
        /// </summary>
        public JsonWebKey Jwk { get; set; }

        /// <summary>
        /// The date and time when the entity was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Whether this key is currently active for signing.
        /// </summary>
        public bool IsActive { get; set; }
    }
}