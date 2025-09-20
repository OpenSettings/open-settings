using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetGroupedAppDataByAppSlugAndIdentifierSlugRequest
    {
        [FromRoute]
        public string AppSlug { get; set; }

        [FromRoute]
        public string IdentifierSlug { get; set; }
    }
}