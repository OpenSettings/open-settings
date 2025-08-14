using Microsoft.IdentityModel.Tokens;
using System;

namespace OpenSettings.Models
{
    /// <summary>
    /// ProviderTokenProvider is a class responsible for managing the token keys and signing credentials for a provider.
    /// </summary>
    public class ProviderTokenInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderTokenInfo"/> class.
        /// </summary>
        public ProviderTokenInfo() { }

        public TokenKeySet KeySet { get; set; }

        public RsaSecurityKey[] SigningKeys { get; set; } = Array.Empty<RsaSecurityKey>();

        public SigningCredentials SigningCredential { get; set; }
    }
}