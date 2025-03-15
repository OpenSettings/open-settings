using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateInstanceRequest
    {
        [FromRoute]
        public Guid ClientId { get; set; }

        [FromBody]
        public CreateInstanceRequestBody Body { get; set; }
    }
}