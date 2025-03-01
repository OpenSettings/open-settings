namespace OpenSettings.Models
{
    /// <summary>
    /// Defines the types of operations that can be performed on the settings initialization.
    /// </summary>
    public enum Operation
    {
        /// <summary>
        /// Reads from the settings file if it exists, or initializes a new instance if it does not.
        /// The data is then processed and latest setting data is retrieved.
        /// </summary>
        ReadOrInitialize = 1,

        /// <summary>
        /// Reads from the settings file, maps the data to the appropriate settings.
        /// The data is then processed and latest setting data is retrieved.
        /// </summary>
        Read = 2
    }
}