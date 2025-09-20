using System;

namespace OpenSettings.Models.Inputs
{
    public class PatchConfigurationInput
    {
        public Guid AppId { get; set; }

        public Guid IdentifierId { get; set; }

        public PatchConfigurationInputBody Body { get; set; }

        public Guid? UpdatedById { get; set; }
    }
}