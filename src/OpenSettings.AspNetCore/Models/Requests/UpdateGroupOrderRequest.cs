using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppGroupSortOrderRequest
    {
        [FromRoute]
        public string GroupId { get; set; }

        [Required, FromQuery]
        public bool Ascent { get; set; }

        [Required, FromQuery]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}