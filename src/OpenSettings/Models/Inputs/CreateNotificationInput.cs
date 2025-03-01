using System;

namespace OpenSettings.Models.Inputs
{
    public class CreateNotificationInput
    {
        public Guid? Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public NotificationType Type { get; set; }

        public NotificationSource Source { get; set; }

        public TimeSpan? ExpiresIn { get; set; }

        public Guid? CreatedById { get; set; }
    }
}