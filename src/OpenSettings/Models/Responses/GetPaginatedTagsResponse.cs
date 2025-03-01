using OpenSettings.Models.Inputs;
using System;

namespace OpenSettings.Models.Responses
{
    public class GetPaginatedTagsResponse
    {
        public GetPaginatedTagsResponse(GetPaginatedInput input, int itemCount, ModelForPaginatedResponseData[] tags, int minSortOrder, int maxSortOrder)
        {
            Tags = tags ?? Array.Empty<ModelForPaginatedResponseData>();
            PagingInfo = new PagingInfo(input.PageIndex, input.PageSize, itemCount);
            MinSortOrder = minSortOrder;
            MaxSortOrder = maxSortOrder;
        }

        public PagingInfo PagingInfo { get; }

        public ModelForPaginatedResponseData[] Tags { get; }

        public int MinSortOrder { get; }

        public int MaxSortOrder { get; }
    }
}