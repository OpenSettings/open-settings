using System;
using System.Collections.Generic;

namespace OpenSettings.Extensions
{
    public static class DictionaryExtensions
    {
        public static IDictionary<string, object> GetOrCreateDictionary(this IDictionary<string, Dictionary<string, object>> dictionaryToDictionary, string key)
        {
            if (dictionaryToDictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionaryToDictionary));
            }

            if (dictionaryToDictionary.TryGetValue(key, out var innerDict))
            {
                return innerDict;
            }

            innerDict = new Dictionary<string, object>();

            dictionaryToDictionary[key] = innerDict;

            return innerDict;
        }
    }
}