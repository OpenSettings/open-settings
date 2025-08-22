using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
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
            IdentifierName = Helpers.Helper.GetEnvironmentName();
        }

        /// <summary>
        /// Assigns a random guid at runtime unless a value is manually specified.
        /// </summary>
        public string InstanceDynamicId { get; set; } = Guid.NewGuid().ToString();

        private string _instanceName = OpenSettingsDefaults.DefaultInstanceName;

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

        internal string InstanceNameLowercase { get; private set; } = OpenSettingsDefaults.DefaultLowercase;

        private string _identifierName;

        /// <summary>
        /// Gets or sets the case-insensitive name of the identifier.
        /// This identifier can be used to distinguish between different environments, such as Production, Development, etc.
        /// </summary>
        /// <value>
        /// The identifier name. This value can be set to any non-empty string.
        /// If the provided value is null, empty, or whitespace, the setting identifier name will remain unchanged.
        /// The default value is automatically calculates using <see cref="Helpers.Helper.GetEnvironmentName"/>.
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

        internal string IdentifierNameLowercase { get; private set; }

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
        /// A <see cref="ConsumerConfiguration"/> object that holds the configuration for the consumer service.
        /// </value>
        public ConsumerConfiguration Consumer { get; set; } = new ConsumerConfiguration();

        /// <summary>
        /// Gets or sets the configuration for the provider service.
        /// </summary>
        /// <value>
        /// A <see cref="ProviderConfiguration"/> object that holds the configuration for the provider service.
        /// </value>
        public ProviderConfiguration Provider { get; set; } = new ProviderConfiguration();

        /// <summary>
        /// Gets or sets the configuration for the OpenSettings controller.
        /// </summary>
        /// <value>
        /// A <see cref="ControllerConfiguration"/> object that holds the configuration for the OpenSettings Controller.
        /// </value>
        public ControllerConfiguration Controller { get; set; } = new ControllerConfiguration();

        /// <summary>
        /// Gets or sets the configuration for the OpenSettings Spa.
        /// </summary>
        /// <value>
        /// A <see cref="SpaConfiguration"/> object that holds the configuration for the OpenSettings Spa.
        /// </value>
        public SpaConfiguration Spa { get; set; } = new SpaConfiguration();

        /// <summary>
        /// Gets or sets the resilience configuration for synchronizing application data.
        /// </summary>
        public SyncAppDataResilienceConfiguration SyncAppDataResilience { get; set; } = new SyncAppDataResilienceConfiguration();

        /// <summary>
        /// Gets or sets the operation to perform during the setup process.
        /// The default is <see cref="Operation.ReadOrInitialize"/>.
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
        /// The default is <see cref="RegistrationMode.Singleton"/> &amp; <see cref="RegistrationMode.Configure" />.
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

        internal ILoggerFactory InternalLoggerFactory;

        /// <summary>
        /// An optional logger factory used for logging information during the building process.
        /// </summary>
        /// <remarks>
        /// Behavior:
        /// <list type="bullet">
        ///   <item>
        ///     <description><c>null</c> (default), OpenSettings will attempt to resolve <see cref="ILoggerFactory"/> from DI,
        ///     or fallback to <see cref="NullLoggerFactory.Instance"/> if none is registered.</description>
        ///   </item>
        ///   <item>
        ///     <description>Assign a custom <see cref="ILoggerFactory"/>, OpenSettings uses the provided logger factory.</description>
        ///   </item>
        ///   <item>
        ///     <description>Assign <see cref="NullLoggerFactory.Instance"/> explicitly, disables logging entirely.</description>
        ///   </item>
        /// </list>
        /// </remarks>
        [JsonIgnore]
        public ILoggerFactory LoggerFactory
        {
            get => InternalLoggerFactory ?? NullLoggerFactory.Instance;
            set => InternalLoggerFactory = value;
        }

        /// <summary>
        /// Gets the service reload strategies for the settings.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> representing the reload strategy for the settings. 
        /// The returned value may indicate how the settings are reloaded, such as the method or frequency of reload.
        /// </returns>
        internal List<ReloadStrategy> GetReloadStrategies()
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
            IsProviderSelected = _selection == ServiceType.Provider;
            IsConsumerSelected = !IsProviderSelected;
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

            Controller.Route = configuration.Controller.Route;
            Controller.AllowFromExploring = configuration.Controller.AllowFromExploring;
            Controller.RequiresAuthentication = configuration.Controller.RequiresAuthentication;
            Controller.OpenIdConnect.Authority = configuration.Controller.OpenIdConnect.Authority;
            Controller.OpenIdConnect.ClientId = configuration.Controller.OpenIdConnect.ClientId;
            Controller.OpenIdConnect.ClientSecret = configuration.Controller.OpenIdConnect.ClientSecret;
            Controller.OpenIdConnect.SignedOutRedirectUri = configuration.Controller.OpenIdConnect.SignedOutRedirectUri;
            Controller.OpenIdConnect.AllowOfflineAccess = configuration.Controller.OpenIdConnect.AllowOfflineAccess;
            Controller.OpenIdConnect.IsActive = configuration.Controller.OpenIdConnect.IsActive;

            Spa.RoutePrefix = configuration.Spa.RoutePrefix;
            Spa.DocumentTitle = configuration.Spa.DocumentTitle;
            Spa.IsActive = configuration.Spa.IsActive;
        }
    }
}