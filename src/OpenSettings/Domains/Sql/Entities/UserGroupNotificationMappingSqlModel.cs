using System;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a user group-notification mapping entity.
    /// </summary>
    public class UserGroupNotificationMappingSqlModel : EntityBase<Guid>
    {
        public Guid? TenantId { get; set; }

        /// <summary>
        /// The id of the associated user group.
        /// </summary>
        public Guid UserGroupId { get; set; }

        /// <summary>
        /// The id of the associated notification.
        /// </summary>
        public Guid NotificationId { get; set; }

        /// <summary>
        /// The user group associated with this mapping.
        /// </summary>
        public virtual UserGroupSqlModel UserGroup { get; set; }

        /// <summary>
        /// The notification associated with this mapping.
        /// </summary>
        public virtual NotificationSqlModel Notification { get; set; }

        /// <summary>
        /// The id of the user who created this user group-notification mapping.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user who created this user group-notification mapping.
        /// </summary>
        public virtual UserSqlModel CreatedBy { get; set; }
    }
}