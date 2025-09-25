using System;

namespace OpenSettings.Models.Inputs
{
    public class GetIdentifiersInput
    {
        public string SearchTerm { get; set; }

        public Guid? AppId { get; set; }

        public bool IsAppMapped { get; set; }
    }
}