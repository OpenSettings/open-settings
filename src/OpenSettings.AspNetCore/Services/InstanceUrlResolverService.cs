using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using OpenSettings.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace OpenSettings.AspNetCore.Services
{
    /// <summary>
    /// Provides functionality to resolve the Urls for the current instance of the application.
    /// </summary>
    internal sealed class InstanceUrlResolverService : IInstanceUrlResolverService
    {
        private const string FallbackPort = "5000";

        private readonly IServerAddressesFeature _serverAddressesFeature;

        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceUrlResolverService"/> class.
        /// </summary>
        /// <param name="server">The server.</param>
        public InstanceUrlResolverService(IServer server)
        {
            _serverAddressesFeature = server.Features.Get<IServerAddressesFeature>();
        }

        public string[] ResolveUrls()
        {
            var urls = new List<string>();
            
            var enableK8sDns = Environment.GetEnvironmentVariable("ENABLE_K8S_DNS")?.ToLowerInvariant() == "true";

            var serviceName = Environment.GetEnvironmentVariable("SERVICE_NAME");
            var namespaceName = Environment.GetEnvironmentVariable("POD_NAMESPACE") ?? "default";

            var envPort = Environment.GetEnvironmentVariable("SERVICE_PORT") ??
                          Environment.GetEnvironmentVariable("POD_PORT") ?? "80";

            var envHost = Environment.GetEnvironmentVariable("SERVICE_HOST")
                          ?? Environment.GetEnvironmentVariable("POD_IP");

            var localIps = Dns.GetHostEntry(Dns.GetHostName())
                .AddressList
                .Where(ip => ip.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(ip))
                .ToArray();

            var hasHttp = false;
            var hasHttps = false;

            foreach (var address in _serverAddressesFeature.Addresses)
            {
                var uri = new Uri(address);

                if (string.Equals(uri.Scheme, OpenSettingsDefaults.Names.Http, StringComparison.OrdinalIgnoreCase))
                {
                    hasHttp = true;
                }

                if (string.Equals(uri.Scheme, OpenSettingsDefaults.Names.Https, StringComparison.OrdinalIgnoreCase))
                {
                    hasHttps = true;
                }

                if (uri.Host is "0.0.0.0" || uri.Host is "localhost" || uri.Host is "::")
                {
                    urls.AddRange(localIps.Select(ip => $"{uri.Scheme}://{ip}:{uri.Port}"));
                }
                else
                {
                    urls.Add($"{uri.Scheme}://{uri.Host}:{uri.Port}");
                }
            }

            if (urls.Count == 0 && localIps.Length > 0)
            {
                urls.Add($"http://{localIps.First()}:{FallbackPort}");
            }

            if (hasHttp)
            {
                if (!string.IsNullOrWhiteSpace(envHost))
                {
                    urls.Insert(0, $"http://{envHost}:{envPort}");
                }

                if (enableK8sDns && !string.IsNullOrWhiteSpace(serviceName))
                {
                    urls.Insert(0, $"http://{serviceName}.{namespaceName}.svc.cluster.local:{envPort}");
                }
            }

            if (hasHttps)
            {
                if (!string.IsNullOrWhiteSpace(envHost))
                {
                    urls.Insert(0, $"https://{envHost}:{envPort}");
                }

                if (enableK8sDns && !string.IsNullOrWhiteSpace(serviceName))
                {
                    urls.Insert(0, $"https://{serviceName}.{namespaceName}.svc.cluster.local:{envPort}");
                }
            }

            return urls.Distinct().ToArray();
        }
    }
}