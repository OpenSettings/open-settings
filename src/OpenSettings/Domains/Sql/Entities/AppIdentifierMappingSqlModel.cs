using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents an app-identifier mapping entity.
    /// </summary>
    [Table("AppIdentifierMappings")]
    public class AppIdentifierMappingSqlModel : EntityBase<int>
    {
        /// <summary>
        /// The id of the associated app.
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// The id of the associated identifier.
        /// </summary>
        public int IdentifierId { get; set; }

        /// <summary>
        /// The sort order of this mapping in a list.
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// The id of the user who created this app-identifier mapping.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The id of the user who last updated this app-identifier mapping.
        /// </summary>
        public Guid? UpdatedById { get; set; }

        /// <summary>
        /// A concurrency token used for tracking changes.  
        /// Helps prevent conflicts during concurrent updates.
        /// </summary>
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// The app associated with this mapping.
        /// </summary>
        [ForeignKey(nameof(AppId))]
        public virtual AppSqlModel App { get; set; }

        /// <summary>
        /// The identifier associated with this mapping.
        /// </summary>
        [ForeignKey(nameof(IdentifierId))]
        public virtual IdentifierSqlModel Identifier { get; set; }

        /// <summary>
        /// The user who created this app-identifier mapping.
        /// </summary>
        [ForeignKey(nameof(CreatedById))]
        public virtual UserSqlModel CreatedBy { get; set; }

        /// <summary>
        /// The user who last updated this app-identifier mapping.
        /// </summary>
        [ForeignKey(nameof(UpdatedById))]
        public virtual UserSqlModel UpdatedBy { get; set; }

        [NotMapped]
        public new int Id { get; set; }
    }
}