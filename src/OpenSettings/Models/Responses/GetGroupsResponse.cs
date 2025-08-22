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

            (MinSortOrder, MaxSortOrder) = appGroups.GetSortOrderRange();
        }

        public int MinSortOrder { get; set; }

        public int MaxSortOrder { get; set; }

        public GetAppGroupsResponseGroup[] AppGroups { get; set; } = Array.Empty<GetAppGroupsResponseGroup>();
    }
}