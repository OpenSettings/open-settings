using System;

namespace OpenSettings.Models.Inputs
{
    public class UpdateSettingInput
    {
        public string SettingId { get; set; }

        public Guid ComputedIdentifier { get; set; }

        public bool DataValidationDisabled { get; set; }

        public bool StoreInSeparateFile { get; set; }

        public bool? IgnoreOnFileChange { get; set; }

        public RegistrationMode RegistrationMode { get; set; }

        public byte[] SettingRowVersion { get; set; } = Array.Empty<byte>();

        public string ClassNamespace { get; set; }

        public string ClassName { get; set; }

        public string ClassFullName { get; set; }

        public byte[] ClassRowVersion { get; set; } = Array.Empty<byte>();

        public Guid? UpdatedById { get; set; }
    }
}