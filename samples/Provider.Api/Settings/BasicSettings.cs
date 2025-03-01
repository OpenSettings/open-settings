using OpenSettings.Attributes;
using OpenSettings.Services.Interfaces;

namespace Provider.Api.Settings
{
    public class BasicSettings : ISettings
    {
        public string ConnectionStrings { get; set; } = string.Empty;
    }
}
