using OpenSettings.Extensions;
using System;

namespace OpenSettings.Models.Responses
{
    public class GetAppGroupsResponse
    {
        public GetAppGroupsResponse()
        {
        }

        public GetAppGroupsResponse(GetAppGroupsResponseGroup[] appGroups)
        {
            AppGroups = appGroups ?? Array.Empty<GetAppGroupsResponseGroup>();

            var sortOrderRange = appGroups.GetSortOrderRange();

            SortOrderRange = new SortOrderRange
            {
                Min = sortOrderRange.MinSortOrder,
                Max = sortOrderRange.MaxSortOrder
            };
        }

        public SortOrderRange SortOrderRange { get; set; }

        public GetAppGroupsResponseGroup[] AppGroups { get; set; } = Array.Empty<GetAppGroupsResponseGroup>();
    }
}