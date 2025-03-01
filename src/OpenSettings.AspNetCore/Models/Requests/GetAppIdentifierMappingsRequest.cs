using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppIdentifierMappingsRequest
    {
        [FromRoute]
        public string AppIdOrSlug { get; set; }
    }
}