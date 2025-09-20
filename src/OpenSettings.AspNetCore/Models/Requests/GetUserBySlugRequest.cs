using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetUserBySlugRequest
    {
        [FromRoute]
        public string UserSlug { get; set; }
    }
}