using System;

namespace OpenSettings.Exceptions
{
    /// <summary>
    /// Exception thrown when the [Secret] attribute is applied to a property
    /// that is not of type string, indicating invalid usage of the attribute.
    /// </summary>
    public class InvalidSecretTextAttributeUsageException : Exception
    {
        private const string InvalidSecretAttributeUsageExceptionMessageFormat = "The [SecretText] attribute can only be applied to string properties. Property '{0}' is of type '{1}' in the '{2}' class.";

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSecretTextAttributeUsageException"/> class.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="propertyTypeName">The property type name.</param>
        /// <param name="className">The class name where the property is defined.</param>
        public InvalidSecretTextAttributeUsageException(string propertyName, string propertyTypeName, string className) : base(string.Format(InvalidSecretAttributeUsageExceptionMessageFormat, propertyName, propertyTypeName, className))
        {
        }
    }
}