using System;
using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class SyncAppDataResponse
    {
        public ICollection<SyncAppDataResponseSetting> Settings { get; set; } = Array.Empty<SyncAppDataResponseSetting>();

        public ProviderInfo ProviderInfo { get; set; }
        
        public SyncAppDataResponseConfiguration Configuration { get; set; }
    }
}