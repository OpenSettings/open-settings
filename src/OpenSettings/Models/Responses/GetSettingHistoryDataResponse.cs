using System;

namespace OpenSettings.Models.Responses
{
    public class GetSettingHistoryDataResponse
    {
        public string Data { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}