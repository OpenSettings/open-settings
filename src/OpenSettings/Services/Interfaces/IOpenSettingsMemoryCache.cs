using Microsoft.Extensions.Caching.Memory;

namespace OpenSettings.Services.Interfaces
{
    /// <summary>
    /// Represents a memory cache specifically for OpenSettings. To avoid conflicts with the default <see cref="IMemoryCache"/>.
    /// </summary>
    public interface IOpenSettingsMemoryCache : IMemoryCache
    {
    }
}