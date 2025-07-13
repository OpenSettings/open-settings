using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace OpenSettings.Helpers
{
    /// <summary>
    /// Provides helper methods for parsing version strings and calculating version scores.
    /// Supports both stable versions and preview versions, and helps to compare versions.
    /// </summary>
    public static class VersionHelper
    {
        private const long StableBoost = 500_000L;

        private static readonly Regex PackVersionRegex = new Regex(@"^(?<major>\d+)\.(?<minor>\d+)\.(?<patch>\d+)(?:-preview\.(?<previewNo>\d+)\.(?<runNo>\d+)\.(?<runAttempt>\d+))?$", RegexOptions.Compiled);

        /// <summary>
        /// Parses a version string and calculates its corresponding score.
        /// Determines whether the version is a preview version or a stable version.
        /// </summary>
        /// <param name="packVersion">The version string to parse. Can be in the format 'major.minor.patch' for stable versions 
        /// or 'major.minor.patch-preview.previewNo.runNo.runAttempt' for preview versions.</param>
        /// <returns>A tuple with the pack version score (long) and a boolean indicating if it's a preview version.</returns>
        /// <exception cref="ArgumentException">Thrown if the version format is invalid.</exception>
        public static (long Score, bool IsPreview) GetPackInfo(string packVersion)
        {
            var match = PackVersionRegex.Match(packVersion);

            if (!match.Success)
            {
                throw new ArgumentException("Invalid version format", nameof(packVersion));
            }

            var major = int.Parse(match.Groups["major"].Value);
            var minor = int.Parse(match.Groups["minor"].Value);
            var patch = int.Parse(match.Groups["patch"].Value);

            var baseScore = major * 1_000_000_000_000L + minor * 1_000_000_000L + patch * 1_000_000L;

            long score;

            var isPreview = match.Groups["previewNo"].Success;

            if (!isPreview)
            {
                score = baseScore + StableBoost;
            }
            else
            {
                var previewNo = int.Parse(match.Groups["previewNo"].Value);
                var runNo = int.Parse(match.Groups["runNo"].Value) % 65536;
                var runAttempt = int.Parse(match.Groups["runAttempt"].Value);

                var previewWeight = previewNo * 10_000L + runNo * 100L + runAttempt;

                score = baseScore - StableBoost + previewWeight;
            }

            return (score, isPreview);
        }

        /// <summary>
        /// Retrieves version information from an assembly, including its version score and whether it's a preview version.
        /// Extracts the version from the assembly's informational version attribute.
        /// </summary>
        /// <param name="assembly">The assembly from which to retrieve the version information.</param>
        /// <returns>A tuple containing the pack version string, the pack version's score (long), and a boolean indicating if it's a preview version.</returns>
        /// <exception cref="ArgumentException">Thrown if the version format is invalid or no version is found.</exception>
        public static (string PackVersion, long Score, bool IsPreview) GetPackInfo(this Assembly assembly)
        {
            var informationalVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? OpenSettingsDefaults.DefaultVersion;

            var packVersion = informationalVersion.Split('+')[0];

            var packInfo = GetPackInfo(packVersion);

            return (packVersion, packInfo.Score, packInfo.IsPreview);
        }
    }
}