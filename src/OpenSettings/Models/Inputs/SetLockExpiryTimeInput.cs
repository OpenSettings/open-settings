using System;

namespace OpenSettings.Models.Inputs
{
    public class SetLockExpiryTimeInput
    {
        public string Key { get; set; }

        public string Owner { get; set; }

        public DateTime ExpiryTime { get; set; }
    }
}