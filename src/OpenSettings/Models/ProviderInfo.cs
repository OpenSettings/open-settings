namespace OpenSettings.Models
{
    /// <summary>
    /// Represents information about a provider, including client details, authorization status, version information,
    /// and configuration related to OpenSettings, OAuth2, and Redis.
    /// </summary>
    public class ProviderInfo
    {
        /// <summary>
        /// Gets or sets a value indicating whether authorization is required for this provider.
        /// Aka "IsAuthorized"
        /// </summary>
        public bool Authorize { get; set; }

        /// <summary>
        /// Gets or sets the client information associated with the provider.
        /// </summary>
        public ProviderInfoClient Client { get; set; } = new ProviderInfoClient();

        /// <summary>
        /// Gets or sets the pack information for OpenSettings, including version, score, and whether it is a preview version.
        /// </summary>
        public PackInfo PackInfo { get; set; } = new PackInfo();

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