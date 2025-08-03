namespace OpenSettings.Models
{
    /// <summary>
    /// Represents a key for caching purposes.
    /// </summary>
    public class CacheEntryKey
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheEntryKey"/> class with the specified key and reference cache model.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="cacheEntry">The cache model which key generated from.</param>
        public CacheEntryKey(string key, CacheEntry cacheEntry)
        {
            Key = key;
            CacheEntry = cacheEntry;
        }

        public string Key { get; }

        internal CacheEntry CacheEntry { get; }
    }
}