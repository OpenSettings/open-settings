namespace OpenSettings.Models
{
    public class OpenIdConnectInfo
    {
        /// <summary>
        /// Gets or sets the authority URL for the OpenIdConnect provider.
        /// The value is trimmed of any trailing slashes.
        /// </summary>
        public string Authority { get; set; }

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