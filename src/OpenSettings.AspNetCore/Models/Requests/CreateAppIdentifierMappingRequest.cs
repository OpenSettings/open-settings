using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateAppIdentifierMappingRequest
    {
        [FromRoute]
        public string AppId { get; set; }

        [FromBody]
        public CreateAppIdentifierMappingRequestBody Body { get; set; }
    }
}