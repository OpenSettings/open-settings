using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateSettingRequest
    {
        [FromBody]
        public CreateSettingRequestBody Body { get; set; }
    }
}