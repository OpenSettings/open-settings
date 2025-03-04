using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using OpenSettings.Models;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="CacheModel"/> to interact with both in-memory and distributed caches.
    /// This includes methods for setting, getting, and creating cached items, as well as handling expiration and callback options.
    /// </summary>
    public static class CacheModelExtensions
    {
        /// <summary>
        /// Applies cache settings from the <see cref="CacheModel"/> to a cache entry.
        /// </summary>
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

        /// <summary>
        /// Converts the <see cref="CacheModel"/> into <see cref="DistributedCacheEntryOptions"/> for use in distributed caching.
        /// </summary>
        /// <param name="cacheModel">The cache model that holds expiration and other settings.</param>
        /// <returns>The <see cref="DistributedCacheEntryOptions"/> with properties copied from the <see cref="CacheModel"/>.</returns>
        private static DistributedCacheEntryOptions ToDistributedCacheEntryOptions(this CacheModel cacheModel) =>
            new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = cacheModel.AbsoluteExpirationRelativeToNow,
                AbsoluteExpiration = cacheModel.AbsoluteExpiration,
                SlidingExpiration = cacheModel.SlidingExpiration
            };

        /// <summary>
        /// Sets a value with the specified key in the in-memory cache.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="model">The <see cref="CacheModel"/> representing the cache settings.</param>
        /// <param name="cache">The in-memory cache instance to store the value.</param>
        /// <param name="value">The item to store in the cache.</param>
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

        /// <summary>
        /// Asynchronously sets a value with the specified key in the distributed cache.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="model">The <see cref="CacheModel"/> representing the cache settings.</param>
        /// <param name="cache">The distributed cache instance to store the value.</param>
        /// <param name="value">The item to store in the cache.</param>
        /// <param name="cancellationToken">A cancellation token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous set operation.</returns>
        public static Task SetAsync<TItem>(this CacheModel model, IDistributedCache cache, TItem value, CancellationToken cancellationToken = default)
        {
            return cache?.SetAsync(model.Key.ToString(), JsonSerializer.SerializeToUtf8Bytes(value),
                model.ToDistributedCacheEntryOptions(), cancellationToken) ?? Task.CompletedTask;
        }

        /// <summary>
        /// Asynchronously gets or creates a value for the specified key in the in-memory cache, using the provided factory function.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="model">The <see cref="CacheModel"/> representing the cache settings.</param>
        /// <param name="cache">The in-memory cache instance to store the value.</param>
        /// <param name="factory">The factory function to generate the value if it does not exist in the cache.</param>
        /// <returns>A task that represents the asynchronous get or create operation.</returns>
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

        /// <summary>
        /// Asynchronously gets or creates a value for the specified key in the distributed cache, using the provided factory function.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="model">The <see cref="CacheModel"/> representing the cache settings.</param>
        /// <param name="cache">The distributed cache instance to store the value.</param>
        /// <param name="factory">The factory function to generate the value if it does not exist in the cache.</param>
        /// <param name="cancellationToken">A cancellation token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous get or create operation.</returns>
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

        /// <summary>
        /// Gets or creates a value for the specified key in the in-memory cache, using the provided factory function.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="model">The <see cref="CacheModel"/> representing the cache settings.</param>
        /// <param name="cache">The in-memory cache instance to store the value.</param>
        /// <param name="factory">The factory function to generate the value if it does not exist in the cache.</param>
        /// <returns>The cached or newly created value.</returns>
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

        /// <summary>
        /// Gets or creates a value for the specified key in the distributed cache, using the provided factory function.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="model">The <see cref="CacheModel"/> representing the cache settings.</param>
        /// <param name="cache">The distributed cache instance to store the value.</param>
        /// <param name="factory">The factory function to generate the value if it does not exist in the cache.</param>
        /// <returns>The cached or newly created value.</returns>
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

        /// <summary>
        /// Attempts to get a value for the specified key from the in-memory cache.
        /// </summary>
        /// <param name="model">The <see cref="CacheModel"/> representing the cache settings.</param>
        /// <param name="cache">The in-memory cache instance to retrieve the value from.</param>
        /// <param name="value">The retrieved value, if found.</param>
        /// <returns>True if the value was found; otherwise, false.</returns>
        public static bool TryGetValue(this CacheModel model, IMemoryCache cache, out object value)
        {
            if (cache != null)
            {
                return cache.TryGetValue(model.Key, out value);
            }

            value = null;

            return false;
        }

        /// <summary>
        /// Attempts to get a strongly typed value for the specified key from the in-memory cache.
        /// </summary>
        /// <typeparam name="T">The type of the value to retrieve.</typeparam>
        /// <param name="model">The <see cref="CacheModel"/> representing the cache settings.</param>
        /// <param name="cache">The in-memory cache instance to retrieve the value from.</param>
        /// <param name="value">The retrieved value, if found.</param>
        /// <returns>True if the value was found; otherwise, false.</returns>
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