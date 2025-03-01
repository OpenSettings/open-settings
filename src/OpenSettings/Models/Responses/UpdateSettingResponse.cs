using System;

namespace OpenSettings.Models.Responses
{
    public class UpdateSettingResponse
    {
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}