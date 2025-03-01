using System;

namespace OpenSettings.Models.Inputs
{
    public class DragItemSortOrderInput
    {
        public string SourceId { get; set; }

        public string TargetId { get; set; }

        public bool Ascent { get; set; }

        public byte[] SourceRowVersion { get; set; } = Array.Empty<byte>();

        public Guid? UpdatedById { get; set; }
    }
}