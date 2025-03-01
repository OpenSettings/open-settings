using OpenSettings.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateSettingRequestBody
    {
        [Required]
        public Guid ComputedIdentifier { get; set; }

        public bool DataValidationDisabled { get; set; }

        public bool StoreInSeparateFile { get; set; }

        public bool? IgnoreOnFileChange { get; set; }

        public RegistrationMode RegistrationMode { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public UpdateSettingRequestBodyClass Class { get; set; }
    }
}