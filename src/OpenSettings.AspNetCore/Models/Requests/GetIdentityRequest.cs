using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    internal class GetIdentityRequest
    {
        [FromQuery]
        public string ClaimTypes { get; set; }
    }
}