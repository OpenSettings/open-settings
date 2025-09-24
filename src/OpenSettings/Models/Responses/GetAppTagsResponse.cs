using OpenSettings.Extensions;
using System;

namespace OpenSettings.Models.Responses
{
    public class GetAppTagsResponse
    {
        public GetAppTagsResponse()
        {
        }

        public GetAppTagsResponse(GetAppTagsResponseTag[] tags)
        {
            Tags = tags ?? Array.Empty<GetAppTagsResponseTag>();

            var sortOrderRange = tags.GetSortOrderRange();

            SortOrderRange = new SortOrderRange
            {
                Min = sortOrderRange.MinSortOrder,
                Max = sortOrderRange.MaxSortOrder
            };
        }

        public SortOrderRange SortOrderRange { get; set; }

        public GetAppTagsResponseTag[] Tags { get; set; } = Array.Empty<GetAppTagsResponseTag>();
    }
}