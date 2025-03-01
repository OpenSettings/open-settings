using Ogu.Compressions.Abstractions;
using OpenSettings.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Compression;

namespace OpenSettings.Domains.Sql.Entities
{
    [Table("Settings")]
    public class SettingSqlModel : EntityBase<int>
    {
        /// <summary>
        /// The binary data associated with the setting.
        /// </summary>
        public byte[] Data { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// The computed identifier is either provided directly as a GUID or is computed based on the class full name (or other string identifier)
        /// using an MD5 hash of the UTF-8 bytes of the string. This allows each setting to have a unique identifier.
        /// </summary>
        public Guid ComputedIdentifier { get; set; }

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
        /// Represents the version of the setting.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Indicates whether the data has been restored, preserving a history record.
        /// </summary>
        public bool DataRestored { get; set; }

        /// <summary>
        /// Specifies whether data validation is disabled for this setting.
        /// </summary>
        public bool DataValidationDisabled { get; set; }

        /// <summary>
        /// Determines whether the setting should be stored in a separate file.
        /// </summary>
        public bool StoreInSeparateFile { get; set; }

        /// <summary>
        /// Indicates whether changes to the file should be ignored.  
        /// This property has a value only if <see cref="StoreInSeparateFile"/> is set to <c>true</c>.
        /// </summary>
        public bool? IgnoreOnFileChange { get; set; }

        /// <summary>
        /// Defines the registration mode used for this setting.
        /// </summary>
        public RegistrationMode RegistrationMode { get; set; }

        /// <summary> 
        /// Indicates whether the setting is in draft mode.  
        /// Multiple settings can be associated with the same <see cref="Identifier"/> and <see cref="ComputedIdentifier"/>,  
        /// but only one of them can have this property set to <c>false</c>.
        /// </summary>
        public bool IsDraft { get; set; } // Todo: Later feature

        /// <summary>
        /// The identifier associated with this setting.
        /// </summary>
        public int IdentifierId { get; set; }

        /// <summary>
        /// The app id associated with this setting.
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// The id of the user who created this setting.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The id of the user who last updated this setting.
        /// </summary>
        public Guid? UpdatedById { get; set; }

        /// <summary>
        /// A concurrency token used for tracking changes.  
        /// Helps prevent conflicts during concurrent updates.
        /// </summary>
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// The associated setting class that provides metadata for this setting.
        /// </summary>
        public virtual SettingClassSqlModel SettingClass { get; set; }

        /// <summary>
        /// A collection of historical records for this setting.
        /// </summary>
        public virtual List<SettingHistorySqlModel> SettingHistories { get; set; } = new List<SettingHistorySqlModel>();

        /// <summary>
        /// The identifier associated with this setting.
        /// </summary>
        [ForeignKey(nameof(IdentifierId))]
        public virtual IdentifierSqlModel Identifier { get; set; }

        /// <summary>
        /// The app associated with this setting.
        /// </summary>
        [ForeignKey(nameof(AppId))]
        public virtual AppSqlModel App { get; set; }

        /// <summary>
        /// The user who created this setting.
        /// </summary>
        [ForeignKey(nameof(CreatedById))]
        public virtual UserSqlModel CreatedBy { get; set; }

        /// <summary>
        /// The user who last updated this setting.
        /// </summary>
        [ForeignKey(nameof(UpdatedById))]
        public virtual UserSqlModel UpdatedBy { get; set; }
    }
}