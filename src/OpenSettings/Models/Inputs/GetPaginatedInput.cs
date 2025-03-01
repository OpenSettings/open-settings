using System;

namespace OpenSettings.Models.Inputs
{
    public class GetPaginatedInput
    {
        public GetPaginatedInput(string searchTerm, string searchBy, int pageIndex, int pageSize, string sortBy, SortDirection sortDirection)
        {
            SearchTerm = searchTerm;
            SearchBy = searchBy;
            PageIndex = Math.Max(Constants.MinPageIndex, pageIndex);
            PageSize = Math.Min(Constants.MaxPageSize, Math.Max(Constants.MinPageSize, pageSize));
            SortBy = sortBy;
            SortDirection = sortDirection;
        }

        public string SearchTerm { get; }

        public string SearchBy { get; }

        public int PageIndex { get; }

        public int PageSize { get; }

        public string SortBy { get; }

        public SortDirection SortDirection { get; } 
    }
}