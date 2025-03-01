using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenSettings.Models.Responses
{
    public class GetSettingsLastUpdatedComputedIdentifiersResponse
    {
        public IEnumerable<KeyValuePair<Guid, DateTime>> ComputedIdentifierToUpdatedOn { get; set; } = Enumerable.Empty<KeyValuePair<Guid,DateTime>>();
    }
}