using Microsoft.EntityFrameworkCore;
using Ogu.Compressions;
using Ogu.Compressions.Abstractions;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Extensions;
using OpenSettings.Models;
using System.IO.Compression;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Configurations
{
    /// <summary>
    /// Represents the configuration for the provider service, including data access settings, 
    /// compression options, and the selection of specific data access strategies.
    /// </summary>
    public class ProviderConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderConfiguration"/> class with the default.
        /// <see cref="DataAccessType.Orm"/> selection.
        /// </summary>
        public ProviderConfiguration() : this(DataAccessType.Orm)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderConfiguration"/> class with a specific data access type.
        /// </summary>
        /// <param name="selection">
        /// The <see cref="DataAccessType"/> that determines which data access method (e.g., Orm) is selected.
        /// </param>
        public ProviderConfiguration(DataAccessType selection)
        {
            Selection = selection;
        }

        /// <summary>
        /// Gets or sets the current data access method selected for the provider.
        /// The selection determines the type of data persistence used.
        /// </summary>
        /// <value>
        /// A <see cref="DataAccessType"/> value indicating the current data access strategy (e.g., <see cref="DataAccessType.Orm"/>).
        /// </value>
        public DataAccessType Selection { get; set; }
        
        /// <summary>
        /// Gets or sets the configuration settings for the Orm (Object-Relational Mapper).
        /// This property is used when the <see cref="Selection"/> is set to <see cref="DataAccessType.Orm"/>.
        /// </summary>
        /// <value>
        /// An <see cref="OrmConfiguration"/> object containing settings related to the Orm configuration.
        /// </value>
        public OrmConfiguration Orm { get; set; } = new OrmConfiguration();

        /// <summary>
        /// Gets or sets the configuration settings for Redis.
        /// </summary>
        /// <value>
        /// A <see cref="RedisConfiguration"/> object containing Redis-related configuration.
        /// </value>
        public RedisConfiguration Redis { get; set; } = new RedisConfiguration();

        /// <summary>
        /// Gets a value indicating whether the Orm data access type is selected.
        /// This property is automatically updated based on the <see cref="Selection"/>.
        /// </summary>
        /// <value>
        /// A <see cref="bool"/> indicating whether ORM is selected (<c>true</c>) or not (<c>false</c>).
        /// </value>
        /// <remarks>
        /// This property is ignored in Json serialization.
        /// </remarks>
        [JsonIgnore]
        public bool IsOrmSelected { get; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the database has been initialized, it is used for internal purposes.
        /// </summary>
        /// <remarks>
        /// This property is ignored in Json serialization.
        /// </remarks>
        [JsonIgnore]
        internal bool IsDbInitialized { get; set; }

        /// <summary>
        /// Gets or sets the license key.
        /// </summary>
        /// <remarks>
        /// Behavior:
        /// <list type="bullet">
        ///   <item>
        ///     <description></description>
        ///   </item>
        ///   <item>
        ///     <description>When provided, it is used as the primary source for license validation.</description>
        ///   </item>
        ///   <item>
        ///     <description>If invalid or missing, the system will check for a license key in the project directory ("<c>OpenSettings-License.key</c>").</description>
        ///   </item>
        ///   <item>
        ///     <description>If the file is also not found or is invalid, the license key will be retrieved from the database.</description>
        ///   </item>
        /// </list>
        /// </remarks>
        public string LicenseKey { get; set; }

        /// <summary>
        /// Gets or sets the compression type used by the provider when storing setting data. Default type is <see cref="CompressionType.None"/>.
        /// </summary>
        /// <value>
        /// A <see cref="CompressionType"/> value indicating the type of compression used.
        /// </value>
        public CompressionType CompressionType { get; set; } = CompressionType.None;

        /// <summary>
        /// Gets or sets the compression level used by the provider when storing setting data. Default level is <see cref="CompressionLevel.Fastest"/>.
        /// </summary>
        /// <value>
        /// A <see cref="CompressionLevel"/> value indicating the compression level.
        /// </value>
        public CompressionLevel CompressionLevel { get; set; } = CompressionLevel.Fastest;

        /// <summary>
        /// Gets or sets whether database migrations are applied automatically on startup. Default is '<c>false</c>'.
        /// </summary>
        public bool DisableDatabaseMigrationsOnStartup { get; set; }

        internal async ValueTask InitializeDbAsync(OpenSettingsDbContext context, CancellationToken cancellationToken = default)
        {
            if (IsDbInitialized)
            {
                return;
            }

            if (!DisableDatabaseMigrationsOnStartup &&
                !context.Database.IsInMemory() && 
                (!await context.Database.CanConnectAsync(cancellationToken) ||
                 (await context.Database.GetPendingMigrationsAsync(cancellationToken)).Any()))
            {
                await context.Database.MigrateAsync(cancellationToken);
            }

            IsDbInitialized = true;

            Orm.DbProviderName = context.Database.ProviderName?.Split(OpenSettingsDefaults.Format.DotChar).LastOrDefault() ?? OpenSettingsDefaults.Names.Unknown;
        }

        internal CompressionProvider CreateCompressionProvider()
        {
            return new CompressionProvider(new ICompression[]
            {
                new BrotliCompression(new Ogu.Compressions.BrotliCompressionOptions(CompressionLevel)),
                new DeflateCompression(new DeflateCompressionOptions(CompressionLevel)),
                new GzipCompression(new GzipCompressionOptions(CompressionLevel)),
                new SnappyCompression(new SnappyCompressionOptions(CompressionLevel)),
                new ZstdCompression(new ZstdCompressionOptions(CompressionLevel)),
                new NoneCompression(new NoneCompressionOptions(CompressionLevel))
            });
        }
    }
}