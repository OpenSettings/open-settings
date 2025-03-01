using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppsRequest
    {
        [FromQuery]
        public string SearchTerm { get; set; }
    }
}