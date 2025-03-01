using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CopySettingToRequest
    {
        [FromRoute]
        public string SettingId { get; set; }

        [FromBody]
        public CopySettingToRequestBody Body { get; set; }
    }
}