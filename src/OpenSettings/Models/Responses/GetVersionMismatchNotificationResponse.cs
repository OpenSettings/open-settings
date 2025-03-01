using System;

namespace OpenSettings.Models.Responses
{
    internal class InternalNotificationResponse
    {
        public Guid NotificationId { get; set; }

        public GetNotificationsResponseNotification Notification { get; set; }
    }
}