using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class IsAuthenticatedRequest
    {
        [FromQuery]
        public string Uuid { get; set; }
    }
}