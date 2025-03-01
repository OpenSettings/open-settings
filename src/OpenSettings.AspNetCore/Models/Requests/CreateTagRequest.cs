using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateTagRequest
    {
        [FromBody]
        public CreateTagRequestBody Body { get; set; }
    }
}