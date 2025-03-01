using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateSettingRequestBodyClass
    {
        [Required(AllowEmptyStrings = false)]
        public string Namespace { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FullName { get; set; }
    }
}