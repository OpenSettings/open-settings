using System;
using Microsoft.Extensions.Options;

namespace OpenSettings.Models
{
    /// <summary>
    /// Configuration options for the <see cref="OpenSettingsNotificationSyncTimedServiceOptions"/>.
    /// Used to control the behavior of the timed synchronization service for OpenSettings notifications.
    /// </summary>
    internal sealed class OpenSettingsNotificationSyncTimedServiceOptions : IOptions<OpenSettingsNotificationSyncTimedServiceOptions>
    {
        /// <summary>
        /// Indicates whether the service should preserve the period between executions.
        /// </summary>
        public bool PreservePeriod { get; set; } = true;

        /// <summary>
        /// The timeout for each task execution.
        /// </summary>
        public TimeSpan TaskTimeout { get; set; } = TimeSpan.FromMinutes(2);

        /// <summary>
        /// The initial delay before the first cleanup check is performed.
        /// </summary>
        /// <remarks>Default is '<c>1</c>' minute.</remarks>
        public TimeSpan StartsIn { get; set; } = TimeSpan.FromMinutes(1);

        OpenSettingsNotificationSyncTimedServiceOptions IOptions<OpenSettingsNotificationSyncTimedServiceOptions>.Value => this;
    }
}