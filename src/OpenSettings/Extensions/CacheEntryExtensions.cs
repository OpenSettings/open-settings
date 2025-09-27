using Microsoft.Extensions.Caching.Memory;
using OpenSettings.Models;
using System;
using System.Linq;

namespace OpenSettings.Extensions
{
    internal static class CacheEntryExtensions
    {
        internal static void Remove(this CacheEntry cacheEntry, IMemoryCache memoryCache)
        {
            Remove(cacheEntry, memoryCache, o => true);
        }

        internal static void Remove(this CacheEntry cacheEntry, IMemoryCache memoryCache, Func<object, bool> predicate)
        {
            cacheEntry = cacheEntry ?? throw new ArgumentNullException(nameof(cacheEntry));
            memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));

            var keys = OpenSettingsDefaults.Caches.CacheKeys.Keys.Where(key => $"{key}".StartsWith(cacheEntry.BaseKey) && predicate(key)).ToArray();

            foreach (var key in keys)
            {
                memoryCache.Remove(key);
                OpenSettingsDefaults.Caches.CacheKeys.TryRemove(key, out _);
            }
        }
    }
}