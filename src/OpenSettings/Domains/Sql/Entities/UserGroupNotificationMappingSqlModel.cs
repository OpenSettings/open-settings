using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a user group-notification mapping entity.
    /// </summary>
    [Table("UserGroupNotificationMappings")]
    public class UserGroupNotificationMappingSqlModel : EntityBase<int>
    {
        /// <summary>
        /// The id of the associated user group.
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// The id of the associated notification.
        /// </summary>
        public Guid NotificationId { get; set; }

        /// <summary>
        /// The id of the user who created this user group-notification mapping.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user group associated with this mapping.
        /// </summary>
        public virtual UserGroupSqlModel Group { get; set; }

        /// <summary>
        /// The notification associated with this mapping.
        /// </summary>
        public virtual NotificationSqlModel Notification { get; set; }

        /// <summary>
        /// The user who created this user group-notification mapping.
        /// </summary>
        [ForeignKey(nameof(CreatedById))]
        public virtual UserSqlModel CreatedBy { get; set; }

        [NotMapped]
        public new int Id { get; set; }

        [NotMapped]
        public new DateTime? UpdatedOn { get; set; }
    }
}