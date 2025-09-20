using System;
using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class PatchConfigurationRequest
    {
        [FromRoute]
        public Guid AppId { get; set; }

        [FromRoute]
        public Guid IdentifierId { get; set; }

        [FromBody]
        public PatchConfigurationRequestBody Body { get; set; }
    }
}