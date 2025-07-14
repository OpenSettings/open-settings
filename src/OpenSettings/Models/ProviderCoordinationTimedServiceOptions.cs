using Microsoft.Extensions.Options;

namespace OpenSettings.AspNetCore.Models
{
    /// <summary>
    /// Configuration options for the <see cref="ProviderCoordinationTimedServiceOptions"/>.
    /// Used to control the behavior of the provider coordination timed service.
    /// </summary>
    internal sealed class ProviderCoordinationTimedServiceOptions : IOptions<ProviderCoordinationTimedServiceOptions>
    {
        private int _masterCheckInterval = 8000;

        /// <summary>
        /// Interval (in milliseconds) between checks to determine if master is stale.
        /// </summary>
        /// <remarks>Default is <c>8000ms</c></remarks>
        public int MasterCheckInterval
        {
            get => _masterCheckInterval;
            set
            {
                _masterCheckInterval = value;
                CalculateHeartbeatInterval();
            }
        }

        /// <summary>
        /// Interval (in milliseconds) for this instance to send heartbeat updates.
        /// </summary>
        /// <remarks>Default is <c>5000ms</c></remarks>
        public int HeartbeatInterval { get; private set; } = 5000;

        /// <summary>
        /// Grace buffer (in milliseconds) to tolerate minor delays when evaluating stale masters.
        /// </summary>
        /// <remarks>Default is <c>1000ms</c></remarks>
        public int GraceBuffer { get; set; } = 1000;

        private void CalculateHeartbeatInterval()
        {
            HeartbeatInterval = _masterCheckInterval / 2 + 1;
        }

        ProviderCoordinationTimedServiceOptions IOptions<ProviderCoordinationTimedServiceOptions>.Value => this;
    }
}