using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DeleteAppRequest
    {
        [FromRoute]
        public string AppId { get; set; }

        [FromQuery]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}