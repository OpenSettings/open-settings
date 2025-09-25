using System;

namespace OpenSettings.Models.Inputs
{
    public class UpdateIdentifierSortOrderInput
    {
        public Guid IdentifierId { get; set; }

        public MoveDirection Direction { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Guid? UpdatedById { get; set; }
    }
}