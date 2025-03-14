﻿using System;

namespace OpenSettings.Models.Responses
{
    public class GetGroupedAppDataResponseSetting
    {
        public string Id { get; set; }

        public Guid ComputedIdentifier { get; set; }

        public string Version { get; set; }

        public bool DataValidationDisabled { get; set; }

        public bool DataRestored { get; set; }

        public GetGroupedAppDataResponseSettingClass Class { get; set; }

        public bool StoreInSeparateFile { get; set; }

        public bool? IgnoreOnFileChange { get; set; }

        public RegistrationMode RegistrationMode { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}