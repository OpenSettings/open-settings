using System;

namespace OpenSettings.Models.Inputs
{
    public class UpdateGroupSortOrderInput
    {
        public Guid AppGroupId { get; set; }

        public bool Ascent { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Guid? UpdatedById { get; set; }
    }
}