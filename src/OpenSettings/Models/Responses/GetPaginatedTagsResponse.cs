using OpenSettings.Models.Inputs;
using System;

namespace OpenSettings.Models.Responses
{
    public class GetPaginatedTagsResponse
    {
        public GetPaginatedTagsResponse(GetPaginatedInput input, int itemCount, ModelForPaginatedResponseData[] tags, int minSortOrder, int maxSortOrder)
        {
            MinSortOrder = minSortOrder;
            MaxSortOrder = maxSortOrder;
            Tags = tags ?? Array.Empty<ModelForPaginatedResponseData>();
            PagingInfo = new PagingInfo(input.PageIndex, input.PageSize, itemCount);
        }

        public int MinSortOrder { get; }

        public int MaxSortOrder { get; }

        public PagingInfo PagingInfo { get; }

        public ModelForPaginatedResponseData[] Tags { get; }
    }
}