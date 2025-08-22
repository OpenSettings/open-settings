using OpenSettings.Extensions;
using System;

namespace OpenSettings.Models.Responses
{
    public class GetTagsResponse
    {
        public GetTagsResponse()
        {
        }

        public GetTagsResponse(GetTagsResponseTag[] tags)
        {
            Tags = tags ?? Array.Empty<GetTagsResponseTag>();

            (MinSortOrder, MaxSortOrder) = tags.GetSortOrderRange();
        }

        public int MinSortOrder { get; set; }

        public int MaxSortOrder { get; set; }

        public GetTagsResponseTag[] Tags { get; set; } = Array.Empty<GetTagsResponseTag>();
    }
}