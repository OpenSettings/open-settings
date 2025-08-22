namespace OpenSettings.Configurations
{
    /// <summary>
    /// Configuration options for the settings controller, including route, authorization and Api visibility.
    /// </summary>
    public class ControllerConfiguration
    {
        private string _route = OpenSettingsDefaults.Routes.OpenSettingsApiRoute;

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
            set => _route = string.IsNullOrWhiteSpace(value) 
                ? value 
                : value.TrimStart(OpenSettingsDefaults.Format.SlashChar).TrimEnd(OpenSettingsDefaults.Format.SlashChar);
        }

        /// <summary>
        /// Specifies whether the open settings controller's endpoints should be exposed in
        /// Api documentation (e.g., for Swagger or other Api explorers).
        /// </summary>
        /// <remarks>
        /// The default value is '<c>false</c>'.
        /// </remarks>
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
        /// <remarks>
        /// Middleware should be registered in the following order to ensure authentication works: 
        /// <code>
        /// app.UseRouting();
        /// app.UseAuthentication();
        /// app.UseAuthorization();
        /// app.UseOpenSettings();
        /// app.MapControllers();
        /// </code>
        /// For more information, see <see href="https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-9.0#middleware-order">Asp.Net Core Middleware Order</see>
        /// </remarks>
        public bool RequiresAuthentication { get; set; }

        /// <summary>
        /// Gets or sets OpenIdConnect configuration for the open settings controller, allowing for 
        /// more detailed configuration of authentication and authorization using OpenIdConnect.
        /// </summary>
        public OpenIdConnectConfiguration OpenIdConnect { get; set; } = new OpenIdConnectConfiguration();
    }
}