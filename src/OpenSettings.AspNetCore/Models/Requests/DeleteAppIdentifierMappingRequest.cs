using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DeleteAppIdentifierMappingRequest
    {
        [FromRoute]
        public string AppId { get; set; }

        [FromRoute]
        public string IdentifierId { get; set; }

        [FromQuery]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}