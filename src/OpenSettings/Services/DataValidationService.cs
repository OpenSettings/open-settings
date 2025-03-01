using OpenSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace OpenSettings.Services
{
    public class DataValidationService
    {
        private const string NullableGenericTypeName = "Nullable`1";

        public bool IsDataMappingValid(string data, ICollection<PropertyInfoHelperModel> properties)
        {
            var deserializedData = JsonSerializer.Deserialize<Dictionary<string, object>>(data);

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
                            return false;
                        }
                    }
                    else
                    {
                        if (!ValidatePropertyValue(propertyValue, propertyFromDb.TypeFullName))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateComplexType(IReadOnlyDictionary<string, object> complexData, PropertyInfoHelperModel propertyFromDb)
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
                    catch
                    {
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

        private static object DeserializeJsonElement(JsonElement jsonElement, string typeName)
        {
            var targetType = Type.GetType(typeName);

            if (targetType == null)
            {
                return null;
            }

            try
            {
                return JsonSerializer.Deserialize(jsonElement.GetRawText(), targetType);
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }
}