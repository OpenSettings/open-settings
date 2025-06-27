using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetUserRequest
    {
        [FromRoute]
        public string UserIdOrSlug { get; set; }
    }
}