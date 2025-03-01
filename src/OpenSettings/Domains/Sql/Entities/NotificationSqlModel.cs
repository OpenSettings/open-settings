using OpenSettings.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a notification entity.
    /// </summary>
    [Table("Notifications")]
    public class NotificationSqlModel : EntityBase<Guid>
    {
        /// <summary>
        /// The title of the notification.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The message content of the notification.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The type of the notification, specifying its category or purpose.
        /// </summary>
        public NotificationType Type { get; set; }

        /// <summary>
        /// The source of the notification, indicating where it originated from.
        /// </summary>
        public NotificationSource Source { get; set; }

        /// <summary>
        /// Additional metadata associated with the notification, stored as key-value pairs.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// The duration after which the notification expires. If null, the notification does not expire.
        /// </summary>
        public TimeSpan? ExpiresIn { get; set; }

        /// <summary>
        /// Indicates whether the notification has expired.  
        /// If <c>true</c>, new user mappings will not be created for this notification.
        /// </summary>
        public bool IsExpired { get; set; }

        /// <summary>
        /// The date and time when the notification was marked as expired.
        /// </summary>
        public DateTime? ExpiredOn { get; set; }

        /// <summary>
        /// The name of the user who created this notification.
        /// </summary>
        public string CreatorName { get; set; }

        /// <summary>
        /// The id of the user who created this notification.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The id of the user who last updated this notification.
        /// </summary>
        public Guid? UpdatedById { get; set; }

        /// <summary>
        /// The user who created this notification.
        /// </summary>
        [ForeignKey(nameof(CreatedById))]
        public virtual UserSqlModel CreatedBy { get; set; }

        /// <summary>
        /// The user who last updated this notification.
        /// </summary>
        [ForeignKey(nameof(UpdatedById))]
        public virtual UserSqlModel UpdatedBy { get; set; }

        /// <summary>
        /// The collection of user-notification mappings associated with this notification.
        /// </summary>
        public virtual ICollection<UserNotificationMappingSqlModel> UserNotificationMappings { get; set; } = new List<UserNotificationMappingSqlModel>();

        /// <summary>
        /// The collection of user group-notification mappings associated with this notification.
        /// </summary>
        public virtual ICollection<UserGroupNotificationMappingSqlModel> UserGroupNotificationMappings { get; set; } = new List<UserGroupNotificationMappingSqlModel>();
    }
}