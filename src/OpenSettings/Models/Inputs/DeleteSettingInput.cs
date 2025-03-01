using System;

namespace OpenSettings.Models.Inputs
{
    public class DeleteSettingInput
    {
        public string SettingId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}