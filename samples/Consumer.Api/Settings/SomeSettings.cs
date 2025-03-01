using OpenSettings.Services.Interfaces;

namespace Consumer.Api.Settings
{
    public class SomeSettings : ISettings
    {
        public SomeSettings(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}