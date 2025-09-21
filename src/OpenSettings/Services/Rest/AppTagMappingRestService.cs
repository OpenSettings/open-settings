using OpenSettings.Services.Rest.Interfaces;
using System.Net.Http;
using OpenSettings.Extensions;

namespace OpenSettings.Services.Rest
{
    public class AppTagMappingRestService : IAppTagMappingRestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AppTagMappingRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient GetProviderHttpClient()
        {
            return _httpClientFactory.CreateOpenSettingsProviderHttpClient();
        }
    }
}