namespace OpenSettings.Models
{
    public class ConfigurationSpa
    {
        public string RoutePrefix { get; set; } = Constants.DefaultSpaRoutePrefix;

        public string DocumentTitle { get; set; } = Constants.DefaultDocumentTitle;

        public bool IsActive { get; set; } = true;
    }
}