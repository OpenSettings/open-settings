using System;

namespace OpenSettings.Models.Inputs
{
    public class GenerateMachineToMachineTokenInput
    {
        public Guid ClientId { get; set; }

        public Guid ClientSecret { get; set; }

        public CallerType CallerType { get; set; }
    }
}