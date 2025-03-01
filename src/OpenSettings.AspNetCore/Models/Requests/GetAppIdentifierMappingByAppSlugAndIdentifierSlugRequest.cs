using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppIdentifierMappingByAppAndIdentifierRequest
    {
        [FromRoute]
        public string AppIdOrSlug { get; set; }

        [FromRoute]
        public string IdentifierIdOrSlug { get; set; }
    }
}