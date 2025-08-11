
using OpenSettings.Services.Interfaces;

namespace Consumer.Api.Settings
{
    public class GeneralSettings : ISettings
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}