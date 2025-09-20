using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetGroupedAppDataByAppSlugRequest
    {
        [FromRoute]
        public string AppSlug { get; set; }
    }
}