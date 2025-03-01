using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppIdentifierMappingSortOrderRequest
    {
        [FromRoute]
        public string AppId { get; set; }

        [FromRoute]
        public string IdentifierId { get; set; }

        [FromBody]
        public UpdateAppIdentifierMappingOrderRequestBody Body { get; set; }
    }
}