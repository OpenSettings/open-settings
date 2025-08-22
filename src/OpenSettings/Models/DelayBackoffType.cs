namespace OpenSettings.Models
{
    /// <summary>
    /// Represents the type of delay backoff strategy used for retrying operations.
    /// </summary>
    public enum DelayBackoffType
    {
        /// <summary>
        /// Constant backoff is a strategy in which the wait time between retries remains constant for each attempt.
        /// </summary>
        Constant = 0,

        /// <summary>
        /// Linear backoff is a strategy in which the wait time between retries increases linearly with each attempt.
        /// </summary>
        Linear = 1,

        /// <summary>
        /// Exponential backoff is a strategy in which the wait time between retries increases exponentially with each attempt.
        /// </summary>
        Exponential = 2
    }
}