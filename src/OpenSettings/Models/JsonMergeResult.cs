using System.Collections.Generic;
using System.Text.Json;

namespace OpenSettings.Models
{
    public class JsonMergeResult
    {
        public bool IsFaulted { get; set; }

        public string FailureReason { get; set; }

        public Dictionary<string, JsonElement> Data { get; set; } = new Dictionary<string, JsonElement>();
    }
}