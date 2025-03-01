using System;

namespace OpenSettings.Models.Inputs
{
    public class SyncAppDataInputSetting
    {
        public string Data { get; set; }

        public Guid ComputedIdentifier { get; set; }

        public string Version { get; set; }

        public bool DataRestored { get; set; }

        public bool DataValidationDisabled { get; set; }

        public bool StoreInSeparateFile { get; set; }

        public bool? IgnoreOnFileChange { get; set; }

        public RegistrationMode RegistrationMode { get; set; }

        public SyncAppDataInputSettingClass SettingClass { get; set; }

        public int HashCode { get; set; }

        public override int GetHashCode()
        {
            return 0;

            var hash = 17;

            hash = hash * 31 + (Data?.GetHashCode() ?? 0);
            hash = hash * 31 + (Version?.GetHashCode() ?? 0);

            return hash;
        }
    }
}