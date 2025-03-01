using OpenSettings.Configurations;
using OpenSettings.Models.Responses;

namespace OpenSettings.Models
{
    public class LocalSyncDataResponse
    {
        public LocalSyncDataResponse(SyncAppDataResponse syncAppDataResponse, OpenSettingsConfiguration openSettingsConfiguration)
        {
            if (syncAppDataResponse != null)
            {
                ProviderInfo = syncAppDataResponse.ProviderInfo;
                openSettingsConfiguration.AllowAnonymousAccess = syncAppDataResponse.Configuration.AllowAnonymousAccess;
                openSettingsConfiguration.StoreInSeparateFile = syncAppDataResponse.Configuration.StoreInSeparateFile;
                openSettingsConfiguration.IgnoreOnFileChange = syncAppDataResponse.Configuration.IgnoreOnFileChange;
                openSettingsConfiguration.RegistrationMode = syncAppDataResponse.Configuration.RegistrationMode;

                if (openSettingsConfiguration.IsConsumerSelected)
                {
                    openSettingsConfiguration.Consumer.RequestEncodings = syncAppDataResponse.Configuration.Consumer.RequestEncodings;
                    openSettingsConfiguration.Consumer.IsRedisActive = syncAppDataResponse.Configuration.Consumer.IsRedisActive;
                    openSettingsConfiguration.Consumer.PollingSettingsWorker.IsActive = syncAppDataResponse.Configuration.Consumer.PollingSettingsWorker.IsActive;
                    openSettingsConfiguration.Consumer.PollingSettingsWorker.StartsIn = syncAppDataResponse.Configuration.Consumer.PollingSettingsWorker.StartsIn;
                    openSettingsConfiguration.Consumer.PollingSettingsWorker.Period = syncAppDataResponse.Configuration.Consumer.PollingSettingsWorker.Period;
                }
                else
                {
                    openSettingsConfiguration.Provider.CompressionLevel = syncAppDataResponse.Configuration.Provider.CompressionLevel;
                    openSettingsConfiguration.Provider.CompressionType = syncAppDataResponse.Configuration.Provider.CompressionType;
                    openSettingsConfiguration.Provider.Redis.IsActive = syncAppDataResponse.Configuration.Provider.Redis.IsActive;
                    openSettingsConfiguration.Provider.Redis.Configuration = syncAppDataResponse.Configuration.Provider.Redis.Configuration;
                    openSettingsConfiguration.Provider.Redis.Channel = syncAppDataResponse.Configuration.Provider.Redis.Channel;
                }

                IsSynced = true;
            }

            AllowAnonymousAccess = openSettingsConfiguration.AllowAnonymousAccess;
            StoreInSeparateFile = openSettingsConfiguration.StoreInSeparateFile;
            IgnoreOnFileChange = openSettingsConfiguration.IgnoreOnFileChange;
            RegistrationMode = openSettingsConfiguration.RegistrationMode;
        }

        public ProviderInfo ProviderInfo { get; }

        public bool AllowAnonymousAccess { get; }

        public bool StoreInSeparateFile { get; }

        public bool IgnoreOnFileChange { get; }

        public RegistrationMode RegistrationMode { get; }

        public bool IsSynced { get; }
    }
}