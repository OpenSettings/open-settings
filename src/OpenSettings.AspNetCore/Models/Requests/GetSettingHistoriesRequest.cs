using System;
using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetSettingHistoriesRequest
    {
        [FromRoute]
        public Guid AppSettingId { get; set; }

        [FromQuery]
        public string Excludes { get; set; }
    }
}