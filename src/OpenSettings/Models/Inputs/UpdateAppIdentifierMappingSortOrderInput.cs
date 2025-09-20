using System;

namespace OpenSettings.Models.Inputs
{
    public class UpdateAppIdentifierMappingSortOrderInput
    {
        public Guid AppId { get; set; }

        public Guid IdentifierId { get; set; }

        public bool Ascent { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Guid? UpdatedById { get; set; }
    }
}