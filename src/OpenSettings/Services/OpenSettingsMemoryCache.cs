using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenSettings.Services.Interfaces;

namespace OpenSettings.Services
{
    /// <summary>
    /// Represents a custom implementation of the <see cref="MemoryCache"/> 
    /// to avoid conflicts with the default <see cref="MemoryCache"/>.
    /// </summary>
    internal sealed class OpenSettingsMemoryCache : MemoryCache, IOpenSettingsMemoryCache
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenSettingsMemoryCache"/> class 
        /// using the provided options for memory cache configuration.
        /// </summary>
        public OpenSettingsMemoryCache() : base(Options.Create(new MemoryCacheOptions()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenSettingsMemoryCache"/> class 
        /// using the provided options and logger factory for memory cache configuration.
        /// </summary>
        /// <param name="loggerFactory">The <see cref="ILoggerFactory"/> used to create loggers for the memory cache operations.</param>
        public OpenSettingsMemoryCache(ILoggerFactory loggerFactory) : base(Options.Create(new MemoryCacheOptions()), loggerFactory)
        {
        }
    }
}