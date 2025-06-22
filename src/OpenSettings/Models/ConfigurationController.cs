using OpenSettings.Configurations;

namespace OpenSettings.Models
{
    public class ConfigurationController
    {
        public string Route { get; set; } = Constants.OpenSettingsApiRoute;

        public bool AllowFromExploring { get; set; }

        public bool Authorize { get; set; }

        public OAuth2Configuration OAuth2 { get; set; } = new OAuth2Configuration();
    }
}