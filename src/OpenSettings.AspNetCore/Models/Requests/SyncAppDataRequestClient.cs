using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class SyncAppDataRequestClient
    {
        public string Name { get; set; }

        public Guid Secret { get; set; }
    }
}