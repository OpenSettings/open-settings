using OpenSettings.Models;
using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateIdentifierRequestBody
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public int SortOrder { get; set; }
        
        public SetSortOrderPosition? SetSortOrderPosition { get; set; }
    }
}