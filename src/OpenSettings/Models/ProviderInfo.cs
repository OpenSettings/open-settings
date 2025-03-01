using System.Collections.Generic;

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

        public KeyValuePair<string, string>[] GetAsKeyValuePairs()
        {
            return new []
            {
                new KeyValuePair<string, string>($"{nameof(ProviderInfo)}:{nameof(Client)}:{nameof(Client.Id)}", $"{Client.Id}"),
                new KeyValuePair<string, string>($"{nameof(ProviderInfo)}:{nameof(Client)}:{nameof(Client.Name)}", Client.Name),
                new KeyValuePair<string, string>($"{nameof(ProviderInfo)}:{nameof(Authorize)}", $"{Authorize}"),
                new KeyValuePair<string, string>($"{nameof(ProviderInfo)}:{nameof(Version)}", Version),
                new KeyValuePair<string, string>($"{nameof(ProviderInfo)}:{nameof(PackVersion)}", PackVersion),
                new KeyValuePair<string, string>($"{nameof(ProviderInfo)}:{nameof(PackVersionScore)}", $"{PackVersionScore}"),
                new KeyValuePair<string, string>($"{nameof(ProviderInfo)}:{nameof(OAuth2)}:{nameof(OAuth2.Authority)}", OAuth2.Authority),
                new KeyValuePair<string, string>($"{nameof(ProviderInfo)}:{nameof(OAuth2)}:{nameof(OAuth2.AllowOfflineAccess)}", $"{OAuth2.AllowOfflineAccess}"),
                new KeyValuePair<string, string>($"{nameof(ProviderInfo)}:{nameof(OAuth2)}:{nameof(OAuth2.IsActive)}", $"{OAuth2.IsActive}"),
                new KeyValuePair<string, string>($"{nameof(ProviderInfo)}:{nameof(Redis)}:{nameof(Redis.Channel)}", Redis.Channel),
                new KeyValuePair<string, string>($"{nameof(ProviderInfo)}:{nameof(Redis)}:{nameof(Redis.Configuration)}", Redis.Configuration),
                new KeyValuePair<string, string>($"{nameof(ProviderInfo)}:{nameof(Redis)}:{nameof(Redis.IsActive)}", $"{Redis.IsActive}"),
            };
        }
    }
}