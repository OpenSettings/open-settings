using System;

namespace OpenSettings.Models.Responses
{
    public class UpdateAppSettingResponse
    {
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}