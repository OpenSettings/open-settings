using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using OpenSettings.Models;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Extensions
{
    public static class CacheModelExtensions
    {
        private static Action<ICacheEntry, CacheModel> ApplyCache { get; } = (cacheEntry, model) =>
        {
            cacheEntry.AbsoluteExpirationRelativeToNow = model.AbsoluteExpirationRelativeToNow;
            cacheEntry.AbsoluteExpiration = model.AbsoluteExpiration;
            cacheEntry.SlidingExpiration = model.SlidingExpiration;

            foreach (var expirationToken in model.ExpirationTokens)
            {
                cacheEntry.ExpirationTokens.Add(expirationToken);
            }

            foreach (var postEvictionCallback in model.PostEvictionCallbacks)
            {
                cacheEntry.PostEvictionCallbacks.Add(postEvictionCallback);
            }

            cacheEntry.Priority = model.Priority;
        };

        private static DistributedCacheEntryOptions ToDistributedCacheEntryOptions(this CacheModel cacheModel) =>
            new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = cacheModel.AbsoluteExpirationRelativeToNow,
                AbsoluteExpiration = cacheModel.AbsoluteExpiration,
                SlidingExpiration = cacheModel.SlidingExpiration
            };

        public static void Set<TItem>(this CacheModel model, IMemoryCache cache, TItem value)
        {
            if (cache == null)
            {
                return;
            }

            using (var cacheEntry = cache.CreateEntry(model.Key))
            {
                ApplyCache(cacheEntry, model);

                cacheEntry.Value = value;
            }
        }

        /// <summary>
        /// Sets a value with the specified key in the cache model.
        /// </summary>
        /// <typeparam name="TItem">Item type to set.</typeparam>
        /// <param name="model"></param>
        /// <param name="cache">Concrete class which implements the <see cref="IDistributedCache"/>.</param>
        /// <param name="value">Item to set.</param>
        public static void Set<TItem>(this CacheModel model, IDistributedCache cache, TItem value)
        {
            cache?.Set(model.Key.ToString(), JsonSerializer.SerializeToUtf8Bytes(value),
                model.ToDistributedCacheEntryOptions());
        }

        public static Task SetAsync<TItem>(this CacheModel model, IDistributedCache cache, TItem value, CancellationToken cancellationToken = default)
        {
            return cache?.SetAsync(model.Key.ToString(), JsonSerializer.SerializeToUtf8Bytes(value),
                model.ToDistributedCacheEntryOptions(), cancellationToken) ?? Task.CompletedTask;
        }

        public static async Task<TItem> GetOrCreateAsync<TItem>(this CacheModel model, IMemoryCache cache, Func<CacheModel, Task<TItem>> factory)
        {
            if (cache == null)
            {
                return await factory(model).ConfigureAwait(false);
            }

            if (!cache.TryGetValue(model.Key, out var value))
            {
                using (var cacheEntry = cache.CreateEntry(model.Key))
                {
                    value = (cacheEntry.Value = await factory(model).ConfigureAwait(continueOnCapturedContext: false));

                    ApplyCache(cacheEntry, model);
                }
            }

            return (TItem)value;
        }

        public static async Task<TItem> GetOrCreateAsync<TItem>(this CacheModel model, IDistributedCache cache, Func<CacheModel, Task<TItem>> factory, CancellationToken cancellationToken = default)
        {
            if (cache == null)
            {
                return await factory(model).ConfigureAwait(false);
            }

            var valueAsBytes = await cache.GetAsync(model.Key.ToString(), cancellationToken).ConfigureAwait(false);

            if (valueAsBytes != null)
            {
                return JsonSerializer.Deserialize<TItem>(valueAsBytes);
            }

            var value = await factory(model).ConfigureAwait(false);

            await cache.SetAsync(model.Key.ToString(), JsonSerializer.SerializeToUtf8Bytes(value), model.ToDistributedCacheEntryOptions(), cancellationToken).ConfigureAwait(false);

            return value;
        }

        public static TItem GetOrCreate<TItem>(this CacheModel model, IMemoryCache cache, Func<CacheModel, TItem> factory)
        {
            if (cache == null)
            {
                return factory(model);
            }

            if (!cache.TryGetValue(model.Key, out var value))
            {
                using (var cacheEntry = cache.CreateEntry(model.Key))
                {
                    value = (cacheEntry.Value = factory(model));

                    ApplyCache(cacheEntry, model);
                }
            }

            return (TItem)value;
        }

        public static TItem GetOrCreate<TItem>(this CacheModel model, IDistributedCache cache, Func<CacheModel, TItem> factory)
        {
            if (cache == null)
            {
                return factory(model);
            }

            var valueAsBytes = cache.Get(model.Key.ToString());

            if (valueAsBytes != null)
            {
                return JsonSerializer.Deserialize<TItem>(valueAsBytes);
            }

            var value = factory(model);

            cache.Set(model.Key.ToString(), JsonSerializer.SerializeToUtf8Bytes(value), model.ToDistributedCacheEntryOptions());

            return value;
        }

        public static bool TryGetValue(this CacheModel model, IMemoryCache cache, out object value)
        {
            if (cache != null)
            {
                return cache.TryGetValue(model.Key, out value);
            }

            value = null;

            return false;
        }

        public static bool TryGetValue<T>(this CacheModel model, IMemoryCache cache, out T value)
        {
            if (model.TryGetValue(cache, out var valueAsObject))
            {
                value = (T)valueAsObject;

                return true;
            }

            value = default;

            return false;
        }
    }
}