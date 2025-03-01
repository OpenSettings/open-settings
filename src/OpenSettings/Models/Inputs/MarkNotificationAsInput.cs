using System;

namespace OpenSettings.Models.Inputs
{
    public class MarkNotificationAsInput
    {
        public Guid NotificationId { get; set; }

        public Guid UserId { get; set; }
    }
}