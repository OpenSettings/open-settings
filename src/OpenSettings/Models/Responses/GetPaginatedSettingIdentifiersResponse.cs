using OpenSettings.Models.Inputs;
using System;

namespace OpenSettings.Models.Responses
{
    public class GetPaginatedIdentifiersResponse
    {
        public GetPaginatedIdentifiersResponse(GetPaginatedInput input, int itemCount, ModelForPaginatedResponseData[] identifiers, int minSortOrder, int maxSortOrder)
        {
            Identifiers = identifiers ?? Array.Empty<ModelForPaginatedResponseData>();
            PagingInfo = new PagingInfo(input.PageIndex, input.PageSize, itemCount);
            MinSortOrder = minSortOrder;
            MaxSortOrder = maxSortOrder;
        }

        public PagingInfo PagingInfo { get; }

        public ModelForPaginatedResponseData[] Identifiers { get; }

        public int MinSortOrder { get; }

        public int MaxSortOrder { get; }
    }
}