using OpenSettings.Models.Inputs;
using System;

namespace OpenSettings.Models.Responses
{
    public class GetPaginatedIdentifiersResponse
    {
        public GetPaginatedIdentifiersResponse()
        {
        }

        public GetPaginatedIdentifiersResponse(GetPaginatedInput input, int itemCount, ModelForPaginatedResponseData[] identifiers, int minSortOrder, int maxSortOrder)
        {
            SortOrderRange = new SortOrderRange
            {
                Min = minSortOrder,
                Max = maxSortOrder
            };
            PagingInfo = new PagingInfo(input.PageIndex, input.PageSize, itemCount);
            Identifiers = identifiers ?? Array.Empty<ModelForPaginatedResponseData>();
        }

        public SortOrderRange SortOrderRange { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public ModelForPaginatedResponseData[] Identifiers { get; set; } = Array.Empty<ModelForPaginatedResponseData>();
    }
}