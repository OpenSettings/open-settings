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
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILoggerFactory _loggerFactory;
        private readonly RequestDelegate _requestDelegate;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly ProviderInfo _providerInfo;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenSettingsSpaMiddleware"/> class.
        /// </summary>
        /// <param name="openSettingsMemoryCache">In-memory cache for Open Settings.</param>
        /// <param name="hostingEnvironment">Web hosting environment.</param>
        /// <param name="loggerFactory">Factory for creating loggers.</param>
        /// <param name="requestDelegate">The request delegate.</param>
        /// <param name="openSettingsConfiguration">Configuration for Open Settings.</param>
        /// <param name="providerInfo">Provider information.</param>
        public OpenSettingsSpaMiddleware(
            IOpenSettingsMemoryCache openSettingsMemoryCache,
            IWebHostEnvironment hostingEnvironment,
            ILoggerFactory loggerFactory,
            RequestDelegate requestDelegate,
            OpenSettingsConfiguration openSettingsConfiguration,
            ProviderInfo providerInfo)
        {
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _hostingEnvironment = hostingEnvironment;
            _loggerFactory = loggerFactory;
            _requestDelegate = requestDelegate;
            _openSettingsConfiguration = openSettingsConfiguration;
            _providerInfo = providerInfo;

            if (openSettingsConfiguration.Spa.IndexStream == null)
            {
                openSettingsConfiguration.Spa.IndexStream = () => _currentAssembly.GetManifestResourceStream(OpenSettingsDefaults.Spa.EmbeddedIndexHtmlFileNamespace);
            }

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            };
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var httpMethod = httpContext.Request.Method;
            var path = httpContext.Request.Path.Value;

            var routePrefixes =
                OpenSettingsDefaults.Caches.OpenSettingsSpaMiddlewareCacheEntryRoutePrefixesKey.GetOrCreate(
                    _openSettingsMemoryCache,
                    c =>
                    {
                        return new
                        {
                            RoutePrefixPattern = string.IsNullOrWhiteSpace(_openSettingsConfiguration.Spa.RoutePrefix)
                                ? "^/$"
                                : $"^/{Regex.Escape(_openSettingsConfiguration.Spa.RoutePrefix)}/?$",
                            RoutePrefixWithINdexHtmlPattern =
                                string.IsNullOrWhiteSpace(_openSettingsConfiguration.Spa.RoutePrefix)
                                    ? $"^/{IndexHtml}$"
                                    : $"^/{Regex.Escape(_openSettingsConfiguration.Spa.RoutePrefix)}/{IndexHtml}$"
                        };
                    });

            switch (httpMethod)
            {
                case "GET" when Regex.IsMatch(path, routePrefixes.RoutePrefixPattern, RegexOptions.IgnoreCase):

                    var relativeIndexUrl = string.IsNullOrEmpty(path) || path.EndsWith(OpenSettingsDefaults.Format.Hyphen)
                        ? IndexHtml
                        : CalculateRedirectSpaRoute(path, _openSettingsConfiguration.Spa.RoutePrefix);
                    httpContext.Response.RespondWithRedirect(relativeIndexUrl);
                    return;

                case "GET" when Regex.IsMatch(path, routePrefixes.RoutePrefixWithINdexHtmlPattern, RegexOptions.IgnoreCase):

                    var text = await OpenSettingsDefaults.Caches.OpenSettingsSpaMiddlewareCacheEntryHtmlKey.GetOrCreateAsync(_openSettingsMemoryCache, c =>
                    {
                        var indexArguments = BuildIndexArguments();

                        return BuildHtmlAsync(_openSettingsConfiguration.Spa.IndexStream, indexArguments);
                    }).ConfigureAwait(false);

                    await httpContext.Response.RespondWithIndexHtmlAsync(text).ConfigureAwait(false);
                    return;

                default:

                    var staticMiddleware =
                        OpenSettingsDefaults.Caches.OpenSettingsSpaMiddlewareCacheEntryStaticMiddlewareKey.GetOrCreate(
                            _openSettingsMemoryCache,
                            c => _requestDelegate.CreateStaticFileMiddleware(_hostingEnvironment, _loggerFactory,
                                _openSettingsConfiguration.Spa.RoutePrefix,
                                OpenSettingsDefaults.Spa.EmbeddedFileNamespace, typeof(OpenSettingsSpaMiddleware)));

                    await staticMiddleware.Invoke(httpContext);
                    break;
            }
        }

        private Dictionary<string, string> BuildIndexArguments()
        {
            var indexArguments = new Dictionary<string, string>(9)
            {
                [IndexArguments.Controller] = JsonSerializer.Serialize(GetControllerClone(), _jsonSerializerOptions),
                [IndexArguments.ProviderInfo] = JsonSerializer.Serialize(GetProviderInfoClone(), _jsonSerializerOptions),
                [IndexArguments.PackInfo] = JsonSerializer.Serialize(OpenSettingsAssemblyInfo.Instance.PackInfo, _jsonSerializerOptions),
                [IndexArguments.Client] = JsonSerializer.Serialize(GetClientClone(), _jsonSerializerOptions),
                [IndexArguments.License] = JsonSerializer.Serialize(LicenseProvider.Instance.License, _jsonSerializerOptions),
                [IndexArguments.DocumentTitle] = _openSettingsConfiguration.Spa.DocumentTitle
            };

            if (!indexArguments.ContainsKey(IndexArguments.ServiceType))
            {
                indexArguments[IndexArguments.ServiceType] = $"{_openSettingsConfiguration.Selection}";
            }

            if (!indexArguments.ContainsKey(IndexArguments.DataAccessType))
            {
                indexArguments[IndexArguments.DataAccessType] = _openSettingsConfiguration.IsConsumerSelected ? string.Empty : $"{_openSettingsConfiguration.Provider.Selection}";
            }

            if (!indexArguments.ContainsKey(IndexArguments.DbProviderName))
            {
                indexArguments[IndexArguments.DbProviderName] = _openSettingsConfiguration.IsProviderSelected && _openSettingsConfiguration.Provider.IsOrmSelected ? $"{_openSettingsConfiguration.Provider.Orm.DbProviderName}" : string.Empty;
            }

            return indexArguments;

            object GetControllerClone()
            {
                return new
                {
                    Route = $"/{_openSettingsConfiguration.Controller.Route}",
                    _openSettingsConfiguration.Controller.AllowFromExploring,
                    _openSettingsConfiguration.Controller.RequiresAuthentication,
                    _openSettingsConfiguration.Controller.OpenIdConnect
                };
            }

            object GetProviderInfoClone()
            {

                return new
                {
                    _providerInfo.RequiresAuthentication,
                    Client = new
                    {
                        _providerInfo.Client.Id,
                        _providerInfo.Client.Name,
                        _providerInfo.Client.Version
                    },
                    PackInfo = new
                    {
                        _providerInfo.PackInfo.Version,
                        _providerInfo.PackInfo.Score,
                        _providerInfo.PackInfo.IsPreview,
                    },
                    OpenIdConnect = new
                    {
                        _providerInfo.OpenIdConnect.Authority,
                        _providerInfo.OpenIdConnect.AllowOfflineAccess,
                        _providerInfo.OpenIdConnect.IsActive
                    },
                    Redis = new
                    {
                        _providerInfo.Redis.Channel,
                        _providerInfo.Redis.Configuration,
                        _providerInfo.Redis.IsActive
                    }
                };
            }

            object GetClientClone()
            {
                return new
                {
                    _openSettingsConfiguration.Client.Id,
                    _openSettingsConfiguration.Client.Name,
                    _openSettingsConfiguration.Client.Version,
                };
            }
        }

        private static async Task<string> BuildHtmlAsync(Func<Stream> funcStream, Dictionary<string, string> indexArguments)
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