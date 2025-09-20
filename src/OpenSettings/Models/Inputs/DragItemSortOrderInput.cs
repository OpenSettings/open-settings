using System;

namespace OpenSettings.Models.Inputs
{
    public class DragItemSortOrderInput
    {
        public Guid SourceId { get; set; }

        public Guid TargetId { get; set; }

        public bool Ascent { get; set; }

        public byte[] SourceRowVersion { get; set; } = Array.Empty<byte>();

        public Guid? UpdatedById { get; set; }
    }
}