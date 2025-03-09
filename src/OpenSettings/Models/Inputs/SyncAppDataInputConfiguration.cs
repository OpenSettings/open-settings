namespace OpenSettings.Models.Inputs
{
    public class SyncAppDataInputConfiguration
    {
        public bool StoreInSeparateFile { get; set; }

        public bool IgnoreOnFileChange { get; set; }

        public RegistrationMode RegistrationMode { get; set; }

        public ConfigurationConsumer Consumer { get; set; }

        public ConfigurationProvider Provider { get; set; }
    }
}