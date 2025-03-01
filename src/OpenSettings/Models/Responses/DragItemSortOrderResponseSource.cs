using System;

namespace OpenSettings.Models.Responses
{
    public class DragItemSortOrderResponseSource
    {
        public int NewSortOrder { get; set; }

        public int OldSortOrder { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}