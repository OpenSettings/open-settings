using System.Collections.Generic;
using System.Text.Json;

namespace OpenSettings.Models
{
    public class FileMergeResult
    {
        public Dictionary<string, JsonElement> Data { get; set; }

        public FileModel[] Files { get; set; }

        public string Name { get; set; }

        public bool StoredInSeparateFile { get; set; }
    }
}