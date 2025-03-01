using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;

namespace OpenSettings.Domains.Redis
{
    public class OpenSettingsDistributedRedisCache : RedisCache, IOpenSettingsDistributedCache
    {
        public OpenSettingsDistributedRedisCache(IOptions<RedisCacheOptions> optionsAccessor) : base(optionsAccessor)
        {
        }
    }
}