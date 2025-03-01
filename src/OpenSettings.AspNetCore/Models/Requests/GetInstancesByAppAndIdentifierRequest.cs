using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetInstancesByAppAndIdentifierRequest
    {
        [FromRoute]
        public string AppIdOrSlug { get; set; }

        [FromRoute]
        public string IdentifierIdOrSlug { get; set; }
    }
}