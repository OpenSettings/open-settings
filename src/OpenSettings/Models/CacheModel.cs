using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Models
{
    /// <summary>
    /// Represents a model for organizing and tracking memory cache keys.
    /// <para>
    /// This class is designed to track cache keys in a more organized manner, supporting operations like 
    /// managing cache key parts and reusing cache details efficiently.
    /// </para>
    /// <para>
    /// The <see cref="CacheModel"/> class provides functionality for concatenating cache key parts, storing cache keys, 
    /// and organizing them using a concurrent dictionary for better performance and thread safety.
    /// </para>
    /// </summary>
    public class CacheModel
    {
        private const string ColumnConcatenator = ":";

        private static readonly ConcurrentDictionary<object, HashSet<object>> AllKeys = new ConcurrentDictionary<object, HashSet<object>>();

        private readonly object _keyFirstPart;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheModel"/> class with the specified key and relative expiration time.
        /// </summary>
        /// <param name="key">The key used to identify the cache entry.</param>
        /// <param name="absoluteExpirationRelativeToNow">The relative expiration time after which the cache entry will expire.</param>
        public CacheModel(object key, TimeSpan? absoluteExpirationRelativeToNow) : this(key, absoluteExpirationRelativeToNow, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheModel"/> class with the specified key parts and relative expiration time.
        /// </summary>
        /// <param name="keyParts">An array of key parts used to identify the cache entry.</param>
        /// <param name="absoluteExpirationRelativeToNow">The relative expiration time after which the cache entry will expire.</param>
        public CacheModel(object[] keyParts, TimeSpan? absoluteExpirationRelativeToNow) : this(keyParts, absoluteExpirationRelativeToNow, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheModel"/> class with the specified key and absolute expiration date.
        /// </summary>
        /// <param name="key">The key used to identify the cache entry.</param>
        /// <param name="absoluteExpiration">The absolute expiration date after which the cache entry will expire.</param>
        public CacheModel(object key, DateTimeOffset? absoluteExpiration) : this(key, absoluteExpiration, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheModel"/> class with the specified key parts and absolute expiration date.
        /// </summary>
        /// <param name="keyParts">An array of key parts used to identify the cache entry.</param>
        /// <param name="absoluteExpiration">The absolute expiration date after which the cache entry will expire.</param>
        public CacheModel(object[] keyParts, DateTimeOffset? absoluteExpiration) : this(keyParts, absoluteExpiration, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheModel"/> class with the specified key, absolute expiration date, and sliding expiration time.
        /// </summary>
        /// <param name="key">The key used to identify the cache entry.</param>
        /// <param name="absoluteExpiration">The absolute expiration date after which the cache entry will expire.</param>
        /// <param name="slidingExpiration">The sliding expiration time after which the cache entry will expire if not accessed.</param>
        public CacheModel(object key, DateTimeOffset? absoluteExpiration, TimeSpan? slidingExpiration) : this(key)
        {
            AbsoluteExpiration = absoluteExpiration;
            SlidingExpiration = slidingExpiration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheModel"/> class with the specified key parts, absolute expiration date, and sliding expiration time.
        /// </summary>
        /// <param name="keyParts">An array of key parts used to identify the cache entry.</param>
        /// <param name="absoluteExpiration">The absolute expiration date after which the cache entry will expire.</param>
        /// <param name="slidingExpiration">The sliding expiration time after which the cache entry will expire if not accessed.</param>
        public CacheModel(object[] keyParts, DateTimeOffset? absoluteExpiration, TimeSpan? slidingExpiration) : this(keyParts)
        {
            AbsoluteExpiration = absoluteExpiration;
            SlidingExpiration = slidingExpiration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheModel"/> class with the specified key and relative expiration time, and sliding expiration time.
        /// </summary>
        /// <param name="key">The key used to identify the cache entry.</param>
        /// <param name="absoluteExpirationRelativeToNow">The relative expiration time after which the cache entry will expire.</param>
        /// <param name="slidingExpiration">The sliding expiration time after which the cache entry will expire if not accessed.</param>
        public CacheModel(object key, TimeSpan? absoluteExpirationRelativeToNow, TimeSpan? slidingExpiration) : this(key)
        {
            AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow;
            SlidingExpiration = slidingExpiration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheModel"/> class with the specified key parts, relative expiration time, and sliding expiration time.
        /// </summary>
        /// <param name="keyParts">An array of key parts used to identify the cache entry.</param>
        /// <param name="absoluteExpirationRelativeToNow">The relative expiration time after which the cache entry will expire.</param>
        /// <param name="slidingExpiration">The sliding expiration time after which the cache entry will expire if not accessed.</param>
        public CacheModel(object[] keyParts, TimeSpan? absoluteExpirationRelativeToNow, TimeSpan? slidingExpiration) : this(keyParts)
        {
            AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow;
            SlidingExpiration = slidingExpiration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheModel"/> class with the specified key parts.
        /// </summary>
        /// <param name="keyParts">An array of key parts used to identify the cache entry.</param>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="keyParts"/> is null.</exception>
        public CacheModel(params object[] keyParts)
        {
            if (keyParts == null)
            {
                throw new ArgumentNullException(nameof(keyParts));
            }

            _keyFirstPart = keyParts[0];

            var values = AllKeys.GetOrAdd(_keyFirstPart, s => new HashSet<object>());

            Key = string.Join(ColumnConcatenator, keyParts.Where(k => k != null));

            values.Add(Key);

            PostEvictionCallbacks.Add(GetDefaultCallbackRegistration(_keyFirstPart));
        }

        private static PostEvictionCallbackRegistration GetDefaultCallbackRegistration(object keyFirstPart) =>
            new PostEvictionCallbackRegistration
            {
                EvictionCallback = (k, value, reason, state) =>
                {
                    if ((int)reason >= 3)
                    {
                        var keyValues = AllKeys[keyFirstPart];

                        keyValues.Remove(k);
                    }
                }
            };

        public CacheModel(object key)
        {
            _keyFirstPart = key ?? throw new ArgumentNullException(nameof(key));

            var values = AllKeys.GetOrAdd(_keyFirstPart, s => new HashSet<object>());

            Key = _keyFirstPart;

            values.Add(Key);

            PostEvictionCallbacks.Add(GetDefaultCallbackRegistration(_keyFirstPart));
        }

        public object Key { get; }

        /// <summary>
        /// Gets or sets an absolute expiration date for the cache entry.
        /// </summary>
        public DateTimeOffset? AbsoluteExpiration { get; }

        /// <summary>
        /// Gets or sets an absolute expiration time, relative to now.
        /// </summary>
        public TimeSpan? AbsoluteExpirationRelativeToNow { get; }

        /// <summary>
        /// Gets or sets how long a cache entry can be inactive (e.g. not accessed) before
        /// it will be removed. This will not extend the entry lifetime beyond the absolute
        /// expiration (if set).
        /// </summary>
        public TimeSpan? SlidingExpiration { get; }

        /// <summary>
        /// Gets the Microsoft.Extensions.Primitives.IChangeToken instances which cause the
        /// cache entry to expire
        /// </summary>
        public IList<IChangeToken> ExpirationTokens { get; } = new List<IChangeToken>();

        /// <summary>
        /// Gets or sets the callbacks will be fired after the cache entry is evicted from
        /// the cache.
        /// </summary>
        public IList<PostEvictionCallbackRegistration> PostEvictionCallbacks { get; } = new List<PostEvictionCallbackRegistration>();

        /// <summary>
        /// Gets or sets the priority for keeping the cache entry in the cache during a memory
        /// pressure triggered cleanup. The default is Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal.
        /// </summary>
        public CacheItemPriority Priority { get; set; } = CacheItemPriority.Normal;

        /// <summary>
        /// Deletes cache entries from memory cache based on the provided predicate.
        /// <para>
        /// The <see cref="Delete(IMemoryCache, Func{object, bool})"/> method will evaluate the given predicate to filter cache keys, 
        /// and removes the corresponding cache entries from the memory cache.
        /// </para>
        /// </summary>
        /// <param name="memoryCache">The <see cref="IMemoryCache"/> instance used to remove the cache entries.</param>
        /// <param name="predicate">A function used to evaluate and filter cache keys to be deleted.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="predicate"/> is <c>null</c>.</exception>
        public void Delete(IMemoryCache memoryCache, Func<object, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            var keyValues = AllKeys[_keyFirstPart];

            var keys = keyValues.Where(predicate).ToArray();

            foreach (var key in keys)
            {
                keyValues.Remove(key);
                memoryCache?.Remove(key);
            }
        }

        /// <summary>
        /// Deletes cache entries from memory cache if the cache key starts with the given key parts.
        /// <para>
        /// The <see cref="DeleteIfStartsWith(IMemoryCache, object[])"/> method removes cache entries whose keys match a given pattern 
        /// that starts with the specified <paramref name="keyParts"/>.
        /// </para>
        /// </summary>
        /// <param name="memoryCache">The <see cref="IMemoryCache"/> instance used to remove the cache entries.</param>
        /// <param name="keyParts">The parts of the key to match the cache keys starting with.</param>
        public void DeleteIfStartsWith(IMemoryCache memoryCache, params object[] keyParts)
        {
            var keyPattern = string.Join(ColumnConcatenator, keyParts[0] != _keyFirstPart ? keyParts.Prepend(_keyFirstPart) : keyParts);

            var keyValues = AllKeys[_keyFirstPart];

            var keys = keyValues.Select(k => k.ToString()).Where(k => k.StartsWith(keyPattern)).ToArray();

            foreach (var key in keys)
            {
                keyValues.Remove(key);
                memoryCache?.Remove(key);
            }
        }

        /// <summary>
        /// Deletes cache entries from distributed cache asynchronously if the cache key starts with the given key parts.
        /// <para>
        /// The <see cref="DeleteIfStartsWithAsync(IDistributedCache, CancellationToken, object[])"/> method removes cache entries from 
        /// the distributed cache that match a given pattern based on the <paramref name="keyParts"/>. This operation is performed asynchronously.
        /// </para>
        /// </summary>
        /// <param name="distributedCache">The <see cref="IDistributedCache"/> instance used to remove the cache entries.</param>
        /// <param name="cancellationToken">A token used to cancel the asynchronous operation.</param>
        /// <param name="keyParts">The parts of the key to match the cache keys starting with.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task DeleteIfStartsWithAsync(IDistributedCache distributedCache, CancellationToken cancellationToken, params object[] keyParts)
        {
            var keyPattern = string.Join(ColumnConcatenator, keyParts[0] != _keyFirstPart ? keyParts.Prepend(_keyFirstPart) : keyParts);

            var keyValues = AllKeys[_keyFirstPart];

            var keys = keyValues.Select(k => k.ToString()).Where(k => k.StartsWith(keyPattern)).ToArray();

            var tasks = new List<Task>();

            foreach (var key in keys)
            {
                keyValues.Remove(key);

                if (distributedCache != null)
                {
                    tasks.Add(distributedCache.RemoveAsync(key, cancellationToken));
                }
            }

            return Task.WhenAll(tasks);
        }

        /// <summary>
        /// Deletes a specific cache entry from memory cache.
        /// <para>
        /// The <see cref="Delete(IMemoryCache)"/> method removes the cache entry corresponding to the cache key from the memory cache.
        /// </para>
        /// </summary>
        /// <param name="memoryCache">The <see cref="IMemoryCache"/> instance used to remove the cache entry.</param>
        public void Delete(IMemoryCache memoryCache)
        {
            var keyValues = AllKeys[_keyFirstPart];

            keyValues.Remove(Key);
            memoryCache?.Remove(Key);
        }

        /// <summary>
        /// Deletes a specific cache entry from distributed cache.
        /// <para>
        /// The <see cref="Delete(IDistributedCache)"/> method removes the cache entry corresponding to the cache key from the distributed cache.
        /// </para>
        /// </summary>
        /// <param name="distributedCache">The <see cref="IDistributedCache"/> instance used to remove the cache entry.</param>
        public void Delete(IDistributedCache distributedCache)
        {
            var keyValues = AllKeys[_keyFirstPart];

            keyValues.Remove(Key);
            distributedCache?.Remove($"{Key}");
        }

        /// <summary>
        /// Deletes a specific cache entry from distributed cache asynchronously.
        /// <para>
        /// The <see cref="DeleteAsync(IDistributedCache)"/> method removes the cache entry corresponding to the cache key from the distributed cache asynchronously.
        /// </para>
        /// </summary>
        /// <param name="distributedCache">The <see cref="IDistributedCache"/> instance used to remove the cache entry.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task DeleteAsync(IDistributedCache distributedCache)
        {
            var keyValues = AllKeys[_keyFirstPart];

            keyValues.Remove(Key);

            return distributedCache?.RemoveAsync($"{Key}") ?? Task.CompletedTask;
        }

        /// <summary>
        /// Deletes all cache entries from memory cache.
        /// <para>
        /// The <see cref="DeleteAll(IMemoryCache)"/> method removes all cache entries from the memory cache associated with the current cache model.
        /// </para>
        /// </summary>
        /// <param name="memoryCache">The <see cref="IMemoryCache"/> instance used to remove all cache entries.</param>
        public void DeleteAll(IMemoryCache memoryCache)
        {
            var keyValues = AllKeys[_keyFirstPart];

            if (memoryCache != null)
            {
                foreach (var key in keyValues)
                {
                    memoryCache.Remove(key);
                }
            }

            keyValues.Clear();
        }

        /// <summary>
        /// Deletes all cache entries from distributed cache asynchronously.
        /// <para>
        /// The <see cref="DeleteAllAsync(IDistributedCache)"/> method removes all cache entries from the distributed cache associated with the current cache model asynchronously.
        /// </para>
        /// </summary>
        /// <param name="distributedCache">The <see cref="IDistributedCache"/> instance used to remove all cache entries.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteAllAsync(IDistributedCache distributedCache)
        {
            var keyValues = AllKeys[_keyFirstPart];

            if (distributedCache != null)
            {
                await Task.WhenAll(keyValues.Select(k => distributedCache.RemoveAsync($"{k}")))
                    .ConfigureAwait(false);
            }

            keyValues.Clear();
        }
    }
}