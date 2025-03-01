using System;
using System.Collections.Generic;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class PatchConfigurationRequestBody
    {
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Dictionary<string, object> UpdatedFieldNameToValue { get; set; } = new Dictionary<string, object>();
    }
}