using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OpenSettings.Services.MemoryCache
{
    public class OpenSettingsMemoryCache : Microsoft.Extensions.Caching.Memory.MemoryCache
    {
        public OpenSettingsMemoryCache(
            IOptions<MemoryCacheOptions> optionsAccessor) : base(optionsAccessor)
        {
        }

        public OpenSettingsMemoryCache(IOptions<MemoryCacheOptions> optionsAccessor,
            ILoggerFactory loggerFactory
         ) : base(optionsAccessor, loggerFactory)
        {
        }
    }
}