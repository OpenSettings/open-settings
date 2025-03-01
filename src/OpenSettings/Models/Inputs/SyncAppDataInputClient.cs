using System;

namespace OpenSettings.Models.Inputs
{
    public class SyncAppDataInputClient
    {
        public Guid Id { get; set; }

        public Guid Secret { get; set; }

        public string Name { get; set; }
    }
}