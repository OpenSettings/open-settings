using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppGroupSortOrderRequest
    {
        [FromRoute]
        public Guid AppGroupId { get; set; }

        [FromBody]
        public UpdateSortOrderRequestBody Body { get; set; }
    }
}