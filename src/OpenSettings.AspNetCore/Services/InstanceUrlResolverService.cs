using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using OpenSettings.AspNetCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace OpenSettings.AspNetCore.Services
{
    internal sealed class InstanceUrlResolverService : IInstanceUrlResolverService
    {
        private const int FallbackPort = 5000;

        private readonly IServerAddressesFeature _serverAddressesFeature;

        public InstanceUrlResolverService(IServer server)
        {
            _serverAddressesFeature = server.Features.Get<IServerAddressesFeature>();
        }

        public string[] ResolveUrls()
        {
            var urls = new List<string>();

            var envHost = Environment.GetEnvironmentVariable("SERVICE_HOST")
                          ?? Environment.GetEnvironmentVariable("POD_IP");

            if (!string.IsNullOrWhiteSpace(envHost))
            {
                urls.Add($"http://{envHost}:{FallbackPort}");
            }

            var localIps = Dns.GetHostEntry(Dns.GetHostName())
                .AddressList
                .Where(ip => ip.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(ip))
                .ToArray();

            foreach (var address in _serverAddressesFeature.Addresses)
            {
                var uri = new Uri(address);

                if (uri.Host is "0.0.0.0" || uri.Host is "localhost" || uri.Host is "::")
                {
                    //urls.Add($"{uri.Scheme}://127.0.0.1:{uri.Port}");
                    urls.AddRange(localIps.Select(ip => $"{uri.Scheme}://{ip}:{uri.Port}"));
                }
                else
                {
                    urls.Add($"{uri.Scheme}://{uri.Host}:{uri.Port}");
                }
            }

            if (urls.Count == 0 && localIps.Length > 0)
            {
                var fallbackIp = localIps.First();
                urls.Add($"http://{fallbackIp}:{FallbackPort}");
            }

            return urls.Distinct().ToArray();
        }
    }
}