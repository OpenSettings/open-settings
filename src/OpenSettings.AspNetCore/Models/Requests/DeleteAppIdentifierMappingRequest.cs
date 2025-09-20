using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DeleteAppIdentifierMappingRequest
    {
        [FromRoute]
        public Guid AppId { get; set; }

        [FromRoute]
        public Guid IdentifierId { get; set; }

        [FromQuery]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}