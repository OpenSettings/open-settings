using OpenSettings.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a registry entry for a provider instance, used to track metadata within the system.
    /// </summary>
    [Table("ProviderRegistries")]
    public class ProviderRegistrySqlModel : EntityBase<Guid>
    {
        /// <summary>
        /// The type of the provider registered in the system.
        /// </summary>
        public ProviderRegistryType Type { get; set; }

        /// <summary>
        /// The unique identifier of the app.
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// The lowercase version of the <see cref="ClientId"/>, typically used for case-insensitive comparisons.
        /// </summary>
        public string ClientIdLowercase { get; set; }

        /// <summary>
        /// The dynamic identifier of the instance. 
        /// </summary>
        /// <remarks>The referenced id in the `dbo.Instances` table may not exist if the instance has been deleted.</remarks>
        public string InstanceDynamicId { get; set; }

        /// <summary>
        /// The communication scheme used by the provider (e.g., HTTP, gRPC).
        /// </summary>
        public ProviderRegistryScheme Scheme { get; set; }

        /// <summary>
        /// The host address of the provider instance.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// The network port on which the provider is running.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The region where the provider is deployed or operating.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// The version of the instance.
        /// e.g. '<c>1.0.0</c>'
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The version of the OpenSettings pack used by the provider.
        /// e.g. '<c>1.0.0-preview.1.0.1</c>'.
        /// </summary>
        public string PackVersion { get; set; }

        /// <summary>
        /// The timestamp of the last successful heartbeat sent by the provider.
        /// Used for determining availability and liveness.
        /// </summary>
        public DateTime LastHeartbeatOn { get; set; }

        [NotMapped]
        public override DateTime? UpdatedOn { get; set; }
    }
}