using OpenSettings.Extensions;
using OpenSettings.Services.Rest.Interfaces;
using System.Net.Http;

namespace OpenSettings.Services.Rest
{
    public sealed class SettingClassesRestService : ISettingClassesRestService
    {
        private HttpClient HttpClient => _httpClientFactory.CreateOpenSettingsHttpClient();

        private readonly IHttpClientFactory _httpClientFactory;

        public SettingClassesRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}