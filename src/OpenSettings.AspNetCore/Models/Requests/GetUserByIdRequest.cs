using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetUserByIdRequest
    {
        [FromRoute]
        public string UserId { get; set; }
    }
}