using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppGroupByIdRequest
    {
        [FromRoute]
        public string AppGroupId { get; set; }
    }
}