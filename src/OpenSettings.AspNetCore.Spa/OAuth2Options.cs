using System.Text.Json.Serialization;

namespace OpenSettings.AspNetCore
{
    /// <summary>
    /// Represents the configuration options for OAuth2 authentication.
    /// This class holds the necessary settings for connecting to an OAuth2 provider and handling authentication.
    /// </summary>
    public class OAuth2Options
    {
        private string _authority;

        /// <summary>
        /// Gets or sets the authority URL for the OAuth2 provider.
        /// The value is trimmed of any trailing slashes.
        /// </summary>
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
        /// Gets or sets the client id used to authenticate with the OAuth2 provider.
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret used to authenticate with the OAuth2 provider.
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore]
        public string ClientSecret { get; set; }

        private string _signedOutRedirectUri = $"/{Spa.Constants.DefaultSpaRoutePrefix}";

        /// <summary>
        /// Gets or sets the URI to redirect to after the user is signed out.
        /// <para>The default value is '<c>settings</c>'.</para>
        /// </summary>
        public string SignedOutRedirectUri
        {
            get => _signedOutRedirectUri;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _signedOutRedirectUri = $"/{value.TrimStart('/')}";
                }
            }
        }

        //public string RedirectUri { get; set; }
        //public string PostLogoutRedirectUri { get; set; }
        //public string[] ResponseTypes { get; set; } = new[] { "code" };
        //public string[] Scopes { get; set; } = new string[] { "openid", "profile" };

        /// <summary>
        /// Gets or sets a value indicating whether offline access is allowed.
        /// If set to true, offline access tokens can be obtained.
        /// </summary>
        public bool AllowOfflineAccess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the OAuth2 configuration is active.
        /// If true, the OAuth2 authentication is enabled.
        /// </summary>
        public bool IsActive { get; set; }
    }
}