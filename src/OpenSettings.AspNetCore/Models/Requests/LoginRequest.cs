using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class LoginRequest
    {
        [FromQuery]
        public string ReturnUrl { get; set; }

        [FromQuery]
        public string ApiUrl { get; set; }

        [FromQuery]
        public string Uuid { get; set; }
    }
}