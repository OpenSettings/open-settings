using System;
using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class GetOpenSettingsNotificationsResponse
    {
        public string CacheControl { get; set; }

        public string Expires { get; set; }

        public bool IsFaulted { get; set; }

        public Dictionary<Guid, GetOpenSettingsNotificationsResponseNotification> IdToNotification { get; set; } = new Dictionary<Guid, GetOpenSettingsNotificationsResponseNotification>();
    }
}