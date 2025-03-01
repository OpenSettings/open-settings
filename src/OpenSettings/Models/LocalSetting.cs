using System;

namespace OpenSettings.Models
{
    internal sealed class LocalSetting : ILocalSetting
    {
        public Type Type { get; internal set; }

        public Guid ComputedIdentifier { get; internal set; }

        public object Instance { get; internal set; }

        public bool HasStoreInSeparateFileAttribute { get; internal set; }

        public bool StoreInSeparateFile { get; internal set; }

        public bool? IgnoreOnFileChange { get; internal set; }

        public bool HasRegistrationModeAttribute { get; internal set; }

        public RegistrationMode RegistrationMode { get; internal set; }

        public string FilePath { get; internal set; }

        public string GeneratedFilePath { get; internal set; }

        public bool IsPreDataExists { get; internal set; }
    }
}