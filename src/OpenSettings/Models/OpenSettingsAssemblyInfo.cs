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

            Version = VersionHelper.GetVersion(assemblyName);

            var packInfo = assembly.GetPackInfo();

            PackVersion = packInfo.PackVersion;
            IsPreviewVersion = packInfo.IsPreview;
            PackVersionScore = packInfo.Score;
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
        /// Gets the OpenSettings pack version information without the '<c>v</c>' prefix. 
        /// e.g. '<c>1.0.0</c>', '<c>1.0.0-preview.1.0.1</c>'.
        /// </summary>
        public string PackVersion { get; }

        /// <summary>
        /// Gets the OpenSettings pack version score information.
        /// e.g. '<c>1000000500000</c>'.
        /// </summary>
        public long PackVersionScore { get; }

        /// <summary>
        /// Specifies whether the OpenSettings version is a preview version.
        /// </summary>
        public bool IsPreviewVersion { get; }
    }
}