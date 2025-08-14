using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Sql.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql
{
    internal sealed class TokenSqlService : TokenServiceBase, ITokenSqlService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly ILogger _logger;

        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly string _clientId;

        public TokenSqlService(IServiceProvider serviceProvider) : base(new JwtSecurityTokenHandler())
        {
            _serviceProvider = serviceProvider;
            _openSettingsMemoryCache = serviceProvider.GetRequiredService<IOpenSettingsMemoryCache>();
            _openSettingsConfiguration = serviceProvider.GetRequiredService<OpenSettingsConfiguration>();
            _logger = _openSettingsConfiguration.LoggerFactory.CreateLogger<TokenSqlService>();

            _clientId = $"{_openSettingsConfiguration.Client.Id}";
        }

        public async ValueTask<ProviderTokenInfo> GetProviderTokenInfoAsync(CancellationToken cancellationToken)
        {
            if (OpenSettingsDefaults.Caches.ProviderTokenInfoCacheEntryKey.TryGetValue(_openSettingsMemoryCache, out ProviderTokenInfo providerTokenInfo))
            {
                return providerTokenInfo;
            }

            using (var scope = _serviceProvider.CreateScope())
            {
                var sp = scope.ServiceProvider;

                var globalConfiguration = sp.GetRequiredService<IGlobalConfigurationSqlService>();

                var keySet = await globalConfiguration.GetTokenKeySetAsync(cancellationToken);

                var signingKeys = GenerateSigningKeys(keySet);

                var firstAvailableSigningKey = signingKeys[0];
                
                var signingCredential = new SigningCredentials(firstAvailableSigningKey, SecurityAlgorithms.RsaSha256);

                providerTokenInfo = new ProviderTokenInfo
                {
                    KeySet = keySet,
                    SigningKeys = signingKeys,
                    SigningCredential = signingCredential
                };

                OpenSettingsDefaults.Caches.ProviderTokenInfoCacheEntryKey.Set(_openSettingsMemoryCache, providerTokenInfo,
                    cacheEntry =>
                    {
                        cacheEntry.PostEvictionCallbacks.Add(new PostEvictionCallbackRegistration()
                        {
                            EvictionCallback = ((key, value, reason, state) =>
                            {
                                    
                            })
                        });
                    });

                return providerTokenInfo;
            }
        }

        private static RsaSecurityKey[] GenerateSigningKeys(TokenKeySet keySet)
        {
            var issuerSigningKeys = keySet.Keys.Where(k => k.IsActive).Select(signingKey =>
            {
                var rsa = RSA.Create();

                rsa.ImportPkcs8PrivateKey(signingKey.PrivateKey, out _);

                var securityKey = new RsaSecurityKey(rsa)
                {
                    KeyId = signingKey.KeyId,
                };

                return securityKey;
            }).ToArray();

            return issuerSigningKeys;
        }

        public async Task<IResponse<GenerateTokenResponse>> GenerateTokenForMachineAsync(GenerateTokenForMachineInput input, CancellationToken cancellationToken)
        {
            if (input.CallerType == CallerType.Service)
            {
                // Use the service method to generate a token for consumer-to-provider communication, caching the result.
                return await GenerateTokenForServiceAsync(input, cancellationToken);
            }

            // Use the internal method to generate a token with machine credentials, resulting in a new token each time.
            var response = await InternalGenerateMachineTokenAsync(input, OpenSettingsDefaults.TimeSpans.TokenExpiryTime, cancellationToken);

            return response == null
                ? HttpStatusCode.Unauthorized.ToFailureResponse<GenerateTokenResponse>()
                : HttpStatusCode.OK.ToSuccessResponseOf(response);
        }

        public async Task<GenerateTokenResponse> GenerateTokenForUserAsync(GenerateTokenForUserInput input, CancellationToken cancellationToken)
        {
            var openSettingsClaims = new OpenSettingsClaims
            {
                UserId = input.UserId,
                DisplayName = input.DisplayName,
                UserInitials = input.UserInitials,
                AuthType = AuthType.OAuth2,
                AuthMethod = _clientId == input.Audience ? AuthMethod.Cookie : AuthMethod.Jwt
            };

            var claims = openSettingsClaims.GenerateClaims();

            var tokenResponse = await GenerateTokenAsync(input.Audience, OpenSettingsDefaults.TimeSpans.TokenExpiryTime, claims, cancellationToken);

            return tokenResponse;
        }

        public async Task<string> GetPublicJwksAsync(CancellationToken cancellationToken)
        {
            var providerTokenInfo = await GetProviderTokenInfoAsync(cancellationToken);

            return providerTokenInfo.KeySet.PublicJwksJson;
        }

        private async Task<GenerateTokenResponse> GenerateTokenAsync(string audience, TimeSpan expiryTimeSpan, List<Claim> claims, CancellationToken cancellationToken)
        {
            var providerTokenInfo = await GetProviderTokenInfoAsync(cancellationToken);

            var currentTime = DateTimeOffset.UtcNow;

            var expires = currentTime + expiryTimeSpan;

            var token = new JwtSecurityToken(
                issuer: _openSettingsConfiguration.Client.Name,
                audience: audience,
                claims: claims,
                notBefore: currentTime.UtcDateTime,
                expires: expires.UtcDateTime,
                signingCredentials: providerTokenInfo.SigningCredential
            );

            var accessToken = WriteJwtToken(token);

            var tokenResponse = new GenerateTokenResponse(accessToken, expires, expiryTimeSpan.TotalSeconds, claims);

            return tokenResponse;
        }

        private async Task<IResponse<GenerateTokenResponse>> GenerateTokenForServiceAsync(GenerateTokenForMachineInput input, CancellationToken cancellationToken)
        {
            var tokenCacheEntryKey = OpenSettingsDefaults.Caches.TokenServiceGenerateMachineToMachineTokenCacheEntry.GetKey(input.ClientId, input.ClientSecret);

            if (tokenCacheEntryKey.TryGetValue(_openSettingsMemoryCache, out GenerateTokenResponse response))
            {
                return HttpStatusCode.OK.ToSuccessResponseOf(response);
            }

            response = await InternalGenerateMachineTokenAsync(input, OpenSettingsDefaults.TimeSpans.TokenExpiryTime, cancellationToken);

            if (response == null)
            {
                return HttpStatusCode.Unauthorized.ToFailureResponse<GenerateTokenResponse>();
            }

            tokenCacheEntryKey.Set(_openSettingsMemoryCache, response, cacheEntry =>
            {
                cacheEntry.AbsoluteExpiration = Helper.GetExpiryTimeOffset(response.Expires) - OpenSettingsDefaults.TimeSpans.TokenExpirySafetyMargin;
            });

            return HttpStatusCode.OK.ToSuccessResponseOf(response);
        }

        private async Task<GenerateTokenResponse> InternalGenerateMachineTokenAsync(GenerateTokenForMachineInput input, TimeSpan tokenExpiryTime, CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var appService = scope.ServiceProvider.GetRequiredService<IAppService>();

                var registeredAppResponse = await appService.GetRegisteredAppAsync(new GetRegisteredAppInput
                {
                    ClientId = input.ClientId,
                    ClientSecret = input.ClientSecret
                }, cancellationToken);

                var registeredApp = registeredAppResponse.Data;

                if (!registeredApp.IsClientSecretMatched)
                {
                    return null;
                }

                var openSettingsClaims = new OpenSettingsClaims
                {
                    UserId = input.ClientId,
                    DisplayName = registeredApp.ClientName,
                    AuthType = AuthType.Machine,
                    AuthMethod = AuthMethod.Jwt
                };

                var claims = openSettingsClaims.GenerateClaims();

                var tokenResponse = await GenerateTokenAsync(registeredApp.ClientName, tokenExpiryTime, claims, cancellationToken);

                return tokenResponse;
            }
        }
    }
}