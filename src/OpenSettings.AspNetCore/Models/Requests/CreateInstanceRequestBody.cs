using OpenSettings.Models;
using System;
using System.Collections.Generic;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateInstanceRequestBody
    {
        public Guid ClientSecret { get; set; }

        public string InstanceName { get; set; }

        public string IdentifierName { get; set; }

        public string DynamicId { get; set; }

        public string[] Urls { get; set; } = Array.Empty<string>();

        public string Version { get; set; }

        public bool IsActive { get; set; }

        public string IpAddress { get; set; }

        public string MachineName { get; set; }

        public string Environment { get; set; }

        public List<ReloadStrategy> ReloadStrategies { get; set; } = new List<ReloadStrategy>();

        public ServiceType ServiceType { get; set; }

        public DataAccessType? DataAccessType { get; set; }
    }
}