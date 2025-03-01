using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateSettingDataRequestBody
    {
        public string Data { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}