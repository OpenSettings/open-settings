using System;

namespace OpenSettings.Models.Inputs
{
    public class UpdateSettingDataInput
    {
        public string SettingId { get; set; }

        public string Data { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Guid? UpdatedById { get; set; }
    }
}