using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateIdentifierSortOrderRequest
    {
        [FromRoute]
        public string IdentifierId { get; set; }

        [FromQuery, Required]
        public bool Ascent { get; set; }

        [FromQuery, Required]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}