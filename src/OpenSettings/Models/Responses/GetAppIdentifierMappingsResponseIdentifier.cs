using System;

namespace OpenSettings.Models.Responses
{
    public class GetAppIdentifierMappingsResponseIdentifier
    {
        public string Id { get; set; }

        public int SortOrder { get; set; }

        public int MappingSortOrder { get; set; }

        public byte[] MappingRowVersion { get; set; } = Array.Empty<byte>();
    }
}