using Ogu.Response.Abstractions;
using OpenSettings.Extensions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    internal sealed class TokenRestService : TokenServiceBase, ITokenRestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TokenRestService(IHttpClientFactory httpClientFactory) : base(new JwtSecurityTokenHandler())
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse<GenerateTokenResponse>> GenerateTokenForMachineAsync(GenerateTokenForMachineInput input, CancellationToken cancellationToken)
        {
            const string relativeUri = "v1/token/machine";

            var body = new
            {
                Client = new
                {
                    Id = input.ClientId,
                    Secret = input.ClientSecret
                }
            };

            var httpClient = GetProviderHttpClient();

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await httpClient.PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync<GenerateTokenResponse>(cancellationToken: cancellationToken);
                }
            }
        }

        public Task<string> GetPublicJwksAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetPublicJwksAsync));

            //const string relativeUri = "v1/token/jwks";

            //var httpClient = GetProviderHttpClient();

            //using (var response = await httpClient.GetAsync(relativeUri))
            //{
            //    return await response.Content.ReadAsStringAsync();
            //}
        }

        private HttpClient GetProviderHttpClient()
        {
            return _httpClientFactory.CreateOpenSettingsProviderHttpClient();
        }
    }
}