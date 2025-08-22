using OpenSettings.Models.Inputs;
using System;

namespace OpenSettings.Models.Responses
{
    public class GetPaginatedAppGroupsResponse
    {
        public GetPaginatedAppGroupsResponse()
        {
        }

        public GetPaginatedAppGroupsResponse(GetPaginatedInput input, int itemCount, ModelForPaginatedResponseData[] groups, int minSortOrder, int maxSortOrder)
        {
            AppGroups = groups ?? Array.Empty<ModelForPaginatedResponseData>();
            PagingInfo = new PagingInfo(input.PageIndex, input.PageSize, itemCount);
            MinSortOrder = minSortOrder;
            MaxSortOrder = maxSortOrder;
        }

        public int MinSortOrder { get; set; }

        public int MaxSortOrder { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public ModelForPaginatedResponseData[] AppGroups { get; set; }
    }
}