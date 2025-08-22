using System;

namespace OpenSettings.Models.Responses
{
    public class GetConfigsDataResponse
    {
        /// <summary>
        /// e.g. "public, max-age=3600"
        /// </summary>
        public string CacheControl { get; set; }

        /// <summary>
        /// e.g. "Thu, 26 Jun 2025 14:14:56 GMT"
        /// </summary>
        public string Expires { get; set; }

        /// <summary>
        /// A non-negative integer that represents the time in seconds for which the object was in a cache.
        /// e.g. 0
        /// </summary>
        public int Age { get; set; }

        public byte[] Data { get; set; } = Array.Empty<byte>();
    }
}