using System;

namespace OpenSettings.Exceptions
{
    /// <summary>
    /// Exception thrown when the total timeout for an operation is exceeded.
    /// </summary>
    internal class TotalTimeoutExceededException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TotalTimeoutExceededException"/>.
        /// </summary>
        /// <param name="operation">The name or description of the operation that timed out.</param>
        /// <param name="totalTimeout">The total allowed timeout that was exceeded.</param>
        public TotalTimeoutExceededException(string operation, TimeSpan totalTimeout) : base($"The total timeout of {totalTimeout} for the operation '{operation}' exceeded.")
        {
        }
    }
}