using System;
using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateSettingRequestBodyClass
    {
        [Required(AllowEmptyStrings = false)]
        public string Namespace { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FullName { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}