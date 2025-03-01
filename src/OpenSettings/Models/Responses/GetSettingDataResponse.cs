using System;

namespace OpenSettings.Models.Responses
{
    public class GetSettingDataResponse
    {
        public string Data { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}