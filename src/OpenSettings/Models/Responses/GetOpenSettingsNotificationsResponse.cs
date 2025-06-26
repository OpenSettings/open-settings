using System;
using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class GetOpenSettingsNotificationsResponse
    {
        public Dictionary<Guid, GetOpenSettingsNotificationsResponseNotification> IdToNotification { get; set; } = new Dictionary<Guid, GetOpenSettingsNotificationsResponseNotification>();

        public string CacheControl { get; set; }

        public string Expires { get; set; }
    }
}