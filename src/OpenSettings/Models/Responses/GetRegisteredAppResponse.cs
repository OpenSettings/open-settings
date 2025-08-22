namespace OpenSettings.Models.Responses
{
    public class GetRegisteredAppResponse
    {
        /// <summary>
        /// The unique identifier of the client application.
        /// </summary>
        /// <remarks>
        /// May contains empty if the client is not registered.
        /// </remarks>
        public string ClientName { get; set; }

        /// <summary>
        /// Indicates whether the client is registered in the OpenSettings.
        /// </summary>
        public bool IsRegistered { get; set; }

        /// <summary>
        /// Indicates whether the client id is unique in the OpenSettings.
        /// </summary>
        public bool IsClientIdUnique { get; set; }

        /// <summary>
        /// Indicates whether the client secret matches the one stored in the OpenSettings.
        /// </summary>
        public bool IsClientSecretMatched { get; set; }
    }
}