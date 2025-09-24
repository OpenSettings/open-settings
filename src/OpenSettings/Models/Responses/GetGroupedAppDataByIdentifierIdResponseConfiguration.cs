using System;

namespace OpenSettings.Models.Responses
{
    public class GetGroupedAppDataByIdentifierIdResponseConfiguration
    {
        public string Id { get; set; }

        public bool StoreInSeparateFile { get; set; }

        public bool IgnoreOnFileChange { get; set; }

        public RegistrationMode RegistrationMode { get; set; }

        public ConfigurationConsumer Consumer { get; set; }

        public ConfigurationProvider Provider { get; set; }

        public ConfigurationController Controller { get; set; }

        public ConfigurationSpa Spa { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}