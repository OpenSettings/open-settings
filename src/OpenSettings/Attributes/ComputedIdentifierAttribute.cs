using System;

namespace OpenSettings.Attributes
{
    /// <summary>
    /// Attribute used to assign a unique identifier (GUID) to setting classes.
    /// The computed identifier is either provided directly as a GUID or is computed based on the class full name (or other string identifier)
    /// using an MD5 hash of the UTF-8 bytes of the string. This allows each setting to have a unique identifier.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ComputedIdentifierAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComputedIdentifierAttribute"/> class.
        /// The constructor attempts to parse the provided identifier as a GUID.
        /// If the string cannot be parsed as a GUID, the identifier is computed using an MD5 hash of the UTF-8 bytes of the string,
        /// typically representing the class name or other unique setting identifier.
        /// </summary>
        /// <param name="identifier">A string that can either be a GUID or a class name (or another string) representing a setting's unique identifier.</param>
        public ComputedIdentifierAttribute(string identifier)
        {
            ComputedIdentifier = Guid.TryParse(identifier, out var guid)
                ? guid
                : Helper.ComputeIdentifier(identifier);
        }

        /// <summary>
        /// Gets the computed or provided GUID that uniquely identifies the setting class.
        /// </summary>
        public Guid ComputedIdentifier { get; }
    }
}