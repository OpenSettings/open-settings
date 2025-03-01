using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenSettings.Models.Inputs
{
    public class PatchConfigurationInputBody
    {
        public PatchConfigurationInputBody(byte[] rowVersion, Dictionary<string, object> updatedFieldNameToValue)
        {
            RowVersion = rowVersion ?? Array.Empty<byte>();
            UpdatedFieldNameToValue = updatedFieldNameToValue?.ToDictionary(kvp => kvp.Key.Trim().ToLowerInvariant(), kvp => kvp.Value) ?? new Dictionary<string, object>();
        }

        public byte[] RowVersion { get; }

        public Dictionary<string, object> UpdatedFieldNameToValue { get; }
    }
}