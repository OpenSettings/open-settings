using OpenSettings.Services.Interfaces;

namespace Provider.Api.Settings
{
    public class ClientSettings : ISettings
    {
        public string ClientName { get; set; } = "MyClient";
        public string ClientSecret { get; set; } = "4";
        public string ClientSecretSecret { get; set; } = "123";
    }
}