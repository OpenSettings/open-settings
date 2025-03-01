using System;
using System.Collections.Generic;

namespace OpenSettings.Models.Inputs
{
    public class SyncAppDataInputInstance
    {
        private string _instanceName = Constants.DefaultInstanceName;

        public string InstanceName
        {
            get => _instanceName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _instanceName = value;
                }
            }
        }

        public string DynamicId { get; set; }

        public string[] Urls { get; set; } = Array.Empty<string>();

        public string MachineName { get; set; }

        public string Environment { get; set; }

        public List<ReloadStrategy> ReloadStrategies { get; set; } = new List<ReloadStrategy>();

        public ServiceType ServiceType { get; set; }

        public DataAccessType? DataAccessType { get; set; }

        public string Version { get; set; }

        public bool IsDisabled { get; set; }
    }
}