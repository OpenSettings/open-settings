using System;
using System.Linq;

namespace OpenSettings.Models.Responses
{
    public class GetTagsResponse
    {
        public GetTagsResponse(GetTagsResponseTag[] tags)
        {
            Tags = tags ?? Array.Empty<GetTagsResponseTag>();

            if (Tags.Length == 0)
            {
                return;
            }

            var firstIndex = Tags[0];

            MinSortOrder = firstIndex.SortOrder;
            MaxSortOrder = firstIndex.SortOrder;

            foreach (var item in Tags.Skip(1))
            {
                MinSortOrder = Math.Min(MinSortOrder, item.SortOrder);
                MaxSortOrder = Math.Max(MaxSortOrder, item.SortOrder);
            }
        }

        public int MinSortOrder { get; }

        public int MaxSortOrder { get; }

        public GetTagsResponseTag[] Tags { get; }
    }
}