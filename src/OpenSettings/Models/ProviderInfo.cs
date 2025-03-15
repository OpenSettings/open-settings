namespace OpenSettings.Models
{
    /// <summary>
    /// Represents information about a provider, including client details, authorization status, version information,
    /// and configuration related to OpenSettings, OAuth2, and Redis.
    /// </summary>
    public class ProviderInfo
    {
        /// <summary>
        /// Gets or sets the client information associated with the provider.
        /// </summary>
        public ProviderInfoClient Client { get; set; } = new ProviderInfoClient();

        /// <summary>
        /// Gets or sets a value indicating whether the provider is authorized.
        /// </summary>
        public bool Authorize { get; set; }

        /// <summary>
        /// Gets or sets the client's version.
        /// </summary>
        /// <remarks>
        /// e.g. "1.0.0"
        /// </remarks>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the version of the OpenSettings.
        /// </summary>
        /// <remarks>
        ///e.g. "1.0.0"
        /// </remarks>
        public string PackVersion { get; set; }

        /// <summary>
        /// Gets or sets the numerical score of the OpenSettings version, used for comparing versions.
        /// A higher score indicates a more recent version.
        /// </summary>
        /// <remarks>
        /// e.g. "281474976710656"
        /// </remarks>
        public long PackVersionScore { get; set; }

        /// <summary>
        /// Gets or sets the OAuth2 configuration for the provider.
        /// </summary>
        public OAuth2Info OAuth2 { get; set; } = new OAuth2Info();

        /// <summary>
        /// Gets or sets the Redis configuration for the provider.
        /// </summary>
        public RedisInfo Redis { get; set; } = new RedisInfo();
    }
}