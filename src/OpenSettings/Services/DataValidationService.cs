using Microsoft.Extensions.Logging;
using OpenSettings.Configurations;
using OpenSettings.Models;
using OpenSettings.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace OpenSettings.Services
{
    internal sealed class DataValidationService : IDataValidationService
    {
        private const string NullableGenericTypeName = "Nullable`1";

        private readonly ILogger _logger;

        public DataValidationService(OpenSettingsConfiguration openSettingsConfiguration)
        {
            _logger = openSettingsConfiguration.LoggerFactory.CreateLogger<DataValidationService>();
        }

        public bool IsDataMappingValid(string jsonData, ICollection<PropertyInfoHelperModel> properties)
        {
            try
            {
                using (var jsonDocument = JsonDocument.Parse(jsonData))
                {
                    return IsDataMappingValid(jsonDocument, properties);
                }
            }
            catch (Exception ex)
            {
                Logs.FailedToParseJsonDocument(_logger, ex);

                return false;
            }
        }

        public bool IsDataMappingValid(JsonDocument jsonDocument, ICollection<PropertyInfoHelperModel> properties)
        {
            if (jsonDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                return false;
            }

            var deserializedData = jsonDocument.Deserialize<Dictionary<string, JsonElement>>();

            return InternalIsDataMappingValid(deserializedData, properties);
        }

        private bool InternalIsDataMappingValid(Dictionary<string, JsonElement> deserializedData, ICollection<PropertyInfoHelperModel> properties)
        {
            foreach (var propertyFromDb in properties)
            {
                var propertyName = propertyFromDb.Name;

                if (deserializedData.TryGetValue(propertyName, out var propertyValue))
                {
                    if (propertyValue.ValueKind == JsonValueKind.Null)
                    {
                        if (propertyFromDb.CanBeNull)
                        {
                            continue;
                        }

                        return false;
                    }

                    if (propertyFromDb.IsComplexType)
                    {
                        try
                        {
                            if (propertyValue.ValueKind == JsonValueKind.Array)
                            {
                                var deserializedResult = DeserializeJsonElement(propertyValue, propertyFromDb.TypeFullName);

                                if (deserializedResult != null)
                                {
                                    continue;
                                }
                            }

                            if (propertyFromDb.TypeName == NullableGenericTypeName)
                            {
                                if (!ValidatePropertyValue(propertyValue, propertyFromDb.GenericTypeArguments.First()))
                                {
                                    return false;
                                }
                            }
                            else if (!ValidateComplexType(propertyValue.Deserialize<Dictionary<string, JsonElement>>(), propertyFromDb))
                            {
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            Logs.FailedToDeserializeComplexType(_logger, propertyName, propertyValue, ex);

                            return false;
                        }
                    }
                    else if (!ValidatePropertyValue(propertyValue, propertyFromDb.TypeFullName))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateComplexType(Dictionary<string, JsonElement> complexData, PropertyInfoHelperModel propertyFromDb)
        {
            if (complexData == null)
            {
                return true;
            }

            foreach (var property in propertyFromDb.Properties.SelectMany(s => s.Properties))
            {
                if (!complexData.TryGetValue(property.Name, out var propertyValue))
                {
                    return false;
                }

                if (property.IsComplexType)
                {
                    try
                    {
                        var nestedComplexData = propertyValue.Deserialize<Dictionary<string, JsonElement>>();

                        if (!ValidateComplexType(nestedComplexData, property))
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logs.FailedToValidateComplexProperty(_logger, property.Name, propertyValue, ex);

                        return false;
                    }
                }
                else
                {
                    if (!ValidatePropertyValue(propertyValue, property.TypeFullName))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool ValidatePropertyValue(JsonElement propertyValue, string typeName)
        {
            switch (typeName)
            {
                case "System.String":
                    return propertyValue.ValueKind == JsonValueKind.String;

                case "System.Decimal":
                    return propertyValue.ValueKind == JsonValueKind.Number && decimal.TryParse(propertyValue.GetRawText(), out _);

                case "System.Double":
                    return propertyValue.ValueKind == JsonValueKind.Number && double.TryParse(propertyValue.GetRawText(), out _);

                case "System.Int64":
                    return propertyValue.ValueKind == JsonValueKind.Number && long.TryParse(propertyValue.GetRawText(), out _);

                case "System.Int32":
                    return propertyValue.ValueKind == JsonValueKind.Number && int.TryParse(propertyValue.GetRawText(), out _);

                case "System.Int16":
                    return propertyValue.ValueKind == JsonValueKind.Number && short.TryParse(propertyValue.GetRawText(), out _);

                case "System.Single": // float
                    return propertyValue.ValueKind == JsonValueKind.Number && float.TryParse(propertyValue.GetRawText(), out _);

                case "System.Byte":
                    return propertyValue.ValueKind == JsonValueKind.Number && byte.TryParse(propertyValue.GetRawText(), out _);

                case "System.Enum":
                    return propertyValue.ValueKind == JsonValueKind.Number;

                case "System.Guid":
                    return propertyValue.ValueKind == JsonValueKind.String && Guid.TryParse(propertyValue.GetString(), out _);

                case "System.Boolean":
                    return propertyValue.ValueKind == JsonValueKind.False || propertyValue.ValueKind == JsonValueKind.True;

                case "System.DateTime":
                    return propertyValue.ValueKind == JsonValueKind.String && DateTime.TryParse(propertyValue.GetString(), out _);

                case "System.TimeSpan":
                    return propertyValue.ValueKind == JsonValueKind.String && TimeSpan.TryParse(propertyValue.GetString(), out _);

                case "System.Nullable`1":
                    return propertyValue.ValueKind == JsonValueKind.Null;

                case "System.Object":
                    return propertyValue.ValueKind == JsonValueKind.Object;

                case "System.Array": // Collections (IEnumerable<T>, Array<T>, List<T>, HashSet<T>, etc.)
                case var _ when typeName.StartsWith("System.Collections.Generic.IEnumerable"):
                    return propertyValue.ValueKind == JsonValueKind.Array;

                default:
                    Logs.UnsupportedTypeEncountered(_logger, typeName, null);
                    return false;
            }
        }

        private object DeserializeJsonElement(JsonElement propertyValue, string typeName)
        {
            var targetType = OpenSettingsDefaults.Caches.TypeNameToType.GetOrAdd(typeName, Type.GetType);
            
            if (targetType == null)
            {
                return null;
            }

            try
            {
               return propertyValue.Deserialize(targetType);
            }
            catch (JsonException ex)
            {
                Logs.FailedToDeserializeJsonElement(_logger, targetType.Name, propertyValue, ex);
            }
            catch (Exception ex)
            {
                Logs.UnexpectedErrorOccurredWhileDeserializingToType(_logger, targetType.Name, propertyValue, ex);
            }

            return null;
        }

        private static class Logs
        {
            public static readonly Action<ILogger, Exception> FailedToParseJsonDocument =
                LoggerMessage.Define(LogLevel.Error,
                    OpenSettingsDefaults.EventIds.DataValidationService.FailedToDeserializeComplexType,
                    "Failed to parse data as a JsonDocument.");

            public static readonly Action<ILogger, string, JsonElement, Exception> FailedToDeserializeComplexType =
                LoggerMessage.Define<string, JsonElement>(LogLevel.Error,
                    OpenSettingsDefaults.EventIds.DataValidationService.FailedToDeserializeComplexType,
                    "Failed to deserialize complex type for property '{propertyName}' with value '{propertyValue}'.");

            public static readonly Action<ILogger, string, JsonElement, Exception> FailedToValidateComplexProperty =
                LoggerMessage.Define<string, JsonElement>(LogLevel.Error,
                    OpenSettingsDefaults.EventIds.DataValidationService.FailedToValidateComplexProperty,
                    "Failed to validate complex property '{propertyName}' with value '{propertyValue}'.");

            public static readonly Action<ILogger, string, JsonElement, Exception> FailedToDeserializeJsonElement = LoggerMessage.Define<string, JsonElement>(LogLevel.Error,
                OpenSettingsDefaults.EventIds.DataValidationService.FailedToDeserializeJsonElement,
                "Failed to deserialize JsonElement to type '{targetTypeName}' with value '{propertyValue}'.");

            public static readonly Action<ILogger, string, JsonElement, Exception> UnexpectedErrorOccurredWhileDeserializingToType = LoggerMessage.Define<string, JsonElement>(LogLevel.Error,
                OpenSettingsDefaults.EventIds.DataValidationService.UnexpectedErrorOccurredWhileDeserializingToType,
                "Unexpected error while deserializing to type '{targetTypeName}' with value '{propertyValue}'.");

            public static readonly Action<ILogger, string, Exception> UnsupportedTypeEncountered =
                LoggerMessage.Define<string>(LogLevel.Warning,
                    OpenSettingsDefaults.EventIds.DataValidationService.UnsupportedTypeEncountered,
                    "Unsupported type '{typeName}' encountered during property value validation.");
        }
    }
}