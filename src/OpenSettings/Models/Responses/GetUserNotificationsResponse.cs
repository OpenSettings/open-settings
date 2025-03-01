using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class GetUserNotificationsResponse
    {
        public GetUserNotificationsResponseNotificationCounts NotificationCounts { get; set; }

        public List<GetUserNotificationsResponseNotification> Notifications { get; set; }
    }
}