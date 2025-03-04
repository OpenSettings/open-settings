using Microsoft.EntityFrameworkCore;
using OpenSettings.Attributes;
using OpenSettings.Exceptions;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Services.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings
{
    /// <summary>
    /// Provides utility methods for string manipulation and collection operations in OpenSettings.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Extracts and returns the initials from a given name.
        /// </summary>
        /// <param name="name">The full name from which to extract initials.</param>
        /// <returns>A string containing the uppercase initials of the name. Returns an empty string if the input is empty.</returns>
        public static string GetInitials(string name)
        {
            var parts = name.Replace(Constants.Dot, Constants.Space).Split(Constants.SpaceSeparator, StringSplitOptions.RemoveEmptyEntries);

            return parts.Length == 0 ? string.Empty : string.Join(string.Empty, parts.Select(p => p[0])).ToUpper();
        }

#if !NET6_0_OR_GREATER
        /// <summary>
        /// Returns distinct elements from a sequence based on a specified key selector.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the source sequence.</typeparam>
        /// <typeparam name="TKey">The type of the key used for distinct comparisons.</typeparam>
        /// <param name="source">The sequence to remove duplicates from.</param>
        /// <param name="keySelector">A function that extracts the key for each element.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing distinct elements from the source sequence.
        /// </returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();

            foreach (var element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
#endif

        internal static void MarkAsModified<TEntity>(this DbContext context, TEntity entity, params Expression<Func<TEntity, object>>[] properties) where TEntity : class
        {
            var entry = context.Entry(entity);

            foreach (var property in properties)
            {
                entry.Property(property).IsModified = true;
            }
        }

        internal static void MarkAsModified<TEntity>(this DbContext context, TEntity entity, ICollection<Expression<Func<TEntity, object>>> properties) where TEntity : class
        {
            var entry = context.Entry(entity);

            foreach (var property in properties)
            {
                entry.Property(property).IsModified = true;
            }
        }

        internal static string GetEnvironmentName()
        {
            var value = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            value = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            value = Environment.GetEnvironmentVariable("ENVIRONMENT");

            return string.IsNullOrWhiteSpace(value) ? "Production" : value;
        }

        internal static long ToVersionScore(this Version version)
        {
            return Math.Min(65535, Math.Max(1, (long)version.Major)) << 48 |
                   Math.Min(65535, (long)version.Minor) << 32 |
                   Math.Min(65535, (long)version.Build) << 16 |
                   Math.Min(65535, (long)Math.Min(0, version.Revision));
        }

        internal static string ToVersion(this Version version)
        {
            return version.ToString(version.Revision > 0 ? 4 : 3);
        }

        

        internal static string CalculateVersion(DateTime currentTime, DateTime createdOn)
        {
            return $"{(currentTime.Ticks - createdOn.Ticks) / 10_000.0}{GenerateRandomCharacters(3)}";
        }

        internal static RedisChannel ConstructChannelName(string providerChannel, Guid clientId, string identifier)
        {
            return new RedisChannel($"{providerChannel}/{clientId}/{identifier}", RedisChannel.PatternMode.Literal);
        }

        internal static async Task<Dictionary<string, FileMergeResult>> GetPreSettingsFilesAsync(string environmentName, CancellationToken cancellationToken = default)
        {
            var environmentSuffix = $"-{environmentName}";
            var environmentSpecificSettingStartsWith = string.Concat(Constants.SettingsFileNameWithoutExtension, environmentSuffix);

            var baseNameToFileModel = Directory.GetFiles(Environment.CurrentDirectory, string.Concat(Constants.SettingsFileNameWithoutExtension, ".*", Constants.SettingsFileExtension))
                .Select(f =>
                {
                    var fileName = Path.GetFileNameWithoutExtension(f);

                    bool storedInSeparateFile;
                    string name;

                    if (fileName == Constants.SettingsFileNameWithoutExtension)
                    {
                        name = Constants.SettingsFileNameTag;
                        storedInSeparateFile = false;
                    }
                    else
                    {
                        name = fileName.Remove(0, Constants.SettingsFileNameWithoutExtension.Length + 1);
                        storedInSeparateFile = true;
                    }

                    return new
                    {
                        Name = name,
                        FilePath = f,
                        FileName = fileName,
                        StoredInSeparateFile = storedInSeparateFile
                        //EnvironmentSpecificFileName = fileName.Insert(Constants.SettingsFileNameWithoutExtension.Length, environmentSuffix)
                    };
                })
                .Where(f => !f.FileName.StartsWith(Constants.GeneratedSettingsFileNameWithoutExtension))
                .ToDictionary(f => f.Name);

            var environmentNameToFileModel =
#if NETSTANDARD2_0
            Directory.GetFiles(Environment.CurrentDirectory, string.Concat(environmentSpecificSettingStartsWith, ".*", Constants.SettingsFileExtension))
#else
            Directory.GetFiles(Environment.CurrentDirectory, string.Concat(environmentSpecificSettingStartsWith, ".*", Constants.SettingsFileExtension), new EnumerationOptions { MatchCasing = MatchCasing.CaseInsensitive })
#endif
                    .Select(f =>
                    {
                        var environmentSpecificFileName = Path.GetFileNameWithoutExtension(f);

                        bool storedInSeparateFile;
                        string name;

                        if (environmentSpecificFileName == environmentSpecificSettingStartsWith)
                        {
                            name = Constants.SettingsFileNameTag;
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
            var baseNameToFileModel = Directory.GetFiles(Environment.CurrentDirectory, string.Concat(Constants.GeneratedSettingsFileNameWithoutExtension, ".*", Constants.SettingsFileExtension))
                .Select(f =>
                {
                    var fileName = Path.GetFileNameWithoutExtension(f);

                    bool storedInSeparateFile;
                    string name;

                    if (fileName == Constants.GeneratedSettingsFileNameWithoutExtension)
                    {
                        name = Constants.SettingsFileNameTag;
                        storedInSeparateFile = false;
                        fileName = Constants.SettingsFileNameWithoutExtension;
                    }
                    else
                    {
                        name = fileName.Remove(0, Constants.GeneratedSettingsFileNameWithoutExtension.Length + 1);
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

        internal static async Task<LocalSetting[]> CreateLocalSettingsFromFiles(string environmentName, RegistrationMode registrationMode, Operation operation, CancellationToken cancellationToken, params Type[] settingsTypes)
        {
            var preSettingsFiles = await GetPreSettingsFilesAsync(environmentName, cancellationToken);

            var preSettingsData = preSettingsFiles.Values.SelectMany(v => v.Data).ToDictionary(k => k.Key, k => k.Value);

            var enumeratedTypes = settingsTypes?.Length > 0 ? settingsTypes : GetSettingsTypesFromAssemblies();

            using (var md5 = MD5.Create())
            {
                var stringBuilder = new StringBuilder();

                var settingsFilePath = Path.Combine(Environment.CurrentDirectory, Constants.SettingsFileNameWithExtension);
                var generatedSettingsFilePath = Path.Combine(Environment.CurrentDirectory, Constants.GeneratedSettingsFileNameWithExtension);

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

            var enumeratedTypes = settingsTypes?.Length > 0 ? settingsTypes : GetSettingsTypesFromAssemblies();

            using (var md5 = MD5.Create())
            {
                var stringBuilder = new StringBuilder();

                var settingsFilePath = Path.Combine(Environment.CurrentDirectory, Constants.SettingsFileNameWithExtension);
                var generatedSettingsFilePath = Path.Combine(Environment.CurrentDirectory, Constants.GeneratedSettingsFileNameWithExtension);

                return enumeratedTypes
                    .DistinctBy(t => t.FullName)
                    .Where(t => !t.IsGenericType && t.GetInterface(nameof(ISettings)) != null && t.GetConstructor(Type.EmptyTypes) != null && !t.IsAbstract)
                    .Select(t => CreateSettingDataFromGeneratedData(md5, t, fullNameToGeneratedSettingData, settingsFilePath, generatedSettingsFilePath, operation == Operation.ReadOrInitialize, stringBuilder, registrationMode))
                    .ToArray();
            }
        }

        internal static Guid ComputeIdentifier(string identifier)
        {
            using (var md5 = MD5.Create())
            {
                return ComputeIdentifier(md5, identifier);
            }
        }

        internal static Guid ComputeIdentifier(MD5 md5, string identifier)
        {
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(identifier));

            return new Guid(hash);
        }

        internal static string GetSettingFilePathWithExtension(string className, StringBuilder stringBuilder)
        {
            stringBuilder.Clear();
            stringBuilder.Append(Constants.SettingsFileNameWithoutExtension)
                .Append(Constants.DotChar)
                .Append(className)
                .Append(Constants.DotChar)
                .Append(Constants.SettingsFileExtension);

            return Path.Combine(Environment.CurrentDirectory, stringBuilder.ToString());
        }

        internal static string GetSettingFileNameWithExtension(string className)
        {
            return $"{Constants.SettingsFileNameWithoutExtension}.{className}.{Constants.SettingsFileExtension}";
        }

        internal static string GetGeneratedSettingFilePathWithExtension(string className, StringBuilder stringBuilder)
        {
            stringBuilder.Clear();
            stringBuilder.Append(Constants.GeneratedSettingsFileNameWithoutExtension)
                .Append(Constants.DotChar)
                .Append(className)
                .Append(Constants.DotChar)
                .Append(Constants.SettingsFileExtension);

            return Path.Combine(Environment.CurrentDirectory, stringBuilder.ToString());
        }

        internal static string GetGeneratedSettingFileNameWithExtension(string className)
        {
            return $"{Constants.GeneratedSettingsFileNameWithoutExtension}.{className}.{Constants.SettingsFileExtension}";
        }

        private static LocalSetting[] ProcessSettingsTypes(IReadOnlyCollection<Type> settingsTypes, Dictionary<string, object> preSettingsData, bool createInstances, RegistrationMode registrationMode)
        {
            var enumeratedTypes = settingsTypes?.Count > 0 ? settingsTypes : GetSettingsTypesFromAssemblies();

            using (var md5 = MD5.Create())
            {
                var stringBuilder = new StringBuilder();

                var settingsFilePath = Path.Combine(Environment.CurrentDirectory, Constants.SettingsFileNameWithExtension);
                var generatedSettingsFilePath = Path.Combine(Environment.CurrentDirectory, Constants.GeneratedSettingsFileNameWithExtension);

                return enumeratedTypes
                    .DistinctBy(t => t.FullName)
                    .Where(t => !t.IsGenericType && t.GetInterface(nameof(ISettings)) != null && t.GetConstructor(Type.EmptyTypes) != null && !t.IsAbstract)
                    .Select(t => CreateSettingDataFromPreData(md5, t, preSettingsData, settingsFilePath, generatedSettingsFilePath, createInstances, stringBuilder, registrationMode))
                    .ToArray();
            }
        }

        private static IEnumerable<Type> GetSettingsTypesFromAssemblies()
        {
            var entryAssembly = Assembly.GetEntryAssembly();

            var referencedAssemblies = entryAssembly.GetReferencedAssemblies();

            return referencedAssemblies
                .SelectMany(assemblyName => Assembly.Load(assemblyName).GetTypes())
                .Concat(entryAssembly.GetTypes());
        }

        private static LocalSetting CreateSettingDataFromPreData(MD5 md5, Type type, Dictionary<string, object> preSettingsData, string settingsFilePath, string generatedSettingsFilePath, bool createInstance, StringBuilder stringBuilder, RegistrationMode registrationMode)
        {
            ISettings instance = null;

            if (preSettingsData.TryGetValue(type.Name, out var jsonSettings))
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
                ComputedIdentifier = ((ComputedIdentifierAttribute)type.GetCustomAttribute(Constants.ComputedIdentifierAttributeType, true))?.ComputedIdentifier ?? ComputeIdentifier(md5, type.FullName),
                Instance = instance
            };

            var storeInSeparateFileAttribute = (StoreInSeparateFileAttribute)type.GetCustomAttribute(Constants.StoreInSeparateFileAttributeType, true);

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

            var registrationModeAttribute = type.GetCustomAttribute(Constants.RegistrationModeAttributeType, true);

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
                ComputedIdentifier = ((ComputedIdentifierAttribute)type.GetCustomAttribute(Constants.ComputedIdentifierAttributeType, true))?.ComputedIdentifier ?? ComputeIdentifier(md5, type.FullName)
            };

            var storeInSeparateFileAttribute = (StoreInSeparateFileAttribute)type.GetCustomAttribute(Constants.StoreInSeparateFileAttributeType, true);

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

            var registrationModeAttribute = type.GetCustomAttribute(Constants.RegistrationModeAttributeType, true);

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

        private const string Chars = "abcdefghijklmnopqrstuvwxyz";

        private static string GenerateRandomCharacters(int length)
        {
            var randomBytes = new byte[length];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return string.Join(string.Empty,
                Enumerable.Range(0, length).Select(i => Chars[randomBytes[i] % Chars.Length]));
        }
    }
}