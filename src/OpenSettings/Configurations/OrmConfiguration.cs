using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

namespace OpenSettings.Configurations
{
    /// <summary>
    /// Represents the configuration for an Object-Relational Mapper (Orm) for data access.
    /// This class allows for configuring the <see cref="DbContext"/> used for persistence, 
    /// including options for pooling and the database provider.
    /// </summary>
    public class OrmConfiguration
    {
        /// <summary>
        /// Callback to configure the DbContext.
        /// </summary>
        /// <value>
        /// The configure database context.
        /// </value>
        [JsonIgnore]
        public Action<DbContextOptionsBuilder> ConfigureDbContext { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether DbContext pooling is enabled.
        /// Enabling pooling can improve performance by reusing database contexts instead of creating new instances.
        /// </summary>
        /// <value>
        /// A <see cref="bool"/> indicating whether DbContext pooling is enabled. 
        /// The default value is <c>false</c>.
        /// </value>
        public bool EnablePooling { get; set; }

        /// <summary>
        /// Gets or sets the pool size to use when DbContext pooling is enabled. 
        /// If not set, the default pool size will be used by the provider.
        /// </summary>
        /// <value>
        /// An optional <see cref="int"/> representing the maximum number of <see cref="DbContext"/> instances 
        /// that can be pooled. If <c>null</c>, the default pool size is used.
        /// </value>
        public int? PoolSize { get; set; }

        /// <summary>
        /// Gets configured DbContext provider name
        /// </summary>
        /// <value>
        /// A <see cref="string"/> representing the name of the database provider. 
        /// This value is set internally and is not meant to be changed directly.
        /// </value>
        public string DbProviderName { get; internal set; }
    }
}