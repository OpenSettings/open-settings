using System;

namespace OpenSettings.Exceptions
{
    /// <summary>
    /// Exception thrown when an attempt exceeds its configured timeout. This is informational only; it does not stop the retry loop.
    /// </summary>
    public class AttemptTimeoutExceededException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AttemptTimeoutExceededException"/>.
        /// </summary>
        /// <param name="operation">The name or description of the operation that timed out.</param>
        /// <param name="attempt">The attempt number that exceeded the timeout.</param>
        /// <param name="attemptTimeout">The configured timeout for this attempt.</param>
        public AttemptTimeoutExceededException(string operation, int attempt, TimeSpan attemptTimeout)
            : base($"Attempt #{attempt} for '{operation}' exceeded timeout of {attemptTimeout}.")
        {
        }
    }
}