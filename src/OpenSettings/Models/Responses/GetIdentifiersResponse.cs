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

            (MinSortOrder, MaxSortOrder) = identifiers.GetSortOrderRange();
        }

        public int MinSortOrder { get; set; }

        public int MaxSortOrder { get; set; }

        public GetIdentifiersResponseIdentifier[] Identifiers { get; set; }
    }
}