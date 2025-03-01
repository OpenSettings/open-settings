using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
#if NETSTANDARD2_0 || NETSTANDARD2_1
using IWebHostEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
#else
using Microsoft.AspNetCore.Hosting;
#endif

namespace OpenSettings.AspNetCore.Spa
{
    internal static class InternalExtensions
    {
        internal static void RespondWithRedirect(this HttpResponse response, string location)
        {
            response.StatusCode = 301;
            response.Headers[Constants.LocationHeaderName] = location;
        }

        internal static Task RespondWithIndexHtmlAsync(this HttpResponse response, string text)
        {
            response.StatusCode = 200;
            response.ContentType = Constants.TextHtmlContentType;

            return response.WriteAsync(text, Encoding.UTF8, response.HttpContext.RequestAborted);
        }

        internal static StaticFileMiddleware CreateStaticFileMiddleware(
            this RequestDelegate next,
            IWebHostEnvironment hostingEnv,
            ILoggerFactory loggerFactory,
            string routePrefix,
            string embeddedFileNamespace,
            Type middlewareType)
        {
            var staticFileOptions = new StaticFileOptions
            {
                RequestPath = string.IsNullOrEmpty(routePrefix) ? string.Empty : $"/{routePrefix}",
                FileProvider = new EmbeddedFileProvider(middlewareType.GetTypeInfo().Assembly, embeddedFileNamespace),
            };

            return new StaticFileMiddleware(next, hostingEnv, Options.Create(staticFileOptions), loggerFactory);
        }
    }
}