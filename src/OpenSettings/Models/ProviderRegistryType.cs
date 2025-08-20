namespace OpenSettings.Models
{
    /// <summary>
    /// Represents the type of provider registry entry in the system.
    /// </summary>
    public enum ProviderRegistryType
    {
        /// <summary>
        /// Represents an unset or undefined provider instance in the registry.
        /// </summary>
        Unset = 0,

        /// <summary>
        /// Represents a slave provider instance in the registry.
        /// </summary>
        Slave = 1,

        /// <summary>
        /// Represents a master provider instance in the registry.
        /// </summary>
        Master = 2
    }
}