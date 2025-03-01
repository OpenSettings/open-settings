using Microsoft.AspNetCore.Mvc;
using OpenSettings.Models;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetPaginatedRequest
    {
        public string SearchTerm { get; set; }

        public string SearchBy { get; set; }

        [FromQuery(Name = "page")]
        public int PageIndex { get; set; }

        [FromQuery(Name = "size")]
        public int PageSize { get; set; }

        public string SortBy { get; set; }

        public SortDirection SortDirection { get; set; }
    }
}