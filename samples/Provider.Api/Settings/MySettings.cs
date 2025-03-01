using OpenSettings.Services.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Provider.Api.Settings
{
    public class MySettings : ISettings
    {
        [Required]
        public string Name { get; set; } = "Oğulcan";
        public string Can { get; set; } = "31";
        public string DeliCan { get; set; } = "Delican";
        public IEnumerable<string> OSettings { get; set; } = new List<string>() { "1", "2", "3" };
        public IEnumerable<double> NullSettings { get; set; }
        public IEnumerable<SomeSet> BokSettingsList { get; set; }
        public IDictionary<string, int> StringToIntDictionary { get; set; }
        public IDictionary<string, SomeSet> StringToSomeSetDictionary { get; set; }
        public IDictionary<string, SomeSet[]> StringToSomeSetListDictionary { get; set; }
        public SomeSet BokSettings { get; set; } = new SomeSet();
        public SomeSet CokSettings { get; set; }

        public IEnumerable<int> NoSettings { get; set; } = new List<int>() { 1, 2, 3 };
    }
}
