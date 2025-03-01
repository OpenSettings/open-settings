using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppRequest
    {
        [FromRoute]
        public string AppIdOrSlug { get; set; }
    }
}