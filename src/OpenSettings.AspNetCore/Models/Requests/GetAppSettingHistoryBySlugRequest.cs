using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppSettingHistoryBySlugRequest
    {
        [FromRoute]
        public string Slug { get; set; }
    }
}