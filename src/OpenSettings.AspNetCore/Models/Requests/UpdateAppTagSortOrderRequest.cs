using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppTagSortOrderRequest
    {
        [FromRoute]
        public Guid AppTagId { get; set; }

        [FromBody]
        public UpdateSortOrderRequestBody Body { get; set; }
    }
}