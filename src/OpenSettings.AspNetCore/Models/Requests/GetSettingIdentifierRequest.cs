using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetIdentifierRequest
    {
        [FromRoute]
        public string IdentifierIdOrSlug { get; set; }
    }
}