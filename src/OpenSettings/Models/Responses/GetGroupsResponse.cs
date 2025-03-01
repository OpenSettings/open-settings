using System;
using System.Linq;

namespace OpenSettings.Models.Responses
{
    public class GetAppGroupsResponse
    {
        public GetAppGroupsResponse(GetAppGroupsResponseGroup[] appGroups)
        {
            AppGroups = appGroups ?? Array.Empty<GetAppGroupsResponseGroup>();

            if (AppGroups.Length == 0)
            {
                return;
            }

            var firstIndex = AppGroups[0];

            MinSortOrder = firstIndex.SortOrder;
            MaxSortOrder = firstIndex.SortOrder;

            foreach (var item in AppGroups.Skip(1))
            {
                MinSortOrder = Math.Min(MinSortOrder, item.SortOrder);
                MaxSortOrder = Math.Max(MaxSortOrder, item.SortOrder);
            }
        }

        public int MinSortOrder { get; }

        public int MaxSortOrder { get; }

        public GetAppGroupsResponseGroup[] AppGroups { get; }
    }
}