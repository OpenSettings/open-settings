using OpenSettings.Attributes;
using OpenSettings.Services.Interfaces;

namespace Provider.Api.Settings
{
    [StoreInSeparateFile]
    public class MySeparateSettings : ISettings
    {
        public int ValueType { get; set; } = 10;
        public int? NullableValueType { get; set; } = 15;
    }
}