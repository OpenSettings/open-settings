using OpenSettings.Attributes;
using OpenSettings.Services.Interfaces;

namespace Provider.Api.Settings
{
    [ComputedIdentifier("OguBogu")]
    [StoreInSeparateFile]
    public class CanCanSettings : ISettings
    {
        public string Ak { get; set; }
    }
}