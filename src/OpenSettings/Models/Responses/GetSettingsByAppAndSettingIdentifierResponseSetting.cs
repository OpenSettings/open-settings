using System;

namespace OpenSettings.Models.Responses
{
    public class GetSettingsByAppAndIdentifierResponseSetting
    {
        public string Id { get; set; }

        public Guid ComputedIdentifier { get; set; }

        public string Version { get; set; }

        public bool DataValidationDisabled { get; set; }

        public bool DataRestored { get; set; }

        public GetSettingsByAppAndIdentifierResponseSettingClass Class { get; set; }
    }
}