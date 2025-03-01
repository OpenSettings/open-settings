using System;

namespace OpenSettings.Models.Inputs
{
    public class GetAppInstanceStatusInput
    {
        public Guid ClientId { get; set; }

        public string Instance { get; set; }
    }
}