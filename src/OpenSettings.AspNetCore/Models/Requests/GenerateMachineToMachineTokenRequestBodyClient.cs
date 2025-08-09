using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GenerateMachineToMachineTokenRequestBodyClient
    {
        public Guid Id { get; set; }

        public Guid Secret { get; set; }
    }
}