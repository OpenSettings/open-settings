using OpenSettings.Models.Inputs;
using System;

namespace OpenSettings.Models.Responses
{
    public class GetPaginatedAppTagsResponse
    {
        public GetPaginatedAppTagsResponse()
        {
        }

        public GetPaginatedAppTagsResponse(GetPaginatedInput input, int itemCount, ModelForPaginatedResponseData[] tags, int minSortOrder, int maxSortOrder)
        {
            SortOrderRange = new SortOrderRange
            {
                Min = minSortOrder,
                Max = maxSortOrder
            };
            PagingInfo = new PagingInfo(input.PageIndex, input.PageSize, itemCount);
            Tags = tags ?? Array.Empty<ModelForPaginatedResponseData>();
        }

        public SortOrderRange SortOrderRange { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public ModelForPaginatedResponseData[] Tags { get; set; } = Array.Empty<ModelForPaginatedResponseData>();
    }
}