using System;

namespace OpenSettings.Models.Responses
{
    public class GetPrimaryProviderResponse
    {
        public Guid Id { get; set; }

        public ProviderRegistryType Type { get; set; }

        public Guid ClientId { get; set; }

        public ProviderRegistryScheme Scheme { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string Region { get; set; }

        public string Version { get; set; }

        public string PackVersion { get; set; }

        public DateTime LastHeartbeatOn { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}