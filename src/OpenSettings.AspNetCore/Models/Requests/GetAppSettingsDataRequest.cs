using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppSettingsDataRequest
    {
        [FromRoute]
        public string AppId { get; set; }

        [FromQuery]
        public string IdentifierId { get; set; }

        [FromQuery]
        public string Ids { get; set; }
    }
}