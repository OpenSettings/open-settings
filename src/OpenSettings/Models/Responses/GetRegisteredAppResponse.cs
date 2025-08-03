namespace OpenSettings.Models.Responses
{
    public class GetRegisteredAppResponse
    {
        /// <summary>
        /// The unique identifier of the client application.
        /// </summary>
        /// <remarks>
        /// May be empty if the client is not registered.
        /// </remarks>
        public string ClientName { get; set; }

        /// <summary>
        /// Indicates whether the client is registered in the OpenSettings system.
        /// </summary>
        public bool IsRegistered { get; set; }

        /// <summary>
        /// Indicates whether the client id is unique in the OpenSettings system.
        /// </summary>
        public bool IsClientIdUnique { get; set; }

        /// <summary>
        /// Indicates whether the client secret matches the one stored in the system.
        /// </summary>
        public bool IsClientSecretMatched { get; set; }
    }
}