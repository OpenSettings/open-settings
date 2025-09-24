using System;
using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class GetSettingsLastUpdatedComputedIdentifiersResponse
    {
        public Dictionary<Guid, DateTime> ComputedIdentifierToUpdatedOn { get; set; } = new Dictionary<Guid, DateTime>();
    }
}