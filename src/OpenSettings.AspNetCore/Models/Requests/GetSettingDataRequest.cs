using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetSettingDataRequest
    {
        [FromRoute]
        public string SettingId { get; set; }
    }
}