using Ogu.Compressions.Abstractions;
using OpenSettings.Models;
using System;
using System.Collections.Generic;
using System.IO.Compression;

namespace OpenSettings.Domains.Sql.Entities
{
    public class GlobalConfigurationSqlModel : EntityBase<Guid>
    {
        /// <summary>
        /// The key of the global configuration.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The binary data associated with the global configuration.
        /// </summary>
        public byte[] Data { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// The associated client id with this global configuration if any.
        /// </summary>
        public Guid? ClientId { get; set; }

        /// <summary>
        /// The identifier associated with this global configuration if any.
        /// </summary>
        public Guid? IdentifierId { get; set; }

        /// <summary>
        /// Defines the serialization type used for data serialization and deserialization.
        /// </summary>
        public SerializerType SerializerType { get; set; }

        /// <summary>
        /// Specifies the type of compression applied to the data.  
        /// Determines which decoding method should be used.
        /// </summary>
        public CompressionType CompressionType { get; set; }

        /// <summary>
        /// Defines the level of compression used.
        /// </summary>
        public CompressionLevel CompressionLevel { get; set; }

        /// <summary>
        /// Represents the version of the global configuration.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// A concurrency token used for tracking changes.  
        /// Helps prevent conflicts during concurrent updates.
        /// </summary>
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Guid? TenantId { get; set; }

        public virtual TenantSqlModel Tenant { get; set; }

        /// <summary>
        /// The id of the user who created this global configuration.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user who created this setting.
        /// </summary>
        public virtual UserSqlModel CreatedBy { get; set; }

        /// <summary>
        /// The id of the user who last updated this global configuration.
        /// </summary>
        public Guid? UpdatedById { get; set; }

        /// <summary>
        /// The user who last updated this setting.
        /// </summary>
        public virtual UserSqlModel UpdatedBy { get; set; }

        public virtual ICollection<GlobalConfigurationHistorySqlModel> GlobalConfigurationHistories { get; set; } = new List<GlobalConfigurationHistorySqlModel>();
    }
}