using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppBySlugRequest
    {
        [FromRoute]
        public string Slug { get; set; }
    }
}