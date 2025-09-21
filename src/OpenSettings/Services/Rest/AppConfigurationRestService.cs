using Ogu.Response.Abstractions;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Rest.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public class AppConfigurationRestService : IAppConfigurationRestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AppConfigurationRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse> GetAppConfigurationByAppIdAndIdentifierIdAsync(GetAppConfigurationByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppConfigurationByAppIdAndIdentifierId,
                new[] { input.AppIdOrSlug, input.IdentifierIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> PatchAppConfigurationAsync(PatchConfigurationInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.PatchAppConfiguration,
                new[] { $"{input.AppId}", $"{input.IdentifierId}" });

            using (var jsonContent = JsonContent.Create(input.Body))
            {
#if NETSTANDARD2_0
                using (var response = await GetProviderHttpClient().SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), relativeUri) { Content = jsonContent }, cancellationToken))
#else
                using (var response = await GetProviderHttpClient().PatchAsync(relativeUri, jsonContent, cancellationToken))
#endif
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        private HttpClient GetProviderHttpClient()
        {
            return _httpClientFactory.CreateOpenSettingsProviderHttpClient();
        }
    }
}