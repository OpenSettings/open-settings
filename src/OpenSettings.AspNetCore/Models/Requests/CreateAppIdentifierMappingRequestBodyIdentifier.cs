using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateAppIdentifierMappingRequestBodyIdentifier
    {
        [Required(AllowEmptyStrings = false)]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}