using OpenSettings.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenSettings.Services.Interfaces
{
    internal interface IDataValidationService
    {
        /// <summary>
        /// Validates the data mapping of a json document against a collection of properties.
        /// </summary>
        /// <param name="jsonDocument">The json document to validate.</param>
        /// <param name="properties">The collection of expected property definitions.</param>
        /// <returns><c>True</c> if the data mapping is valid; otherwise, <c>false</c>.</returns>
        bool IsDataMappingValid(JsonDocument jsonDocument, ICollection<PropertyInfoHelperModel> properties);
    }
}