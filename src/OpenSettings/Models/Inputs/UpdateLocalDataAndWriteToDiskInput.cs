using System;

namespace OpenSettings.Models.Inputs
{
    public class UpdateLocalDataAndWriteToDiskInput
    {
        public Guid ComputedIdentifier { get; set; }

        public string Data { get; set; }

        public bool StoreInSeparateFile { get; set; }

        public bool IgnoreOnFileChange { get; set; }
    }
}