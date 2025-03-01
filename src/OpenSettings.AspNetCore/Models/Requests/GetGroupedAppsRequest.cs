using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetGroupedAppsRequest
    {
        [FromQuery]
        public string GroupId { get; set; }

        [FromQuery]
        public string SearchTerm { get; set; }
    }
}