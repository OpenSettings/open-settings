using System;
using System.Collections.Generic;

namespace OpenSettings.Models
{
    public class ReorderResponse
    {
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Dictionary<string, int> IdToSortOrder { get; set; } = new Dictionary<string, int>();
    }
}