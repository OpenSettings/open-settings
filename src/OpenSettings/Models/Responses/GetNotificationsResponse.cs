using System;

namespace OpenSettings.Models.Responses
{
    public class GetNotificationsResponse
    {
        public GetNotificationsResponseNotification[] Notifications { get; set; } = Array.Empty<GetNotificationsResponseNotification>();
    }
}