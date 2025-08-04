using System;
using Microsoft.Extensions.Options;

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
        /// <remarks>Default is <c>16000</c> ms.</remarks>
        public TimeSpan CleanupCheckInterval { get; set; } = TimeSpan.FromSeconds(16);

        /// <summary>
        /// The age threshold for determining when a provider registry entry is considered outdated and eligible for cleanup.
        /// </summary>
        /// <remarks>
        /// Entries with a <c>LastHeartbeat</c> older than this value will be removed during cleanup. Default is <c>21000</c> ms.
        /// </remarks>
        public TimeSpan CleanupOlderThan { get; set; } = TimeSpan.FromSeconds(21);

        ProviderRegistryCleanupTimedServiceOptions IOptions<ProviderRegistryCleanupTimedServiceOptions>.Value => this;
    }
}