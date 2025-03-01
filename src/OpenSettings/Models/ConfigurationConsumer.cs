using Ogu.Compressions.Abstractions;
using System.Collections.Generic;

namespace OpenSettings.Models
{
    public class ConfigurationConsumer
    {
        public HashSet<CompressionType> RequestEncodings { get; set; } = new HashSet<CompressionType>();

        public bool IsRedisActive { get; set; }

        public ConfigurationConsumerPollingSettingsWorker PollingSettingsWorker { get; set; } = new ConfigurationConsumerPollingSettingsWorker();
    }
}