using System;
using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppTagRequest
    {
        [FromRoute]
        public Guid AppTagId { get; set; }

        [FromBody]
        public UpdateAppTagRequestBody Body { get; set; }
    }
}