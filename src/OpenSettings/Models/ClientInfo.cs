using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;

namespace OpenSettings.Models
{
    /// <summary>
    /// Represents information about a client, including its name, id, secret key, and version.
    /// </summary>
    public class ClientInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientInfo"/> class with specified values or defaults.
        /// </summary>
        /// <param name="id">The unique identifier for the client. A new Guid will be generated if not provided. Value cannot be empty guid.</param>
        /// <param name="secret">The secret key for the client. A new Guid will be generated if not provided. Value cannot be empty guid.</param>
        /// <param name="name">The name of the client.</param>
        /// <param name="version">The version of the client application. Defaults to the version of the entry assembly if not provided.</param>
        [JsonConstructor]
        public ClientInfo(Guid? id = null, Guid? secret = null, string name = null, string version = null)
        {
            var assemblyName = Assembly.GetEntryAssembly()?.GetName();

            Name = string.IsNullOrWhiteSpace(name) ? GetClientName(assemblyName) : name;
            Id = id == Guid.Empty ? Guid.NewGuid() : id ?? Guid.NewGuid();
            Secret = secret == Guid.Empty ? Guid.NewGuid() : secret ?? Guid.NewGuid();
            Version = version ?? GetVersion(assemblyName);
        }

        /// <summary>
        /// Gets or sets the name of the client.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the unique identifier for the client.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets or sets the secret key for the client.
        /// </summary>
        public Guid Secret { get; }

        /// <summary>
        /// Gets the version information without the '<c>v</c>' prefix. 
        /// e.g. '<c>1.0.0</c>'.
        /// </summary>
        [JsonIgnore]
        public string Version { get; }

        private static string GetClientName(AssemblyName entryAssembly)
        {
            return entryAssembly?.Name ??
                   Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);
        }

        private static string GetVersion(AssemblyName entryAssembly)
        {
            return entryAssembly?.Version.ToVersion() ?? Constants.DefaultVersion;
        }
    }
}