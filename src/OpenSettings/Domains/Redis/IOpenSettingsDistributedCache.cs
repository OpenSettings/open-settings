using Microsoft.Extensions.Caching.Distributed;

namespace OpenSettings.Domains.Redis
{
    public interface IOpenSettingsDistributedCache : IDistributedCache { }
}