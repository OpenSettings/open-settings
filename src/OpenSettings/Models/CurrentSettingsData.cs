using System;
using System.Collections.Generic;

namespace OpenSettings.Models
{
    internal class CurrentSettingsData
    {
        public DateTime LastUpdatedOn { get; set; }

        public IDictionary<Guid, object> ComputedIdentifierToInstance { get; set; } = new Dictionary<Guid, object>();
    }
}