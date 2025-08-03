using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;

namespace OpenSettings.Models
{
    /// <summary>
    /// Represents a model for organizing and tracking memory cache keys.
    /// <para>
    /// This class is designed to track cache keys in a more organized manner, supporting operations like 
    /// managing cache key parts and reusing cache details efficiently.
    /// </para>
    /// <para>
    /// The <see cref="CacheEntry"/> class provides functionality for concatenating cache key parts, storing cache keys, 
    /// and organizing them using a concurrent dictionary for better performance and thread safety.
    /// </para>
    /// </summary>
    public class CacheEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheEntry"/> class with the specified key and relative expiration time.
        /// </summary>
        /// <param name="baseKey">The key used to identify the cache entry.</param>
        /// <param name="absoluteExpirationRelativeToNow">The relative expiration time after which the cache entry will expire.</param>
        public CacheEntry(string baseKey, TimeSpan? absoluteExpirationRelativeToNow) : this(baseKey, absoluteExpirationRelativeToNow, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheEntry"/> class with the specified key parts and relative expiration time.
        /// </summary>
        /// <param name="keyParts">An array of key parts used to identify the cache entry.</param>
        /// <param name="absoluteExpirationRelativeToNow">The relative expiration time after which the cache entry will expire.</param>
        public CacheEntry(object[] keyParts, TimeSpan? absoluteExpirationRelativeToNow) : this(keyParts, absoluteExpirationRelativeToNow, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheEntry"/> class with the specified key and absolute expiration date.
        /// </summary>
        /// <param name="baseKey">The key used to identify the cache entry.</param>
        /// <param name="absoluteExpiration">The absolute expiration date after which the cache entry will expire.</param>
        public CacheEntry(string baseKey, DateTimeOffset? absoluteExpiration) : this(baseKey, absoluteExpiration, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheEntry"/> class with the specified key parts and absolute expiration date.
        /// </summary>
        /// <param name="keyParts">An array of key parts used to identify the cache entry.</param>
        /// <param name="absoluteExpiration">The absolute expiration date after which the cache entry will expire.</param>
        public CacheEntry(object[] keyParts, DateTimeOffset? absoluteExpiration) : this(keyParts, absoluteExpiration, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheEntry"/> class with the specified key, absolute expiration date, and sliding expiration time.
        /// </summary>
        /// <param name="baseKey">The key used to identify the cache entry.</param>
        /// <param name="absoluteExpiration">The absolute expiration date after which the cache entry will expire.</param>
        /// <param name="slidingExpiration">The sliding expiration time after which the cache entry will expire if not accessed.</param>
        public CacheEntry(string baseKey, DateTimeOffset? absoluteExpiration, TimeSpan? slidingExpiration) : this(baseKey)
        {
            Options.AbsoluteExpiration = absoluteExpiration;
            Options.SlidingExpiration = slidingExpiration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheEntry"/> class with the specified key parts, absolute expiration date, and sliding expiration time.
        /// </summary>
        /// <param name="keyParts">An array of key parts used to identify the cache entry.</param>
        /// <param name="absoluteExpiration">The absolute expiration date after which the cache entry will expire.</param>
        /// <param name="slidingExpiration">The sliding expiration time after which the cache entry will expire if not accessed.</param>
        public CacheEntry(object[] keyParts, DateTimeOffset? absoluteExpiration, TimeSpan? slidingExpiration) : this(keyParts)
        {
            Options.AbsoluteExpiration = absoluteExpiration;
            Options.SlidingExpiration = slidingExpiration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheEntry"/> class with the specified key and relative expiration time, and sliding expiration time.
        /// </summary>
        /// <param name="baseKey">The key used to identify the cache entry.</param>
        /// <param name="absoluteExpirationRelativeToNow">The relative expiration time after which the cache entry will expire.</param>
        /// <param name="slidingExpiration">The sliding expiration time after which the cache entry will expire if not accessed.</param>
        public CacheEntry(object baseKey, TimeSpan? absoluteExpirationRelativeToNow, TimeSpan? slidingExpiration) : this(baseKey)
        {
            Options.AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow;
            Options.SlidingExpiration = slidingExpiration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheEntry"/> class with the specified key parts, relative expiration time, and sliding expiration time.
        /// </summary>
        /// <param name="keyParts">An array of key parts used to identify the cache entry.</param>
        /// <param name="absoluteExpirationRelativeToNow">The relative expiration time after which the cache entry will expire.</param>
        /// <param name="slidingExpiration">The sliding expiration time after which the cache entry will expire if not accessed.</param>
        public CacheEntry(object[] keyParts, TimeSpan? absoluteExpirationRelativeToNow, TimeSpan? slidingExpiration) : this(keyParts)
        {
            Options.AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow;
            Options.SlidingExpiration = slidingExpiration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheEntry"/> class with the specified key parts.
        /// </summary>
        /// <param name="keyParts">An array of key parts used to identify the cache entry.</param>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="keyParts"/> is null.</exception>
        public CacheEntry(params object[] keyParts)
        {
            if (keyParts == null)
            {
                throw new ArgumentNullException(nameof(keyParts));
            }

            BaseKey = string.Join(OpenSettingsDefaults.Format.Column, keyParts);

            Options.PostEvictionCallbacks.Add(GetDefaultCallbackRegistration(BaseKey));
        }

        private static PostEvictionCallbackRegistration GetDefaultCallbackRegistration(object baseKey) =>
            new PostEvictionCallbackRegistration
            {
                EvictionCallback = (k, value, reason, state) =>
                {
                    OpenSettingsDefaults.Caches.CacheKeys.TryRemove(baseKey, out _);
                }
            };

        public CacheEntry(string baseKey)
        {
            BaseKey = baseKey ?? throw new ArgumentNullException(nameof(baseKey));

            Options.PostEvictionCallbacks.Add(GetDefaultCallbackRegistration(BaseKey));
        }

        public string BaseKey { get; }

        public MemoryCacheEntryOptions Options { get; } = new MemoryCacheEntryOptions();

        /// <summary>
        /// Generates a cache key based on the base key and provided key parts.
        /// </summary>
        /// <param name="keyParts">Additional key parts.</param>
        /// <returns></returns>
        public CacheEntryKey GetKey(params object[] keyParts)
        {
            var key = keyParts?.Length > 0 
                ? string.Join(OpenSettingsDefaults.Format.Column, keyParts.Prepend(BaseKey)) 
                : BaseKey;

            return new CacheEntryKey(key, this);
        }
    }
}