using System;
using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class GetInstancesResponseInstance
    {
        public string Id { get; set; }

        public string DynamicId { get; set; }

        public string IdentifierId { get; set; }

        public string Name { get; set; }

        public string[] Urls { get; set; } = Array.Empty<string>();

        public bool IsActive { get; set; }

        public string MachineName { get; set; }

        public List<ReloadStrategy> ReloadStrategies { get; set; } = new List<ReloadStrategy>();

        public ServiceType ServiceType { get; set; }

        public string Version { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}