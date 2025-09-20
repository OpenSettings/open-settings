using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppSettingHistoryByIdRequest
    {
        [FromRoute]
        public string AppSettingHistoryId { get; set; }
    }
}