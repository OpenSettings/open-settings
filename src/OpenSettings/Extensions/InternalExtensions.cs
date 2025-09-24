using Microsoft.EntityFrameworkCore;
using Ogu.Compressions.Abstractions;
using Ogu.Extensions.Hosting.HostedServices;
using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ClientInfo = OpenSettings.Models.ClientInfo;

namespace OpenSettings.Extensions
{
    internal static class InternalExtensions
    {
#if !NET6_0_OR_GREATER
        /// <summary>
        /// Returns distinct elements from a sequence based on a specified key selector.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the source sequence.</typeparam>
        /// <typeparam name="TKey">The type of the key used for distinct comparisons.</typeparam>
        /// <param name="source">The sequence to remove duplicates from.</param>
        /// <param name="keySelector">A function that extracts the key for each element.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing distinct elements from the source sequence.
        /// </returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();

            foreach (var element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
#endif

        internal static ITaskQueue GetNotificationQueue(this ITaskQueueFactory taskQueueFactory)
        {
            return taskQueueFactory.Get(OpenSettingsDefaults.TaskQueues.Notification);
        }

        internal static ITaskQueue GetDataChangeQueue(this ITaskQueueFactory taskQueueFactory)
        {
            return taskQueueFactory.Get(OpenSettingsDefaults.TaskQueues.DataChange);
        }

        internal static HttpClient CreateOpenSettingsProviderHttpClient(this IHttpClientFactory httpClientFactory)
        {
            return httpClientFactory.CreateClient(OpenSettingsDefaults.Names.ProviderHttpClientName);
        }

        internal static Task<T[]> ToPaginatedArrayAsync<T>(this IQueryable<T> entities, int pageIndex, int pageSize,
            CancellationToken cancellationToken)
        {
            return entities.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToArrayAsync(cancellationToken);
        }

        internal static AuthenticationHeaderValue CreateBasicAuthenticationHeaderValue(this ClientInfo clientInfo)
        {
            return new AuthenticationHeaderValue(OpenSettingsDefaults.Names.BasicSchemeName, Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientInfo.Id}:{clientInfo.Secret}")));
        }

        internal static async Task<string> DecompressToUtf8StringAsync(this ICompressionProvider compressionProvider, byte[] data, CompressionType compressionType, CancellationToken cancellationToken = default)
        {
            return Encoding.UTF8.GetString(await compressionProvider.DecompressAsync(compressionType, data, cancellationToken));
        }

        internal static async Task<T> DecompressJsonDataAsync<T>(this ICompressionProvider compressionProvider, CompressionType compressionType, byte[] data, CancellationToken cancellationToken = default)
        {
            using (var decompressedData = await compressionProvider.DecompressToStreamAsync(compressionType, data, cancellationToken))
            {
                return JsonSerializer.Deserialize<T>(decompressedData);
            }
        }

        internal static RedisMessage ToRedisMessage(this RedisValue redisValue)
        {
            return JsonSerializer.Deserialize<RedisMessage>(redisValue.ToString());
        }

        /// <summary>
        /// Converts the given string into a URL-friendly slug by trimming, 
        /// converting to lowercase, and replacing spaces or special characters with hyphens.
        /// </summary>
        /// <param name="value">The input string to convert.</param>
        /// <returns>A slug version of the input string.</returns>
        public static string ToSlug(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            value = PascalCaseRegex.Replace(value, OpenSettingsDefaults.Format.SlugReplacement);

            value = value
                .ToLowerInvariant()
                .Replace(OpenSettingsDefaults.Format.Space, OpenSettingsDefaults.Format.Hyphen);

            value = InvalidCharactersRegex.Replace(value, OpenSettingsDefaults.Format.Hyphen);

            value = MultipleDashesRegex.Replace(value, OpenSettingsDefaults.Format.Hyphen);

            value = value.Trim(OpenSettingsDefaults.Format.HyphenChar);

            return value;
        }

        private static readonly Regex PascalCaseRegex = new Regex("([a-z])([A-Z])", RegexOptions.Compiled);

        private static readonly Regex InvalidCharactersRegex = new Regex(@"[^a-z0-9\-_]", RegexOptions.Compiled);

        private static readonly Regex MultipleDashesRegex = new Regex("-{2,}", RegexOptions.Compiled);

       

        public static async Task<IResponse<TData>> ToResponseAsync<TData>(this DbUpdateConcurrencyException exception, CancellationToken cancellationToken = default)
        {
            var concurrencyConflict = await GetConcurrencyConflictAsync(exception, cancellationToken);

            var jsonResponse = HttpStatusCode.Conflict.ToFailureResponse<TData>("Concurrency Conflict", "The data has been modified or row version didn't match.");

            jsonResponse.Extras["Conflicts"] = concurrencyConflict;

            return jsonResponse;
        }

        public static async Task<IResponse> ToResponseAsync(this DbUpdateConcurrencyException exception, CancellationToken cancellationToken = default)
        {
            var concurrencyConflict = await GetConcurrencyConflictAsync(exception, cancellationToken);

            var jsonResponse = HttpStatusCode.Conflict.ToFailureResponse("Concurrency Conflict", "The data has been modified or row version didn't match.");

            jsonResponse.Extras["Conflicts"] = concurrencyConflict;

            return jsonResponse;
        }

        public static async Task<ConcurrencyConflict> GetConcurrencyConflictAsync(this DbUpdateConcurrencyException exception, CancellationToken cancellationToken)
        {
            var concurrencyConflict = new ConcurrencyConflict();

            foreach (var entry in exception.Entries)
            {
                var currentValues = await entry.GetDatabaseValuesAsync(cancellationToken);
                var proposedValues = entry.CurrentValues;

                var id = proposedValues["Id"]?.ToString();

                if (id == null)
                {
                    continue;
                }

                if (currentValues == null)
                {
                    concurrencyConflict[id] = new ConcurrencyConflictInfo { Deleted = true };
                    continue;
                }

                var updatedConflict = new Dictionary<string, ConcurrencyConflictValue>();

                foreach (var property in currentValues.Properties)
                {
                    if (!entry.Property(property.Name).IsModified)
                    {
                        continue;
                    }

                    var proposed = proposedValues[property.Name];
                    var current = currentValues[property.Name];

                    if (!Equals(proposed, current))
                    {
                        updatedConflict[property.Name] = new ConcurrencyConflictValue(current, proposed);
                    }
                }

                if (updatedConflict.Count != 0)
                {
                    concurrencyConflict[id] = new ConcurrencyConflictInfo { Properties = updatedConflict };
                }
            }

            return concurrencyConflict;
        }

        public static ValidationRule ValidJsonRule(string propertyName, string attemptedValue, bool storeParsedValue)
        {
            return new ValidationRule(() => ValidationFailures.InvalidJsonFormat(propertyName, attemptedValue), delegate (IValidationStore v)
            {
                try
                {
                    var value = JsonDocument.Parse(attemptedValue);

                    if (storeParsedValue)
                    {
                        v.Store(value);
                    }
                    else
                    {
                        value.Dispose();
                    }

                    return true;
                }
                catch (JsonException)
                {
                    return false;
                }
            });
        }
    }
}