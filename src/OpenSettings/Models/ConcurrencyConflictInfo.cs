using System.Collections.Generic;

namespace OpenSettings.Models
{
    public class ConcurrencyConflictInfo
    {
        public bool Deleted { get; set; }

        public Dictionary<string, ConcurrencyConflictValue> Properties { get; set; } = new Dictionary<string, ConcurrencyConflictValue>();
    }
}