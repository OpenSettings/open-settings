using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using OpenSettings.Models;

namespace OpenSettings.Helpers
{
    /// <summary>
    /// Provides utility methods for string manipulation and collection operations in OpenSettings.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Extracts and returns the initials from a given name.
        /// </summary>
        /// <param name="name">The full name from which to extract initials.</param>
        /// <returns>A string containing the uppercase initials of the name. Returns an empty string if the input is empty.</returns>
        public static string GetInitials(string name)
        {
            var parts = name.Replace(OpenSettingsDefaults.Format.Dot, OpenSettingsDefaults.Format.Space).Split(OpenSettingsDefaults.Separators.SpaceSeparator, StringSplitOptions.RemoveEmptyEntries);

            return parts.Length == 0 ? string.Empty : string.Join(string.Empty, parts.Select(p => p[0])).ToUpper();
        }

        /// <summary>
        /// Indicates whether the application is running in "Migration" mode.
        /// Used to determine if Entity Framework Core migration should be generated.
        /// </summary>
        public static bool IsMigrationEnabled()
        {
            return Environment.GetCommandLineArgs().FirstOrDefault()?.Contains("ef.dll") ?? false;
        }

        internal static IOrderedQueryable<TEntity> ApplySorting<TEntity, TKey>(
            IQueryable<TEntity> source,
            IOrderedQueryable<TEntity> orderedSource,
            Expression<Func<TEntity, TKey>> keySelector,
            SortDirection direction)
        {
            return source != null
                ? direction == SortDirection.Desc
                    ? source.OrderByDescending(keySelector)
                    : source.OrderBy(keySelector)
                : direction == SortDirection.Desc
                    ? orderedSource.ThenByDescending(keySelector)
                    : orderedSource.ThenBy(keySelector);
        }

        public static string GetPublicCacheControlValue(double expiresInSeconds)
        {
            return string.Format(OpenSettingsDefaults.Format.PublicCacheControlValue, (int)expiresInSeconds);
        }

        /// <summary>
        /// Retrieves the current environment name from environment variables. 
        /// It checks the following variables in order: ASPNETCORE_ENVIRONMENT, DOTNET_ENVIRONMENT, and ENVIRONMENT. 
        /// If none are set, it defaults to "Production".
        /// </summary>
        /// <returns>The detected environment name or "Production" if none are found.</returns>
        public static string GetEnvironmentName()
        {
            var value = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            value = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            value = Environment.GetEnvironmentVariable("ENVIRONMENT");

            return string.IsNullOrWhiteSpace(value) ? "Production" : value;
        }

        internal static string GenerateVersion(DateTime currentTime, DateTime createdOn)
        {
            return $"{(currentTime.Ticks - createdOn.Ticks) / 10_000.0}{GenerateRandomCharacters(3)}";
        }

        internal static RedisChannel ConstructChannelName(string providerChannel, Guid clientId, string identifier)
        {
            return new RedisChannel($"{providerChannel}/{clientId}/{identifier}", RedisChannel.PatternMode.Literal);
        }

        internal static Guid ComputeIdentifier(string identifier)
        {
            using (var md5 = MD5.Create())
            {
                return ComputeIdentifier(md5, identifier);
            }
        }

        internal static Guid ComputeIdentifier(MD5 md5, string identifier)
        {
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(identifier));

            return new Guid(hash);
        }

        /// <summary>
        /// Parses an HTTP-date formatted expiration string (RFC1123 format) into a UTC <see cref="DateTime"/>.
        /// </summary>
        /// <param name="expires">The expiration time as a string in RFC1123 ("R") format.</param>
        /// <returns>A <see cref="DateTime"/> object representing the expiration time in UTC.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        public static DateTime GetExpiryTime(string expires)
        {
            return DateTime.ParseExact(expires, "R", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
        }

        /// <summary>
        /// Parses an HTTP-date formatted expiration string (RFC1123 format) into a UTC <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="expires">Expiry time in RFC1123 format e.g. "Thu, 26 Jun 2025 14:14:56 GMT".</param>
        /// <returns>A <see cref="DateTimeOffset"/> object representing the expiration time in UTC.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        public static DateTimeOffset GetExpiryTimeOffset(string expires)
        {
            return DateTimeOffset.ParseExact(expires, "R", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
        }

        internal static IEnumerable<Type> GetTypesFromAssemblies()
        {
            var entryAssembly = Assembly.GetEntryAssembly();

            var referencedAssemblies = entryAssembly.GetReferencedAssemblies();

            return referencedAssemblies
                .SelectMany(assemblyName => Assembly.Load(assemblyName).GetTypes())
                .Concat(entryAssembly.GetTypes());
        }

        private const string Chars = "abcdefghijklmnopqrstuvwxyz";

        private static string GenerateRandomCharacters(int length)
        {
            var randomBytes = new byte[length];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return string.Join(string.Empty,
                Enumerable.Range(0, length).Select(i => Chars[randomBytes[i] % Chars.Length]));
        }
    }
}