using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppInstanceRequest
    {
        [FromRoute]
        public Guid ClientId { get; set; }

        [FromBody]
        public UpdateAppInstanceRequestBody Body { get; set; }
    }
}