using OpenSettings.Services.Interfaces;

namespace OpenSettings.Api
{
    public class MyFirstSetting : ISettings
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}