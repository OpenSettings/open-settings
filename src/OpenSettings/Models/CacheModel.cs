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
    public class CacheModel
    {
        private const string ColumnConcatenator = ":";

        private static readonly ConcurrentDictionary<object, HashSet<object>> AllKeys = new ConcurrentDictionary<object, HashSet<object>>();

        private readonly object _keyFirstPart;

        public CacheModel(object key, TimeSpan? absoluteExpirationRelativeToNow) : this(key, absoluteExpirationRelativeToNow, null) { }

        public CacheModel(object[] keyParts, TimeSpan? absoluteExpirationRelativeToNow) : this(keyParts, absoluteExpirationRelativeToNow, null) { }

        public CacheModel(object key, DateTimeOffset? absoluteExpiration) : this(key, absoluteExpiration, null) { }

        public CacheModel(object[] keyParts, DateTimeOffset? absoluteExpiration) : this(keyParts, absoluteExpiration, null) { }

        public CacheModel(object key, DateTimeOffset? absoluteExpiration, TimeSpan? slidingExpiration) : this(key)
        {
            AbsoluteExpiration = absoluteExpiration;
            SlidingExpiration = slidingExpiration;
        }

        public CacheModel(object[] keyParts, DateTimeOffset? absoluteExpiration, TimeSpan? slidingExpiration) :
            this(keyParts)
        {
            AbsoluteExpiration = absoluteExpiration;
            SlidingExpiration = slidingExpiration;
        }

        public CacheModel(object key, TimeSpan? absoluteExpirationRelativeToNow, TimeSpan? slidingExpiration) : this(key)
        {
            AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow;
            SlidingExpiration = slidingExpiration;
        }

        public CacheModel(object[] keyParts, TimeSpan? absoluteExpirationRelativeToNow, TimeSpan? slidingExpiration) : this(keyParts)
        {
            AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow;
            SlidingExpiration = slidingExpiration;
        }

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
            new PostEvictionCallbackRegistration()
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

        //
        // Summary:
        //     Gets or sets an absolute expiration date for the cache entry.
        public DateTimeOffset? AbsoluteExpiration { get; }

        //
        // Summary:
        //     Gets or sets an absolute expiration time, relative to now.
        public TimeSpan? AbsoluteExpirationRelativeToNow { get; }

        //
        // Summary:
        //     Gets or sets how long a cache entry can be inactive (e.g. not accessed) before
        //     it will be removed. This will not extend the entry lifetime beyond the absolute
        //     expiration (if set).
        public TimeSpan? SlidingExpiration { get; }

        //
        // Summary:
        //     Gets the Microsoft.Extensions.Primitives.IChangeToken instances which cause the
        //     cache entry to expire.
        public IList<IChangeToken> ExpirationTokens { get; } = new List<IChangeToken>();

        //
        // Summary:
        //     Gets or sets the callbacks will be fired after the cache entry is evicted from
        //     the cache.
        public IList<PostEvictionCallbackRegistration> PostEvictionCallbacks { get; } = new List<PostEvictionCallbackRegistration>();

        //
        // Summary:
        //     Gets or sets the priority for keeping the cache entry in the cache during a memory
        //     pressure triggered cleanup. The default is Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal.
        public CacheItemPriority Priority { get; set; } = CacheItemPriority.Normal;

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

        public void Delete(IMemoryCache memoryCache)
        {
            var keyValues = AllKeys[_keyFirstPart];

            keyValues.Remove(Key);
            memoryCache?.Remove(Key);
        }

        public void Delete(IDistributedCache distributedCache)
        {
            var keyValues = AllKeys[_keyFirstPart];

            keyValues.Remove(Key);
            distributedCache?.Remove($"{Key}");
        }

        public Task DeleteAsync(IDistributedCache distributedCache)
        {
            var keyValues = AllKeys[_keyFirstPart];

            keyValues.Remove(Key);

            return distributedCache?.RemoveAsync($"{Key}") ?? Task.CompletedTask;
        }

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