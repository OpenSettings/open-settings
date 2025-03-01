using System;

namespace OpenSettings.Models.Responses
{
    public class UpdateSettingDataResponseSetting
    {
        public Guid ComputedIdentifier { get; set; }

        public string IdentifierName { get; set; }

        public string CurrentVersion { get; set; }

        public string PreviousVersion { get; set; }

        public bool DataValidationDisabled { get; set; }

        public bool DataRestored { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}