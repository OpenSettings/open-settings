using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateTagSortOrderRequest
    {
        [FromRoute]
        public string TagId { get; set; }

        [FromQuery]
        public bool Ascent { get; set; }

        [FromQuery, Required]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}