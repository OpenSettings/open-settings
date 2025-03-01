using System;

namespace OpenSettings.Models.Inputs
{
    public class UpdateInstanceInput
    {
        public Guid ClientId { get; set; }

        public Guid ClientSecret { get; set; }

        public string InstanceName { get; set; }

        public string IdentifierName { get; set; }

        public string[] Urls { get; set; } = Array.Empty<string>();

        public bool IsActive { get; set; }

        public string IpAddress { get; set; }

        public Guid? UpdatedById { get; set; }
    }
}