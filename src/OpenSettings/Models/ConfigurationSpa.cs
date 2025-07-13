namespace OpenSettings.Models
{
    public class ConfigurationSpa
    {
        public string RoutePrefix { get; set; } = OpenSettingsDefaults.Spa.DefaultRoutePrefix;

        public string DocumentTitle { get; set; } = OpenSettingsDefaults.Spa.DefaultDocumentTitle;

        public bool IsActive { get; set; } = true;
    }
}