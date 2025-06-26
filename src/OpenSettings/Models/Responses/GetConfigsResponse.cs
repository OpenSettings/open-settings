using System;

namespace OpenSettings.Models.Responses
{
    public class GetConfigsResponse
    {
        /// <summary>
        /// e.g. "public, max-age=3600"
        /// </summary>
        public string CacheControl { get; set; }

        /// <summary>
        /// e.g. "Thu, 26 Jun 2025 14:14:56 GMT"
        /// </summary>
        public string Expires { get; set; }

        public byte[] Data { get; set; } = Array.Empty<byte>();
    }
}