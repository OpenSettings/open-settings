using System;

namespace OpenSettings.Models.Responses
{
    public class GetSettingByIdResponse
    {
        public string Data { get; set; }
        
        public bool DataRestored { get; set; }

        public string IdentifierId { get; set; }

        public RegistrationMode RegistrationMode { get; set; }

        public bool DataValidationDisabled { get; set; }

        public bool StoreInSeparateFile { get; set; }

        public bool? IgnoreOnFileChange { get; set; }

        public Guid ComputedIdentifier { get; set; }

        public string Version { get; set; }

        public GetSettingByIdResponseClass Class { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}