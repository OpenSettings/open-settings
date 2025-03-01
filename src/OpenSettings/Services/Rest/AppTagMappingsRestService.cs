using OpenSettings.Services.Rest.Interfaces;
using System.Net.Http;

namespace OpenSettings.Services.Rest
{
    public class AppTagMappingsRestService : IAppTagMappingsRestService
    {
        private readonly HttpClient _httpClient;

        public AppTagMappingsRestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}