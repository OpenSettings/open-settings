using OpenSettings.Extensions;
using OpenSettings.Services.Rest.Interfaces;
using System.Net.Http;

namespace OpenSettings.Services.Rest
{
    public sealed class AppSettingClassRestService : ISettingClassRestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AppSettingClassRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient GetProviderHttpClient()
        {
            return _httpClientFactory.CreateOpenSettingsProviderHttpClient();
        }
    }
}