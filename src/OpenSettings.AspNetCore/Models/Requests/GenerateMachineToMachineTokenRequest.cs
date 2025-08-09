using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GenerateMachineToMachineTokenRequest
    {
        [FromBody]
        public GenerateMachineToMachineTokenRequestBody Body { get; set; }
    }
}