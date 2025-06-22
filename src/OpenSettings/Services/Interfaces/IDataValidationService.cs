using OpenSettings.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenSettings.Services.Interfaces
{
    /// <summary>
    /// Provides methods for validating data mappings against expected property definitions.
    /// </summary>
    internal interface IDataValidationService
    {
        /// <summary>
        /// Validates the data mapping of a json serialized data against a collection of properties.
        /// </summary>
        /// <param name="jsonData">The json serialized data to validate.</param>
        /// <param name="properties">The collection of expected property definitions.</param>
        /// <returns><c>True</c> if the data mapping is valid; otherwise, <c>false</c>.</returns>
        bool IsDataMappingValid(string jsonData, ICollection<PropertyInfoHelperModel> properties);

        /// <summary>
        /// Validates the data mapping of a json document against a collection of properties.
        /// </summary>
        /// <param name="jsonDocument">The json document to validate.</param>
        /// <param name="properties">The collection of expected property definitions.</param>
        /// <returns><c>True</c> if the data mapping is valid; otherwise, <c>false</c>.</returns>
        bool IsDataMappingValid(JsonDocument jsonDocument, ICollection<PropertyInfoHelperModel> properties);
    }
}