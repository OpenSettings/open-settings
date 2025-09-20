using System;
using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetSettingDataRequest
    {
        [FromRoute]
        public Guid AppSettingId { get; set; }
    }
}