using OpenSettings.Services.Interfaces;

namespace Consumer.Api.Settings
{
    public class MySettings : ISettings
    {
        public string Name { get; set; }
        public int No { get; set; }
        public SomeSettings Some { get; set; }
    }
}