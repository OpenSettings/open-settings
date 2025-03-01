using System;
using System.Linq;

namespace OpenSettings.Models.Responses
{
    public class GetIdentifiersResponse
    {
        public GetIdentifiersResponse(GetIdentifiersResponseIdentifier[] identifiers)
        {
            Identifiers = identifiers ?? Array.Empty<GetIdentifiersResponseIdentifier>();

            if (Identifiers.Length == 0)
            {
                return;
            }

            var firstIndex = Identifiers[0];

            MinSortOrder = firstIndex.SortOrder;
            MaxSortOrder = firstIndex.SortOrder;

            foreach (var item in Identifiers.Skip(1))
            {
                MinSortOrder = Math.Min(MinSortOrder, item.SortOrder);
                MaxSortOrder = Math.Max(MaxSortOrder, item.SortOrder);
            }
        }

        public int MinSortOrder { get; }

        public int MaxSortOrder { get; }

        public GetIdentifiersResponseIdentifier[] Identifiers { get; }
    }
}