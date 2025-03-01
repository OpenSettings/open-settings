using System;
using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class GetAvailableNotificationsResponse
    {
        public Dictionary<Guid, GetNotificationsResponseNotification> NotificationIdToNotification { get; set; } = new Dictionary<Guid, GetNotificationsResponseNotification>();

        public List<GetUserNotificationsResponseNotification> UserNotifications { get; set; } = new List<GetUserNotificationsResponseNotification>();
    }
}