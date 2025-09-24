using System;

namespace OpenSettings.Models.Responses
{
    public class GetAppIdentifierMappingsResponse
    {
        public SortOrderRange IdentifierSortOrderRange { get; set; }

        public SortOrderRange AppIdentifierMappingSortOrderRange { get; set; }

        public GetAppIdentifierMappingsResponseIdentifier[] Identifiers { get; set; } = Array.Empty<GetAppIdentifierMappingsResponseIdentifier>();
    }
}