namespace OpenSettings.Models
{
    /// <summary>
    /// Represents the type of caller making a request to the OpenSettings.
    /// </summary>
    public enum CallerType
    {
        /// <summary>
        /// Unset caller type, used when the type is not specified.
        /// </summary>
        Unset = 0,

        /// <summary>
        /// Represents a Single Page Application (SPA) client.
        /// </summary>
        Spa = 1,

        /// <summary>
        /// Represents a backend service client.
        /// </summary>
        Service = 2
    }
}