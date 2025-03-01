using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateIdentifierRequest
    {
        [FromRoute]
        public string IdentifierId { get; set; }

        [FromBody]
        public UpdateIdentifierRequestBody Body { get; set; }
    }
}