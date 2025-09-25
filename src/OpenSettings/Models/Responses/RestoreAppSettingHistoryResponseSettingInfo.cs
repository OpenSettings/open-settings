using System;

namespace OpenSettings.Models.Responses
{
    public class RestoreAppSettingHistoryResponseSettingInfo
    {
        public string Version { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}