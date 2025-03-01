using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetSettingHistoryDataRequest
    {
        [FromRoute]
        public string HistoryId { get; set; }
    }
}