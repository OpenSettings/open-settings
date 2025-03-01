namespace OpenSettings.Models
{
    /// <summary>
    /// Defines the types of service configurations for the settings service.
    /// This enum specifies whether the service operates as a provider or consumer.
    /// </summary>
    public enum ServiceType
    {
        /// <summary>
        /// Represents the service functioning as a provider.
        /// <para>
        /// This type configures the service to provide settings to other services or clients.
        /// </para>
        /// </summary>
        Provider = 1,

        /// <summary>
        /// Represents the service functioning as a consumer. 
        /// <para>
        /// This type configures the service to consume settings from a provider service.
        /// </para>
        /// </summary>
        Consumer = 2
    }
}