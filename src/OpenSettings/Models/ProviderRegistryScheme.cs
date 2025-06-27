namespace OpenSettings.Models
{
    /// <summary>
    /// Represents the communication scheme used for provider registry entries.
    /// </summary>
    public enum ProviderRegistryScheme
    {
        /// <summary>
        /// Not set or unknown scheme.
        /// </summary>
        Unset = 0,

        /// <summary>
        /// Transmission Control Protocol (TCP).
        /// </summary>
        Tcp = 1,

        /// <summary>
        /// gRPC communication protocol.
        /// </summary>
        Grpc = 2,

        /// <summary>
        /// HyperText Transfer Protocol.
        /// </summary>
        Http = 3,

        /// <summary>
        /// Secure HyperText Transfer Protocol.
        /// </summary>
        Https = 4,

        /// <summary>
        /// WebSocket protocol.
        /// </summary>
        WebSocket = 5,

        /// <summary>
        /// Secure WebSocket protocol (WSS).
        /// </summary>
        WebSocketSecure = 6
    }
}