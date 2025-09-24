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
            SortOrderRange = new SortOrderRange
            {
                Min = minSortOrder,
                Max = maxSortOrder
            };
            PagingInfo = new PagingInfo(input.PageIndex, input.PageSize, itemCount);
            AppGroups = groups ?? Array.Empty<ModelForPaginatedResponseData>();
        }

        public SortOrderRange SortOrderRange { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public ModelForPaginatedResponseData[] AppGroups { get; set; } = Array.Empty<ModelForPaginatedResponseData>();
    }
}