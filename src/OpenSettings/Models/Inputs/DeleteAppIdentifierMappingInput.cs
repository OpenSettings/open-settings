using System;

namespace OpenSettings.Models.Inputs
{
    public class DeleteAppIdentifierMappingInput
    {
        public Guid AppId { get; set; }

        public Guid IdentifierId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}