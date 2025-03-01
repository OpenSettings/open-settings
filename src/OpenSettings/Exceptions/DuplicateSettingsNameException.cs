using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenSettings.Exceptions
{
    /// <summary>
    /// Exception thrown when duplicate settings are found.
    /// </summary>
    public class DuplicateSettingsNameException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateSettingsNameException"/> class 
        /// with a default error message.
        /// </summary>
        public DuplicateSettingsNameException() : base("Duplicate settings found.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateSettingsNameException"/> class 
        /// with a list of duplicate settings.
        /// </summary>
        /// <param name="duplicateSettings">The collection of duplicate setting names.</param>
        public DuplicateSettingsNameException(IEnumerable<string> duplicateSettings) : base(GenerateDefaultMessage(duplicateSettings))
        {
            DuplicateSettings = duplicateSettings ?? Enumerable.Empty<string>();
        }

        /// <summary>
        /// Gets the collection of duplicate setting names.
        /// </summary>
        public IEnumerable<string> DuplicateSettings { get; }

        /// <summary>
        /// Generates a default error message based on the duplicate settings.
        /// </summary>
        /// <param name="duplicateSettings">The collection of duplicate setting names.</param>
        /// <returns>A formatted error message listing the duplicate settings.</returns>
        private static string GenerateDefaultMessage(IEnumerable<string> duplicateSettings)
        {
            return $"Duplicate settings found: {string.Join(", ", duplicateSettings)}";
        }
    }
}