using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DeleteUserRequest
    {
        [FromRoute]
        public string UserId { get; set; }
    }
}