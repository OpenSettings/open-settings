using Microsoft.Extensions.Configuration;
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

        public static SyncAppDataResponse Get(IConfiguration configuration)
        {
            var localSyncDataResponse = configuration.GetSection(InstanceFullName).Get<SyncAppDataResponse>();

            return localSyncDataResponse;
        }

        public static async Task<SyncAppDataResponse> GetAsync(CancellationToken cancellationToken = default)
        {
            if (!File.Exists(Constants.GeneratedOpenSettingsFilePath))
            {
                return null;
            }

            var jsonFile = await JsonHelper.GetJsonFileAsync(Constants.GeneratedOpenSettingsFilePath, cancellationToken);

            if (!jsonFile.TryGetValue(InstanceFullName, out var localSyncDataResponseObj) ||
                !(localSyncDataResponseObj is JsonElement localSyncDataResponseJsonElement))
            {
                return null;
            }

            return localSyncDataResponseJsonElement.Deserialize<SyncAppDataResponse>();
        }

        public Task WriteToFileAsync(CancellationToken cancellationToken = default)
        {
            var fullPathToInstanceFullNameToObjectInstance = new Dictionary<string, Dictionary<string, object>>();

            var dictionary = fullPathToInstanceFullNameToObjectInstance.GetOrCreateDictionary(Constants.GeneratedOpenSettingsFilePath);

            dictionary[InstanceFullName] = new
            {
                ProviderInfo,
                Configuration
            };

#if NETSTANDARD2_0
            FileHelper.WriteToDisk(fullPathToInstanceFullNameToObjectInstance);

            return Task.CompletedTask;
#else
            return FileHelper.WriteToDiskAsync(fullPathToInstanceFullNameToObjectInstance, cancellationToken);
#endif
        }
    }
}