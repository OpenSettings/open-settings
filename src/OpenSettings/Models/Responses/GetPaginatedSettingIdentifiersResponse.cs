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
            Identifiers = identifiers ?? Array.Empty<ModelForPaginatedResponseData>();
            PagingInfo = new PagingInfo(input.PageIndex, input.PageSize, itemCount);
            MinSortOrder = minSortOrder;
            MaxSortOrder = maxSortOrder;
        }

        public int MinSortOrder { get; set; }

        public int MaxSortOrder { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public ModelForPaginatedResponseData[] Identifiers { get; set; } = Array.Empty<ModelForPaginatedResponseData>();
    }
}