using OpenSettings.Extensions;
using OpenSettings.Services.Rest.Interfaces;
using System.Net.Http;

namespace OpenSettings.Services.Rest
{
    public class AppTagMappingsRestService : IAppTagMappingsRestService
    {
        private HttpClient HttpClient => _httpClientFactory.CreateOpenSettingsHttpClient();

        private readonly IHttpClientFactory _httpClientFactory;

        public AppTagMappingsRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}