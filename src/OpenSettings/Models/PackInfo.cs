namespace OpenSettings.Models
{
    public class PackInfo
    {
        /// <summary>
        /// Gets or sets the version of the OpenSettings without the '<c>v</c>' prefix.
        /// </summary>
        /// <remarks>
        /// e.g. '<c>1.0.0</c>', '<c>1.0.0-preview.1.0.1</c>'
        /// </remarks>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the numerical score of the OpenSettings version, used for comparing versions.
        /// A higher score indicates a more recent version.
        /// </summary>
        /// <remarks>
        /// e.g. "1000000500000"
        /// </remarks>
        public long Score { get; set; }

        /// <summary>
        /// Specifies whether the OpenSettings version is a preview version.
        /// </summary>
        /// <remarks>
        /// e.g. "1.0.0" = <c>false</c>
        /// </remarks>
        public bool IsPreview { get; set; }
    }
}