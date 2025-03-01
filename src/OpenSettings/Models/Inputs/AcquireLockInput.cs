using System;

namespace OpenSettings.Models.Inputs
{
    public class AcquireLockInput
    {
        public string Key { get; set; }

        public string Owner { get; set; }

        public TimeSpan Timeout { get; set; }
    }
}