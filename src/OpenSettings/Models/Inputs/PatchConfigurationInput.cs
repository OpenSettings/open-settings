using System;

namespace OpenSettings.Models.Inputs
{
    public class PatchConfigurationInput
    {
        public string AppId { get; set; }

        public string IdentifierId { get; set; }

        public PatchConfigurationInputBody Body { get; set; }

        public Guid? UpdatedById { get; set; }
    }
}