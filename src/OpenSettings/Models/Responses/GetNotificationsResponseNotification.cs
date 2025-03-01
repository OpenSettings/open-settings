using System;
using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class GetNotificationsResponseNotification
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public NotificationType Type { get; set; }

        public NotificationSource Source { get; set; }

        public Dictionary<string, object> Metadata { get; set; }

        public bool IsExpired { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorName { get; set; }
    }
}