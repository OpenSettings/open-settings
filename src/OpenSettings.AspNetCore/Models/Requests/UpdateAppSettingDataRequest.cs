using System;
using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppSettingDataRequest
    {
        [FromRoute]
        public Guid AppSettingId { get; set; }

        [FromBody]
        public UpdateAppSettingDataRequestBody Body { get; set; }
    }
}