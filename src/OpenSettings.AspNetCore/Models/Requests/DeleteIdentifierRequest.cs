using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DeleteIdentifierRequest
    {
        [FromRoute]
        public string IdentifierId { get; set; }

        [FromQuery]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}