﻿using OpenSettings.Models;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Helpers
{
    /// <summary>
    /// Provides helper methods for JSON manipulation, including options for reading and writing JSON documents and merging JSON objects.
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Gets the default options for parsing a JSON document, which allows trailing commas and skips comments.
        /// </summary>
        public static JsonDocumentOptions DefaultJsonDocumentOptions { get; } = new JsonDocumentOptions
        {
            AllowTrailingCommas = true,
            CommentHandling = JsonCommentHandling.Skip
        };

        /// <summary>
        /// Gets the default options for writing a JSON document, which does not indent and uses relaxed escaping.
        /// </summary>
        public static JsonWriterOptions DefaultJsonWriterOptions { get; } = new JsonWriterOptions
        {
            Indented = false,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        /// <summary>
        /// Gets the default options for serializing JSON, which allows trailing commas, uses relaxed escaping, and skips comments.
        /// </summary>
        public static JsonSerializerOptions DefaultJsonSerializerOptions { get; } = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            ReadCommentHandling = JsonCommentHandling.Skip
        };

        /// <summary>
        /// Reads a JSON file asynchronously and returns it as a dictionary.
        /// </summary>
        /// <param name="filePath">The file path of the JSON file to read.</param>
        /// <param name="cancellationToken">A cancellation token to support cancellation of the operation.</param>
        /// <returns>A <see cref="Task"/> containing a <b>Dictionary&lt;string, object&gt;</b> with the JSON data.</returns>
        public static async Task<Dictionary<string, object>> GetJsonFileAsync(string filePath, CancellationToken cancellationToken = default)
        {
            using (var jsonStream = File.OpenRead(filePath))
            {
                return await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(jsonStream,
                    DefaultJsonSerializerOptions, cancellationToken);
            }
        }

        /// <summary>
        /// Merges two JSON files asynchronously by reading their contents from the specified file paths.
        /// </summary>
        /// <param name="baseFilePath">The file path of the base JSON file.</param>
        /// <param name="patchFilePath">The file path of the patch JSON file to apply.</param>
        /// <param name="cancellationToken">A cancellation token to support cancellation of the operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation, with the result as a <see cref="JsonMergeResult"/>.</returns>
        public static async Task<JsonMergeResult> MergeFileAsync(string baseFilePath, string patchFilePath, CancellationToken cancellationToken = default)
        {
            var jsonMergeResult = new JsonMergeResult();

#if !NETSTANDARD2_0
            var output = new ArrayBufferWriter<byte>();
#endif
            using (var firstStream = File.OpenRead(baseFilePath))
            using (var secondStream = File.OpenRead(patchFilePath))
            using (var firstDoc = JsonDocument.ParseAsync(firstStream, DefaultJsonDocumentOptions, cancellationToken))
            using (var secondDoc = JsonDocument.ParseAsync(secondStream, DefaultJsonDocumentOptions, cancellationToken))
#if NETSTANDARD2_0
            using (var output = new MemoryStream())
            using (var jsonWriter = new Utf8JsonWriter(output, DefaultJsonWriterOptions))
#else
            await using (var jsonWriter = new Utf8JsonWriter(output, DefaultJsonWriterOptions))
#endif
            {
                await Task.WhenAll(firstDoc, secondDoc);

                var firstRoot = firstDoc.Result.RootElement;
                var secondRoot = secondDoc.Result.RootElement;

                if (firstRoot.ValueKind != JsonValueKind.Array && firstRoot.ValueKind != JsonValueKind.Object)
                {
                    jsonMergeResult.IsFaulted = true;
                    jsonMergeResult.FailureReason = $"Warning: the base file path content is neither an Array nor an Object, but a {firstRoot.ValueKind}. Merging will proceed with the patch file, but the result may not be as expected!.";
                    jsonMergeResult.Data = secondRoot.Deserialize<Dictionary<string, object>>(DefaultJsonSerializerOptions);

                    return jsonMergeResult;
                }

                if (firstRoot.ValueKind != secondRoot.ValueKind)
                {
                    jsonMergeResult.IsFaulted = true;
                    jsonMergeResult.FailureReason = $"ValueKind mismatch: the base file has a {firstRoot.ValueKind} and the patch file has a {secondRoot.ValueKind}. Merging will proceed with the patch file, but the result may not be as expected!.";
                    jsonMergeResult.Data = secondRoot.Deserialize<Dictionary<string, object>>(DefaultJsonSerializerOptions);

                    return jsonMergeResult;
                }

                if (firstRoot.ValueKind == JsonValueKind.Array)
                {
                    MergeArrays(jsonWriter, secondRoot);
                }
                else
                {
                    MergeObjects(jsonWriter, firstRoot, secondRoot);
                }

#if NETSTANDARD2_0

                await jsonWriter.FlushAsync(cancellationToken);

                jsonMergeResult.Data = JsonSerializer.Deserialize<Dictionary<string, object>>(output.ToArray());
            }
#else
            }
            jsonMergeResult.Data = JsonSerializer.Deserialize<Dictionary<string, object>>(output.WrittenSpan);
#endif
            return jsonMergeResult;
        }

        /// <summary>
        /// Merges two JSON strings (baseJson and patchJson) into a single JSON object.
        /// </summary>
        /// <param name="baseJson">The base JSON string to be merged with the patch.</param>
        /// <param name="patchJson">The JSON string containing the changes to be applied to the base JSON.</param>
        /// <returns>A <see cref="JsonMergeResult"/> containing the result of the merge operation.</returns>
        public static JsonMergeResult Merge(string baseJson, string patchJson)
        {
            var jsonMergeResult = new JsonMergeResult();

#if !NETSTANDARD2_0
            var output = new ArrayBufferWriter<byte>();
#endif
            using (var firstDoc = JsonDocument.Parse(baseJson, DefaultJsonDocumentOptions))
            using (var secondDoc = JsonDocument.Parse(patchJson, DefaultJsonDocumentOptions))
#if NETSTANDARD2_0
            using (var output = new MemoryStream())
            using (var jsonWriter = new Utf8JsonWriter(output, DefaultJsonWriterOptions))
#else
            using (var jsonWriter = new Utf8JsonWriter(output, DefaultJsonWriterOptions))
#endif
            {
                var firstRoot = firstDoc.RootElement;
                var secondRoot = secondDoc.RootElement;

                if (firstRoot.ValueKind != JsonValueKind.Array && firstRoot.ValueKind != JsonValueKind.Object)
                {
                    jsonMergeResult.IsFaulted = true;
                    jsonMergeResult.FailureReason = $"Warning: the base file path content is neither an Array nor an Object, but a {firstRoot.ValueKind}. Merging will proceed with the patch file, but the result may not be as expected!.";
                    jsonMergeResult.Data = JsonSerializer.Deserialize<Dictionary<string, object>>(patchJson);

                    return jsonMergeResult;
                }

                if (firstRoot.ValueKind != secondRoot.ValueKind)
                {
                    jsonMergeResult.IsFaulted = true;
                    jsonMergeResult.FailureReason = $"ValueKind mismatch: the base file has a {firstRoot.ValueKind} and the patch file has a {secondRoot.ValueKind}. Merging will proceed with the patch file, but the result may not be as expected!.";
                    jsonMergeResult.Data = JsonSerializer.Deserialize<Dictionary<string, object>>(patchJson);

                    return jsonMergeResult;
                }

                if (firstRoot.ValueKind == JsonValueKind.Array)
                {
                    MergeArrays(jsonWriter, secondRoot);
                }
                else
                {
                    MergeObjects(jsonWriter, firstRoot, secondRoot);
                }

#if NETSTANDARD2_0

                jsonWriter.Flush();

                jsonMergeResult.Data = JsonSerializer.Deserialize<Dictionary<string, object>>(output.ToArray());
            }
#else
            }

            jsonMergeResult.Data = JsonSerializer.Deserialize<Dictionary<string, object>>(output.WrittenSpan);
#endif

            return jsonMergeResult;
        }

        private static void MergeObjects(Utf8JsonWriter jsonWriter, JsonElement root1, JsonElement root2)
        {
            jsonWriter.WriteStartObject();

            foreach (var property in root1.EnumerateObject())
            {
                var propertyName = property.Name;

                JsonValueKind newValueKind;

                if (root2.TryGetProperty(propertyName, out var newValue) && (newValueKind = newValue.ValueKind) != JsonValueKind.Null)
                {
                    jsonWriter.WritePropertyName(propertyName);

                    var originalValue = property.Value;
                    var originalValueKind = originalValue.ValueKind;

                    switch (newValueKind)
                    {
                        case JsonValueKind.Object when originalValueKind == JsonValueKind.Object:

                            MergeObjects(jsonWriter, originalValue, newValue);

                            break;

                        case JsonValueKind.Array when originalValueKind == JsonValueKind.Array:

                            MergeArrays(jsonWriter, newValue);

                            break;

                        default:

                            newValue.WriteTo(jsonWriter);

                            break;
                    }
                }
                else
                {
                    property.WriteTo(jsonWriter);
                }
            }

            foreach (var property in root2.EnumerateObject().Where(property => !root1.TryGetProperty(property.Name, out _)))
            {
                property.WriteTo(jsonWriter);
            }

            jsonWriter.WriteEndObject();
        }

        private static void MergeArrays(Utf8JsonWriter jsonWriter, JsonElement root2)
        {
            jsonWriter.WriteStartArray();

            foreach (var element in root2.EnumerateArray())
            {
                element.WriteTo(jsonWriter);
            }

            jsonWriter.WriteEndArray();
        }
    }
}