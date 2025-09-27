using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class PatchAppConfigurationRequest
    {
        [FromRoute]
        public Guid AppId { get; set; }

        [FromRoute]
        public Guid IdentifierId { get; set; }

        [FromBody]
        public PatchConfigurationRequestBody Body { get; set; }
    }
}