using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppIdentifierMappingsByAppSlugRequest
    {
        [FromRoute]
        public string AppSlug { get; set; }
    }
}