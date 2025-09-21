using System;
using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class RestoreSettingHistoryRequest
    {
        [FromRoute]
        public Guid AppSettingHistoryId { get; set; }

        [FromBody]
        public RestoreSettingHistoryRequestBody Body { get; set; }
    }
}