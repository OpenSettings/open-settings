using System;

namespace OpenSettings.Configurations
{
    /// <summary>
    /// Represents the configuration for Redis. 
    /// These settings determine whether Redis is active, how to connect to Redis, and how to interact with Redis channels.
    /// </summary>
    public class RedisConfiguration
    {
        /// <summary>
        /// Gets or sets a value indicating whether Redis is active.
        /// When <c>true</c>, Redis is enabled and used for communication.
        /// </summary>
        /// <value>
        /// A <see cref="bool"/> indicating if Redis is active. Default is <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        private string _configuration;

        /// <summary>
        /// Gets or sets the configuration string for Redis. 
        /// This property is used to parse the configuration string for Redis connections, 
        /// typically via <see cref="StackExchange.Redis.ConfigurationOptions.Parse(string)"/> in the Redis StackExchange library.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> representing the configuration for Redis, which is parsed using 
        /// <see cref="StackExchange.Redis.ConfigurationOptions.Parse(string)"/> to establish Redis connection settings.
        /// </value>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="value"/> is null or whitespace while <see cref="IsActive"/> is <c>true</c>.
        /// </exception>
        public string Configuration
        {
            get => _configuration;
            set
            {
                if (string.IsNullOrWhiteSpace(value) && IsActive)
                {
                    throw new ArgumentNullException(nameof(Configuration));
                }

                _configuration = value;
            }
        }

        private string _channel = "Settings";

        /// <summary>
        /// Gets or sets the Redis channel used for communication. 
        /// This channel is used to send or receive messages related to settings.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> representing the Redis channel name. The default value is "Settings".
        /// </value>
        public string Channel
        {
            get => _channel;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _channel = value;
                }
            }
        }
    }
}