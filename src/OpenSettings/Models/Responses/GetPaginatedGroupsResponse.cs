using OpenSettings.Models.Inputs;
using System;

namespace OpenSettings.Models.Responses
{
    public class GetPaginatedAppGroupsResponse
    {
        public GetPaginatedAppGroupsResponse(GetPaginatedInput input, int itemCount, ModelForPaginatedResponseData[] groups, int minSortOrder, int maxSortOrder)
        {
            AppGroups = groups ?? Array.Empty<ModelForPaginatedResponseData>();
            PagingInfo = new PagingInfo(input.PageIndex, input.PageSize, itemCount);
            MinSortOrder = minSortOrder;
            MaxSortOrder = maxSortOrder;
        }

        public PagingInfo PagingInfo { get; }

        public ModelForPaginatedResponseData[] AppGroups { get; }

        public int MinSortOrder { get; }

        public int MaxSortOrder { get; }
    }
}