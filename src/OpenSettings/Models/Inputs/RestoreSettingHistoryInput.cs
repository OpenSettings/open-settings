using System;

namespace OpenSettings.Models.Inputs
{
    public class RestoreSettingHistoryInput
    {
        public string AppSettingHistoryId { get; set; }

        // For safety!
        public byte[] SettingRowVersion { get; set; } = Array.Empty<byte>();

        public byte[] HistoryRowVersion { get; set; } = Array.Empty<byte>();

        public Guid? UserId { get; set; }
    }
}