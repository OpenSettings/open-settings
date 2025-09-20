using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateAppTagRequest
    {
        [FromBody]
        public CreateAppTagRequestBody Body { get; set; }
    }
}