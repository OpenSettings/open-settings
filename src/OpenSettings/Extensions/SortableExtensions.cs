using OpenSettings.Models;
using System;
using System.Linq;

namespace OpenSettings.Extensions
{
    internal static class SortableExtensions
    {
        public static (int MinSortOrder, int MaxSortOrder) GetSortOrderRange<T>(this T[] items) where T : ISortable
        {
            if (items.Length == 0)
            {
                return (0, 0);
            }

            var firstIndex = items[0];

            var minSortOrder = firstIndex.SortOrder;
            var maxSortOrder = firstIndex.SortOrder;

            foreach (var item in items.Skip(1))
            {
                minSortOrder = Math.Min(minSortOrder, item.SortOrder);
                maxSortOrder = Math.Max(maxSortOrder, item.SortOrder);
            }

            return (minSortOrder, maxSortOrder);
        }
    }
}