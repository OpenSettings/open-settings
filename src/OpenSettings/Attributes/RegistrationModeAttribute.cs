using OpenSettings.Models;
using OpenSettings.Services.Interfaces;
using System;

namespace OpenSettings.Attributes
{
    /// <summary>
    /// Specifies how a single settings file (separate setting files should have their own setting or setting class) can be registered and resolved within the service.
    /// This attribute supports resolving via configuration options or as a singleton service.
    /// <para>
    /// The registration mode can be applied to any class that implements the <see cref="ISettings"/> interface. 
    /// It defines how that class is registered within the service container, such as through general or specific configuration options.
    /// </para>
    /// <para>
    /// There are four possible ways the registration mode can be determined:
    /// <list type="bullet">
    ///     <item>
    ///         <description>Provider value: If a registration mode is found in the provider source, it will override any other configuration or attribute.</description>
    ///     </item>
    ///     <item>
    ///         <description>Attribute value: If no provider source value is found, the registration mode defined in this attribute is used.</description>
    ///     </item>
    ///     <item>
    ///         <description>Configuration value in provider source: If neither the provider nor the attribute has a registration mode, the configuration value from the provider source will be applied.</description>
    ///     </item>
    ///     <item>
    ///         <description>Default configuration value: If the configuration value from the provider source is missing, the default configuration value will be applied.</description>
    ///     </item>
    /// </list>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This attribute should be applied only to concrete classes that implement the <see cref="ISettings"/> interface.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class)]
    public class RegistrationModeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationModeAttribute"/> class with the specified registration mode.
        /// </summary>
        /// <param name="registrationMode">The registration mode for the class.</param>
        public RegistrationModeAttribute(RegistrationMode registrationMode)
        {
            RegistrationMode = registrationMode;
        }

        /// <summary>
        /// Gets the registration mode associated with the class.
        /// </summary>
        public RegistrationMode RegistrationMode { get; }
    }
}