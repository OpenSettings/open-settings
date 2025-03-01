using StackExchange.Redis;

namespace OpenSettings.Domains.Redis.DataContext
{
    public class Context : RedisContext
    {
        public Context(ConfigurationOptions opts, RedisContextOptions redisContextOptions) : base(opts, redisContextOptions) { }
    }
}