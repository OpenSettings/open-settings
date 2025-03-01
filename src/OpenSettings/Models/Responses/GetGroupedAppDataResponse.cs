using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class GetGroupedAppDataResponse
    {
        public GetGroupedAppDataResponseIdentifierInfo IdentifierInfo { get; set; }

        public Dictionary<string, GetGroupedAppDataResponseIdentifier> IdentifierIdToIdentifier { get; set; } = new Dictionary<string, GetGroupedAppDataResponseIdentifier>();

        public Dictionary<string, GetGroupedAppDataResponseConfiguration> IdentifierIdToConfiguration { get; set; } = new Dictionary<string, GetGroupedAppDataResponseConfiguration>();

        public Dictionary<string, GetGroupedAppDataResponseSetting[]> IdentifierIdToSettings { get; set; } = new Dictionary<string, GetGroupedAppDataResponseSetting[]>();

        public Dictionary<string, GetGroupedAppDataResponseInstance[]> IdentifierIdToInstances { get; set; } = new Dictionary<string, GetGroupedAppDataResponseInstance[]>();
    }
}