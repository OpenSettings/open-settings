using OpenSettings.Services.Interfaces;
using System;

namespace Provider.Api.Settings
{
    public class SqlSettings : ISettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public bool EnablePooling { get; set; }

        public int? PoolSize { get; set; }

        public TimeSpan Timeout { get; set; }

        public bool IsActive { get; set; }
    }
}