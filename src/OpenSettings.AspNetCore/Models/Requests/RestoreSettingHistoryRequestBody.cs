using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class RestoreSettingHistoryRequestBody
    {
        public byte[] HistoryRowVersion { get; set; } = Array.Empty<byte>();

        public byte[] SettingRowVersion { get; set; } = Array.Empty<byte>();
    }
}