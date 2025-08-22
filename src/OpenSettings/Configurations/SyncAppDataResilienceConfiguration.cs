using OpenSettings.Exceptions;
using OpenSettings.Models;
using System;

namespace OpenSettings.Configurations
{
    /// <summary>
    /// Configuration for resilience settings when synchronizing application data.
    /// </summary>
    public class SyncAppDataResilienceConfiguration
    {
        /// <summary>
        /// Gets or sets the total timeout for the sync app data operation.
        /// This is the maximum time allowed for the entire operation to complete, including all retries.
        /// </summary>
        /// <remarks>
        /// The default value is '<c>null</c>' which refer to indefinite timeout.
        /// If the total timeout is reached, a <see cref="TotalTimeoutExceededException"/> will be thrown.
        /// </remarks>
        /// <exception cref="TotalTimeoutExceededException">When the total timeout is reached.</exception>
        public TimeSpan? TotalTimeout { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of retries for initial syncing data. The retry behavior is determined as follows:
        /// <list type="bullet">
        ///     <item>
        ///         <c>0</c> or any negative value other than <c>-1</c>: No retries (operation will fail immediately on failure).
        ///     </item>
        ///     <item>
        ///         <c>-1</c>: Infinite retries (operation will continue retrying until success).
        ///     </item>
        ///     <item>
        ///         Any positive integer: Retry up to the specified number of attempts.
        ///     </item>
        /// </list>
        /// <para>
        /// By default, the value is <c>-1</c>, which means infinite retries. Negative values other than <c>-1</c> are interpreted as "no retries" (equivalent to <c>0</c> retries), while <c>-1</c> signifies infinite retries. 
        /// If set to a positive value, the system will attempt the operation that many times before giving up.
        /// </para>
        /// <remarks>
        /// If the maximum retry attempts is reached, a <see cref="MaxRetryExceededException"/> will be thrown.
        /// </remarks>
        /// </summary>
        /// <exception cref="MaxRetryExceededException">When the max retry attempts is reached.</exception>
        public int MaxRetryAttempts { get; set; } = -1;

        /// <summary>
        /// Gets or sets the timeout for each individual attempt to sync app data.
        /// </summary>
        /// <remarks>
        /// The default value is '<c>null</c>' which refer to indefinite timeout.
        /// </remarks>
        public TimeSpan? AttemptTimeout { get; set; }

        /// <summary>
        /// Gets or sets the type of backoff strategy to use for retrying failed sync app data operations.
        /// </summary>
        public DelayBackoffType BackoffType { get; set; } = DelayBackoffType.Constant;

        /// <summary>
        /// Gets or sets the delay time between retry attempts when a sync app data operation fails.
        /// </summary>
        /// <value>
        /// The timespan to wait before retrying a failed sync app data operation. The default value is <c>1000ms</c>.
        /// </value>
        public TimeSpan RetryDelay { get; set; } = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Gets or sets the maximum delay time between retry attempts when a sync app data operation fails.
        /// Only used if <see cref="BackoffType"/> is set to <see cref="DelayBackoffType.Linear"/> or <see cref="DelayBackoffType.Exponential"/>.
        /// </summary>
        public TimeSpan? MaxRetryDelay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use jitter in the delay between retry attempts.
        /// The jitter uses a random factor to vary the delay time, which can help to avoid thundering herd problems in distributed systems.
        /// </summary>
        public bool UseJitter { get; set; }
    }
}