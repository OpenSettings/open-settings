using System;

namespace OpenSettings.Models.Inputs
{
    public class GetInstancesDataInput
    {
        public Guid ClientId { get; set; }

        public string IdentifierId { get; set; }

        public string Ids { get; set; }
    }
}