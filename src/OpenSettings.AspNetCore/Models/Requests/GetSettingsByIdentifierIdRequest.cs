using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetSettingsByAppAndIdentifierRequest
    {
        [FromRoute]
        public string AppIdOrAppSlug { get; set; }

        [FromRoute]
        public string IdentifierIdOrSlug { get; set; }
    }
}