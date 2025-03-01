using System.Collections.Generic;

namespace OpenSettings.Models
{
    public class FileMergeResult
    {
        public Dictionary<string, object> Data { get; set; }

        public FileModel[] Files { get; set; }

        public string Name { get; set; }

        public bool StoredInSeparateFile { get; set; }
    }
}