using System;
using System.Text.Json.Serialization;

namespace OpenSettings.Models
{
    /// <summary>
    /// Represents information about a client.
    /// </summary>
    public class ProviderInfoClient
    {
        /// <summary>
        /// Gets or sets the unique identifier for the client.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique secret for the client.
        /// </summary>
        /// <remarks>Only set if the application is acting as the provider.</remarks>
        [JsonIgnore]
        public Guid? Secret { get; set; }

        /// <summary>
        /// Gets or sets the client's name.
        /// </summary>
        /// <remarks>
        /// e.g. "OpenSettings.Api"
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the client's version.
        /// </summary>
        /// <remarks>
        /// e.g. "1.0.0"
        /// </remarks>
        public string Version { get; set; }
    }
}