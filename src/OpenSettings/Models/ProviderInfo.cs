namespace OpenSettings.Models
{
    /// <summary>
    /// Represents information about a provider, including client details, authorization status, version information,
    /// and configuration related to OpenSettings, OpenIdConnect, and Redis.
    /// </summary>
    public class ProviderInfo
    {
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether authentication is required for this provider.
        /// </summary>
        public bool RequiresAuthentication { get; set; }

        /// <summary>
        /// Gets or sets the client information associated with the provider.
        /// </summary>
        public ProviderInfoClient Client { get; set; } = new ProviderInfoClient();

        /// <summary>
        /// Gets or sets the pack information for OpenSettings, including version, score, and whether it is a preview version.
        /// </summary>
        public PackInfo PackInfo { get; set; } = new PackInfo();

        /// <summary>
        /// Gets or sets the OpenIdConnect configuration for the provider.
        /// </summary>
        public OpenIdConnectInfo OpenIdConnect { get; set; } = new OpenIdConnectInfo();

        /// <summary>
        /// Gets or sets the Redis configuration for the provider.
        /// </summary>
        public RedisInfo Redis { get; set; } = new RedisInfo();
    }
}