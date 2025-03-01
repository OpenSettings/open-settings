using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class MarkNotificationAsRequest
    {
        public Guid NotificationId { get; set; }

        public Guid UserId { get; set; }
    }
}