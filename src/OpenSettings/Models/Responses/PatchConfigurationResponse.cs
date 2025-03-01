using System;
using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class PatchConfigurationResponse
    {
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Dictionary<string, object> UpdatedFieldNameToValue { get; set; } = new Dictionary<string, object>();
    }
}