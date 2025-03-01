using OpenSettings.Models.Inputs;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class SyncAppDataRequestBody
    {
        public SyncAppDataRequestClient Client { get; set; }

        public SyncAppDataInputConfiguration Configuration { get; set; }

        public SyncAppDataInputSetting[] Settings { get; set; } = Array.Empty<SyncAppDataInputSetting>();

        public SyncAppDataInputInstance Instance { get; set; }
    }
}