using System;

namespace OpenSettings.Exceptions
{
    /// <summary>
    /// Exception thrown when the maximum number of retry attempts for an operation is exceeded.
    /// </summary>
    public class MaxRetryExceededException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MaxRetryExceededException"/>.
        /// </summary>
        /// <param name="operation">The name or description of the operation that exceeded the retry limit.</param>
        /// <param name="maxRetryCount">The maximum number of allowed retry attempts.</param>
        public MaxRetryExceededException(string operation, int maxRetryCount) : base($"The operation '{operation}' exceeded the maximum retry limit. MaxRetryCount: {maxRetryCount}.")
        {
            MaxRetryCount = maxRetryCount;
        }

        /// <summary>
        /// Gets the maximum number of retry attempts allowed for the operation.
        /// </summary>
        public int MaxRetryCount { get; }
    }
}