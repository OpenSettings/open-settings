using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateAppInstanceRequest
    {
        [FromRoute]
        public Guid ClientId { get; set; }

        [FromBody]
        public CreateAppInstanceRequestBody Body { get; set; }
    }
}