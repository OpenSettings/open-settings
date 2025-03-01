using System;

namespace OpenSettings.Models.Responses
{
    public class RestoreSettingHistoryResponse
    {
        public Guid ClientId { get; set; }

        public RestoreSettingHistoryResponseSetting Setting { get; set; }

        public byte[] HistoryRowVersion { get; set; } = Array.Empty<byte>();
    }
}