using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppGroupBySlug
    {
        [FromRoute]
        public string AppGroupSlug { get; set; }
    }
}