using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetSettingHistoryRequest
    {
        [FromRoute]
        public string HistoryIdOrSlug { get; set; }
    }
}