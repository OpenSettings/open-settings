using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services
{
    internal sealed class MachineToMachineRequestHandler : DelegatingHandler
    {
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly ITokenService _tokenService;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly AuthenticationHeaderValue _basicAuthenticationHeaderValue;

        public MachineToMachineRequestHandler(IOpenSettingsMemoryCache openSettingsMemoryCache, ITokenService tokenService, OpenSettingsConfiguration openSettingsConfiguration)
        {
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _tokenService = tokenService;
            _openSettingsConfiguration = openSettingsConfiguration;

            _basicAuthenticationHeaderValue = _openSettingsConfiguration.Client.CreateBasicAuthenticationHeaderValue();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (false && (!request.RequestUri?.LocalPath.EndsWith(OpenSettingsDefaults.Routes.V1.Token) ?? false))
            {
                request.Headers.Authorization = await GetMachineToMachineTokenAsync(cancellationToken);
                request.Headers.TryAddWithoutValidation(OpenSettingsDefaults.Headers.AuthMethod, nameof(AuthMethod.Jwt));
            }
            else
            {
                request.Headers.Authorization = _basicAuthenticationHeaderValue;
                request.Headers.TryAddWithoutValidation(OpenSettingsDefaults.Headers.AuthMethod, nameof(AuthMethod.Basic));
            }

            request.Headers.TryAddWithoutValidation(OpenSettingsDefaults.Headers.CallerType, nameof(CallerType.Service));
            request.Headers.TryAddWithoutValidation(OpenSettingsDefaults.Headers.AuthType, nameof(AuthType.Machine));

            return await base.SendAsync(request, cancellationToken);
        }

        public async ValueTask<AuthenticationHeaderValue> GetMachineToMachineTokenAsync(CancellationToken cancellationToken)
        {
            if (OpenSettingsDefaults.Caches.MachineToMachineTokenCacheEntryKey.TryGetValue<AuthenticationHeaderValue>(_openSettingsMemoryCache, out var authorization))
            {
                return authorization;
            }

            var generateTokenResponse = await _tokenService.GenerateMachineToMachineTokenAsync(new GenerateMachineToMachineTokenInput
            {
                ClientId = _openSettingsConfiguration.Client.Id,
                ClientSecret = _openSettingsConfiguration.Client.Secret,
            }, cancellationToken);

            if (!generateTokenResponse.Success)
            {
                return null;
            }

            authorization = new AuthenticationHeaderValue(OpenSettingsDefaults.Names.JwtBearerSchemaName, generateTokenResponse.Data.AccessToken);

            OpenSettingsDefaults.Caches.MachineToMachineTokenCacheEntryKey.Set(_openSettingsMemoryCache, authorization,
                cacheEntry =>
                {
                    cacheEntry.AbsoluteExpiration = Helpers.Helper.GetExpiryTimeOffset(generateTokenResponse.Data.Expires);
                });

            return authorization;
        }
    }
}