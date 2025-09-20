using OpenSettings.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateAppSettingRequestBody
    {
        [Required]
        public Guid AppId { get; set; }

        public string Data { get; set; }

        [Required(AllowEmptyStrings = false)]
        public Guid ComputedIdentifier { get; set; }

        [Required]
        public Guid IdentifierId { get; set; }

        public CreateAppSettingRequestBodyClass Class { get; set; }

        public bool StoreInSeparateFile { get; set; }

        public bool IgnoreOnFileChange { get; set; }

        public RegistrationMode RegistrationMode { get; set; }
    }
}