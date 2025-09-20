using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateAppSettingRequest
    {
        [FromBody]
        public CreateAppSettingRequestBody Body { get; set; }
    }
}