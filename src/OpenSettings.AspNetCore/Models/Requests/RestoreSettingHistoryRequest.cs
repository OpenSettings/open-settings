using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class RestoreSettingHistoryRequest
    {
        [FromRoute]
        public string HistoryId { get; set; }

        [FromBody]
        public RestoreSettingHistoryRequestBody Body { get; set; }
    }
}