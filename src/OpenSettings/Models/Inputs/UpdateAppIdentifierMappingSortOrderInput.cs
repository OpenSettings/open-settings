using System;

namespace OpenSettings.Models.Inputs
{
    public class UpdateAppIdentifierMappingSortOrderInput
    {
        public string AppId { get; set; }

        public string IdentifierId { get; set; }

        public bool Ascent { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Guid? UpdatedById { get; set; }
    }
}