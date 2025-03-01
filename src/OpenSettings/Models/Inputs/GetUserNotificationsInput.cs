using System;

namespace OpenSettings.Models.Inputs
{
    public class GetUserNotificationsInput
    {
        public Guid UserId { get; set; }

        public bool? IsOpened { get; set; }

        public bool? IsViewed { get; set; }

        public bool? IsDismissed { get; set; }

        public bool? IsExpired { get; set; }

        public NotificationType? Type { get; set; }

        public NotificationSource? Source { get; set; }

        public string PackVersion { get; set; }
    }
}