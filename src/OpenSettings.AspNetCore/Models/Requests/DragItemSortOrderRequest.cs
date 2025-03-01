using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DragItemSortOrderRequest
    {
        [FromRoute]
        public string SourceId { get; set; }

        [FromRoute]
        public string TargetId { get; set; }

        [FromQuery]
        public bool Ascent { get; set; }

        [FromQuery, Required]
        public byte[] SourceRowVersion { get; set; } = Array.Empty<byte>();
    }
}