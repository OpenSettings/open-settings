using OpenSettings.Attributes;
using OpenSettings.Exceptions;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Helpers
{
    internal static class SettingsFileHelper
    {
        internal static async Task<LocalSetting[]> CreateLocalSettingsFromFiles(string environmentName, RegistrationMode registrationMode, Operation operation, CancellationToken cancellationToken, params Type[] settingsTypes)
        {
            var preSettingsFiles = await GetPreSettingsFilesAsync(environmentName, cancellationToken);

            var preSettingsData = preSettingsFiles.Values.SelectMany(v => v.Data).ToDictionary(k => k.Key, k => k.Value);

            using (var md5 = MD5.Create())
            {
                var settingsFilePath = Path.Combine(AppContext.BaseDirectory, OpenSettingsDefaults.Files.SettingsFileNameWithExtension);
                var generatedSettingsFilePath = Path.Combine(AppContext.BaseDirectory, OpenSettingsDefaults.Files.GeneratedSettingsFileNameWithExtension);

                var stringBuilder = new StringBuilder();

                var enumeratedTypes = settingsTypes?.Length > 0 ? settingsTypes : Helper.GetTypesFromAssemblies();

                return enumeratedTypes
                    .DistinctBy(t => t.FullName)
                    .Where(IsSettingsType)
                    .Select(t => CreateSettingDataFromPreData(md5, t, preSettingsData, settingsFilePath, generatedSettingsFilePath, operation == Operation.ReadOrInitialize, stringBuilder, registrationMode))
                    .ToArray();
            }
        }

        internal static async Task<LocalSetting[]> CreateLocalSettingsFromGeneratedFilesAsync(RegistrationMode registrationMode, Operation operation, CancellationToken cancellationToken, params Type[] settingsTypes)
        {
            var generatedSettingsFiles = await GetGeneratedSettingsFilesAsync(cancellationToken);

            var fullNameToGeneratedSettingData = generatedSettingsFiles.Values.SelectMany(v => v.Data,
                (result, pair) => new
                {
                    pair.Key,
                    pair.Value,
                    result.StoredInSeparateFile
                })
                .ToDictionary(
                    item => item.Key,
                    item => new GeneratedSettingData
                    {
                        Value = item.Value,
                        StoredInSeparateFile = item.StoredInSeparateFile
                    }
                );

            using (var md5 = MD5.Create())
            {
                var settingsFilePath = Path.Combine(AppContext.BaseDirectory, OpenSettingsDefaults.Files.SettingsFileNameWithExtension);
                var generatedSettingsFilePath = Path.Combine(AppContext.BaseDirectory, OpenSettingsDefaults.Files.GeneratedSettingsFileNameWithExtension);

                var stringBuilder = new StringBuilder();

                var enumeratedTypes = settingsTypes?.Length > 0 ? settingsTypes : Helper.GetTypesFromAssemblies();

                return enumeratedTypes
                    .DistinctBy(t => t.FullName)
                    .Where(IsSettingsType)
                    .Select(t => CreateSettingDataFromGeneratedData(md5, t, fullNameToGeneratedSettingData, settingsFilePath, generatedSettingsFilePath, operation == Operation.ReadOrInitialize, stringBuilder, registrationMode))
                    .ToArray();
            }
        }

        internal static async Task<Dictionary<string, FileMergeResult>> GetPreSettingsFilesAsync(string environmentName, CancellationToken cancellationToken = default)
        {
            var environmentSuffix = $"-{environmentName}";
            var environmentSpecificSettingStartsWith = string.Concat(OpenSettingsDefaults.Files.SettingsFileNameWithoutExtension, environmentSuffix);

            var environmentNameToFileModel =
#if NETSTANDARD2_0
            Directory.GetFiles(AppContext.BaseDirectory, string.Concat(environmentSpecificSettingStartsWith, ".*", OpenSettingsDefaults.Files.SettingsFileExtension))
#else
            Directory.GetFiles(AppContext.BaseDirectory, string.Concat(environmentSpecificSettingStartsWith, ".*", OpenSettingsDefaults.Files.SettingsFileExtension), new EnumerationOptions { MatchCasing = MatchCasing.CaseInsensitive })
#endif
                    .Select(f =>
                    {
                        var environmentSpecificFileName = Path.GetFileNameWithoutExtension(f);

                        bool storedInSeparateFile;
                        string name;

                        if (environmentSpecificFileName == environmentSpecificSettingStartsWith)
                        {
                            name = OpenSettingsDefaults.Files.SettingsFileNameTag;
                            storedInSeparateFile = false;
                        }
                        else
                        {
                            name = environmentSpecificFileName.Remove(0, environmentSpecificSettingStartsWith.Length + 1);
                            storedInSeparateFile = true;
                        }

                        return new
                        {
                            Name = name,
                            FilePath = f,
                            FileName = environmentSpecificFileName,
                            StoredInSeparateFile = storedInSeparateFile
                        };
                    }).ToDictionary(f => f.Name);

            var settingsFullName = new ConcurrentDictionary<string, byte>();

            var duplicateSettingsFullName = new ConcurrentDictionary<string, byte>();

            var fileMergeResultsTasks = Directory.GetFiles(AppContext.BaseDirectory, string.Concat(OpenSettingsDefaults.Files.SettingsFileNameWithoutExtension, ".*", OpenSettingsDefaults.Files.SettingsFileExtension))
                .Select(async filePath =>
                {
                    var fileName = Path.GetFileNameWithoutExtension(filePath);

                    if (fileName.StartsWith(OpenSettingsDefaults.Files.GeneratedSettingsFileNameWithoutExtension))
                    {
                        return null;
                    }

                    bool storedInSeparateFile;
                    string name;

                    if (fileName == OpenSettingsDefaults.Files.SettingsFileNameWithoutExtension)
                    {
                        name = OpenSettingsDefaults.Files.SettingsFileNameTag;
                        storedInSeparateFile = false;
                    }
                    else
                    {
                        name = fileName.Remove(0, OpenSettingsDefaults.Files.SettingsFileNameWithoutExtension.Length + 1);
                        storedInSeparateFile = true;
                    }

                    //EnvironmentSpecificFileName = fileName.Insert(OpenSettingsDefaults.Files.SettingsFileNameWithoutExtension.Length, environmentSuffix)

                    if (environmentNameToFileModel.TryGetValue(name, out var environmentFile))
                    {
                        var jsonMergeResult = await JsonHelper.MergeFileAsync(filePath, environmentFile.FilePath, cancellationToken);

                        foreach (var duplicate in jsonMergeResult.Data.Keys.Select(settingFullName => settingFullName.ToLower()).Where(k => !settingsFullName.TryAdd(k, 0)))
                        {
                            duplicateSettingsFullName.AddOrUpdate(duplicate, 0, (_, __) => 0);
                        }

                        return new FileMergeResult
                        {
                            Data = jsonMergeResult.Data,
                            Files = new FileModel[]
                            {
                                new FileModel // Base file
                                {
                                    FilePath = filePath,
                                    FileName = fileName
                                },
                                new FileModel // Environment file
                                {
                                    FilePath = environmentFile.FilePath,
                                    FileName = environmentFile.FileName
                                }
                            },
                            Name = name,
                            StoredInSeparateFile = storedInSeparateFile
                        };
                    }

                    var data = await JsonHelper.GetJsonFileAsync(filePath, cancellationToken);

                    foreach (var duplicate in data.Keys.Select(settingFullName => settingFullName.ToLower()).Where(settingFullName => !settingsFullName.TryAdd(settingFullName, 0)))
                    {
                        duplicateSettingsFullName.AddOrUpdate(duplicate, 0, (_, __) => 0);
                    }

                    return new FileMergeResult
                    {
                        Data = data,
                        Files = new FileModel[]
                        {
                            new FileModel // Base file
                            {
                                FilePath = filePath,
                                FileName = fileName
                            }
                        },
                        Name = name,
                        StoredInSeparateFile = storedInSeparateFile,
                    };
                })
                .Where(f => f != null);

            var fileMergeResults = await Task.WhenAll(fileMergeResultsTasks);

            var nameToFileMergeResult = fileMergeResults.ToDictionary(f => f.Name);

            var onlyEnvFileMergeResultsTasks = environmentNameToFileModel.Where(e => !nameToFileMergeResult.ContainsKey(e.Key)).Select(
                async envFile =>
                {
                    var data = await JsonHelper.GetJsonFileAsync(envFile.Value.FilePath, cancellationToken);

                    foreach (var duplicate in data.Keys.Select(k => k.ToLower()).Where(k => !settingsFullName.TryAdd(k, 0)))
                    {
                        duplicateSettingsFullName.AddOrUpdate(duplicate, 0, (_, __) => 0);
                    }

                    return new FileMergeResult
                    {
                        Data = data,
                        Files = new FileModel[]
                        {
                            new FileModel // Environment file
                            {
                                FilePath = envFile.Value.FilePath,
                                FileName = envFile.Value.FileName
                            }
                        },
                        Name = envFile.Key,
                        StoredInSeparateFile = envFile.Value.StoredInSeparateFile
                    };
                });

            var onlyEnvFileMergeResults = await Task.WhenAll(onlyEnvFileMergeResultsTasks);

            if (duplicateSettingsFullName.Count > 0)
            {
                throw new DuplicateSettingsNameException(duplicateSettingsFullName.Keys);
            }

            foreach (var onlyEnvFileMergeResult in onlyEnvFileMergeResults)
            {
                nameToFileMergeResult[onlyEnvFileMergeResult.Name] = onlyEnvFileMergeResult;
            }

            return nameToFileMergeResult;
        }

        /// <summary>
        /// Retrieves all generated settings files from the application base directory.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns></returns>
        /// <exception cref="DuplicateSettingsNameException"></exception>
        internal static async Task<Dictionary<string, FileMergeResult>> GetGeneratedSettingsFilesAsync(CancellationToken cancellationToken = default)
        {
            var settingsFullName = new ConcurrentDictionary<string, byte>();

            var duplicateSettingsFullName = new ConcurrentDictionary<string, byte>();

            var fileMergeResultsTasks = Directory.GetFiles(AppContext.BaseDirectory,
                string.Concat(OpenSettingsDefaults.Files.GeneratedSettingsFileNameWithoutExtension, ".*",
                    OpenSettingsDefaults.Files.SettingsFileExtension)).Select(async filePath =>
            {
                var fileName = Path.GetFileNameWithoutExtension(filePath);

                bool storedInSeparateFile;
                string name;

                if (fileName == OpenSettingsDefaults.Files.GeneratedSettingsFileNameWithoutExtension)
                {
                    name = OpenSettingsDefaults.Files.SettingsFileNameTag;
                    storedInSeparateFile = false;
                    fileName = OpenSettingsDefaults.Files.SettingsFileNameWithoutExtension;
                }
                else
                {
                    name = fileName.Remove(0, OpenSettingsDefaults.Files.GeneratedSettingsFileNameWithoutExtension.Length + 1);
                    storedInSeparateFile = true;
                }

                var data = await JsonHelper.GetJsonFileAsync(filePath, cancellationToken);

                foreach (var duplicate in data.Keys.Select(k => k.ToLower()).Where(k => !settingsFullName.TryAdd(k, 0)))
                {
                    duplicateSettingsFullName.AddOrUpdate(duplicate, 0, (_, __) => 0);
                }

                return new FileMergeResult
                {
                    Data = data,
                    Files = new FileModel[]
                    {
                        new FileModel // Base file
                        {
                            FilePath = filePath,
                            FileName = fileName
                        }
                    },
                    Name = name,
                    StoredInSeparateFile = storedInSeparateFile
                };
            });

            var fileMergeResults = await Task.WhenAll(fileMergeResultsTasks);

            if (!duplicateSettingsFullName.IsEmpty)
            {
                throw new DuplicateSettingsNameException(duplicateSettingsFullName.Keys);
            }

            return fileMergeResults.ToDictionary(f => f.Name);
        }

        internal static string GetSettingFilePathWithExtension(string className, StringBuilder stringBuilder)
        {
            return GetSettingFilePathWithExtension(OpenSettingsDefaults.Files.SettingsFileNameWithoutExtension, className, stringBuilder);
        }

        internal static string GetGeneratedSettingFilePathWithExtension(string className, StringBuilder stringBuilder)
        {
            return GetSettingFilePathWithExtension(OpenSettingsDefaults.Files.GeneratedSettingsFileNameWithoutExtension, className, stringBuilder);
        }

        private static string GetSettingFilePathWithExtension(string filePrefix, string className, StringBuilder stringBuilder)
        {
            stringBuilder.Clear();
            stringBuilder.Append(filePrefix)
                .Append(OpenSettingsDefaults.Format.DotChar)
                .Append(className)
                .Append(OpenSettingsDefaults.Format.DotChar)
                .Append(OpenSettingsDefaults.Files.SettingsFileExtension);

            return Path.Combine(AppContext.BaseDirectory, stringBuilder.ToString());
        }

        private static LocalSetting CreateSettingDataFromPreData(MD5 md5, Type type, Dictionary<string, object> preSettingsData, string settingsFilePath, string generatedSettingsFilePath, bool createInstance, StringBuilder stringBuilder, RegistrationMode registrationMode)
        {
            var settingData = new LocalSetting
            {
                Type = type,
                ComputedIdentifier = ((ComputedIdentifierAttribute)type.GetCustomAttribute(OpenSettingsDefaults.Types.ComputedIdentifierAttributeType, true))?.ComputedIdentifier ?? Helper.ComputeIdentifier(md5, type.FullName)
            };

            var storeInSeparateFileAttribute = (StoreInSeparateFileAttribute)type.GetCustomAttribute(OpenSettingsDefaults.Types.StoreInSeparateFileAttributeType, true);

            if (preSettingsData.TryGetValue(type.FullName, out var jsonSettings))
            {
                settingData.Instance = JsonSerializer.Deserialize($"{jsonSettings}", type) as ISettings;
            }
            else if (createInstance)
            {
                settingData.Instance = Activator.CreateInstance(type) as ISettings;
            }

            if (storeInSeparateFileAttribute == null)
            {
                settingData.FilePath = settingsFilePath;
                settingData.GeneratedFilePath = generatedSettingsFilePath;
            }
            else
            {
                settingData.HasStoreInSeparateFileAttribute = true;
                settingData.StoreInSeparateFile = true;
                settingData.IgnoreOnFileChange = storeInSeparateFileAttribute.IgnoreOnFileChange;
                settingData.FilePath = GetSettingFilePathWithExtension(type.Name, stringBuilder);
                settingData.GeneratedFilePath = GetGeneratedSettingFilePathWithExtension(type.Name, stringBuilder);
            }

            var registrationModeAttribute = type.GetCustomAttribute(OpenSettingsDefaults.Types.RegistrationModeAttributeType, true);

            if (registrationModeAttribute == null)
            {
                settingData.RegistrationMode = registrationMode;
            }
            else
            {
                settingData.HasRegistrationModeAttribute = true;
                settingData.RegistrationMode = ((RegistrationModeAttribute)registrationModeAttribute).RegistrationMode;
            }

            return settingData;
        }

        private static LocalSetting CreateSettingDataFromGeneratedData(MD5 md5, Type type, Dictionary<string, GeneratedSettingData> generatedSettingsData, string settingsFilePath, string generatedSettingsFilePath, bool createInstance, StringBuilder stringBuilder, RegistrationMode registrationMode)
        {
            var settingData = new LocalSetting
            {
                Type = type,
                ComputedIdentifier = ((ComputedIdentifierAttribute)type.GetCustomAttribute(OpenSettingsDefaults.Types.ComputedIdentifierAttributeType, true))?.ComputedIdentifier ?? Helper.ComputeIdentifier(md5, type.FullName),
            };

            var storeInSeparateFileAttribute = (StoreInSeparateFileAttribute)type.GetCustomAttribute(OpenSettingsDefaults.Types.StoreInSeparateFileAttributeType, true);

            if (storeInSeparateFileAttribute != null)
            {
                settingData.HasStoreInSeparateFileAttribute = true;
                settingData.IgnoreOnFileChange = storeInSeparateFileAttribute.IgnoreOnFileChange;
            }

            bool shouldStoreSeparately;

            if (generatedSettingsData.TryGetValue(type.Name, out var generatedSettingData))
            {
                settingData.Instance = JsonSerializer.Deserialize($"{generatedSettingData.Value}", type) as ISettings;
                settingData.IsPreDataExists = true;
                settingData.StoreInSeparateFile = shouldStoreSeparately = generatedSettingData.StoredInSeparateFile;
            }
            else
            {
                if (createInstance)
                {
                    settingData.Instance = Activator.CreateInstance(type) as ISettings;
                }

                shouldStoreSeparately = settingData.HasStoreInSeparateFileAttribute;
            }

            if (shouldStoreSeparately)
            {
                settingData.FilePath = GetSettingFilePathWithExtension(type.Name, stringBuilder);
                settingData.GeneratedFilePath = GetGeneratedSettingFilePathWithExtension(type.Name, stringBuilder);
            }
            else
            {
                settingData.FilePath = settingsFilePath;
                settingData.GeneratedFilePath = generatedSettingsFilePath;
            }

            var registrationModeAttribute = type.GetCustomAttribute(OpenSettingsDefaults.Types.RegistrationModeAttributeType, true);

            if (registrationModeAttribute == null)
            {
                settingData.RegistrationMode = registrationMode;
            }
            else
            {
                settingData.HasRegistrationModeAttribute = true;
                settingData.RegistrationMode = ((RegistrationModeAttribute)registrationModeAttribute).RegistrationMode;
            }

            return settingData;
        }

        private static bool IsSettingsType(Type type)
        {
            return !type.IsGenericType && type.GetInterface(nameof(ISettings)) != null &&
                   type.GetConstructor(Type.EmptyTypes) != null && !type.IsAbstract;
        }
    }
}