using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppGroupRequest
    {
        [FromRoute]
        public string GroupIdOrSlug { get; set; }
    }
}