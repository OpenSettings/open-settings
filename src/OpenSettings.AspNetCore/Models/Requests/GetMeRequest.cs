using System;
using OpenSettings.Models.Inputs;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetMeRequest
    {
        public Guid? StateId { get; set; }

        public string ClaimTypes { get; set; }

        public GetMeInputIncludes Includes { get; set; }
    }
}