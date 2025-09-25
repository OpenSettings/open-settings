using System;
using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppIdentifierMappingSortOrderRequest
    {
        [FromRoute]
        public Guid AppId { get; set; }

        [FromRoute]
        public Guid IdentifierId { get; set; }

        [FromBody]
        public UpdateSortOrderRequestBody Body { get; set; }
    }
}