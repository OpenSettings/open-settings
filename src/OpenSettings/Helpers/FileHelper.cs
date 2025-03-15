using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Helpers
{
    internal static class FileHelper
    {
#if NETSTANDARD2_0
        internal static void WriteToDisk(
            Dictionary<string, Dictionary<string, object>> fullPathToInstanceFullNameToObjectInstance)
#else
        internal static async Task WriteToDiskAsync(
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

#if NETSTANDARD2_0
        internal static void WriteSettingsToFile(string filePath, IDictionary<string, object> data)
#else
        internal static async Task WriteSettingsToFileAsync(string filePath, IDictionary<string, object> data, CancellationToken cancellationToken = default)
#endif
        {
            if (filePath == null)
            {
                return;
            }

            var json = JsonSerializer.Serialize(data, Constants.UnsafeRelaxedJsonAndWriteIndentedSerializerOptions);

#if NETSTANDARD2_0
            File.WriteAllText(filePath, json);
#else
            await File.WriteAllTextAsync(filePath, json, cancellationToken);
#endif
        }

        internal static void DeleteSettingsFiles()
        {
            foreach (var settingData in Constants.ComputedIdentifierToLocalSetting.Values)
            {
                File.Delete(settingData.GeneratedFilePath);
            }
        }
    }
}