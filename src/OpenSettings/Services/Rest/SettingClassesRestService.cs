using OpenSettings.Services.Rest.Interfaces;
using System.Net.Http;

namespace OpenSettings.Services.Rest
{
    public sealed class SettingClassesRestService : ISettingClassesRestService
    {
        private readonly HttpClient _httpClient;

        public SettingClassesRestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}