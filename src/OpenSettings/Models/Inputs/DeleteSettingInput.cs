using System;

namespace OpenSettings.Models.Inputs
{
    public class DeleteSettingInput
    {
        public Guid AppSettingId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}