using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DragItemSortOrderRequest
    {
        [FromRoute]
        public Guid SourceId { get; set; }

        [FromRoute]
        public Guid TargetId { get; set; }

        [FromBody]
        public DragItemSortOrderRequestBody Body { get; set; }
    }
}