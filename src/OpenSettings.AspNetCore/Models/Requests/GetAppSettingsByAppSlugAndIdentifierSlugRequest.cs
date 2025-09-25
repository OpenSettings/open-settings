using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppSettingsByAppSlugAndIdentifierSlugRequest
    {
        [FromRoute]
        public string AppSlug { get; set; }

        [FromRoute]
        public string IdentifierSlug { get; set; }
    }
}