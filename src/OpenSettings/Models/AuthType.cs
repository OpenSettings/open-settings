namespace OpenSettings.Models
{
    /// <summary>
    /// Represents the type of login used for authentication in OpenSettings.
    /// </summary>
    public enum AuthType
    {
        /// <summary>
        /// Represents an unset login type, indicating that no specific login type has been defined.
        /// </summary>
        Unset = 0,

        /// <summary>
        /// Represents a login type where the user is authenticated via OpenIdConnect flow.
        /// </summary>
        OpenIdConnect = 2,

        /// <summary>
        /// Represents a login type where the user is authenticated via a machine account.
        /// </summary>
        Machine = 3
    }
}