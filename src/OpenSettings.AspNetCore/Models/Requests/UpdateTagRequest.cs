using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateTagRequest
    {
        [FromRoute]
        public string TagId { get; set; }

        [FromBody]
        public UpdateTagRequestBody Body { get; set; }
    }
}