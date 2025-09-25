using System;

namespace OpenSettings.Models.Inputs
{
    public class UpdateAppTagSortOrderInput
    {
        public Guid AppTagId { get; set; }

        public MoveDirection Direction { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Guid? UpdatedById { get; set; }
    }
}