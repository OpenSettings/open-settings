using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetRegisteredAppRequest
    {
        [FromRoute]
        public Guid ClientId { get; set; }

        [FromBody]
        public Guid ClientSecret { get; set; }
    }
}