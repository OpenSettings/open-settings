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

        public ValueTask<bool> IsUserTokenExpiredAsync(JwtSecurityToken jwtSecurityToken, Func<Task<string>> refreshTokenRetrieveFunc)
        {
            throw new NotSupportedException();
        }

        public ValueTask<bool> IsUserTokenExpiredAsync(string accessToken, Func<Task<string>> refreshTokenRetrieveFunc)
        {
            throw new NotSupportedException();
        }

        public async Task<IResponse<RefreshUserTokenResponse>> RefreshUserTokenAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var refreshTokenRequest = new HttpRequestMessage(HttpMethod.Post, "v1/token/refresh");

            refreshTokenRequest.Headers.Authorization = new AuthenticationHeaderValue(OpenSettingsDefaults.Names.JwtBearerSchemaName, accessToken);

            var httpClient = GetProviderHttpClient();

            using (var response = await httpClient.SendAsync(refreshTokenRequest, cancellationToken))
            {
                return await response.Content.ToResponseAsync<RefreshUserTokenResponse>(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse<GenerateTokenResponse>> GenerateTokenAsync(GenerateTokenInput input, CancellationToken cancellationToken)
        {
            const string relativeUri = "v1/token";

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

        private HttpClient GetProviderHttpClient()
        {
            return _httpClientFactory.CreateOpenSettingsProviderHttpClient();
        }
    }
}