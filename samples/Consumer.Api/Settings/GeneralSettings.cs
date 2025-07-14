
namespace Consumer.Api.Settings
{
using OpenSettings.Services.Interfaces;

public class MyFirstSetting: ISettings
{
    public string Name { get; set; }
    public string Description { get; set; }
}
}