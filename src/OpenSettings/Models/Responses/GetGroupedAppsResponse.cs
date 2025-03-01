using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class GetGroupedAppsResponse
    {
        public Dictionary<string, GetGroupedAppsResponseApp[]> GroupNameToApps { get; set; } = new Dictionary<string, GetGroupedAppsResponseApp[]>();

        public int GroupsCount { get; set; }

        public int AppsCount { get; set; }
    }
}