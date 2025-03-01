using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetInstancesByAppRequest
    {
        [FromRoute]
        public string AppIdOrAppSlug { get; set; }

        [FromQuery]
        public string IdentifierId { get; set; }
    }
}