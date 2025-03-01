using System.Collections.Generic;

namespace OpenSettings.Models
{
    public class OpenSettingsConfigModel
    {
        public int ExpiresInSeconds { get; set; }

        public Dictionary<string, OpenSettingsConfigsDataModel> Data { get; set; } = new Dictionary<string, OpenSettingsConfigsDataModel>();
    }
}