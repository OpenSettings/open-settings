using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppTagBySlugRequest
    {
        [FromRoute]
        public string Slug { get; set; }
    }
}