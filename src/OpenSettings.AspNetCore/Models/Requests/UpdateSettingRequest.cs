using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateSettingRequest
    {
        [FromRoute]
        public string SettingId { get; set; }

        [FromBody, Required]
        public UpdateSettingRequestBody Body { get; set; }
    }
}