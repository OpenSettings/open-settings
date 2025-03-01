using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetInstancesDataRequest
    {
        [FromRoute]
        public Guid ClientId { get; set; }

        [FromQuery]
        public string IdentifierId { get; set; }

        [FromQuery]
        public string Ids { get; set; }
    }
}