using System;

namespace OpenSettings.Attributes
{
    /// <summary>
    /// Specifies that a setting should be stored in a separate file, such as <c>settings-generated.*.json</c>, 
    /// rather than the general settings file <c>settings-generated.json</c>.
    /// </summary>
    /// <remarks>
    /// If the class is marked with this attribute, its settings will be stored in a specific file. 
    /// The <see cref="IgnoreOnFileChange"/> property determines whether changes to the file 
    /// should be ignored when the file is modified.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class)]
    public class StoreInSeparateFileAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreInSeparateFileAttribute"/> class.
        /// </summary>
        /// <param name="ignoreOnFileChange">Indicates whether changes to the file should be ignored on file change.</param>
        public StoreInSeparateFileAttribute(bool ignoreOnFileChange = false)
        {
            IgnoreOnFileChange = ignoreOnFileChange;
        }

        /// <summary>
        /// Gets a value indicating whether changes to the file should be ignored when the file is modified.
        /// </summary>
        public bool IgnoreOnFileChange { get; }
    }
}