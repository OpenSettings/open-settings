using OpenSettings.Services.Interfaces;

namespace Provider.Api.Settings
{
    public class SiteSettings : ISettings
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}