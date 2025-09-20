using System;

namespace OpenSettings.Models.Inputs
{
    public class DeleteGroupInput
    {
        public string AppGroupId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}