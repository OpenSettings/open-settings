using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetTagRequest
    {
        [FromRoute]
        public string TagIdOrSlug { get; set; }
    }
}