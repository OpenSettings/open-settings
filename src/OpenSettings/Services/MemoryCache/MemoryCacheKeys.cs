using OpenSettings.Models;
using System;

namespace OpenSettings.Services.MemoryCache
{
    /// <summary>
    /// Provides predefined cache keys for various parts of the application. 
    /// These keys are used for caching specific data in the memory cache to improve performance.
    /// </summary>
    public static class MemoryCacheKeys
    {
        /// <summary>
        /// The cache key for available notification ids, with a 5-minute expiration time.
        /// </summary>
        public static CacheModel GetAvailableNotificationIds = new CacheModel("nss:gania", TimeSpan.FromMinutes(5));

        /// <summary>
        /// The cache key for the Settings Spa Middleware Html content.
        /// </summary>
        public static CacheModel SettingsSpaMiddlewareHtml = new CacheModel("ossm:html");
    }
}