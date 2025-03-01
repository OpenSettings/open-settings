using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateAppRequest
    {
        [FromBody]
        public CreateAppRequestBody Body { get; set; }
    }
}