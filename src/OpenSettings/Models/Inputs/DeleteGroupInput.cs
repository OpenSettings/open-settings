using System;

namespace OpenSettings.Models.Inputs
{
    public class DeleteGroupInput
    {
        public string GroupId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}