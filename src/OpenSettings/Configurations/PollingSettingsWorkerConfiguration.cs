using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace OpenSettings.Configurations
{
    /// <summary>
    /// Represents a worker that handles polling for the latest settings within a specified period.
    /// <para>
    /// This class allows you to configure the initial wait time before starting the polling, 
    /// the interval at which the polling occurs, and whether the worker is currently active.
    /// </para>
    /// <para>It also validates the input for time spans and sets default values if none are provided.</para>
    /// </summary>
    public class PollingSettingsWorkerConfiguration
    {
        public PollingSettingsWorkerConfiguration(bool isActive, TimeSpan startsIn, TimeSpan period)
        {
            IsActive = isActive;
            StartsIn = startsIn;
            Period = period;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PollingSettingsWorkerConfiguration"/> class.
        /// <para>
        /// This constructor takes parameters to set the initial wait time, polling interval, and the active state of the worker.
        /// </para>
        /// </summary>
        /// <param name="isActive">Indicates whether the polling worker is active.</param>
        /// <param name="startsIn">
        ///  The time span to wait before starting the polling. Defaults to 5 minutes if not specified.
        /// </param>
        /// <param name="period">
        ///  The time span between polling period. Defaults to 5 minutes if not specified.
        /// </param>
        /// <exception cref="FormatException">
        ///  Thrown when the format of the <paramref name="startsIn"/> 
        ///  or <paramref name="period"/> parameters is incorrect.
        /// </exception>
        [JsonConstructor]
        public PollingSettingsWorkerConfiguration(bool isActive = false, string startsIn = null, string period = null)
        {
            IsActive = isActive;

            if (!string.IsNullOrEmpty(startsIn))
            {
                if (!TimeSpan.TryParseExact(input: startsIn, format: "G", CultureInfo.InvariantCulture, out var startsInTimeSpan))
                {
                    throw new FormatException($"PollingSettingsWorker > {nameof(StartsIn)} property format is not correct, e.g. \"0:00:05:00.0000000\"");
                }

                StartsIn = startsInTimeSpan;
            }
            else
            {
                StartsIn = TimeSpan.FromMinutes(5);
            }

            if (!string.IsNullOrEmpty(period))
            {
                if (!TimeSpan.TryParseExact(input: period, format: "G", CultureInfo.InvariantCulture, out var periodTimeSpan))
                {
                    throw new FormatException($"PollingSettingsWorker > {nameof(Period)} property format is not correct, e.g. \"0:00:05:00.0000000\"");
                }

                Period = periodTimeSpan;
            }
            else
            {
                Period = TimeSpan.FromMinutes(5);
            }

        }

        /// <summary>
        /// Gets a value indicating whether the polling worker is active.
        /// <para>If true, the worker is actively polling at the specified intervals; otherwise, it is paused.</para>
        /// </summary>
        public bool IsActive { get; internal set; }

        /// <summary>
        /// Gets the time span to wait before starting the first polling.
        /// <para>This value determines how long the worker will wait before initiating the first polling process.</para>
        /// </summary>
        public TimeSpan StartsIn { get; internal set; }

        /// <summary>
        /// Gets the time span between each polling interval.
        /// <para>This value specifies how frequently the worker should poll for updates.</para>
        /// </summary>
        public TimeSpan Period { get; internal set; }
    }
}