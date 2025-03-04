using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OpenSettings.Services.MemoryCache
{
    /// <summary>
    /// Represents a custom implementation of the <see cref="Microsoft.Extensions.Caching.Memory.MemoryCache"/> 
    /// to avoid conflicts with the default <see cref="MemoryCache"/>.
    /// </summary>
    public class OpenSettingsMemoryCache : Microsoft.Extensions.Caching.Memory.MemoryCache
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenSettingsMemoryCache"/> class 
        /// using the provided options for memory cache configuration.
        /// </summary>
        /// <param name="optionsAccessor">The <see cref="IOptions{MemoryCacheOptions}"/> used to configure the memory cache.</param>
        public OpenSettingsMemoryCache(
            IOptions<MemoryCacheOptions> optionsAccessor) : base(optionsAccessor)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenSettingsMemoryCache"/> class 
        /// using the provided options and logger factory for memory cache configuration.
        /// </summary>
        /// <param name="optionsAccessor">The <see cref="IOptions{MemoryCacheOptions}"/> used to configure the memory cache.</param>
        /// <param name="loggerFactory">The <see cref="ILoggerFactory"/> used to create loggers for the memory cache operations.</param>
        public OpenSettingsMemoryCache(IOptions<MemoryCacheOptions> optionsAccessor,
            ILoggerFactory loggerFactory
         ) : base(optionsAccessor, loggerFactory)
        {
        }
    }
}