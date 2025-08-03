using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class LogoutRequest
    {
        [FromQuery]
        public string ReturnUrl { get; set; }

        [FromQuery]
        public string ApiUrl { get; set; }
    }
}