using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetSettingByIdRequest
    {
        [FromRoute]
        public string SettingId { get; set; }

        [FromQuery]
        public string Excludes { get; set; }
    }
}