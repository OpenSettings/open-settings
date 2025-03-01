using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a user-notification mapping entity.
    /// </summary>
    [Table("UserNotificationMappings")]
    public class UserNotificationMappingSqlModel : EntityBase<int>
    {
        /// <summary>
        /// The id of the associated user.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The id of the associated notification.
        /// </summary>
        public Guid NotificationId { get; set; }

        /// <summary>
        /// The id of the user who created this user notification mapping.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the notification has been opened.
        /// </summary>
        public bool IsOpened { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the notification was opened.
        /// If the notification has not been opened, this value is null.
        /// </summary>
        public DateTime? OpenedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the notification has been viewed.
        /// A notification is considered viewed if the user has seen it or interacted with it.
        /// </summary>
        public bool IsViewed { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the notification was viewed.
        /// If the notification has not been viewed, this value is null.
        /// </summary>
        public DateTime? ViewedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the notification has been dismissed by the user.
        /// </summary>
        public bool IsDismissed { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the notification was dismissed.
        /// If the notification has not been dismissed, this value is null.
        /// </summary>
        public DateTime? DismissedOn { get; set; }

        /// <summary>
        /// The user associated with this mapping.
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public virtual UserSqlModel User { get; set; }

        /// <summary>
        /// The notification associated with this mapping.
        /// </summary>
        [ForeignKey(nameof(NotificationId))]
        public virtual NotificationSqlModel Notification { get; set; }

        /// <summary>
        /// The user who created this user-notification mapping.
        /// </summary>
        [ForeignKey(nameof(CreatedById))]
        public virtual UserSqlModel CreatedBy { get; set; }

        [NotMapped]
        public new int Id { get; set; }
    }
}