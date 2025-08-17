using System;

namespace OpenSettings.Models.Inputs
{
    public class GetMeInput
    {
        public Guid? StateId { get; set; }

        public string ClaimTypes { get; set; }

        public GetMeInputIncludes Includes { get; set; }
    }
}