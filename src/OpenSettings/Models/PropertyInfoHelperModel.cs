using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenSettings.Models
{
    public class PropertyInfoHelperModel
    {
        public string Name { get; set; }

        public Guid TypeIdentifier { get; set; }

        public string TypeName { get; set; }

        public string TypeFullName { get; set; }

        public string TypeNamespace { get; set; }

        public bool IsComplexType { get; set; }

        public bool IsGenericType { get; set; }

        public bool CanBeNull { get; set; }

        public ICollection<string> GenericTypeArguments { get; set; } = Array.Empty<string>();

        public ICollection<string> Attributes { get; set; } = Array.Empty<string>();

        public ICollection<PropertyInfoHelperModel> Properties { get; set; } = new List<PropertyInfoHelperModel>();

        public static PropertyInfoHelperModel CreatePropertyInfo(Type type, HashSet<Type> visitedTypes = null)
        {
            visitedTypes = visitedTypes ?? new HashSet<Type>();

            if (!visitedTypes.Add(type))
            {
                return null;
            }

            var propertyInfo = new PropertyInfoHelperModel
            {
                Name = type.Name,
                TypeIdentifier = type.GUID,
                TypeName = type.Name,
                TypeFullName = type.FullName,
                TypeNamespace = type.Namespace,
                IsComplexType = true,
                IsGenericType = type.IsGenericType,
                CanBeNull = CheckIfCanBeNull(type),
                GenericTypeArguments = type.GetGenericArguments().Select(t => t.FullName).ToArray(),
                Attributes = type.CustomAttributes.Select(a => a.AttributeType.FullName).ToArray()
            };

            foreach (var property in type.GetProperties())
            {
                var propertyType = property.PropertyType;
                var isComplexType = !propertyType.IsPrimitive && !BasicTypes.Contains(propertyType);

                var propertyInfoItem = new PropertyInfoHelperModel
                {
                    Name = property.Name,
                    TypeIdentifier = propertyType.GUID,
                    TypeName = propertyType.Name,
                    TypeFullName = propertyType.FullName,
                    IsComplexType = isComplexType,
                    IsGenericType = propertyType.IsGenericType,
                    CanBeNull = CheckIfCanBeNull(propertyType),
                    GenericTypeArguments = propertyType.GetGenericArguments().Select(t => t.FullName).ToArray(),
                    Attributes = property.CustomAttributes.Select(a => a.AttributeType.FullName).ToArray()
                };

                if (isComplexType)
                {
                    var recursivePropertyInfo = CreatePropertyInfo(propertyType);

                    if (recursivePropertyInfo != null && propertyInfoItem.TypeFullName != recursivePropertyInfo.TypeFullName)
                    {
                        propertyInfoItem.Properties.Add(recursivePropertyInfo);
                    }
                }

                propertyInfo.Properties.Add(propertyInfoItem);
            }

            return propertyInfo;
        }

        private static readonly HashSet<Type> BasicTypes = new HashSet<Type>
        {
            typeof(string),
            typeof(DateTime),
            typeof(TimeSpan)
        };

        private static bool CheckIfCanBeNull(Type type)
        {
            return !type.IsValueType || Nullable.GetUnderlyingType(type) != null;
        }
    }
}