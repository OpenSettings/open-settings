using System;

namespace OpenSettings.Models
{
    public class PagingInfo
    {
        public PagingInfo(int pageIndex, int pageSize, int itemCount, int pageCount, bool hasPrevious, bool hasNext)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            ItemCount = itemCount;
            PageCount = pageCount;
            HasPrevious = hasPrevious;
            HasNext = hasNext;
        }

        public PagingInfo(int pageIndex, int pageSize, int itemCount)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            ItemCount = itemCount;
            PageCount = (int)Math.Ceiling(ItemCount / (double)PageSize);
            HasPrevious = PageIndex > 1;
            HasNext = PageIndex < PageCount;
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int ItemCount { get; set; }

        public int PageCount { get; set; }

        public bool HasPrevious { get; set; }

        public bool HasNext { get; set; }
    }
}