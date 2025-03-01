using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetGroupedAppDataByAppRequest
    {
        [FromRoute]
        public string AppIdOrSlug { get; set; }
    }
}