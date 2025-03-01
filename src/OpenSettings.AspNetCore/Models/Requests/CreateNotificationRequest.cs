using Microsoft.AspNetCore.Mvc;
using OpenSettings.AspNetCore.Controllers.v1;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateNotificationRequest
    {
        [FromBody]
        public CreateNotificationRequestBody Body { get; set; }
    }
}