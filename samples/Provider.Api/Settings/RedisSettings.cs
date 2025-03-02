using OpenSettings.Services.Interfaces;
using System;

namespace Provider.Api.Settings
{
    public class RedisSettings : ISettings
    {
        public string Configuration { get; set; }

        public TimeSpan Timeout { get; set; }

        public bool IsActive { get; set; }
    }
}