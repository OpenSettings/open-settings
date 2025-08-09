using System;

namespace OpenSettings.Models
{
    public class OpenSettingsConfigsDataCacheModel<T>
    {
        public T Data { get; set; }

        public double ExpiresInSeconds { get; set; }

        public DateTimeOffset AbsoluteExpiration { get; set; }
    }
}