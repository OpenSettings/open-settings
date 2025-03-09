using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using OpenSettings.Services.MemoryCache;
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
    public class SettingsSpaMiddleware
    {
        private readonly SettingsSpaOptions _options;
        private readonly OpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly StaticFileMiddleware _staticFileMiddleware;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        private readonly string _routePrefixPattern;
        private readonly string _routePrefixWithIndexHtmlPattern;

        private readonly IDictionary<string, string> _indexArguments;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsSpaMiddleware"/> class.
        /// </summary>
        /// <param name="requestDelegate">The request delegate.</param>
        /// <param name="options">Spa options.</param>
        /// <param name="openSettingsMemoryCache">In-memory cache for Open Settings.</param>
        /// <param name="controllerOptions">Controller options.</param>
        /// <param name="openSettingsConfiguration">Configuration for Open Settings.</param>
        /// <param name="providerInfo">Provider information.</param>
        /// <param name="hostingEnv">Web hosting environment.</param>
        /// <param name="loggerFactory">Factory for creating loggers.</param>
        public SettingsSpaMiddleware(
            RequestDelegate requestDelegate,
            SettingsSpaOptions options,
            OpenSettingsMemoryCache openSettingsMemoryCache,
            ControllerOptions controllerOptions,
            OpenSettingsConfiguration openSettingsConfiguration,
            ProviderInfo providerInfo,
            IWebHostEnvironment hostingEnv,
            ILoggerFactory loggerFactory)
        {
            _options = options;
            _openSettingsMemoryCache = openSettingsMemoryCache;

            _routePrefixPattern = string.IsNullOrWhiteSpace(_options.RoutePrefix)
                ? "^/$"
                : $"^/{Regex.Escape(_options.RoutePrefix)}/?$";

            _routePrefixWithIndexHtmlPattern = string.IsNullOrWhiteSpace(_options.RoutePrefix)
                ? "^/index.html$"
                : $"^/{Regex.Escape(_options.RoutePrefix)}/index.html$";


            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            };

            var cloneControllerOptions = new
            {
                Route = $"/{controllerOptions.Route}",
                controllerOptions.AllowFromExploring,
                controllerOptions.Authorize,
                controllerOptions.OAuth2Options
            };

            var openSettingsAssemblyInfo = OpenSettingsAssemblyInfo.Instance;

            _indexArguments = new Dictionary<string, string>
            {
                { "%(ControllerOptions)", JsonSerializer.Serialize(cloneControllerOptions, _jsonSerializerOptions) },
                { "%(ProviderInfo)", JsonSerializer.Serialize(providerInfo, _jsonSerializerOptions) },
                { "%(DocumentTitle)", _options.DocumentTitle },
                { "%(ServiceType)", $"{openSettingsConfiguration.Selection}" },
                { "%(DataAccessType)", openSettingsConfiguration.IsConsumerSelected ? string.Empty : $"{openSettingsConfiguration.Provider.Selection}" },
                { "%(DbProviderName)", openSettingsConfiguration.IsProviderSelected && openSettingsConfiguration.Provider.IsOrmSelected ? $"{openSettingsConfiguration.Provider.Orm.DbProviderName}" : string.Empty },
                { "%(PackVersion)", openSettingsAssemblyInfo.Version },
                { "%(PackVersionScore)", $"{openSettingsAssemblyInfo.VersionScore}" },
                { "%(Version)", openSettingsConfiguration.Client.Version },
                { "%(ClientName)", openSettingsConfiguration.Client.Name },
                { "%(ClientId)", $"{openSettingsConfiguration.Client.Id}" },
            };

            _staticFileMiddleware = requestDelegate.CreateStaticFileMiddleware(hostingEnv, loggerFactory, _options.RoutePrefix, Constants.EmbeddedFileNamespace, typeof(SettingsSpaMiddleware));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var httpMethod = httpContext.Request.Method;
            var path = httpContext.Request.Path.Value;

            switch (httpMethod)
            {
                case "GET" when Regex.IsMatch(path, _routePrefixPattern, RegexOptions.IgnoreCase):

                    var relativeIndexUrl = string.IsNullOrEmpty(path) || path.EndsWith("/")
                        ? Constants.IndexHtmlName
                        : $"{path.Split('/').Last()}/index.html";
                    httpContext.Response.RespondWithRedirect(relativeIndexUrl);
                    return;

                case "GET" when Regex.IsMatch(path, _routePrefixWithIndexHtmlPattern, RegexOptions.IgnoreCase):

                    var text = await MemoryCacheKeys.SettingsSpaMiddlewareHtml.GetOrCreateAsync(_openSettingsMemoryCache, c =>
                    {
                        _indexArguments["%(License)"] = JsonSerializer.Serialize(LicenseProvider.Instance.CurrentLicense, _jsonSerializerOptions);

                        return BuildHtmlAsync(_options.IndexStream, _indexArguments);
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
    }
}