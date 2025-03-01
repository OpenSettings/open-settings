using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateInstanceRequest
    {
        [FromRoute]
        public Guid ClientId { get; set; }

        [FromBody]
        public UpdateInstanceRequestBody Body { get; set; }
    }
}