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

        public int PageIndex { get; }

        public int PageSize { get; }

        public int ItemCount { get; }

        public int PageCount { get; }

        public bool HasPrevious { get; }

        public bool HasNext { get; }
    }
}