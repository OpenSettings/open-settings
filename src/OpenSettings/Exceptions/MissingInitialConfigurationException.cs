using System;

namespace OpenSettings.Exceptions
{
    public class MissingConfigurationWhenSkipInitialSyncAppDataException : Exception
    {
        public MissingConfigurationWhenSkipInitialSyncAppDataException() : base("Required configuration: 'settings-generated.open-settings.json' is missing when skipping the initial sync of app data. Ensure that the necessary setup is completed.") { }

        public MissingConfigurationWhenSkipInitialSyncAppDataException(string message)
            : base(message) { }

        public MissingConfigurationWhenSkipInitialSyncAppDataException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}