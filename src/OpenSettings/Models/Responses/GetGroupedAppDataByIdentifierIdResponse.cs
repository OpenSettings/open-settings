using System;

namespace OpenSettings.Models.Responses
{
    public class GetGroupedAppDataByIdentifierIdResponse
    {
        public GetGroupedAppDataByIdentifierIdResponseIdentifier Identifier { get; set; }

        public GetGroupedAppDataByIdentifierIdResponseConfiguration Configuration { get; set; }

        public GetGroupedAppDataByIdentifierIdResponseSetting[] Settings { get; set; } = Array.Empty<GetGroupedAppDataByIdentifierIdResponseSetting>();

        public GetGroupedAppDataByIdentifierIdResponseInstance[] Instances { get; set; } = Array.Empty<GetGroupedAppDataByIdentifierIdResponseInstance>();
    }
}