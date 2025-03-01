using OpenSettings.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateSettingRequestBody
    {
        [Required(AllowEmptyStrings = false)]
        public string AppId { get; set; }

        public string Data { get; set; }

        [Required(AllowEmptyStrings = false)]
        public Guid ComputedIdentifier { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string IdentifierId { get; set; }

        public CreateSettingRequestBodyClass Class { get; set; }

        public bool StoreInSeparateFile { get; set; }

        public bool IgnoreOnFileChange { get; set; }

        public RegistrationMode RegistrationMode { get; set; }
    }
}