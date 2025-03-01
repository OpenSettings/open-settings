using System;
using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class GetOpenSettingsNotificationsResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public NotificationType Type { get; set; }

        public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();

        public DateTime CreatedOn { get; set; }
        
        public TimeSpan? ExpiresIn { get; set; }

        public bool IsExpired { get; set; }

        public string CreatedBy { get; set; }
    }
}