using System;

namespace OpenSettings.Models
{
    public class ConfigurationConsumerPollingSettingsWorker
    {
        public bool IsActive { get; set; }

        public TimeSpan StartsIn { get; set; }
        
        public TimeSpan Period { get; set; }
    }
}