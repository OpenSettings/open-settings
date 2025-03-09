using OpenSettings.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a configuration entity.
    /// </summary>
    [Table("Configurations")]
    public class ConfigurationSqlModel : EntityBase<int>
    {
        /// <summary>
        /// Determines whether the configuration should be stored in a separate file.
        /// </summary>
        public bool StoreInSeparateFile { get; set; }

        /// <summary>
        /// Specifies whether individual settings' <see cref="SettingSqlModel.StoreInSeparateFile"/> values should be ignored,  
        /// enforcing a global setting instead.
        /// </summary>
        public bool IgnoreIndividualStoreInSeparateFile { get; set; }

        /// <summary>
        /// Indicates whether changes to the file should be ignored.
        /// </summary>
        public bool IgnoreOnFileChange { get; set; }

        /// <summary>
        /// Specifies whether individual settings' <see cref="SettingSqlModel.IgnoreOnFileChange"/> values should be ignored,  
        /// enforcing a global setting instead.
        /// </summary>
        public bool IgnoreIndividualIgnoreOnFileChange { get; set; }

        /// <summary>
        /// Defines the registration mode used for the configuration.
        /// </summary>
        public RegistrationMode RegistrationMode { get; set; }

        /// <summary>
        /// Specifies whether individual settings' <see cref="SettingSqlModel.RegistrationMode"/> values should be ignored,  
        /// enforcing a global setting instead.
        /// </summary>
        public bool IgnoreIndividualRegistrationMode { get; set; }

        /// <summary>
        /// Represents the consumer associated with the configuration.  
        /// When the service is running as a consumer, this will be used to define how the configuration is consumed or utilized.
        /// </summary>
        public ConfigurationConsumer Consumer { get; set; }

        /// <summary>
        /// Represents the provider associated with the configuration.  
        /// When the service is running as a provider, this will be used to define how the configuration is supplied or retrieved.
        /// </summary>
        public ConfigurationProvider Provider { get; set; }

        /// <summary>
        /// The identifier associated with this configuration.
        /// </summary>
        public int IdentifierId { get; set; }

        /// <summary>
        /// The app id associated with this configuration.
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// The id of the user who created this configuration.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The id of the user who last updated this configuration.
        /// </summary>
        public Guid? UpdatedById { get; set; }

        /// <summary>
        /// A concurrency token used for tracking changes.  
        /// Helps prevent conflicts during concurrent updates.
        /// </summary>
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// The identifier associated with this configuration.
        /// </summary>
        [ForeignKey(nameof(IdentifierId))]
        public virtual IdentifierSqlModel Identifier { get; set; }

        /// <summary>
        /// The application associated with this configuration.
        /// </summary>
        [ForeignKey(nameof(AppId))]
        public virtual AppSqlModel App { get; set; }

        /// <summary>
        /// The user who created this configuration.
        /// </summary>
        [ForeignKey(nameof(CreatedById))]
        public virtual UserSqlModel CreatedBy { get; set; }

        /// <summary>
        /// The user who last updated this configuration.
        /// </summary>
        [ForeignKey(nameof(UpdatedById))]
        public virtual UserSqlModel UpdatedBy { get; set; }
    }
}