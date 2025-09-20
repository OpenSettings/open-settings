using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppSettingHistoryDataRequest
    {
        [FromRoute]
        public string AppSettingHistoryId { get; set; }
    }
}