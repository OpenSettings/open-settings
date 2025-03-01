using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppRequestBodyClient
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}