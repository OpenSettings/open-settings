using Microsoft.Extensions.Options;
using System;

namespace OpenSettings.Models
{
    /// <summary>
    /// Configuration options for the <see cref="ProviderRegistryCleanupTimedServiceOptions"/>.
    /// Used to control the behavior of the provider registry cleanup timed service.
    /// </summary>
    internal sealed class ProviderRegistryCleanupTimedServiceOptions : IOptions<ProviderRegistryCleanupTimedServiceOptions>
    {
        /// <summary>
        /// Interval between cleanup checks.
        /// </summary>
        /// <remarks>Default is '<c>1</c>' day.</remarks>
        public TimeSpan CleanupCheckInterval { get; set; } = TimeSpan.FromDays(1);

        /// <summary>
        /// The age threshold for determining when a provider registry entry is considered outdated and eligible for cleanup.
        /// </summary>
        /// <remarks>
        /// Entries with a <c>LastHeartbeat</c> older than this value will be removed during cleanup. Default is '<c>30</c>' days.
        /// </remarks>
        public TimeSpan CleanupOlderThan { get; set; } = TimeSpan.FromDays(30);

        /// <summary>
        /// The initial delay before the first cleanup check is performed.
        /// </summary>
        /// <remarks>Default is '<c>1</c>' minute.</remarks>
        public TimeSpan StartsIn { get; set; } = TimeSpan.FromMinutes(1);

        ProviderRegistryCleanupTimedServiceOptions IOptions<ProviderRegistryCleanupTimedServiceOptions>.Value => this;
    }
}