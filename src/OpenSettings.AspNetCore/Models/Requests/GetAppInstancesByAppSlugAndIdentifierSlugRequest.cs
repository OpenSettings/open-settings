using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppInstancesByAppSlugAndIdentifierSlugRequest
    {
        [FromRoute]
        public string AppSlug { get; set; }

        [FromRoute]
        public string IdentifierSlug { get; set; }
    }
}