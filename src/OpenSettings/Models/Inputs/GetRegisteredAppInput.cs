using System;

namespace OpenSettings.Models.Inputs
{
    public class GetRegisteredAppInput
    {
        public Guid ClientId { get; set; }

        public Guid ClientSecret { get; set; }

        public Guid? TenantId { get; set; }
    }
}