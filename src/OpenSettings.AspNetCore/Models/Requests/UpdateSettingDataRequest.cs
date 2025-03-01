using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateSettingDataRequest
    {
        [FromRoute]
        public string SettingId { get; set; }

        [FromBody]
        public UpdateSettingDataRequestBody Body { get; set; }
    }
}