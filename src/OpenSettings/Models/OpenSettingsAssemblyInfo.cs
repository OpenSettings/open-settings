using System;

namespace OpenSettings.Models
{
    /// <summary>
    /// Represents the assembly information for the OpenSettings library.
    /// </summary>
    public class OpenSettingsAssemblyInfo
    {
        /// <summary>
        /// Singleton instance of the <see cref="OpenSettingsAssemblyInfo"/> class.
        /// </summary>
        public static readonly OpenSettingsAssemblyInfo Instance = new OpenSettingsAssemblyInfo();

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenSettingsAssemblyInfo"/> class.
        /// </summary>
        private OpenSettingsAssemblyInfo()
        {
            var assemblyName = typeof(OpenSettingsAssemblyInfo).Assembly.GetName();

            FullName = assemblyName.FullName;
            Name = assemblyName.Name;

            var version = assemblyName.Version ?? new Version(1, 0, 0); ;

            Version = version.ToVersion();
            VersionScore = version.ToVersionScore();
        }

        /// <summary>
        /// Gets the OpenSettings full name. 
        /// e.g. '<c>OpenSettings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null</c>'.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Gets the OpenSettings name. 
        /// e.g. '<c>OpenSettings</c>'.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the OpenSettings version information without the '<c>v</c>' prefix. 
        /// e.g. '<c>1.0.0</c>'.
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Gets the OpenSettings version score information.
        /// e.g. '<c>281474976710656</c>'.
        /// </summary>
        public long VersionScore { get; }
    }
}