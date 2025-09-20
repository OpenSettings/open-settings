using System;
using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppRequest
    {
        [FromRoute]
        public Guid AppId { get; set; }

        [FromBody]
        public UpdateAppRequestBody Body { get; set; } 
    }
}