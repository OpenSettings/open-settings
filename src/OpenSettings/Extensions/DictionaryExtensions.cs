using System;
using System.Collections.Generic;

namespace OpenSettings.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="IDictionary{TKey, TValue}"/> to simplify dictionary operations.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Retrieves the dictionary associated with the specified key, or creates a new one if not found.
        /// <para>
        /// This method checks if the specified key exists in the outer dictionary. If the key is found, it returns the 
        /// associated inner dictionary. If the key does not exist, it creates a new inner dictionary, adds it to the outer 
        /// dictionary, and returns it.
        /// </para>
        /// </summary>
        /// <param name="dictionaryToDictionary">The outer dictionary which maps a string key to another dictionary.</param>
        /// <param name="key">The key used to access the inner dictionary.</param>
        /// <returns>An inner dictionary of type <c>IDictionary&lt;string,object&gt;</c> associated with the specified key.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the outer <paramref name="dictionaryToDictionary"/> is null.</exception>
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