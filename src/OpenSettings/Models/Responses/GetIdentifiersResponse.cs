using OpenSettings.Extensions;
using System;

namespace OpenSettings.Models.Responses
{
    public class GetIdentifiersResponse
    {
        public GetIdentifiersResponse()
        {
        }

        public GetIdentifiersResponse(GetIdentifiersResponseIdentifier[] identifiers)
        {
            Identifiers = identifiers ?? Array.Empty<GetIdentifiersResponseIdentifier>();

            var sortOrderRange = identifiers.GetSortOrderRange();

            SortOrderRange = new SortOrderRange
            {
                Min = sortOrderRange.MinSortOrder,
                Max = sortOrderRange.MaxSortOrder
            };
        }

        public SortOrderRange SortOrderRange { get; set; }

        public GetIdentifiersResponseIdentifier[] Identifiers { get; set; } = Array.Empty<GetIdentifiersResponseIdentifier>();
    }
}