using System;
using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetIdentifiersRequest
    {
        [FromQuery]
        public string SearchTerm { get; set; }

        [FromQuery]
        public Guid? AppId { get; set; }

        [FromQuery]
        public bool IsAppMapped { get; set; }
    }
}