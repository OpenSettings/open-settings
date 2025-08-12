using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class ReturnToRequest
    {
        [FromQuery]
        public string ReturnUrl { get; set; }

        [FromQuery]
        public string AccessToken { get; set; }

        [FromQuery]
        public string Uuid { get; set; }
    }
}