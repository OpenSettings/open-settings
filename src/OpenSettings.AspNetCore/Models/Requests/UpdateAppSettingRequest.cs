using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppSettingRequest
    {
        [FromRoute]
        public string AppSettingId { get; set; }

        [FromBody, Required]
        public UpdateAppSettingRequestBody Body { get; set; }
    }
}