using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class PatchConfigurationRequest
    {
        [FromRoute]
        public string AppId { get; set; }

        [FromRoute]
        public string IdentifierId { get; set; }

        [FromBody]
        public PatchConfigurationRequestBody Body { get; set; }
    }
}