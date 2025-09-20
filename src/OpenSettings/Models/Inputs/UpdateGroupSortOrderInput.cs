using System;

namespace OpenSettings.Models.Inputs
{
    public class UpdateGroupSortOrderInput
    {
        public string AppGroupId { get; set; }

        public bool Ascent { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Guid? UpdatedById { get; set; }
    }
}