using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppInstancesByAppIdRequest
    {
        [FromRoute]
        public string AppId { get; set; }

        [FromQuery]
        public string IdentifierId { get; set; }
    }
}