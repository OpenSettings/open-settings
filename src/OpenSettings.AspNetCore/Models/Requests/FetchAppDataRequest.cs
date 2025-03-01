using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class FetchAppDataRequest
    {
        [FromRoute]
        public Guid ClientId { get; set; }

        [FromRoute]
        public string IdentifierName { get; set; }

        [FromBody]
        public FetchAppDataRequestBody Body { get; set; }
    }
}