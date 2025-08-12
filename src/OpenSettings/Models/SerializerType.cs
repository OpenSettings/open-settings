namespace OpenSettings.Models
{
    /// <summary>
    /// Represents the type of serialization format to be used.
    /// This enum is used to specify how data should be serialized or deserialized.
    /// </summary>
    public enum SerializerType
    {
        /// <summary>
        /// Represents an unset or default serialization format.
        /// </summary>
        Unset = 0,

        /// <summary>
        /// Represents the Json serialization format.
        /// </summary>
        Json = 1
    }
}