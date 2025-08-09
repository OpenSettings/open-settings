using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services
{
    public class OpenSettingsService : IOpenSettingsService
    {
        private const string Url = "https://raw.githubusercontent.com/OpenSettings/open-settings-configs/refs/heads/" +

                                   "master"

                                   + "/configs.json";

        private const string NotificationsConfigName = "notifications";

        private readonly ILogger _logger;
        private readonly IMemoryCache _openSettingsMemoryCache;
        private readonly IHttpClientFactory _httpClientFactory;

        public OpenSettingsService(ILogger<OpenSettingsService> logger, IOpenSettingsMemoryCache openSettingsMemoryCache, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<GetConfigsResponse> GetConfigsAsync(CancellationToken cancellationToken = default)
        {
            var configs = await GetConfigsDataCacheModelAsync(cancellationToken);

            if (configs == null)
            {
                return null;
            }

            var expiresInSeconds = (configs.AbsoluteExpiration - DateTimeOffset.UtcNow).TotalSeconds;

            var age = configs.ExpiresInSeconds - expiresInSeconds;

            return new GetConfigsResponse
            {
                CacheControl = Helpers.Helper.GetPublicCacheControlValue(expiresInSeconds),
                Expires = configs.AbsoluteExpiration.ToString("R"),
                Age = (int)age,
                Data = JsonSerializer.SerializeToUtf8Bytes(configs.Data)
            };
        }

        public async Task<GetConfigsDataResponse> GetConfigsDataAsync(string configName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(configName))
            {
                return null;
            }

            var configs = await GetConfigsDataCacheModelAsync(cancellationToken);

            if (configs == null)
            {
                return null;
            }

            configName = configName.Trim().ToLowerInvariant();

            if (!configs.Data.TryGetValue(configName, out var data))
            {
                return null;
            }

            var specificConfigCacheKey = OpenSettingsDefaults.Caches.OpenSettingsConfigsCacheEntry.GetKey(configName);
            
            var configsData = await specificConfigCacheKey.GetOrCreateAsync(_openSettingsMemoryCache, async c =>
            {
                c.AbsoluteExpirationRelativeToNow = TimeSpan.FromMilliseconds(1);

                try
                {
                    using (var response = await GetHttpClient().GetAsync(data.Path, cancellationToken))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            return null;
                        }

                        var content = await response.Content.ReadAsByteArrayAsync(
#if NET5_0_OR_GREATER
                            cancellationToken
#endif
                            );

                        var absoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(Math.Max(0, data.ExpiresInSeconds));

                        c.AbsoluteExpiration = absoluteExpiration;
                        c.AbsoluteExpirationRelativeToNow = null;

                        return new OpenSettingsConfigsDataCacheModel<byte[]>
                        {
                            Data = content,
                            ExpiresInSeconds = data.ExpiresInSeconds,
                            AbsoluteExpiration = absoluteExpiration
                        };
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An exception occurred while getting specific config data. Config name: '{configName}'.", configName);

                    return null;
                }
            });

            if (configsData == null)
            {
                return null;
            }
            
            var expiresInSeconds = (int)(configsData.AbsoluteExpiration - DateTimeOffset.UtcNow).TotalSeconds;

            var age = configsData.ExpiresInSeconds - expiresInSeconds;

            return new GetConfigsDataResponse
            {
                CacheControl = Helpers.Helper.GetPublicCacheControlValue(expiresInSeconds),
                Expires = configsData.AbsoluteExpiration.ToString("R"),
                Age = (int)age,
                Data = configsData.Data
            };
        }

        public async Task<GetOpenSettingsNotificationsResponse> GetNotificationsAsync(CancellationToken cancellationToken = default)
        {
            var openSettingsConfigResponse = await GetConfigsDataAsync(NotificationsConfigName, cancellationToken);

            var idToOpenSettingNotification = openSettingsConfigResponse?.Data == null
                ? new Dictionary<Guid, GetOpenSettingsNotificationsResponseNotification>()
                : JsonSerializer.Deserialize<GetOpenSettingsNotificationsResponseNotification[]>(openSettingsConfigResponse.Data, OpenSettingsDefaults.Serialization.JsonCaseInsensitiveOptions)
                    .DistinctBy(n => n.Id)
                    .Where(n => n.Id != Guid.Empty)
                    .ToDictionary(n => n.Id);

            return new GetOpenSettingsNotificationsResponse
            {
                IdToNotification = idToOpenSettingNotification,
                CacheControl = openSettingsConfigResponse?.CacheControl,
                Expires = openSettingsConfigResponse?.Expires,
                IsFaulted = openSettingsConfigResponse == null
            };
        }

        private async Task<OpenSettingsConfigsDataCacheModel<Dictionary<string, OpenSettingsConfigsDataModel>>> GetConfigsDataCacheModelAsync(CancellationToken cancellationToken)
        {
            var configs = await OpenSettingsDefaults.Caches.OpenSettingsConfigsCacheEntryKey.GetOrCreateAsync(_openSettingsMemoryCache, async cacheModel =>
            {
                cacheModel.AbsoluteExpirationRelativeToNow = TimeSpan.FromMilliseconds(1); // Must be greater than 0!

                try
                {
                    using (var response = await GetHttpClient().GetAsync(Url, cancellationToken))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            return null;
                        }

                        var content = await response.Content.ReadFromJsonAsync<OpenSettingsConfigModel>(cancellationToken: cancellationToken);

                        if (content == null)
                        {
                            return null;
                        }

                        var absoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(Math.Max(0, content.ExpiresInSeconds));

                        cacheModel.AbsoluteExpiration = absoluteExpiration;
                        cacheModel.AbsoluteExpirationRelativeToNow = null;

                        return new OpenSettingsConfigsDataCacheModel<Dictionary<string, OpenSettingsConfigsDataModel>>
                        {
                            Data = content.Data,
                            ExpiresInSeconds = content.ExpiresInSeconds,
                            AbsoluteExpiration = absoluteExpiration
                        };
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An exception occurred while getting configs.");

                    return null;
                }
            });

            return configs;
        }

        private HttpClient GetHttpClient()
        {
            return _httpClientFactory.CreateClient();
        }
    }
}