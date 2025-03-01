using System;
using System.Collections.Generic;

namespace OpenSettings.Models.Inputs
{
    public class SyncAppDataInputSettingClass
    {
        public Guid Identifier { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public string Namespace { get; set; }

        public ICollection<PropertyInfoHelperModel> Properties { get; set; } = Array.Empty<PropertyInfoHelperModel>();

        public int HashCode { get; set; }

        public override int GetHashCode()
        {
            return 0;

            var hash = 17;

            hash = hash * 31 + (FullName?.GetHashCode() ?? 0);
            hash = hash * 31 + Identifier.GetHashCode();

            return hash;
        }
    }
}