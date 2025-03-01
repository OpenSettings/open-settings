using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OpenSettings.Domains.Redis
{
    public class OpenSettingsDistributedMemoryCache : MemoryDistributedCache, IOpenSettingsDistributedCache
    {
        public OpenSettingsDistributedMemoryCache(IOptions<MemoryDistributedCacheOptions> optionsAccessor) : base(optionsAccessor) { }

        public OpenSettingsDistributedMemoryCache(IOptions<MemoryDistributedCacheOptions> optionsAccessor, ILoggerFactory loggerFactory) : base(optionsAccessor, loggerFactory) { }
    }
}