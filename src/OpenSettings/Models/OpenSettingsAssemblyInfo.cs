using OpenSettings.Helpers;

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
            var assembly = typeof(OpenSettingsAssemblyInfo).Assembly;

            var assemblyName = assembly.GetName();

            FullName = assemblyName.FullName;
            Name = assemblyName.Name;

            PackInfo = assembly.GetPackInfo();
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
        /// Gets the pack information for OpenSettings, including version, score, and whether it is a preview version.
        /// </summary>
        public PackInfo PackInfo { get; }
    }
}