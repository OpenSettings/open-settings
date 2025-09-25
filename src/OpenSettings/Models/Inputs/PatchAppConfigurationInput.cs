using System;

namespace OpenSettings.Models.Inputs
{
    public class PatchAppConfigurationInput
    {
        public Guid AppId { get; set; }

        public Guid IdentifierId { get; set; }

        public PatchAppConfigurationInputBody Body { get; set; }

        public Guid? UpdatedById { get; set; }
    }
}