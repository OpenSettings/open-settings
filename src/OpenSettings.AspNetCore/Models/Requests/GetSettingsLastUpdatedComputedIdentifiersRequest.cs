using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetSettingsLastUpdatedComputedIdentifiersRequest
    {
        public Guid ClientId { get; set; }

        public string IdentifierName { get; set; }

        public DateTime? LastUpdatedOn { get; set; }
    }
}