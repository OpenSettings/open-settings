namespace OpenSettings.Configurations
{
    /// <summary>
    /// Configuration options for the settings controller, including route, authorization and Api visibility.
    /// </summary>
    public class ControllerConfiguration
    {
        private string _route = Constants.OpenSettingsApiRoute;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerConfiguration"/> class.
        /// </summary>
        public ControllerConfiguration() { }

        /// <summary>
        /// Gets or sets the base route for the service controller's endpoints.
        /// Default is "<c>api/settings</c>". Trailing and leading slashes are trimmed if present.
        /// </summary>
        public string Route 
        { 
            get => _route; 
            set => _route = string.IsNullOrWhiteSpace(value) ? value : value.TrimStart('/').TrimEnd('/');
        }

        /// <summary>
        /// Specifies whether the open settings controller's endpoints should be exposed in
        /// Api documentation (e.g., for Swagger or other Api explorers).
        /// <para>The default value is '<c>false</c>'.</para>
        /// </summary>
        public bool AllowFromExploring { get; set; }

        /// <summary>
        /// Indicates whether the controller requires authentication for access.  
        /// <para>When set to true, authentication is enforced.</para>
        /// <para>
        /// When set to false, the controller is accessible without authentication unless the service type is Consumer,  
        /// in which case the provider's authorization settings take precedence, and authentication may still be required.
        /// </para>
        /// <para>The default value is '<c>false</c>'.</para>
        /// </summary>
        public bool Authorize { get; set; }

        /// <summary>
        /// Gets or sets OAuth2 configuration for the open settings controller, allowing for 
        /// more detailed configuration of authentication and authorization using OAuth2.
        /// </summary>
        public OAuth2Configuration OAuth2 { get; set; } = new OAuth2Configuration();
    }
}