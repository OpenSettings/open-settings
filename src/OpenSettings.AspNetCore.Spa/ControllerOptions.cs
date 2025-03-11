namespace OpenSettings.AspNetCore
{
    /// <summary>
    /// Configuration options for the settings controller, including route, authorization and Api visibility.
    /// </summary>
    public class ControllerOptions
    {
        private string _route = Spa.Constants.OpenSettingsApiRoute;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerOptions"/> class.
        /// </summary>
        public ControllerOptions() { }

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
        /// <para>
        /// (In future releases, this may integrate with AppConfigurations or InstanceConfigurations  
        /// to determine access based on priority or configuration rank).
        /// </para>
        /// <para>The default value is '<c>false</c>'.</para>
        /// </summary>
        public bool Authorize { get; set; }

        /// <summary>
        /// Gets or sets OAuth2 options for the settings controller, allowing for 
        /// more detailed configuration of authentication and authorization using OAuth2.
        /// </summary>
        public OAuth2Options OAuth2Options { get; set; } = new OAuth2Options();
    }
}