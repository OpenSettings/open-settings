using OpenSettings.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a setting class entity.
    /// </summary>
    [Table("SettingClasses")]
    public class SettingClassSqlModel : EntityBase<int>
    {
        /// <summary>
        /// The class type identifier.
        /// </summary>
        public Guid Identifier { get; set; }

        /// <summary>
        /// The name of the setting class.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Combination of the namespace and class name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The namespace of the setting class.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// The id of the associated setting.
        /// </summary>
        public int SettingId { get; set; }

        /// <summary>
        /// The id of the user who created this setting class.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The id of the user who last updated this setting class.
        /// </summary>
        public Guid? UpdatedById { get; set; }

        /// <summary>
        /// The properties of the setting class.
        /// </summary>
        public ICollection<PropertyInfoHelperModel> Properties { get; set; } = Array.Empty<PropertyInfoHelperModel>();

        /// <summary>
        /// A concurrency token used for tracking changes.  
        /// Helps prevent conflicts during concurrent updates.
        /// </summary>
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// The setting associated with this setting class.
        /// </summary>
        [ForeignKey(nameof(SettingId))]
        public virtual SettingSqlModel Setting { get; set; }

        /// <summary>
        /// The user who created this setting class.
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