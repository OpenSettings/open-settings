using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateAppGroupRequest
    {
        [FromBody]
        public CreateAppGroupRequestBody Body { get; set; }
    }
}