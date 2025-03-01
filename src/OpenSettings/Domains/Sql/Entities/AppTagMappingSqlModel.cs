using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents an app-tag mapping entity.
    /// </summary>
    [Table("AppTagMappings")]
    public class AppTagMappingSqlModel : EntityBase<int>
    {
        /// <summary>
        /// The id of the associated app.
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// The id of the associated tag.
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// The id of the user who created this app-tag mapping.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The app associated with this mapping.
        /// </summary>
        [ForeignKey(nameof(AppId))]
        public virtual AppSqlModel App { get; set; }

        /// <summary>
        /// The tag associated with this mapping.
        /// </summary>
        [ForeignKey(nameof(TagId))]
        public virtual TagSqlModel Tag { get; set; }

        /// <summary>
        /// The user who created this app-tag mapping.
        /// </summary>
        [ForeignKey(nameof(CreatedById))]
        public virtual UserSqlModel CreatedBy { get; set; }

        [NotMapped]
        public new int Id { get; set; }

        [NotMapped] 
        public new DateTime? UpdatedOn { get; set; }
    }
}