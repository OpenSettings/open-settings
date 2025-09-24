using System;

namespace OpenSettings.Models.Responses
{
    public class RestoreAppSettingHistoryResponse
    {
        public Guid ClientId { get; set; }

        public RestoreAppSettingHistoryResponseSetting Setting { get; set; }

        public byte[] HistoryRowVersion { get; set; } = Array.Empty<byte>();
    }
}