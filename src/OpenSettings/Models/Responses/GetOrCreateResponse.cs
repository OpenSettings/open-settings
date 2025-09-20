using System;

namespace OpenSettings.Models.Responses
{
    public class GetOrCreateResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int SortOrder { get; set; }

        public bool IsNewlyCreated { get; set; }
    }
}