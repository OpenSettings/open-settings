using System;
using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CopyAppSettingToRequest
    {
        [FromRoute]
        public Guid AppSettingId { get; set; }

        [FromBody]
        public CopyAppSettingToRequestBody Body { get; set; }
    }
}