using Microsoft.Extensions.Configuration;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Models.Responses
{
    public class SyncAppDataResponse
    {
        public const string InstanceFullName = "OpenSettings.Models.Responses.SyncAppDataResponse";

        public ICollection<SyncAppDataResponseSetting> Settings { get; set; } = Array.Empty<SyncAppDataResponseSetting>();

        public ProviderInfo ProviderInfo { get; set; }

        public SyncAppDataResponseConfiguration Configuration { get; set; }

        public SyncAppDataResponseClient Client { get; set; }

        public bool IsProvider { get; set; }

        public bool RequiresAuthentication => ProviderInfo.RequiresAuthentication || Configuration.Controller.RequiresAuthentication;

        public static SyncAppDataResponse Get(IConfiguration configuration)
        {
            var localSyncDataResponse = configuration.GetSection(InstanceFullName).Get<SyncAppDataResponse>();

            return localSyncDataResponse;
        }

        public static ProviderInfo GetProviderInfo(IConfiguration configuration)
        {
            return configuration.GetSection($"{InstanceFullName}:{nameof(ProviderInfo)}").Get<ProviderInfo>();
        }

        public static async Task<SyncAppDataResponse> GetAsync(CancellationToken cancellationToken = default)
        {
            if (!File.Exists(OpenSettingsDefaults.Files.GeneratedOpenSettingsFilePath))
            {
                return null;
            }

            var jsonFile = await JsonHelper.GetJsonFileAsync(OpenSettingsDefaults.Files.GeneratedOpenSettingsFilePath, cancellationToken);

            if (!jsonFile.TryGetValue(InstanceFullName, out var localSyncDataResponseObj) ||
                !(localSyncDataResponseObj is JsonElement localSyncDataResponseJsonElement))
            {
                return null;
            }

            return localSyncDataResponseJsonElement.Deserialize<SyncAppDataResponse>();
        }

        public Task WriteToFileAsync(OpenSettingsConfiguration openSettingsConfiguration, CancellationToken cancellationToken = default)
        {
            var fullPathToInstanceFullNameToObjectInstance = new Dictionary<string, Dictionary<string, object>>();

            var dictionary = fullPathToInstanceFullNameToObjectInstance.GetOrCreateDictionary(OpenSettingsDefaults.Files.GeneratedOpenSettingsFilePath);

            dictionary[InstanceFullName] = ProviderInfo == null
                ? new
                {
                    ProviderInfo = ConstructProviderInfo(openSettingsConfiguration, Configuration.Controller),
                    Configuration,
                    Client = new SyncAppDataResponseClient
                    {
                        Name = openSettingsConfiguration.Client.Name
                    },
                    IsProvider = true
                }
                : new
                {
                    ProviderInfo,
                    Configuration,
                    Client = new SyncAppDataResponseClient
                    {
                        Name = openSettingsConfiguration.Client.Name
                    },
                    IsProvider = false
                };

#if NETSTANDARD2_0
            FileHelper.WriteToDisk(fullPathToInstanceFullNameToObjectInstance);

            return Task.CompletedTask;
#else
            return FileHelper.WriteToDiskAsync(fullPathToInstanceFullNameToObjectInstance, cancellationToken);
#endif
        }

        private static ProviderInfo ConstructProviderInfo(OpenSettingsConfiguration openSettingsConfiguration, ConfigurationController controllerConfiguration)
        {
            var openSettingsAssemblyInfo = OpenSettingsAssemblyInfo.Instance;

            return new ProviderInfo
            {
                Client = new ProviderInfoClient
                {
                    Id = openSettingsConfiguration.Client.Id,
                    Name = openSettingsConfiguration.Client.Name,
                    Version = openSettingsConfiguration.Client.Version,
                },
                Redis = new RedisInfo
                {
                    Channel = openSettingsConfiguration.Provider.Redis.Channel,
                    IsActive= openSettingsConfiguration.Provider.Redis.IsActive,
                    Configuration = openSettingsConfiguration.Provider.Redis.Configuration,
                },
                RequiresAuthentication = controllerConfiguration.RequiresAuthentication,
                PackInfo = new PackInfo
                {
                    Version = openSettingsAssemblyInfo.PackInfo.Version,
                    Score = openSettingsAssemblyInfo.PackInfo.Score,
                    IsPreview = openSettingsAssemblyInfo.PackInfo.IsPreview
                },
                OpenIdConnect = new OpenIdConnectInfo
                {
                    Authority = controllerConfiguration.OpenIdConnect.Authority,
                    AllowOfflineAccess = controllerConfiguration.OpenIdConnect.AllowOfflineAccess,
                    IsActive = controllerConfiguration.OpenIdConnect.IsActive
                }
            };
        }
    }
}