using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ogu.Response.Json;
using OpenSettings.Attributes;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services
{
    internal sealed class LocalSettingsService : ILocalSettingsService
    {
        private static readonly Type GenericOptionsType = typeof(IOptions<>);
        private static readonly Type GenericOptionsSnapshot = typeof(IOptionsSnapshot<>);
        private static readonly Type GenericOptionsMonitor = typeof(IOptionsMonitor<>);
        private static readonly MethodInfo GetServiceMethodInfo = typeof(IServiceProvider).GetMethod("GetService");
        private static readonly ConcurrentDictionary<string, CurrentSettingsData> IdentifierNameToCurrentSettingsData = new ConcurrentDictionary<string, CurrentSettingsData>();

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly ILogger _logger;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly IAppsService _appsService;
        private readonly ISettingsService _settingsService;

        public LocalSettingsService(OpenSettingsConfiguration openSettingsConfiguration, IAppsService appsService, ISettingsService settingsService)
        {
            _logger = openSettingsConfiguration.LoggerFactory.CreateLogger<LocalSettingsService>();
            _openSettingsConfiguration = openSettingsConfiguration;
            _appsService = appsService;
            _settingsService = settingsService;
        }

        public async Task<T> GetSettingAsync<T>(string identifierName, CancellationToken cancellationToken = default) where T : ISettings
        {
            if (string.IsNullOrWhiteSpace(identifierName))
            {
                throw new ArgumentException("Identifier cannot be null, empty, or whitespace.", nameof(identifierName));
            }

            var type = typeof(T);

            var requestComputedIdentifier = Constants.TypeIdToComputedIdentifier.TryGetValue(type.GUID, out var computedIdentifier)
                ? computedIdentifier
                : ((ComputedIdentifierAttribute)type.GetCustomAttribute(Constants.ComputedIdentifierAttributeType, true))?.ComputedIdentifier ?? Helper.ComputeIdentifier(type.FullName);

            identifierName = identifierName.Trim().ToLowerInvariant();

            if (IdentifierNameToCurrentSettingsData.TryGetValue(identifierName, out var result))
            {
                return result.ComputedIdentifierToInstance.TryGetValue(requestComputedIdentifier, out var data) ? (T)data : default;
            }

            var request = new FetchAppDataInput
            {
                ClientId = _openSettingsConfiguration.Client.Id,
                IdentifierName = identifierName,
            };

            var readResponse = await _appsService.FetchAppDataAsync(request, cancellationToken);

            if (readResponse?.Success != true)
            {
                return default;
            }

            var computedIdentifierToInstance = new Dictionary<Guid, object>();
            object requestTypeInstance = null;
            var computedIdentifierToData = readResponse.Data.Settings.ToDictionary(r => r.ComputedIdentifier, r => r.Data);

            foreach (var settingData in Constants.ComputedIdentifierToLocalSetting.Values)
            {
                if (!computedIdentifierToData.TryGetValue(settingData.ComputedIdentifier, out var data))
                {
                    continue;
                }

                try
                {
                    var instance = JsonSerializer.Deserialize(data, settingData.Type);

                    computedIdentifierToInstance[settingData.ComputedIdentifier] = instance;

                    if (settingData.ComputedIdentifier == requestComputedIdentifier)
                    {
                        requestTypeInstance = instance;
                    }
                }
                catch (Exception ex)
                {
                    Logs.ErrorOccurredWhenDeserializing(_logger, data, settingData.Type.Name, ex);
                }
            }

            if (computedIdentifierToInstance.Count == 0)
            {
                return default;
            }

            var model = new CurrentSettingsData
            {
                LastUpdatedOn = readResponse.Data.LastUpdatedOn,
                ComputedIdentifierToInstance = computedIdentifierToInstance,
            };

            IdentifierNameToCurrentSettingsData.AddOrUpdate(identifierName, model, (k, existingValue) => model);

            return requestTypeInstance != null ? (T)requestTypeInstance : default;
        }

        public T GetSetting<T>() where T : ISettings
        {
            var requestTypeGuid = typeof(T).GUID;

            return Constants.TypeIdToComputedIdentifier.TryGetValue(requestTypeGuid, out var computedIdentifier) &&
                   IdentifierNameToCurrentSettingsData.TryGetValue(_openSettingsConfiguration.IdentifierNameLowercase, out var result) &&
                   result.ComputedIdentifierToInstance.TryGetValue(computedIdentifier, out var data)
                ? (T)data
                : default;
        }

        public Task<T> GetSettingAsync<T>(IServiceProvider serviceProvider, params ConfigSource[] configSources)
        {
            return GetSettingAsync<T>(serviceProvider, CancellationToken.None, configSources);
        }

        public async Task<T> GetSettingAsync<T>(IServiceProvider serviceProvider, CancellationToken cancellationToken, params ConfigSource[] configSources)
        {
            var requestTypeGuid = typeof(T).GUID;

            if (!Constants.TypeIdToComputedIdentifier.TryGetValue(requestTypeGuid, out var computedIdentifier))
            {
                return default;
            }

            var setting = await GetSettingAsync(serviceProvider, computedIdentifier, cancellationToken, configSources);

            return setting == null ? default : (T)setting;
        }

        public Task<object> GetSettingAsync(IServiceProvider serviceProvider, Guid computedIdentifier, params ConfigSource[] configSources)
        {
            return GetSettingAsync(serviceProvider, computedIdentifier, CancellationToken.None, configSources);
        }

        public async Task<object> GetSettingAsync(IServiceProvider serviceProvider, Guid computedIdentifier, CancellationToken cancellationToken, params ConfigSource[] configSources)
        {
            if (!Constants.ComputedIdentifierToLocalSetting.TryGetValue(computedIdentifier, out var localSetting) || !(configSources?.Length > 0))
            {
                return null;
            }

            foreach (var configSource in configSources)
            {
                switch (configSource)
                {
                    case ConfigSource.File when File.Exists(localSetting.GeneratedFilePath):

                        var dictionary = await JsonHelper.GetJsonFileAsync(localSetting.GeneratedFilePath, cancellationToken);

                        if (dictionary.TryGetValue(localSetting.Type.FullName, out var instance))
                        {
                            return JsonSerializer.Deserialize($"{instance}", localSetting.Type);
                        }

                        break;

                    case ConfigSource.Singleton when (localSetting.RegistrationMode & RegistrationMode.Singleton) == RegistrationMode.Singleton:

                        return serviceProvider.GetService(localSetting.Type);

                    case ConfigSource.Options when (localSetting.RegistrationMode & RegistrationMode.Configure) == RegistrationMode.Configure:

                        return ((IOptions<object>)GetOptionsService(serviceProvider, GenericOptionsType, localSetting.Type)).Value;

                    case ConfigSource.OptionsSnapshot when (localSetting.RegistrationMode & RegistrationMode.Configure) == RegistrationMode.Configure:

                        return ((IOptionsSnapshot<object>)GetOptionsService(serviceProvider, GenericOptionsSnapshot, localSetting.Type)).Value;

                    case ConfigSource.OptionsMonitor when (localSetting.RegistrationMode & RegistrationMode.Configure) == RegistrationMode.Configure:

                        return ((IOptionsMonitor<object>)GetOptionsService(serviceProvider, GenericOptionsMonitor, localSetting.Type)).CurrentValue;

                    case ConfigSource.Local:

                        return localSetting.Instance;
                }
            }

            return null;
        }

        public async Task SettingDataChangeNotifiedAsync(Guid computedIdentifier, CancellationToken cancellationToken = default)
        {
            if (!Constants.ComputedIdentifierToLocalSetting.TryGetValue(computedIdentifier, out var settingData) ||
                !IdentifierNameToCurrentSettingsData.TryGetValue(_openSettingsConfiguration.IdentifierNameLowercase, out var model) ||
                !model.ComputedIdentifierToInstance.TryGetValue(computedIdentifier, out var instance))
            {
                return;
            }

            IDictionary<string, object> fullNameToInstance;

            var request = new FetchAppDataInput
            {
                ClientId = _openSettingsConfiguration.Client.Id,
                IdentifierName = _openSettingsConfiguration.IdentifierName,
                ComputedIdentifiers = new HashSet<Guid> { computedIdentifier }
            };

            var readResponse = await _appsService.FetchAppDataAsync(request, cancellationToken);

            if (readResponse?.Success != true)
            {
                return;
            }

            var computedIdentifierToData =
                readResponse.Data.Settings.ToDictionary(k => k.ComputedIdentifier, k => k.Data);

            if (computedIdentifierToData.Count == 0 ||
                !computedIdentifierToData.TryGetValue(computedIdentifier, out var data))
            {
                return;
            }

            try
            {
                settingData.Instance = instance = JsonSerializer.Deserialize(data, settingData.Type);

                if (readResponse.Data.LastUpdatedOn > model.LastUpdatedOn)
                {
                    model.LastUpdatedOn = readResponse.Data.LastUpdatedOn;
                }

                if (File.Exists(settingData.GeneratedFilePath))
                {
                    fullNameToInstance = await JsonHelper.GetJsonFileAsync(settingData.GeneratedFilePath, cancellationToken);

                    fullNameToInstance[settingData.Type.FullName] = instance;
                }
                else
                {
                    fullNameToInstance = new Dictionary<string, object>(1) { { settingData.Type.FullName, instance } };
                }
            }
            catch (Exception ex)
            {
                Logs.ErrorOccurredWhenDeserializing(_logger, data, settingData.Type.Name, ex);

                return;
            }

#if NETSTANDARD2_0
            WriteSettingsToFile(settingData.GeneratedFilePath, fullNameToInstance);
#else
            await WriteSettingsToFileAsync(settingData.GeneratedFilePath, fullNameToInstance, cancellationToken);
#endif
        }

        public async Task<bool> ReloadSettingsAsync(string identifierName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(identifierName))
            {
                throw new ArgumentException("Identifier cannot be null, empty, or whitespace.", nameof(identifierName));
            }

            identifierName = identifierName.Trim().ToLowerInvariant();

            if (identifierName == _openSettingsConfiguration.IdentifierNameLowercase)
            {
                return await ReloadSettingsAsync(cancellationToken);
            }

            if (!IdentifierNameToCurrentSettingsData.TryGetValue(identifierName, out var currentSettingsData))
            {
                return false;
            }

            var settingsLastUpdatedClassComputedIdentifiers = await _settingsService.GetSettingsLastUpdatedComputedIdentifiersAsync(
                new GetSettingsLastUpdatedComputedIdentifiersInput
                {
                    ClientId = _openSettingsConfiguration.Client.Id,
                    LastUpdatedOn = currentSettingsData?.LastUpdatedOn,
                    IdentifierName = identifierName
                }, cancellationToken);

            var computedIdentifierToUpdatedOn =
                settingsLastUpdatedClassComputedIdentifiers.Data.ComputedIdentifierToUpdatedOn.ToDictionary(k => k.Key,
                    k => k.Value);

            if (computedIdentifierToUpdatedOn.Count == 0)
            {
                return true;
            }

            var request = new FetchAppDataInput
            {
                ClientId = _openSettingsConfiguration.Client.Id,
                IdentifierName = identifierName,
            };

            var readResponse = await _appsService.FetchAppDataAsync(request, cancellationToken);

            if (readResponse == null)
            {
                return false;
            }

            var computedIdentifierToData = readResponse.Data.Settings.ToDictionary(r => r.ComputedIdentifier, r => r.Data);

            var computedIdentifierToInstance = new Dictionary<Guid, object>();

            foreach (var settingData in Constants.ComputedIdentifierToLocalSetting.Values)
            {
                if (!computedIdentifierToData.TryGetValue(settingData.ComputedIdentifier, out var data))
                {
                    continue;
                }

                try
                {
                    computedIdentifierToInstance[settingData.Type.GUID] = JsonSerializer.Deserialize(data, settingData.Type);
                }
                catch (Exception ex)
                {
                    // ignored
                }
            }

            if (computedIdentifierToInstance.Count == 0)
            {
                return true;
            }

            currentSettingsData = new CurrentSettingsData
            {
                LastUpdatedOn = readResponse.Data.LastUpdatedOn,
                ComputedIdentifierToInstance = computedIdentifierToInstance,
            };

            IdentifierNameToCurrentSettingsData.AddOrUpdate(identifierName, currentSettingsData, (k, existingValue) => currentSettingsData);

            return true;
        }

        public async Task<bool> ReloadSettingsAsync(CancellationToken cancellationToken = default)
        {
#if NETSTANDARD2_0
            IdentifierNameToCurrentSettingsData.TryGetValue(_openSettingsConfiguration.IdentifierNameLowercase, out var settingsData);
#else
            var settingsData = IdentifierNameToCurrentSettingsData.GetValueOrDefault(_openSettingsConfiguration.IdentifierNameLowercase);
#endif
            var settingsLastUpdatedClassComputedIdentifiers = await _settingsService.GetSettingsLastUpdatedComputedIdentifiersAsync(
                new GetSettingsLastUpdatedComputedIdentifiersInput
                {
                    ClientId = _openSettingsConfiguration.Client.Id,
                    LastUpdatedOn = settingsData?.LastUpdatedOn,
                    IdentifierName = _openSettingsConfiguration.IdentifierName
                }, cancellationToken);

            if (settingsLastUpdatedClassComputedIdentifiers?.Success != true)
            {
                return false;
            }

            var computedIdentifierToUpdatedOn = settingsLastUpdatedClassComputedIdentifiers.Data.ComputedIdentifierToUpdatedOn.ToDictionary(k => k.Key, k => k.Value);

            if (computedIdentifierToUpdatedOn.Count == 0)
            {
                return true;
            }

            var readRequest = new FetchAppDataInput
            {
                ClientId = _openSettingsConfiguration.Client.Id,
                IdentifierName = _openSettingsConfiguration.IdentifierName,
                ComputedIdentifiers = new HashSet<Guid>(computedIdentifierToUpdatedOn.Keys)
            };

            var readResponse = await _appsService.FetchAppDataAsync(readRequest, cancellationToken);

            if (readResponse?.Success != true)
            {
                return false;
            }

            var computedIdentifierToData = readResponse.Data.Settings.ToDictionary(s => s.ComputedIdentifier);

            var computedIdentifierToSyncAppDataResponse = new Dictionary<Guid, SyncAppDataResponseSetting>();

            foreach (var responseData in computedIdentifierToData)
            {
                computedIdentifierToSyncAppDataResponse[responseData.Key] = Constants.ComputedIdentifierToLocalSetting.TryGetValue(responseData.Key, out var settingData)
                    ? new SyncAppDataResponseSetting
                    {
                        ComputedIdentifier = settingData.ComputedIdentifier,
                        Data = responseData.Value.Data,
                        StoreInSeparateFile = settingData.StoreInSeparateFile,
                        IgnoreOnFileChange = settingData.IgnoreOnFileChange,
                        RegistrationMode = settingData.RegistrationMode
                    }
                    : new SyncAppDataResponseSetting
                    {
                        ComputedIdentifier = responseData.Value.ComputedIdentifier,
                        Data = responseData.Value.Data,
                        StoreInSeparateFile = responseData.Value.StoreInSeparateFile,
                        IgnoreOnFileChange = responseData.Value.IgnoreOnFileChange,
                        RegistrationMode = responseData.Value.RegistrationMode
                    };
            }

            var fullPathToInstanceFullNameToObjectInstance = UpdateLocalData(computedIdentifierToSyncAppDataResponse);

#if NETSTANDARD2_0
            WriteToDisk(fullPathToInstanceFullNameToObjectInstance);
#else
            await WriteToDiskAsync(fullPathToInstanceFullNameToObjectInstance, cancellationToken);
#endif
            return true;
        }

        public void DeleteSettings(string identifierName)
        {
            if (string.IsNullOrWhiteSpace(identifierName))
            {
                return;
            }

            identifierName = identifierName.Trim().ToLowerInvariant();

            if (_openSettingsConfiguration.IdentifierNameLowercase != identifierName)
            {
                IdentifierNameToCurrentSettingsData.TryRemove(identifierName, out _);
            }
        }

        public async Task<IJsonResponse> GetLocalSettingAsync(IServiceProvider serviceProvider, Guid computedIdentifier, ConfigSource configSource, CancellationToken cancellationToken)
        {
            if (!Constants.ComputedIdentifierToLocalSetting.TryGetValue(computedIdentifier, out var localSetting))
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.LocalSettingNotFound);
            }

            var setting = await GetSettingAsync(serviceProvider, computedIdentifier, cancellationToken, configSource);

            if (setting != null)
            {
                return HttpStatusCode.OK.ToSuccessJsonResponse(setting);
            }

            switch (configSource)
            {
                case ConfigSource.File:

                    return HttpStatusCode.NotFound.ToFailureJsonResponse(File.Exists(localSetting.GeneratedFilePath) ? Errors.SettingNotFound : Errors.GeneratedSettingFileNotFound);

                case ConfigSource.Singleton:

                    return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.RegistrationModeSingletonNotSupported);

                case ConfigSource.Options:

                    return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.RegistrationModeConfigureNotSupported);

                case ConfigSource.OptionsSnapshot:

                    return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.RegistrationModeConfigureNotSupported);

                case ConfigSource.OptionsMonitor:

                    return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.RegistrationModeConfigureNotSupported);

                default:

                    return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.ConfigSourceNotSupported);
            }
        }

        internal async Task<LocalSyncDataResponse> SyncAppDataAsync(CancellationToken cancellationToken = default)
        {
            var appSqlModel = new SyncAppDataInput
            {
                Client = new SyncAppDataInputClient
                {
                    Id = _openSettingsConfiguration.Client.Id,
                    Name = _openSettingsConfiguration.Client.Name,
                    Secret = _openSettingsConfiguration.Client.Secret
                },
                UserId = null,
                Configuration = new SyncAppDataInputConfiguration
                {
                    AllowAnonymousAccess = _openSettingsConfiguration.AllowAnonymousAccess,
                    StoreInSeparateFile = _openSettingsConfiguration.StoreInSeparateFile,
                    IgnoreOnFileChange = _openSettingsConfiguration.IgnoreOnFileChange,
                    RegistrationMode = _openSettingsConfiguration.RegistrationMode,
                    Consumer = new ConfigurationConsumer
                    {
                        RequestEncodings = _openSettingsConfiguration.Consumer.RequestEncodings,
                        IsRedisActive = _openSettingsConfiguration.Consumer.IsRedisActive,
                        PollingSettingsWorker = new ConfigurationConsumerPollingSettingsWorker
                        {
                            IsActive = _openSettingsConfiguration.Consumer.PollingSettingsWorker.IsActive,
                            StartsIn = _openSettingsConfiguration.Consumer.PollingSettingsWorker.StartsIn,
                            Period = _openSettingsConfiguration.Consumer.PollingSettingsWorker.Period
                        }
                    },
                    Provider = new ConfigurationProvider
                    {
                        Redis = _openSettingsConfiguration.Provider.Redis,
                        CompressionType = _openSettingsConfiguration.Provider.CompressionType,
                        CompressionLevel = _openSettingsConfiguration.Provider.CompressionLevel
                    }
                },
                Settings = GenerateSettings(Constants.ComputedIdentifierToLocalSetting.Values, _openSettingsConfiguration),
                Instance = new SyncAppDataInputInstance
                {
                    InstanceName = _openSettingsConfiguration.InstanceName,
                    DynamicId = _openSettingsConfiguration.InstanceDynamicId,
                    Urls = Array.Empty<string>(),
                    MachineName = Environment.MachineName,
                    Environment = Helper.GetEnvironmentName(),
                    ReloadStrategies = _openSettingsConfiguration.GetReloadStrategies(),
                    ServiceType = _openSettingsConfiguration.Selection,
                    DataAccessType = _openSettingsConfiguration.IsConsumerSelected ? (DataAccessType?)null : _openSettingsConfiguration.Provider.Selection,
                    Version = _openSettingsConfiguration.Client.Version,
                    IsDisabled = false
                },
                AppType = AppType.Dotnet,
                IdentifierName = _openSettingsConfiguration.IdentifierName
            };

            SyncAppDataResponse syncAppDataResponse = null;
            var attempt = 1;
            Exception exception = null;

            do
            {
                try
                {
                    var response = await _appsService.SyncAppDataAsync(appSqlModel, cancellationToken);

                    if (!response.Success)
                    {
                        exception = response.Errors.ToException();

                        if (exception != null)
                        {
                            throw exception;
                        }

                        throw new Exception("Unknown exception occurred.");
                    }

                    syncAppDataResponse = response.Data;
                }
                catch (AuthenticationException)
                {
                    throw;
                }
                catch (Exception) when (Debugger.IsAttached)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    exception = ex;
                }

                if (syncAppDataResponse == null)
                {
                    var doNotRetry = Constants.ComputedIdentifierToLocalSetting.Count == 0 || (_openSettingsConfiguration.SyncAppDataMaxRetryCount != -1 && attempt >= _openSettingsConfiguration.SyncAppDataMaxRetryCount);

                    Logs.InitializationFailed(_logger, attempt, !doNotRetry, exception);

                    if (doNotRetry)
                    {
                        break;
                    }

                    await Task.Delay(_openSettingsConfiguration.SyncAppDataRetryDelayMilliseconds, cancellationToken);
                }
                else
                {
                    Logs.InitializationSucceed(_logger, _openSettingsConfiguration.InstanceDynamicId, null);
                }

                attempt++;

            } while (syncAppDataResponse == null);

            var fullPathToInstanceFullNameToObjectInstance = syncAppDataResponse == null
                ? UpdateLocalData()
                : UpdateLocalData(syncAppDataResponse.Settings.ToDictionary(d => d.ComputedIdentifier, d => d));

            DeleteFiles();

#if NETSTANDARD2_0
            WriteToDisk(fullPathToInstanceFullNameToObjectInstance);
#else
            await WriteToDiskAsync(fullPathToInstanceFullNameToObjectInstance, cancellationToken);
#endif

            return new LocalSyncDataResponse(syncAppDataResponse, _openSettingsConfiguration);
        }

#if NETSTANDARD2_0
        internal void WriteToDisk(
            Dictionary<string, Dictionary<string, object>> fullPathToInstanceFullNameToObjectInstance)
#else
        internal async Task WriteToDiskAsync(
            Dictionary<string, Dictionary<string, object>> fullPathToInstanceFullNameToObjectInstance,
            CancellationToken cancellationToken)
#endif
        {
#if NETSTANDARD2_0
            foreach (var kvp in fullPathToInstanceFullNameToObjectInstance)
            {
                WriteSettingsToFile(kvp.Key, kvp.Value);
            }
#else
            var writeSettingsToFileTasks = fullPathToInstanceFullNameToObjectInstance.Select(kvp => WriteSettingsToFileAsync(kvp.Key, kvp.Value, cancellationToken));

            await Task.WhenAll(writeSettingsToFileTasks);
#endif
        }

        internal Dictionary<string, Dictionary<string, object>> UpdateLocalData()
        {
            var fullPathToInstanceFullNameToObjectInstance = new Dictionary<string, Dictionary<string, object>>();
            var computedIdentifierToInstance = new Dictionary<Guid, object>();

            foreach (var kvp in Constants.ComputedIdentifierToLocalSetting)
            {
                var fullNameToObjectInstance = fullPathToInstanceFullNameToObjectInstance.GetOrCreateDictionary(kvp.Value.GeneratedFilePath);

                fullNameToObjectInstance[kvp.Value.Type.FullName] = kvp.Value.Instance;

                computedIdentifierToInstance.Add(kvp.Key, kvp.Value.Instance);
            }

            var model = new CurrentSettingsData
            {
                ComputedIdentifierToInstance = computedIdentifierToInstance
            };

            IdentifierNameToCurrentSettingsData.AddOrUpdate(_openSettingsConfiguration.IdentifierNameLowercase, model,
                (k, existingValue) => model);

            return fullPathToInstanceFullNameToObjectInstance;
        }

        private Dictionary<string, Dictionary<string, object>> UpdateLocalData(Dictionary<Guid, SyncAppDataResponseSetting> computedIdentifierToSetting)
        {
            var fullPathToInstanceFullNameToObjectInstance = new Dictionary<string, Dictionary<string, object>>();

            var singleSettingFilePath = Path.Combine(Environment.CurrentDirectory, Constants.SettingsFileNameWithExtension);
            var singleGeneratedSettingFilePath = Path.Combine(Environment.CurrentDirectory, Constants.GeneratedSettingsFileNameWithExtension);

            var stringBuilder = new StringBuilder();

            var computedIdentifierToInstance = new Dictionary<Guid, object>();

            foreach (var localSetting in Constants.ComputedIdentifierToLocalSetting.Values)
            {
                if (computedIdentifierToSetting.TryGetValue(localSetting.ComputedIdentifier, out var syncAppDataResponseSetting))
                {
                    localSetting.StoreInSeparateFile = syncAppDataResponseSetting.StoreInSeparateFile;
                    localSetting.IgnoreOnFileChange = localSetting.StoreInSeparateFile
                        ? Constants.ClassNameToCount[localSetting.Type.Name] == 1
                            ? syncAppDataResponseSetting.IgnoreOnFileChange
                            : false
                        : null;
                    localSetting.RegistrationMode = syncAppDataResponseSetting.RegistrationMode;

                    try
                    {
                        localSetting.Instance = JsonSerializer.Deserialize(syncAppDataResponseSetting.Data, localSetting.Type);
                    }
                    catch (Exception ex)
                    {
                        Logs.ErrorOccurredWhenDeserializing(_logger, syncAppDataResponseSetting.Data, localSetting.Type.FullName, ex);
                    }

                    string filePath, generatedFilePath;

                    if (localSetting.StoreInSeparateFile)
                    {
                        filePath = Helper.GetSettingFilePathWithExtension(localSetting.Type.Name, stringBuilder);
                        generatedFilePath = Helper.GetGeneratedSettingFilePathWithExtension(localSetting.Type.Name, stringBuilder);
                    }
                    else
                    {
                        filePath = singleSettingFilePath;
                        generatedFilePath = singleGeneratedSettingFilePath;
                    }

                    localSetting.FilePath = filePath;
                    localSetting.GeneratedFilePath = generatedFilePath;

                    var fullNameToObjectInstance = fullPathToInstanceFullNameToObjectInstance.GetOrCreateDictionary(generatedFilePath);

                    fullNameToObjectInstance[localSetting.Type.FullName] = localSetting.Instance;
                }
                else
                {
                    var fullNameToObjectInstance = fullPathToInstanceFullNameToObjectInstance.GetOrCreateDictionary(localSetting.GeneratedFilePath);

                    fullNameToObjectInstance[localSetting.Type.FullName] = localSetting.Instance;
                }

                computedIdentifierToInstance.Add(localSetting.ComputedIdentifier, localSetting.Instance);
            }

            var model = new CurrentSettingsData
            {
                LastUpdatedOn = DateTime.UtcNow,
                ComputedIdentifierToInstance = computedIdentifierToInstance
            };

            IdentifierNameToCurrentSettingsData.AddOrUpdate(_openSettingsConfiguration.IdentifierNameLowercase, model,
                (k, existingValue) => model);

            return fullPathToInstanceFullNameToObjectInstance;
        }

#if NETSTANDARD2_0
        internal void WriteSettingsToFile(string filePath, IDictionary<string, object> data)
#else
        internal async Task WriteSettingsToFileAsync(string filePath, IDictionary<string, object> data, CancellationToken cancellationToken = default)
#endif
        {
            if (filePath == null)
            {
                return;
            }

            var json = JsonSerializer.Serialize(data, Constants.UnsafeRelaxedJsonAndWriteIndentedSerializerOptions);

            try
            {
#if NETSTANDARD2_0
                _semaphore.Wait();

                File.WriteAllText(filePath, json);
#else
                await _semaphore.WaitAsync(cancellationToken);

                await File.WriteAllTextAsync(filePath, json, cancellationToken);
#endif
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private static SyncAppDataInputSetting[] GenerateSettings(IEnumerable<LocalSetting> settingsData, OpenSettingsConfiguration openSettingsConfiguration)
        {
            return settingsData.Select(settingData =>
            {
                var propertyInfoHelperModel = PropertyInfoHelperModel.CreatePropertyInfo(settingData.Type);

                var settingClass = new SyncAppDataInputSettingClass
                {
                    Identifier = propertyInfoHelperModel.TypeIdentifier,
                    Name = propertyInfoHelperModel.Name,
                    FullName = propertyInfoHelperModel.TypeFullName,
                    Namespace = propertyInfoHelperModel.TypeNamespace,
                    Properties = propertyInfoHelperModel.Properties,
                };

                settingClass.HashCode = settingClass.GetHashCode();

                bool storeInSeparateFile;
                bool? ignoreOnFileChange;

                if (settingData.HasStoreInSeparateFileAttribute)
                {
                    storeInSeparateFile = settingData.StoreInSeparateFile;
                    ignoreOnFileChange = Constants.ClassNameToCount[settingData.Type.Name] == 1
                        ? settingData.IgnoreOnFileChange
                        : false;
                }
                else
                {
                    storeInSeparateFile = openSettingsConfiguration.StoreInSeparateFile;
                    ignoreOnFileChange = storeInSeparateFile ? openSettingsConfiguration.IgnoreOnFileChange : (bool?)null;
                }

                var appSettingDto = new SyncAppDataInputSetting
                {
                    Data = JsonSerializer.Serialize(settingData.Instance, Constants.UnsafeRelaxedJsonSerializerOptions),
                    ComputedIdentifier = settingData.ComputedIdentifier,
                    StoreInSeparateFile = storeInSeparateFile,
                    IgnoreOnFileChange = ignoreOnFileChange,
                    RegistrationMode = settingData.HasRegistrationModeAttribute ? settingData.RegistrationMode : openSettingsConfiguration.RegistrationMode,
                    SettingClass = settingClass
                };

                appSettingDto.HashCode = appSettingDto.GetHashCode();

                return appSettingDto;
            }).ToArray();
        }

        private static async Task<Dictionary<string, Dictionary<string, object>>> GetFilesAsDictionaryAsync(string pattern, CancellationToken cancellationToken = default)
        {
            var filePaths = Directory.GetFiles(Environment.CurrentDirectory, pattern);

            var tasks = filePaths.Select(async filePath =>
            {
#if NETCOREAPP
                await
#endif
                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
                {
                    var deserializedData = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(fileStream, cancellationToken: cancellationToken);

                    return (filePath, deserializedData);
                }
            });

            var results = await Task.WhenAll(tasks);

            var dictionary = new Dictionary<string, Dictionary<string, object>>();

            foreach (var (filePath, deserializedData) in results)
            {
                dictionary[filePath] = deserializedData;
            }

            return dictionary;
        }

        private static object GetOptionsService(IServiceProvider serviceProvider, Type baseType, Type configType)
        {
            var closedType = baseType.MakeGenericType(configType);

            return GetServiceMethodInfo.Invoke(serviceProvider, new object[] { closedType });
        }

        internal static void DeleteFiles()
        {
            foreach (var settingData in Constants.ComputedIdentifierToLocalSetting.Values)
            {
                File.Delete(settingData.GeneratedFilePath);
            }
        }

        private static class Logs
        {
            public static readonly Action<ILogger, string, Exception> InitializationSucceed =
                LoggerMessage.Define<string>(
                    LogLevel.Information,
                    new EventId(1, nameof(SyncAppDataAsync)),
                    "Settings initialized with id: {instanceDynamicId}");

            public static readonly Action<ILogger, int, bool, Exception> InitializationFailed =
                LoggerMessage.Define<int, bool>(
                    LogLevel.Warning,
                    new EventId(2, nameof(SyncAppDataAsync)),
                    "Settings couldn't initialize! Attempt: {attempt} - Retry: {retry}");

            public static readonly Action<ILogger, string, string, Exception> ErrorOccurredWhenDeserializing =
                LoggerMessage.Define<string, string>(
                    LogLevel.Error,
                    new EventId(3, "UpdateLocalDataAndWriteToDiskAsync"),
                    "Error occurred when deserializing settings data: {data} - type: {typeName}");
        }
    }
}