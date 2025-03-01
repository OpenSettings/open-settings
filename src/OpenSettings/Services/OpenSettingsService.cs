using Microsoft.Extensions.Caching.Memory;
using OpenSettings.Models;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.MemoryCache;
using System;
using System.Collections.Generic;
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
#if DEBUG
                                   "debug"
#else
                                   "master"
#endif
                                   + "/configs.json";

        private const string CacheControlFormat = "public, max-age={0}";
        private const string GetConfigsKey = "oss:gca:configs";

        private readonly IMemoryCache _memoryCache;
        private readonly HttpClient _httpClient;

        public OpenSettingsService(OpenSettingsMemoryCache memoryCache, HttpClient httpClient)
        {
            _memoryCache = memoryCache;
            _httpClient = httpClient;
        }

        public async Task<GetConfigsResponse> GetConfigsAsync(CancellationToken cancellationToken = default)
        {
            var configs = await GetConfigsDataCacheModelAsync(cancellationToken);

            if (configs == null)
            {
                return null;
            }

            var expiresInSeconds = (int)(configs.AbsoluteExpiration - DateTimeOffset.UtcNow).TotalSeconds;

            return new GetConfigsResponse
            {
                CacheControl = string.Format(CacheControlFormat, expiresInSeconds),
                Expires = configs.AbsoluteExpiration.ToString("R"),
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

            var specificConfigKey = GetSpecificConfigKeyByName(configName);

            var configsData = await _memoryCache.GetOrCreateAsync(specificConfigKey, async c =>
            {
                c.AbsoluteExpirationRelativeToNow = TimeSpan.FromMilliseconds(1);

                try
                {
                    using (var response = await _httpClient.GetAsync(data.Path, cancellationToken))
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

                        var absoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(data.ExpiresInSeconds);

                        c.AbsoluteExpiration = absoluteExpiration;
                        c.AbsoluteExpirationRelativeToNow = null;

                        return new OpenSettingsConfigsDataCacheModel<byte[]>
                        {
                            Data = content,
                            AbsoluteExpiration = absoluteExpiration
                        };
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            });

            if (configsData == null)
            {
                return null;
            }

            var expiresInSeconds = (int)(configsData.AbsoluteExpiration - DateTimeOffset.UtcNow).TotalSeconds;

            return new GetConfigsDataResponse
            {
                CacheControl = string.Format(CacheControlFormat, expiresInSeconds),
                Expires = configsData.AbsoluteExpiration.ToString("R"),
                Data = configsData.Data
            };
        }

        private async Task<OpenSettingsConfigsDataCacheModel<Dictionary<string, OpenSettingsConfigsDataModel>>> GetConfigsDataCacheModelAsync(CancellationToken cancellationToken)
        {
            var configs = await _memoryCache.GetOrCreateAsync(GetConfigsKey, async c =>
            {
                c.AbsoluteExpirationRelativeToNow = TimeSpan.FromMilliseconds(1); // Must be greater than 0!

                try
                {
                    using (var response = await _httpClient.GetAsync(Url, cancellationToken))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            return null;
                        }

                        var content = await response.Content.ReadFromJsonAsync<OpenSettingsConfigModel>(cancellationToken);

                        if (content == null)
                        {
                            return null;
                        }

                        var absoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(content.ExpiresInSeconds);

                        c.AbsoluteExpiration = absoluteExpiration;
                        c.AbsoluteExpirationRelativeToNow = null;

                        return new OpenSettingsConfigsDataCacheModel<Dictionary<string, OpenSettingsConfigsDataModel>>
                        {
                            Data = content.Data,
                            AbsoluteExpiration = absoluteExpiration
                        };
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            });

            return configs;
        }

        private static string GetSpecificConfigKeyByName(string configName)
        {
            return $"{GetConfigsKey}:{configName}";
        }
    }
}