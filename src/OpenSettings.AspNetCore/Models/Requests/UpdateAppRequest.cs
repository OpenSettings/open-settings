using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppRequest
    {
        [FromRoute]
        public string AppId { get; set; }

        [FromBody]
        public UpdateAppRequestBody Body { get; set; } 
    }
}