using System;

namespace OpenSettings.Models.Responses
{
    public class SyncAppDataResponseSetting
    {
        public Guid ComputedIdentifier { get; set; }

        public string Data { get; set; }

        public bool StoreInSeparateFile { get; set; }

        public bool? IgnoreOnFileChange { get; set; }

        public RegistrationMode RegistrationMode { get; set; }
    }
}