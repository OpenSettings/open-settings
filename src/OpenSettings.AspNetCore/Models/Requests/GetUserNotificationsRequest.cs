using Microsoft.AspNetCore.Mvc;
using OpenSettings.Models;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetUserNotificationsRequest
    {
        [FromRoute]
        public Guid UserId { get; set; }

        [FromQuery]
        public bool? IsOpened { get; set; }

        [FromQuery]
        public bool? IsViewed { get; set; }

        [FromQuery]
        public bool? IsDismissed { get; set; }

        [FromQuery]
        public bool? IsExpired { get; set; }

        [FromQuery]
        public NotificationType? Type { get; set; }

        [FromQuery]
        public NotificationSource? Source { get; set; }
    }
}