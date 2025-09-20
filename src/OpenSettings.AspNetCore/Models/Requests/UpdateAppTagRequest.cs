using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppTagRequest
    {
        [FromRoute]
        public string AppTagId { get; set; }

        [FromBody]
        public UpdateAppTagRequestBody Body { get; set; }
    }
}