using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetSettingHistoriesRequest
    {
        [FromRoute]
        public string SettingId { get; set; }

        [FromQuery]
        public string Excludes { get; set; }
    }
}