using OpenSettings.Models.Inputs;
using System;

namespace OpenSettings.Models.Responses
{
    public class GetPaginatedAppGroupsResponse
    {
        public GetPaginatedAppGroupsResponse(GetPaginatedInput input) : this(input, 0, Array.Empty<PaginatedResponseData>(), 0, 0)
        {
        }

        public GetPaginatedAppGroupsResponse(GetPaginatedInput input, int itemCount, PaginatedResponseData[] appGroups, int minSortOrder, int maxSortOrder)
        {
            SortOrderRange = new SortOrderRange
            {
                Min = minSortOrder,
                Max = maxSortOrder
            };
            PagingInfo = new PagingInfo(input.PageIndex, input.PageSize, itemCount);
            AppGroups = appGroups ?? Array.Empty<PaginatedResponseData>();
        }

        public SortOrderRange SortOrderRange { get; }

        public PagingInfo PagingInfo { get; }

        public PaginatedResponseData[] AppGroups { get; } = Array.Empty<PaginatedResponseData>();
    }
}