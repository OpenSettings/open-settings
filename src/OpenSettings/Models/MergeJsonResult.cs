using System.Collections.Generic;

namespace OpenSettings.Models
{
    public class JsonMergeResult
    {
        public bool IsFaulted { get; set; }

        public string FailureReason { get; set; }

        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
    }
}