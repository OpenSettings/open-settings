using System;

namespace OpenSettings.Models.Responses
{
    public class GetConfigsDataResponse
    {
        public string CacheControl { get; set; }

        public string Expires { get; set; }

        public byte[] Data { get; set; } = Array.Empty<byte>();
    }
}