using System;

namespace OpenSettings.Models.Inputs
{
    public class DeleteGroupInput
    {
        public Guid AppGroupId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}