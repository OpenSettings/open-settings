using Microsoft.AspNetCore.Mvc;
using OpenSettings.Models;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetNotificationsRequest
    {
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