using System;
using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateIdentifierRequest
    {
        [FromRoute]
        public Guid IdentifierId { get; set; }

        [FromBody]
        public UpdateAppIdentifierRequestBody Body { get; set; }
    }
}