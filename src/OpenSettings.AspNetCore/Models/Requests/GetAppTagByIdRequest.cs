using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppTagByIdRequest
    {
        [FromRoute]
        public string AppTagId { get; set; }
    }
}