using System;

namespace OpenSettings.Models
{
    public interface ILocalSetting
    {
        Type Type { get; }

        Guid ComputedIdentifier { get; }

        object Instance { get; }

        bool HasStoreInSeparateFileAttribute { get; }

        bool StoreInSeparateFile { get; }

        bool? IgnoreOnFileChange { get; }

        bool HasRegistrationModeAttribute { get; }

        RegistrationMode RegistrationMode { get; }

        string FilePath { get; }

        string GeneratedFilePath { get; }

        bool IsPreDataExists { get; }
    }
}