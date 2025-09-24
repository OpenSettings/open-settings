using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class GetGroupedAppsResponse
    {
        public int GroupCount { get; set; }

        public int AppCount { get; set; }

        public Dictionary<string, GetGroupedAppsResponseApp[]> GroupNameToApps { get; set; } = new Dictionary<string, GetGroupedAppsResponseApp[]>();
    }
}