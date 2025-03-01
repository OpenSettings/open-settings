using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetGroupedAppDataByAppAndIdentifierRequest
    {
        [FromRoute]
        public string AppIdOrSlug { get; set; }

        [FromRoute]
        public string IdentifierIdOrSlug { get; set; }
    }
}