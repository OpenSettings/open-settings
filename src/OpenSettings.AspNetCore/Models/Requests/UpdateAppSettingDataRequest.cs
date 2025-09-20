using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppSettingDataRequest
    {
        [FromRoute]
        public string AppSettingId { get; set; }

        [FromBody]
        public UpdateAppSettingDataRequestBody Body { get; set; }
    }
}