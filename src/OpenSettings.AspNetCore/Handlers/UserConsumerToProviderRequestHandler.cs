using Microsoft.AspNetCore.Http;
using OpenSettings.AspNetCore.Extensions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Handlers
{
    /// <summary>
    /// Handles requests from consumer to provider, adding necessary headers for authentication and caller type.
    /// </summary>
    internal class UserConsumerToProviderRequestHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserConsumerToProviderRequestHandler"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">The http context accessor.</param>
        public UserConsumerToProviderRequestHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext == null) // Consumer To Provider
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var callerType = _httpContextAccessor.HttpContext.Request.Headers.GetCallerTypeHeaderValueOrDefault();

            request.Headers.TryAddWithoutValidation(OpenSettingsDefaults.Headers.CallerType, $"{callerType}");

            request.Headers.Authorization = _httpContextAccessor.HttpContext.Request.Headers.GetAuthenticationHeaderValueFromAuthorizationHeader();

            if (request.Headers.Authorization == null)
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var authType = _httpContextAccessor.HttpContext.Request.Headers.GetAuthTypeHeaderValueOrDefault();
            var authMethod = _httpContextAccessor.HttpContext.Request.Headers.GetAuthMethodHeaderValueOrDefault();

            request.Headers.TryAddWithoutValidation(OpenSettingsDefaults.Headers.AuthType, $"{authType}");
            request.Headers.TryAddWithoutValidation(OpenSettingsDefaults.Headers.AuthMethod, $"{authMethod}");

            return await base.SendAsync(request, cancellationToken);
        }
    }
}