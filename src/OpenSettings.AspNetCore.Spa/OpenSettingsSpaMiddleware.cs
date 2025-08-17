using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Services.Interfaces;
#if NETSTANDARD2_0 || NETSTANDARD2_1
using IWebHostEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
#else
using Microsoft.AspNetCore.Hosting;
#endif

namespace OpenSettings.AspNetCore.Spa
{
    /// <summary>
    /// Middleware responsible for serving static files for the Open Settings Spa.
    /// </summary>
    public class OpenSettingsSpaMiddleware
    {
        private const string IndexHtml = "index.html";

        private readonly Assembly _currentAssembly = typeof(OpenSettingsSpaMiddleware).GetTypeInfo().Assembly;
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly StaticFileMiddleware _staticFileMiddleware;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        private readonly string _routePrefixPattern;
        private readonly string _routePrefixWithIndexHtmlPattern;

        private readonly Dictionary<string, string> _indexArguments;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenSettingsSpaMiddleware"/> class.
        /// </summary>
        /// <param name="openSettingsMemoryCache">In-memory cache for Open Settings.</param>
        /// <param name="hostingEnv">Web hosting environment.</param>
        /// <param name="loggerFactory">Factory for creating loggers.</param>
        /// <param name="requestDelegate">The request delegate.</param>
        /// <param name="openSettingsConfiguration">Configuration for Open Settings.</param>
        /// <param name="providerInfo">Provider information.</param>
        public OpenSettingsSpaMiddleware(
            IOpenSettingsMemoryCache openSettingsMemoryCache,
            IWebHostEnvironment hostingEnv,
            ILoggerFactory loggerFactory,
            RequestDelegate requestDelegate,
            OpenSettingsConfiguration openSettingsConfiguration,
            ProviderInfo providerInfo)
        {
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _openSettingsConfiguration = openSettingsConfiguration;

            if (openSettingsConfiguration.Spa.IndexStream == null)
            {
                openSettingsConfiguration.Spa.IndexStream = () => _currentAssembly.GetManifestResourceStream(OpenSettingsDefaults.Spa.EmbeddedIndexHtmlFileNamespace);
            }

            _routePrefixPattern = string.IsNullOrWhiteSpace(openSettingsConfiguration.Spa.RoutePrefix)
                ? "^/$"
                : $"^/{Regex.Escape(openSettingsConfiguration.Spa.RoutePrefix)}/?$";

            _routePrefixWithIndexHtmlPattern = string.IsNullOrWhiteSpace(openSettingsConfiguration.Spa.RoutePrefix)
                ? $"^/{IndexHtml}$"
                : $"^/{Regex.Escape(openSettingsConfiguration.Spa.RoutePrefix)}/{IndexHtml}$";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            };

            var cloneController = new
            {
                Route = $"/{openSettingsConfiguration.Controller.Route}",
                openSettingsConfiguration.Controller.AllowFromExploring,
                openSettingsConfiguration.Controller.RequiresAuthentication,
                openSettingsConfiguration.Controller.OAuth2
            };

            var cloneProviderInfo = new
            {
                providerInfo.RequiresAuthentication ,
                Client = new
                {
                    providerInfo.Client.Id,
                    providerInfo.Client.Name,
                    providerInfo.Client.Version
                },
                PackInfo = new
                {
                    providerInfo.PackInfo.Version,
                    providerInfo.PackInfo.Score,
                    providerInfo.PackInfo.IsPreview,
                },
                OAuth2 = new
                {
                    providerInfo.OAuth2.Authority,
                    providerInfo.OAuth2.AllowOfflineAccess,
                    providerInfo.OAuth2.IsActive
                },
                Redis = new
                {
                    providerInfo.Redis.Channel,
                    providerInfo.Redis.Configuration,
                    providerInfo.Redis.IsActive
                }
            };

            var cloneClient = new
            {
                openSettingsConfiguration.Client.Id,
                openSettingsConfiguration.Client.Name,
                openSettingsConfiguration.Client.Version,
            };

            var openSettingsAssemblyInfo = OpenSettingsAssemblyInfo.Instance;

            _indexArguments = new Dictionary<string, string>(9)
            {
                { IndexArguments.Controller, JsonSerializer.Serialize(cloneController, _jsonSerializerOptions) },
                { IndexArguments.ProviderInfo, JsonSerializer.Serialize(cloneProviderInfo, _jsonSerializerOptions) },
                { IndexArguments.PackInfo, JsonSerializer.Serialize(openSettingsAssemblyInfo.PackInfo, _jsonSerializerOptions) },
                { IndexArguments.Client, JsonSerializer.Serialize(cloneClient, _jsonSerializerOptions) },
                { IndexArguments.DocumentTitle, openSettingsConfiguration.Spa.DocumentTitle },
                { IndexArguments.ServiceType, $"{openSettingsConfiguration.Selection}" },
                { IndexArguments.DataAccessType, openSettingsConfiguration.IsConsumerSelected ? string.Empty : $"{openSettingsConfiguration.Provider.Selection}" },
                { IndexArguments.DbProviderName, openSettingsConfiguration.IsProviderSelected && openSettingsConfiguration.Provider.IsOrmSelected ? $"{openSettingsConfiguration.Provider.Orm.DbProviderName}" : string.Empty }
            };

            _staticFileMiddleware = requestDelegate.CreateStaticFileMiddleware(hostingEnv, loggerFactory, openSettingsConfiguration.Spa.RoutePrefix, OpenSettingsDefaults.Spa.EmbeddedFileNamespace, typeof(OpenSettingsSpaMiddleware));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var httpMethod = httpContext.Request.Method;
            var path = httpContext.Request.Path.Value;

            switch (httpMethod)
            {
                case "GET" when Regex.IsMatch(path, _routePrefixPattern, RegexOptions.IgnoreCase):

                    var relativeIndexUrl = string.IsNullOrEmpty(path) || path.EndsWith(OpenSettingsDefaults.Format.Hyphen)
                        ? IndexHtml
                        : CalculateRedirectSpaRoute(path, _openSettingsConfiguration.Spa.RoutePrefix);
                    httpContext.Response.RespondWithRedirect(relativeIndexUrl);
                    return;

                case "GET" when Regex.IsMatch(path, _routePrefixWithIndexHtmlPattern, RegexOptions.IgnoreCase):

                    var text = await OpenSettingsDefaults.Caches.OpenSettingsSpaMiddlewareHtmlCacheEntryKey.GetOrCreateAsync(_openSettingsMemoryCache, c =>
                    {
                        _indexArguments[IndexArguments.License] = JsonSerializer.Serialize(LicenseProvider.Instance.License, _jsonSerializerOptions);

                        return BuildHtmlAsync(_openSettingsConfiguration.Spa.IndexStream, _indexArguments);
                    }).ConfigureAwait(false);

                    await httpContext.Response.RespondWithIndexHtmlAsync(text).ConfigureAwait(false);
                    return;

                default:
                    await _staticFileMiddleware.Invoke(httpContext);
                    break;
            }
        }

        private static async Task<string> BuildHtmlAsync(Func<Stream> funcStream, IEnumerable<KeyValuePair<string, string>> indexArguments)
        {
            using (var stream = funcStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var htmlBuilder = new StringBuilder(await reader.ReadToEndAsync().ConfigureAwait(false));

                    foreach (var entry in indexArguments)
                    {
                        htmlBuilder.Replace(entry.Key, entry.Value);
                    }

                    return htmlBuilder.ToString();
                }
            }
        }

        private static string CalculateRedirectSpaRoute(string requestPath, string spaRoutePrefix)
        {
            var index = requestPath.IndexOf(spaRoutePrefix, StringComparison.InvariantCultureIgnoreCase);

            return requestPath.EndsWith(OpenSettingsDefaults.Format.Slash) ? IndexHtml : $"{requestPath.Substring(index)}/{IndexHtml}";
        }

        private static class IndexArguments
        {
            public const string Controller = "%(Controller)";
            public const string ProviderInfo = "%(ProviderInfo)";
            public const string PackInfo = "%(PackInfo)";
            public const string Client = "%(Client)";
            public const string DocumentTitle = "%(DocumentTitle)";
            public const string ServiceType = "%(ServiceType)";
            public const string DataAccessType = "%(DataAccessType)";
            public const string DbProviderName = "%(DbProviderName)";
            public const string License = "%(License)";
        }
    }
}