using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using OpenSettings.Models;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="CacheEntry"/> to interact with both in-memory and distributed caches.
    /// This includes methods for setting, getting, and creating cached items, as well as handling expiration and callback options.
    /// </summary>
    public static class CacheEntryKeyExtensions
    {
        /// <summary>
        /// Applies cache settings from the <see cref="MemoryCacheEntryOptions"/> to a cache entry.
        /// </summary>
        private static Action<ICacheEntry, MemoryCacheEntryOptions> ApplyCacheEntryOptionsToCacheEntry { get; } = (cacheEntry, model) =>
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
            cacheEntry.Size = model.Size;
        };

        /// <summary>
        /// Converts the <see cref="MemoryCacheEntryOptions"/> into <see cref="DistributedCacheEntryOptions"/> for use in distributed caching.
        /// </summary>
        /// <param name="cacheEntryOptions">The cache entry options holds expiration and other settings.</param>
        /// <returns>The <see cref="DistributedCacheEntryOptions"/> with properties copied from the <see cref="CacheEntry"/>.</returns>
        private static DistributedCacheEntryOptions ToDistributedCacheEntryOptions(this MemoryCacheEntryOptions cacheEntryOptions) =>
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = cacheEntryOptions.AbsoluteExpirationRelativeToNow,
                AbsoluteExpiration = cacheEntryOptions.AbsoluteExpiration,
                SlidingExpiration = cacheEntryOptions.SlidingExpiration
            };

        /// <summary>
        /// Sets a value with the specified key in the in-memory cache.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="cache">The in-memory cache instance to store the value.</param>
        /// <param name="value">The item to store in the cache.</param>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static void Set<TItem>(this CacheEntryKey cacheEntryKey, IMemoryCache cache, TItem value)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            cache = cache ?? throw new ArgumentNullException(nameof(cache));

            using (var cacheEntry = cache.CreateEntry(cacheEntryKey.Key))
            {
                ApplyCacheEntryOptionsToCacheEntry(cacheEntry, cacheEntryKey.CacheEntry.Options);

                cacheEntry.Value = value;

                OpenSettingsDefaults.Caches.CacheKeys.TryAdd(cacheEntry.Key, 0);
            }
        }

        /// <summary>
        /// Sets a value with the specified key in the in-memory cache.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="cache">The in-memory cache instance to store the value.</param>
        /// <param name="value">The item to store in the cache.</param>
        /// <param name="options">The options for the cache entry.</param>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static void Set<TItem>(this CacheEntryKey cacheEntryKey, IMemoryCache cache, TItem value, MemoryCacheEntryOptions options)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            cache = cache ?? throw new ArgumentNullException(nameof(cache));
            options = options ?? throw new ArgumentNullException(nameof(options));

            using (var cacheEntry = cache.CreateEntry(cacheEntryKey.Key))
            {
                ApplyCacheEntryOptionsToCacheEntry(cacheEntry, options);

                cacheEntry.Value = value;

                OpenSettingsDefaults.Caches.CacheKeys.TryAdd(cacheEntry.Key, 0);
            }
        }

        /// <summary>
        /// Sets a value with the specified key in the in-memory cache.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="cache">The in-memory cache instance to store the value.</param>
        /// <param name="value">The item to store in the cache.</param>
        /// <param name="action">The action used to configure cache entry.</param>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static void Set<TItem>(this CacheEntryKey cacheEntryKey, IMemoryCache cache, TItem value, Action<ICacheEntry> action)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            cache = cache ?? throw new ArgumentNullException(nameof(cache));
            action = action ?? throw new ArgumentNullException(nameof(action));

            using (var cacheEntry = cache.CreateEntry(cacheEntryKey.Key))
            {
                action(cacheEntry);

                cacheEntry.Value = value;

                OpenSettingsDefaults.Caches.CacheKeys.TryAdd(cacheEntry.Key, 0);
            }
        }

        /// <summary>
        /// Sets a value with the specified key in the cache model.
        /// </summary>
        /// <typeparam name="TItem">Item type to set.</typeparam>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="cache">Concrete class which implements the <see cref="IDistributedCache"/>.</param>
        /// <param name="value">Item to set.</param>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static void Set<TItem>(this CacheEntryKey cacheEntryKey, IDistributedCache cache, TItem value)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            cache = cache ?? throw new ArgumentNullException(nameof(cache));

            cache.Set(cacheEntryKey.Key, JsonSerializer.SerializeToUtf8Bytes(value), cacheEntryKey.CacheEntry.Options.ToDistributedCacheEntryOptions());

            OpenSettingsDefaults.Caches.CacheKeys.TryAdd(cacheEntryKey.Key, 0);
        }

        /// <summary>
        /// Sets a value with the specified key in the cache model.
        /// </summary>
        /// <typeparam name="TItem">Item type to set.</typeparam>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="cache">Concrete class which implements the <see cref="IDistributedCache"/>.</param>
        /// <param name="value">Item to set.</param>
        /// <param name="options">The options for the cache entry.</param>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static void Set<TItem>(this CacheEntryKey cacheEntryKey, IDistributedCache cache, TItem value, DistributedCacheEntryOptions options)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            cache = cache ?? throw new ArgumentNullException(nameof(cache));
            options = options ?? throw new ArgumentNullException(nameof(options));

            cache.Set(cacheEntryKey.Key, JsonSerializer.SerializeToUtf8Bytes(value), options);

            OpenSettingsDefaults.Caches.CacheKeys.TryAdd(cacheEntryKey.Key, 0);
        }

        /// <summary>
        /// Asynchronously sets a value with the specified key in the distributed cache.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="cache">The distributed cache instance to store the value.</param>
        /// <param name="value">The item to store in the cache.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous set operation.</returns>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static async Task SetAsync<TItem>(this CacheEntryKey cacheEntryKey, IDistributedCache cache, TItem value, CancellationToken cancellationToken = default)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            cache = cache ?? throw new ArgumentNullException(nameof(cache));

            await cache.SetAsync(cacheEntryKey.Key, JsonSerializer.SerializeToUtf8Bytes(value), cacheEntryKey.CacheEntry.Options.ToDistributedCacheEntryOptions(), cancellationToken);

            OpenSettingsDefaults.Caches.CacheKeys.TryAdd(cacheEntryKey.Key, 0);
        }

        /// <summary>
        /// Asynchronously sets a value with the specified key in the distributed cache.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="cache">The distributed cache instance to store the value.</param>
        /// <param name="value">The item to store in the cache.</param>
        /// <param name="options">The options for the cache entry.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous set operation.</returns>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static async Task SetAsync<TItem>(this CacheEntryKey cacheEntryKey, IDistributedCache cache, TItem value, DistributedCacheEntryOptions options, CancellationToken cancellationToken = default)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            cache = cache ?? throw new ArgumentNullException(nameof(cache));
            options = options ?? throw new ArgumentNullException(nameof(options));

            await cache.SetAsync(cacheEntryKey.Key, JsonSerializer.SerializeToUtf8Bytes(value), options, cancellationToken);

            OpenSettingsDefaults.Caches.CacheKeys.TryAdd(cacheEntryKey.Key, 0);
        }

        /// <summary>
        /// Asynchronously gets or creates a value for the specified key in the in-memory cache, using the provided factory function.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="cache">The in-memory cache instance to store the value.</param>
        /// <param name="factory">The factory function to generate the value if it does not exist in the cache.</param>
        /// <returns>A task that represents the asynchronous get or create operation.</returns>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static async Task<TItem> GetOrCreateAsync<TItem>(this CacheEntryKey cacheEntryKey, IMemoryCache cache, Func<ICacheEntry, Task<TItem>> factory)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            cache = cache ?? throw new ArgumentNullException(nameof(cache));
            factory = factory ?? throw new ArgumentNullException(nameof(factory));
            
            if (!cache.TryGetValue(cacheEntryKey.Key, out var value))
            {
                using (var cacheEntry = cache.CreateEntry(cacheEntryKey.Key))
                {
                    ApplyCacheEntryOptionsToCacheEntry(cacheEntry, cacheEntryKey.CacheEntry.Options);

                    value = cacheEntry.Value = await factory(cacheEntry).ConfigureAwait(continueOnCapturedContext: false);
                }
            }

            OpenSettingsDefaults.Caches.CacheKeys.TryAdd(cacheEntryKey.Key, 0);

            return (TItem)value;
        }

        /// <summary>
        /// Asynchronously gets or creates a value for the specified key in the distributed cache, using the provided factory function.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="cache">The distributed cache instance to store the value.</param>
        /// <param name="factory">The factory function to generate the value if it does not exist in the cache.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous get or create operation.</returns>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static async Task<TItem> GetOrCreateAsync<TItem>(this CacheEntryKey cacheEntryKey, IDistributedCache cache, Func<DistributedCacheEntryOptions, Task<TItem>> factory, CancellationToken cancellationToken = default)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            cache = cache ?? throw new ArgumentNullException(nameof(cache));
            factory = factory ?? throw new ArgumentNullException(nameof(factory));

            var valueAsBytes = await cache.GetAsync(cacheEntryKey.Key, cancellationToken).ConfigureAwait(false);

            if (valueAsBytes != null)
            {
                return JsonSerializer.Deserialize<TItem>(valueAsBytes);
            }

            var distributedCacheEntryOptions = cacheEntryKey.CacheEntry.Options.ToDistributedCacheEntryOptions();

            var value = await factory(distributedCacheEntryOptions).ConfigureAwait(false);

            await cache.SetAsync(cacheEntryKey.Key, JsonSerializer.SerializeToUtf8Bytes(value), distributedCacheEntryOptions, cancellationToken).ConfigureAwait(false);

            OpenSettingsDefaults.Caches.CacheKeys.TryAdd(cacheEntryKey.Key, 0);

            return value;
        }

        /// <summary>
        /// Gets or creates a value for the specified key in the in-memory cache, using the provided factory function.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="cache">The in-memory cache instance to store the value.</param>
        /// <param name="factory">The factory function to generate the value if it does not exist in the cache.</param>
        /// <returns>The cached or newly created value.</returns>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static TItem GetOrCreate<TItem>(this CacheEntryKey cacheEntryKey, IMemoryCache cache, Func<ICacheEntry, TItem> factory)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            cache = cache ?? throw new ArgumentNullException(nameof(cache));
            factory = factory ?? throw new ArgumentNullException(nameof(factory));

            if (!cache.TryGetValue(cacheEntryKey.Key, out var value))
            {
                using (var cacheEntry = cache.CreateEntry(cacheEntryKey.Key))
                {
                    ApplyCacheEntryOptionsToCacheEntry(cacheEntry, cacheEntryKey.CacheEntry.Options);

                    value = cacheEntry.Value = factory(cacheEntry);
                }
            }

            OpenSettingsDefaults.Caches.CacheKeys.TryAdd(cacheEntryKey.Key, 0);

            return (TItem)value;
        }

        /// <summary>
        /// Gets or creates a value for the specified key in the distributed cache, using the provided factory function.
        /// </summary>
        /// <typeparam name="TItem">The type of the item to be cached.</typeparam>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="distributedCache">The distributed cache instance to store the value.</param>
        /// <param name="factory">The factory function to generate the value if it does not exist in the cache.</param>
        /// <returns>The cached or newly created value.</returns>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static TItem GetOrCreate<TItem>(this CacheEntryKey cacheEntryKey, IDistributedCache distributedCache, Func<DistributedCacheEntryOptions, TItem> factory)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
            factory = factory ?? throw new ArgumentNullException(nameof(factory));

            var valueAsBytes = distributedCache.Get(cacheEntryKey.Key);

            if (valueAsBytes != null)
            {
                OpenSettingsDefaults.Caches.CacheKeys.TryAdd(cacheEntryKey.Key, 0);

                return JsonSerializer.Deserialize<TItem>(valueAsBytes);
            }

            var distributedCacheEntryOptions = cacheEntryKey.CacheEntry.Options.ToDistributedCacheEntryOptions();

            var value = factory(distributedCacheEntryOptions);

            distributedCache.Set(cacheEntryKey.Key, JsonSerializer.SerializeToUtf8Bytes(value), distributedCacheEntryOptions);

            OpenSettingsDefaults.Caches.CacheKeys.TryAdd(cacheEntryKey.Key, 0);

            return value;
        }

        /// <summary>
        /// Attempts to get a value for the specified key from the in-memory cache.
        /// </summary>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="memoryCache">The in-memory cache instance to retrieve the value from.</param>
        /// <param name="value">The retrieved value, if found.</param>
        /// <returns>True if the value was found; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static bool TryGetValue(this CacheEntryKey cacheEntryKey, IMemoryCache memoryCache, out object value)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));

            if (memoryCache.TryGetValue(cacheEntryKey.Key, out value))
            {
                OpenSettingsDefaults.Caches.CacheKeys.TryAdd(cacheEntryKey.Key, 0);

                return true;
            }

            OpenSettingsDefaults.Caches.CacheKeys.TryRemove(cacheEntryKey.Key, out _);

            return false;
        }

        /// <summary>
        /// Attempts to get a strongly typed value for the specified key from the in-memory cache.
        /// </summary>
        /// <typeparam name="T">The type of the value to retrieve.</typeparam>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="memoryCache">The in-memory cache instance to retrieve the value from.</param>
        /// <param name="value">The retrieved value, if found.</param>
        /// <returns>True if the value was found; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static bool TryGetValue<T>(this CacheEntryKey cacheEntryKey, IMemoryCache memoryCache, out T value)
        {
            if (TryGetValue(cacheEntryKey, memoryCache, out var valueAsObject))
            {
                value = (T)valueAsObject;

                return true;
            }

            value = default;

            return false;
        }

        /// <summary>
        /// Remove a specific cache entry from memory cache.
        /// <para>
        /// The <see cref="Remove(CacheEntryKey, IMemoryCache)"/> method removes the cache entry corresponding to the cache key from the memory cache.
        /// </para>
        /// </summary>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="memoryCache">The <see cref="IMemoryCache"/> instance used to remove the cache entry.</param>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static void Remove(this CacheEntryKey cacheEntryKey, IMemoryCache memoryCache)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));

            memoryCache.Remove(cacheEntryKey.Key);
            OpenSettingsDefaults.Caches.CacheKeys.TryRemove(cacheEntryKey.Key, out _);
        }

        /// <summary>
        /// Removes a specific cache entry from distributed cache.
        /// <para>
        /// The <see cref="Remove(CacheEntryKey, IDistributedCache)"/> method removes the cache entry corresponding to the cache key from the distributed cache.
        /// </para>
        /// </summary>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="distributedCache">The <see cref="IDistributedCache"/> instance used to remove the cache entry.</param>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static void Remove(this CacheEntryKey cacheEntryKey, IDistributedCache distributedCache)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));

            distributedCache.Remove(cacheEntryKey.Key);
            OpenSettingsDefaults.Caches.CacheKeys.TryRemove(cacheEntryKey.Key, out _);
        }

        /// <summary>
        /// Removes a specific cache entry from distributed cache asynchronously.
        /// <para>
        /// The <see cref="RemoveAsync(CacheEntryKey, IDistributedCache, CancellationToken)"/> method removes the cache entry corresponding to the cache key from the distributed cache asynchronously.
        /// </para>
        /// </summary>
        /// <param name="cacheEntryKey">The <see cref="CacheEntryKey"/> representing the cache key.</param>
        /// <param name="distributedCache">The <see cref="IDistributedCache"/> instance used to remove the cache entry.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">When any input parameter is null.</exception>
        public static async Task RemoveAsync(this CacheEntryKey cacheEntryKey, IDistributedCache distributedCache, CancellationToken cancellationToken = default)
        {
            cacheEntryKey = cacheEntryKey ?? throw new ArgumentNullException(nameof(cacheEntryKey));
            distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));

            await distributedCache.RemoveAsync(cacheEntryKey.Key, cancellationToken);
            OpenSettingsDefaults.Caches.CacheKeys.TryRemove(cacheEntryKey.Key, out _);
        }
    }
}