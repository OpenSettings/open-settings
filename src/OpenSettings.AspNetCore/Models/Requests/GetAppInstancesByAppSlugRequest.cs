using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppInstancesByAppSlugRequest
    {
        [FromRoute]
        public string AppSlug { get; set; }

        [FromQuery]
        public string IdentifierId { get; set; }
    }
}