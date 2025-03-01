using System;

namespace OpenSettings.Models.Inputs
{
    public class UpdateTagSortOrderInput
    {
        public string TagId { get; set; }

        public bool Ascent { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Guid? UpdatedById { get; set; }
    }
}