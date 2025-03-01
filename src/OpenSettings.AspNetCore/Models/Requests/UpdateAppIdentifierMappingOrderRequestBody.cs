using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppIdentifierMappingOrderRequestBody
    {
        public bool Ascent { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}