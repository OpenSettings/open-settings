using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;
using System.Text.Json;
using OpenSettings.Models;
using Array = System.Array;

namespace OpenSettings.Domains.Sql.Configurations.Utility
{
    internal static class EfValueConverters
    {
        public static ValueConverter<string[], string> ArrayStringConverter = GetArrayJsonValueConverter<string>();

        public static ValueConverter<Dictionary<string, object>, string> ObjectDictionaryConverter = GetJsonValueConverter<Dictionary<string, object>>();

        public static ValueConverter<ConfigurationConsumer, string> ConsumerConverter = GetJsonValueConverter<ConfigurationConsumer>();
        public static ValueConverter<ConfigurationProvider, string> ProviderConverter = GetJsonValueConverter<ConfigurationProvider>();
        public static ValueConverter<ConfigurationController, string> ControllerConverter = GetJsonValueConverter<ConfigurationController>();
        public static ValueConverter<ConfigurationSpa, string> SpaConverter = GetJsonValueConverter<ConfigurationSpa>();

        public static ValueConverter<T, string> GetJsonValueConverter<T>() where T : new()
        {
            return new ValueConverter<T, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => v == null ? new T() : JsonSerializer.Deserialize<T>(v, (JsonSerializerOptions)null));
        }

        public static ValueConverter<T[], string> GetArrayJsonValueConverter<T>()
        {
            return new ValueConverter<T[], string>(
                v => JsonSerializer.Serialize(v ?? Array.Empty<T>(), (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<T[]>(v, (JsonSerializerOptions)null));
        }
    }
}