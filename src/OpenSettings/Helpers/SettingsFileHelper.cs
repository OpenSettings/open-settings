using OpenSettings.Attributes;
using OpenSettings.Exceptions;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Services.Interfaces;
using System;
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
                    .Where(t => !t.IsGenericType && t.GetInterface(nameof(ISettings)) != null && t.GetConstructor(Type.EmptyTypes) != null && !t.IsAbstract)
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
                    .Where(t => !t.IsGenericType && t.GetInterface(nameof(ISettings)) != null && t.GetConstructor(Type.EmptyTypes) != null && !t.IsAbstract)
                    .Select(t => CreateSettingDataFromGeneratedData(md5, t, fullNameToGeneratedSettingData, settingsFilePath, generatedSettingsFilePath, operation == Operation.ReadOrInitialize, stringBuilder, registrationMode))
                    .ToArray();
            }
        }

        internal static async Task<Dictionary<string, FileMergeResult>> GetPreSettingsFilesAsync(string environmentName, CancellationToken cancellationToken = default)
        {
            var environmentSuffix = $"-{environmentName}";
            var environmentSpecificSettingStartsWith = string.Concat(OpenSettingsDefaults.Files.SettingsFileNameWithoutExtension, environmentSuffix);

            var baseNameToFileModel = Directory.GetFiles(AppContext.BaseDirectory, string.Concat(OpenSettingsDefaults.Files.SettingsFileNameWithoutExtension, ".*", OpenSettingsDefaults.Files.SettingsFileExtension))
                .Select(f =>
                {
                    var fileName = Path.GetFileNameWithoutExtension(f);

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

                    return new
                    {
                        Name = name,
                        FilePath = f,
                        FileName = fileName,
                        StoredInSeparateFile = storedInSeparateFile
                        //EnvironmentSpecificFileName = fileName.Insert(OpenSettingsDefaults.Files.SettingsFileNameWithoutExtension.Length, environmentSuffix)
                    };
                })
                .Where(f => !f.FileName.StartsWith(OpenSettingsDefaults.Files.GeneratedSettingsFileNameWithoutExtension))
                .ToDictionary(f => f.Name);

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

            var settingsFullName = new HashSet<string>();

            var duplicateSettingsFullName = new HashSet<string>();

            var fileMergeResultsTasks = baseNameToFileModel.Select(async baseFile =>
            {
                var name = baseFile.Key;
                //var environmentSpecificFileName = baseFile.Value.EnvironmentSpecificFileName;

                if (environmentNameToFileModel.TryGetValue(name, out var environmentFile))
                {
                    var jsonMergeResult =
                        await JsonHelper.MergeFileAsync(baseFile.Value.FilePath, environmentFile.FilePath, cancellationToken);

                    foreach (var duplicate in jsonMergeResult.Data.Keys.Select(k => k.ToLower())
                                 .Where(k => !settingsFullName.Add(k)))
                    {
                        duplicateSettingsFullName.Add(duplicate);
                    }

                    return new FileMergeResult
                    {
                        Data = jsonMergeResult.Data,
                        Files = new FileModel[]
                        {
                            new FileModel // Base file
                            {
                                FilePath = baseFile.Value.FilePath,
                                FileName = baseFile.Value.FileName
                            },
                            new FileModel // Environment file
                            {
                                FilePath = environmentFile.FilePath,
                                FileName = environmentFile.FileName
                            }
                        },
                        Name = name,
                        StoredInSeparateFile = baseFile.Value.StoredInSeparateFile,
                    };
                }

                var data = await JsonHelper.GetJsonFileAsync(baseFile.Value.FilePath, cancellationToken);

                foreach (var duplicate in data.Keys.Select(k => k.ToLower()).Where(k => !settingsFullName.Add(k)))
                {
                    duplicateSettingsFullName.Add(duplicate);
                }

                return new FileMergeResult
                {
                    Data = data,
                    Files = new FileModel[]
                    {
                        new FileModel // Base file
                        {
                            FilePath = baseFile.Value.FilePath,
                            FileName = baseFile.Value.FileName
                        }
                    },
                    Name = name,
                    StoredInSeparateFile = baseFile.Value.StoredInSeparateFile,
                };
            });

            var nameToFileMergeResult = (await Task.WhenAll(fileMergeResultsTasks)).ToDictionary(f => f.Name);

            var onlyEnvFileMergeResultsTasks = environmentNameToFileModel.Where(e => !nameToFileMergeResult.ContainsKey(e.Key)).Select(
                async envFile =>
                {
                    var data = await JsonHelper.GetJsonFileAsync(envFile.Value.FilePath, cancellationToken);

                    foreach (var duplicate in data.Keys.Select(k => k.ToLower()).Where(k => !settingsFullName.Add(k)))
                    {
                        duplicateSettingsFullName.Add(duplicate);
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
                throw new DuplicateSettingsNameException(duplicateSettingsFullName);
            }

            foreach (var onlyEnvFileMergeResult in onlyEnvFileMergeResults)
            {
                nameToFileMergeResult[onlyEnvFileMergeResult.Name] = onlyEnvFileMergeResult;
            }

            return nameToFileMergeResult;
        }

        internal static async Task<Dictionary<string, FileMergeResult>> GetGeneratedSettingsFilesAsync(CancellationToken cancellationToken = default)
        {
            var baseNameToFileModel = Directory.GetFiles(AppContext.BaseDirectory, string.Concat(OpenSettingsDefaults.Files.GeneratedSettingsFileNameWithoutExtension, ".*", OpenSettingsDefaults.Files.SettingsFileExtension))
                .Select(f =>
                {
                    var fileName = Path.GetFileNameWithoutExtension(f);

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

                    return new
                    {
                        Name = name,
                        FilePath = f,
                        FileName = fileName,
                        StoredInSeparateFile = storedInSeparateFile
                    };
                })
                .ToDictionary(f => f.Name);

            var settingsFullName = new HashSet<string>();

            var duplicateSettingsFullName = new HashSet<string>();

            var fileMergeResultsTasks = baseNameToFileModel.Select(async baseFile =>
            {
                var name = baseFile.Key;

                var data = await JsonHelper.GetJsonFileAsync(baseFile.Value.FilePath, cancellationToken);

                foreach (var duplicate in data.Keys.Select(k => k.ToLower()).Where(k => !settingsFullName.Add(k)))
                {
                    duplicateSettingsFullName.Add(duplicate);
                }

                return new FileMergeResult
                {
                    Data = data,
                    Files = new FileModel[]
                    {
                        new FileModel // Base file
                        {
                            FilePath = baseFile.Value.FilePath,
                            FileName = baseFile.Value.FileName
                        }
                    },
                    Name = name,
                    StoredInSeparateFile = baseFile.Value.StoredInSeparateFile
                };
            });

            var nameToFileMergeResult = (await Task.WhenAll(fileMergeResultsTasks)).ToDictionary(f => f.Name);

            if (duplicateSettingsFullName.Count > 0)
            {
                throw new DuplicateSettingsNameException(duplicateSettingsFullName);
            }

            return nameToFileMergeResult;
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
            ISettings instance = null;

            if (preSettingsData.TryGetValue(type.FullName, out var jsonSettings))
            {
                instance = JsonSerializer.Deserialize($"{jsonSettings}", type) as ISettings;
            }
            else if (createInstance)
            {
                instance = Activator.CreateInstance(type) as ISettings;
            }

            var settingData = new LocalSetting
            {
                Type = type,
                ComputedIdentifier = ((ComputedIdentifierAttribute)type.GetCustomAttribute(OpenSettingsDefaults.Types.ComputedIdentifierAttributeType, true))?.ComputedIdentifier ?? Helper.ComputeIdentifier(md5, type.FullName),
                Instance = instance
            };

            var storeInSeparateFileAttribute = (StoreInSeparateFileAttribute)type.GetCustomAttribute(OpenSettingsDefaults.Types.StoreInSeparateFileAttributeType, true);

            if (storeInSeparateFileAttribute == null)
            {
                settingData.FilePath = settingsFilePath;
                settingData.GeneratedFilePath = generatedSettingsFilePath;
                settingData.HasStoreInSeparateFileAttribute = false;
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
            ISettings instance = null;

            var settingData = new LocalSetting
            {
                Type = type,
                ComputedIdentifier = ((ComputedIdentifierAttribute)type.GetCustomAttribute(OpenSettingsDefaults.Types.ComputedIdentifierAttributeType, true))?.ComputedIdentifier ?? Helper.ComputeIdentifier(md5, type.FullName)
            };

            var storeInSeparateFileAttribute = (StoreInSeparateFileAttribute)type.GetCustomAttribute(OpenSettingsDefaults.Types.StoreInSeparateFileAttributeType, true);

            settingData.HasStoreInSeparateFileAttribute = storeInSeparateFileAttribute != null;

            if (generatedSettingsData.TryGetValue(type.Name, out var generatedSettingData))
            {
                instance = JsonSerializer.Deserialize($"{generatedSettingData.Value}", type) as ISettings;
                settingData.IsPreDataExists = true;
                settingData.StoreInSeparateFile = generatedSettingData.StoredInSeparateFile;

                if (generatedSettingData.StoredInSeparateFile)
                {
                    settingData.FilePath = GetSettingFilePathWithExtension(type.Name, stringBuilder);
                    settingData.GeneratedFilePath = GetGeneratedSettingFilePathWithExtension(type.Name, stringBuilder);
                }
                else
                {
                    settingData.FilePath = settingsFilePath;
                    settingData.GeneratedFilePath = generatedSettingsFilePath;
                }
            }
            else if (createInstance)
            {
                instance = Activator.CreateInstance(type) as ISettings;

                if (settingData.HasStoreInSeparateFileAttribute)
                {
                    settingData.FilePath = GetSettingFilePathWithExtension(type.Name, stringBuilder);
                    settingData.GeneratedFilePath = GetGeneratedSettingFilePathWithExtension(type.Name, stringBuilder);
                }
                else
                {
                    settingData.FilePath = settingsFilePath;
                    settingData.GeneratedFilePath = generatedSettingsFilePath;
                }
            }
            else
            {
                if (settingData.HasStoreInSeparateFileAttribute)
                {
                    settingData.FilePath = GetSettingFilePathWithExtension(type.Name, stringBuilder);
                    settingData.GeneratedFilePath = GetGeneratedSettingFilePathWithExtension(type.Name, stringBuilder);
                }
                else
                {
                    settingData.FilePath = settingsFilePath;
                    settingData.GeneratedFilePath = generatedSettingsFilePath;
                }
            }

            settingData.Instance = instance;

            if (storeInSeparateFileAttribute != null)
            {
                settingData.IgnoreOnFileChange = storeInSeparateFileAttribute.IgnoreOnFileChange;
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
    }
}