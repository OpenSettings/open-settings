using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DragItemSortOrderRequest
    {
        [FromRoute]
        public Guid SourceId { get; set; }

        [FromRoute]
        public Guid TargetId { get; set; }

        [FromQuery]
        public bool Ascent { get; set; }

        [FromQuery, Required]
        public byte[] SourceRowVersion { get; set; } = Array.Empty<byte>();
    }
}