using System;

namespace OpenSettings.Models.Responses
{
    public class GetAppIdentifierMappingsResponse
    {
        public int MinSortOrder { get; set; }

        public int MaxSortOrder { get; set; }

        public int MappingMinSortOrder { get; set; }

        public int MappingMaxSortOrder { get; set; }

        public GetAppIdentifierMappingsResponseIdentifier[] Identifiers { get; set; } = Array.Empty<GetAppIdentifierMappingsResponseIdentifier>();
    }
}