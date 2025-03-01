using OpenSettings.Services.Interfaces;

namespace Consumer.Api.Settings
{
    public class DenSettings : ISettings
    {
        public string Name { get; set; }
        public string Bane { get; set; }
        public string Sane { get; set; }
        public string Husran { get; set; }
    }
}