using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using OpenSettings.Exceptions;
using OpenSettings.Models;
using OpenSettings.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenSettings.Configurations
{
    /// <summary>
    /// Represents the configuration for the open settings. 
    /// This class is responsible for handling different configurations
    /// based on the selected service type and the selection status.
    /// </summary>
    public class OpenSettingsConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenSettingsConfiguration"/> class
        /// with the default service type of <see cref="ServiceType.Provider"/>.
        /// </summary>
        public OpenSettingsConfiguration() : this(ServiceType.Provider)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenSettingsConfiguration"/> class
        /// with the specified <paramref name="selection"/> representing the type of service to configure.
        /// </summary>
        /// <param name="selection">
        /// The type of service to be configured. This is an instance of the <see cref="ServiceType"/> enumeration.
        /// The possible values are:
        /// <see cref="ServiceType.Provider"/> (the provider service configuration),
        /// <see cref="ServiceType.Consumer"/> (the consumer service configuration)
        /// </param>
        public OpenSettingsConfiguration(ServiceType selection)
        {
            _selection = selection;
            UpdateSelectionStatus();
        }

        /// <summary>
        /// Assigns a random guid at runtime unless a value is manually specified.
        /// </summary>
        public string InstanceDynamicId { get; set; } = Guid.NewGuid().ToString();

        private string _instanceName = Constants.DefaultInstanceName;

        /// <summary>
        /// Gets or sets the case-insensitive name of the instance.
        /// </summary>
        /// <value>
        /// The instance name. This value can be set to any non-empty string.
        /// If the provided value is null, empty, or whitespace, the instance name will remain unchanged.
        /// The default value is <c>"default"</c>.
        /// </value>
        public string InstanceName
        {
            get => _instanceName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }

                _instanceName = value.Trim();
                InstanceNameLowercase = _instanceName.ToLowerInvariant();
            }
        }

        internal string InstanceNameLowercase { get; private set; } = Constants.DefaultLowercase;

        private string _identifierName = Constants.DefaultIdentifierName;

        /// <summary>
        /// Gets or sets the case-insensitive name of the identifier.
        /// This identifier can be used to distinguish between different environments, such as Production, Development, etc.
        /// </summary>
        /// <value>
        /// The identifier name. This value can be set to any non-empty string.
        /// If the provided value is null, empty, or whitespace, the setting identifier name will remain unchanged.
        /// The default value is <c>"Default"</c>.
        /// The identifier helps to differentiate settings for different application environments, like Production, Development, etc.
        /// </value>
        public string IdentifierName
        {
            get => _identifierName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }

                _identifierName = value.Trim();
                IdentifierNameLowercase = _identifierName.ToLowerInvariant();
            }
        }

        internal string IdentifierNameLowercase { get; private set; } = Constants.DefaultLowercase;

        /// <summary>
        /// Gets or sets the client information, including the client's id, name, and secret.
        /// This information is used to identify the client.
        /// </summary>
        public ClientInfo Client { get; set; }

        private ServiceType _selection;

        /// <summary>
        /// Specifies whether the service acts as a Provider or a Consumer.
        /// </summary>
        public ServiceType Selection
        {
            get => _selection;
            set
            {
                if (_selection == value)
                {
                    return;
                }

                _selection = value;
                UpdateSelectionStatus();
            }
        }

        /// <summary>
        /// Gets or sets the configuration for the consumer service.
        /// </summary>
        /// <value>
        /// A <see cref="ConsumerConfiguration"/> object that holds the settings for the consumer service.
        /// </value>
        public ConsumerConfiguration Consumer { get; set; } = new ConsumerConfiguration();

        /// <summary>
        /// Gets or sets the configuration for the provider service.
        /// </summary>
        /// <value>
        /// A <see cref="ProviderConfiguration"/> object that holds the settings for the provider service.
        /// </value>
        public ProviderConfiguration Provider { get; set; } = new ProviderConfiguration();

        ///// <summary>
        /////     Gets or sets a flag indicating whether to continue processing when a sync data operation fails, 
        /////     but only if the generated settings files already exist.
        ///// </summary>
        ///// <value>
        /////     A boolean value that determines whether to proceed when a sync data operation fails, 
        /////     and the generated settings files already exist. The default is <c>false</c>.
        ///// </value>
        //public bool ContinueOnSyncDataFailureIfGeneratedFilesExist { get; set; }

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
        /// If the maximum retry count is reached, a <see cref="SyncAppDataMaxRetryExceededException"/> will be thrown.
        /// </remarks>
        /// </summary>
        public int SyncAppDataMaxRetryCount { get; set; } = -1;

        /// <summary>
        /// Gets or sets the delay time in milliseconds between retry attempts when a sync app data operation fails.
        /// </summary>
        /// <value>
        /// The number of milliseconds to wait before retrying a failed sync app data operation. The default value is 1000 milliseconds.
        /// </value>
        public int SyncAppDataRetryDelayMilliseconds { get; set; } = 1000;

        /// <summary>
        /// Gets or sets the operation to perform during the setup process.
        /// The default is <see cref="Models.Operation.ReadOrInitialize"/>.
        /// </summary>
        /// <value>The <see cref="Operation"/> value indicating what operation to perform.</value>
        public Operation Operation { get; set; } = Operation.ReadOrInitialize;

        /// <summary>
        /// Gets or sets a value indicating whether the settings should be stored in a separate file, such as 
        /// <c>settings-generated.*.json</c>, rather than the default <c>settings-generated.json</c> file.
        /// </summary>
        /// <remarks>
        /// If not explicitly specified in the specific setting, this will be used 
        /// as the default behavior for the first creation of the settings.
        /// When set to <c>true</c>, settings are stored in a separate file; otherwise, they are stored in the default 
        /// <c>settings-generated.json</c> file.
        /// </remarks>
        public bool StoreInSeparateFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether changes to the <c>settings-generated.json</c> file should be ignored 
        /// when reloading the configuration.
        /// <para>
        /// This property applies specifically to the general <c>settings-generated.json</c> file. For all other settings, 
        /// unless explicitly specified in its own setting, this will be used.
        /// Its works in conjunction with the <see cref="JsonConfigurationExtensions.AddJsonFile(IConfigurationBuilder,string)"/> method. When set to <c>true</c>,
        /// changes to the file will not trigger a reload of the configuration. When set to <c>false</c>,
        /// the file will be reloaded automatically if changes are detected. This property is typically used to
        /// control the reloading behavior for the main settings file.
        /// </para>
        /// </summary>
        /// <value>
        /// <c>true</c> to ignore changes to the <c>settings-generated.json</c> file; otherwise, <c>false</c>.
        /// </value>
        public bool IgnoreOnFileChange { get; set; }

        /// <summary>
        /// Gets or sets the registration mode to use during the setup.
        /// The default is <see cref="RegistrationMode.Singleton"/> & <see cref="RegistrationMode.Configure" />.
        /// </summary>
        /// <value>
        /// The <see cref="Models.RegistrationMode"/> value that determines the registration behavior.
        /// </value>
        public RegistrationMode RegistrationMode { get; set; } = RegistrationMode.Both;

        /// <summary>
        /// Gets a value indicating whether the consumer service is currently selected.
        /// This property is ignored during serialization (marked with <see cref="JsonIgnoreAttribute"/>).
        /// </summary>
        /// <value>
        /// A boolean value that indicates if the consumer service is selected. 
        /// This value is determined internally and cannot be set directly.
        /// </value>
        [JsonIgnore]
        public bool IsConsumerSelected { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the provider service is currently selected.
        /// This property is ignored during serialization (marked with <see cref="JsonIgnoreAttribute"/>).
        /// </summary>
        /// <value>
        /// A boolean value that indicates if the provider service is selected. 
        /// This value is determined internally and cannot be set directly.
        /// </value>
        [JsonIgnore]
        public bool IsProviderSelected { get; private set; }

        private ILoggerFactory _loggerFactory = NullLoggerFactory.Instance;

        /// <summary>
        /// An optional logger factory used for logging information during the settings building process.
        /// </summary>
        [JsonIgnore]
        public ILoggerFactory LoggerFactory
        {
            get => _loggerFactory;
            set
            {
                if (value != null)
                {
                    _loggerFactory = value;
                }
            }
        }

        /// <summary>
        /// Gets the service reload strategies for the settings.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> representing the reload strategy for the settings. 
        /// The returned value may indicate how the settings are reloaded, such as the method or frequency of reload.
        /// </returns>
        public List<ReloadStrategy> GetReloadStrategies()
        {
            var reloadStrategies = new List<ReloadStrategy>();

            if (IsConsumerSelected)
            {
                if (Consumer.IsRedisActive)
                {
                    reloadStrategies.Add(ReloadStrategy.Redis);
                }

                if (Consumer.PollingSettingsWorker.IsActive)
                {
                    reloadStrategies.Add(ReloadStrategy.Polling);
                }
            }
            else if(Provider.Redis.IsActive)
            {
                reloadStrategies.Add(ReloadStrategy.Redis);
            }

            return reloadStrategies;
        }

        private void UpdateSelectionStatus()
        {
            IsConsumerSelected = false;
            IsProviderSelected = false;

            switch (_selection)
            {
                case ServiceType.Provider:

                    IsProviderSelected = true;

                    break;

                case ServiceType.Consumer:
                default:

                    IsConsumerSelected = true;

                    break;
            }
        }

        internal void Update(SyncAppDataResponseConfiguration configuration)
        {
            StoreInSeparateFile = configuration.StoreInSeparateFile;
            IgnoreOnFileChange = configuration.IgnoreOnFileChange;
            RegistrationMode = configuration.RegistrationMode;

            if (IsConsumerSelected)
            {
                Consumer.RequestEncodings = configuration.Consumer.RequestEncodings;
                Consumer.IsRedisActive = configuration.Consumer.IsRedisActive;
                Consumer.PollingSettingsWorker.IsActive = configuration.Consumer.PollingSettingsWorker.IsActive;
                Consumer.PollingSettingsWorker.StartsIn = configuration.Consumer.PollingSettingsWorker.StartsIn;
                Consumer.PollingSettingsWorker.Period = configuration.Consumer.PollingSettingsWorker.Period;
            }
            else
            {
                Provider.CompressionLevel = configuration.Provider.CompressionLevel;
                Provider.CompressionType = configuration.Provider.CompressionType;
                Provider.Redis.IsActive = configuration.Provider.Redis.IsActive;
                Provider.Redis.Configuration = configuration.Provider.Redis.Configuration;
                Provider.Redis.Channel = configuration.Provider.Redis.Channel;
            }
        }
    }
}