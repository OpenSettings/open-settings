using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppGroupsRequest
    {
        [FromQuery]
        public string SearchTerm { get; set; }

        [FromQuery]
        public bool? HasMappings { get; set; }
    }
}