using System;
using System.Collections.Generic;
using OpenSettings.Configurations;

namespace OpenSettings.Models.Inputs
{
    public class CreateInstanceInput
    {
        public CreateInstanceInput()
        {
        }

        public CreateInstanceInput(OpenSettingsConfiguration openSettingsConfiguration, bool isActive, string[] urls)
        {
            ClientId = openSettingsConfiguration.Client.Id;
            ClientSecret = openSettingsConfiguration.Client.Secret;
            InstanceName = openSettingsConfiguration.InstanceName;
            IdentifierName = openSettingsConfiguration.IdentifierName;
            DynamicId = openSettingsConfiguration.InstanceDynamicId;
            Urls = urls ?? Array.Empty<string>();
            Version = openSettingsConfiguration.Client.Version;
            IsActive = isActive;
            MachineName = System.Environment.MachineName;
            Environment = Helpers.Helper.GetEnvironmentName();
            ReloadStrategies = openSettingsConfiguration.GetReloadStrategies();
            ServiceType = openSettingsConfiguration.Selection;
            DataAccessType = openSettingsConfiguration.IsConsumerSelected ? (DataAccessType?)null : openSettingsConfiguration.Provider.Selection;
        }

        public Guid ClientId { get; set; }

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

        public Guid? CreatedById { get; set; }
    }
}