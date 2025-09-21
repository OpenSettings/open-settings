using OpenSettings.Configurations;

namespace OpenSettings.Models
{
    public class ConfigurationController
    {
        public string Route { get; set; } = OpenSettingsDefaults.Routes.OpenSettingsApiDefaultRoute;

        public bool AllowFromExploring { get; set; }

        public bool RequiresAuthentication { get; set; }

        public OpenIdConnectConfiguration OpenIdConnect { get; set; } = new OpenIdConnectConfiguration();
    }
}