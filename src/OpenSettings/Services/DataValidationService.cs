using Microsoft.Extensions.Logging;
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

        public DataValidationService(ILogger<DataValidationService> logger)
        {
            _logger = logger;
        }

        public bool IsDataMappingValid(string jsonData, ICollection<PropertyInfoHelperModel> properties)
        {
            var deserializedData = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonData);

            return InternalIsDataMappingValid(deserializedData, properties);
        }

        public bool IsDataMappingValid(JsonDocument jsonDocument, ICollection<PropertyInfoHelperModel> properties)
        {
            var deserializedData = jsonDocument.Deserialize<Dictionary<string, object>>();

            return InternalIsDataMappingValid(deserializedData, properties);
        }

        private bool InternalIsDataMappingValid(Dictionary<string, object> deserializedData, ICollection<PropertyInfoHelperModel> properties)
        {
            foreach (var propertyFromDb in properties)
            {
                var propertyName = propertyFromDb.Name;

                if (deserializedData.TryGetValue(propertyName, out var propertyValue))
                {
                    if (propertyValue == null)
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
                            var jsonElement = (JsonElement)propertyValue;

                            if (jsonElement.ValueKind == JsonValueKind.Array)
                            {
                                var deserializedResult = DeserializeJsonElement(jsonElement, propertyFromDb.TypeFullName);

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
                            else if (!ValidateComplexType(JsonSerializer.Deserialize<Dictionary<string, object>>(propertyValue.ToString()), propertyFromDb))
                            {
                                return false;
                            }
                        }
                        catch
                        {
                            _logger.LogError("Failed to deserialize complex type for property '{propertyName}' with value '{propertyValue}'", propertyName, propertyValue);

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

        private bool ValidateComplexType(Dictionary<string, object> complexData, PropertyInfoHelperModel propertyFromDb)
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
                        var nestedComplexData = JsonSerializer.Deserialize<Dictionary<string, object>>(propertyValue.ToString());

                        if (!ValidateComplexType(nestedComplexData, property))
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to validate complex property '{propertyName}' with value '{propertyValue}'.", property.Name, propertyValue);

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

        private static bool ValidatePropertyValue(object propertyValue, string typeName)
        {
            var jsonElement = (JsonElement)propertyValue;

            switch (typeName)
            {
                case "System.String":
                    return jsonElement.ValueKind == JsonValueKind.String;

                case "System.Decimal":
                    return jsonElement.ValueKind == JsonValueKind.Number && decimal.TryParse(jsonElement.GetRawText(), out _);

                case "System.Double":
                    return jsonElement.ValueKind == JsonValueKind.Number && double.TryParse(jsonElement.GetRawText(), out _);

                case "System.Int64":
                    return jsonElement.ValueKind == JsonValueKind.Number && long.TryParse(jsonElement.GetRawText(), out _);

                case "System.Int32":
                    return jsonElement.ValueKind == JsonValueKind.Number && int.TryParse(jsonElement.GetRawText(), out _);

                case "System.Int16":
                    return jsonElement.ValueKind == JsonValueKind.Number && short.TryParse(jsonElement.GetRawText(), out _);

                case "System.Single": // float
                    return jsonElement.ValueKind == JsonValueKind.Number && float.TryParse(jsonElement.GetRawText(), out _);

                case "System.Byte":
                    return jsonElement.ValueKind == JsonValueKind.Number && byte.TryParse(jsonElement.GetRawText(), out _);

                case "System.Enum":
                    return jsonElement.ValueKind == JsonValueKind.Number;

                case "System.Guid":
                    return jsonElement.ValueKind == JsonValueKind.String && Guid.TryParse(jsonElement.GetString(), out _);

                case "System.Boolean":
                    return jsonElement.ValueKind == JsonValueKind.False || jsonElement.ValueKind == JsonValueKind.True;

                case "System.DateTime":
                    return jsonElement.ValueKind == JsonValueKind.String && DateTime.TryParse(jsonElement.GetString(), out _);

                case "System.TimeSpan":
                    return jsonElement.ValueKind == JsonValueKind.String && TimeSpan.TryParse(jsonElement.GetString(), out _);

                case "System.Nullable`1":
                    return jsonElement.ValueKind == JsonValueKind.Null;

                case "System.Object":
                    return jsonElement.ValueKind == JsonValueKind.Object;

                case "System.Array": // Collections (IEnumerable<T>, Array<T>, List<T>, HashSet<T>, etc.)
                case var _ when typeName.StartsWith("System.Collections.Generic.IEnumerable"):
                    return jsonElement.ValueKind == JsonValueKind.Array;

                default:
                    return false;
            }
        }

        private object DeserializeJsonElement(JsonElement jsonElement, string typeName)
        {
            var targetType = Type.GetType(typeName);

            if (targetType == null)
            {
                return null;
            }

            string rawJson = null;

            try
            {
                rawJson = jsonElement.GetRawText();

                return JsonSerializer.Deserialize(rawJson, targetType);
            }
            catch (ObjectDisposedException ex)
            {
                _logger.LogError(ex, "Failed to deserialize to type '{targetTypeName}' because the JsonElement was disposed.",
                    targetType.Name);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize JsonElement to type '{targetTypeName}' with value '{rawJson}'.",
                    targetType.Name, rawJson);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while deserializing to type '{targetTypeName}' with value '{rawJson}'.",
                    targetType.Name, rawJson);
            }

            return null;
        }
    }
}