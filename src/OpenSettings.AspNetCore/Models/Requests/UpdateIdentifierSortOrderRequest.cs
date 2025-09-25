using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateIdentifierSortOrderRequest
    {
        [FromRoute]
        public Guid IdentifierId { get; set; }

        [FromBody]
        public UpdateSortOrderRequestBody Body { get; set; }
    }
}