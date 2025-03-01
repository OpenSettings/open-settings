using System;

namespace OpenSettings.Models.Inputs
{
    public class DeleteAppIdentifierMappingInput
    {
        public string AppId { get; set; }

        public string IdentifierId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}