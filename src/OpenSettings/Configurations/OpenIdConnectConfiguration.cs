namespace OpenSettings.Configurations
{
    /// <summary>
    /// Represents the configuration options for OpenIdConnect authentication.
    /// This class holds the necessary settings for connecting to an OpenIdConnect provider and handling authentication.
    /// </summary>
    public class OpenIdConnectConfiguration
    {
        private string _authority;

        /// <summary>
        /// Gets or sets the authority Url for the OpenIdConnect provider.
        /// The value is trimmed of any trailing slashes.
        /// </summary>
        /// <remarks>
        /// e.g. '<c>https://identity.opensettings.net/</c>'.
        /// </remarks>
        public string Authority
        {
            get => _authority;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _authority = value.TrimEnd('/');
                }
            }
        }

        /// <summary>
        /// Gets or sets the client id used to authenticate with the OpenIdConnect provider.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret used to authenticate with the OpenIdConnect provider.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the URI to redirect to after the user is signed out.
        /// </summary>
        /// <remarks>
        /// The default value is '<c>null</c>'. When null, empty or whitespace the default redirect flow is used: - Provider → Spa, Consumer → Spa.
        /// </remarks>
        public string SignedOutRedirectUri { get; set; }

        //public string RedirectUri { get; set; }
        //public string PostLogoutRedirectUri { get; set; }
        //public string[] ResponseTypes { get; set; } = new[] { "code" };
        //public string[] Scopes { get; set; } = new string[] { "openid", "profile" };

        /// <summary>
        /// Gets or sets a value indicating whether offline access is allowed.
        /// If set to true, offline access tokens can be obtained.
        /// </summary>
        /// <remarks>
        /// The default value is '<c>false</c>'.
        /// </remarks>
        public bool AllowOfflineAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the OpenIdConnect configuration is active.
        /// If true, the OpenIdConnect authentication is enabled.
        /// </summary>
        /// <remarks>
        /// The default value is '<c>false</c>'.
        /// </remarks>
        public bool IsActive { get; set; }
    }
}