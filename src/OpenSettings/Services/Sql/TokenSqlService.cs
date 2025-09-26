using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
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
#if NETSTANDARD2_0
using OpenSettings.Helpers;
#endif

namespace OpenSettings.Services.Sql
{
    internal sealed class TokenSqlService : TokenServiceBase, ITokenSqlService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;

        private readonly OpenSettingsConfiguration _openSettingsConfiguration;

        public TokenSqlService(IServiceProvider serviceProvider) : base(new JwtSecurityTokenHandler())
        {
            _serviceProvider = serviceProvider;
            _openSettingsMemoryCache = serviceProvider.GetRequiredService<IOpenSettingsMemoryCache>();
            _openSettingsConfiguration = serviceProvider.GetRequiredService<OpenSettingsConfiguration>();
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

                var keySet = await globalConfiguration.GetOrCreateTokenKeySetAsync(cancellationToken);

                var signingKeys = GenerateSigningKeys(keySet.Keys);

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
                        cacheEntry.PostEvictionCallbacks.Add(new PostEvictionCallbackRegistration
                        {
                            EvictionCallback = (key, value, reason, state) =>
                            {
                                foreach (var signingKey in ((ProviderTokenInfo)value).SigningKeys)
                                {
                                    signingKey.Rsa.Dispose();
                                }
                            }
                        });
                    });

                return providerTokenInfo;
            }
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

        public async Task<GenerateTokenResponse> GenerateTokenForUserAsync(GenerateTokenForUserInput input, TimeSpan tokenExpiryTime, CancellationToken cancellationToken)
        {
            var openSettingsClaims = new OpenSettingsClaims
            {
                UserId = input.UserId,
                DisplayName = input.DisplayName,
                UserInitials = input.UserInitials,
                AuthType = AuthType.OpenIdConnect,
                AuthMethod = AuthMethod.Jwt
            };

            var claims = openSettingsClaims.GenerateClaims();

            var tokenResponse = await GenerateTokenAsync(input.Audience, tokenExpiryTime, claims, cancellationToken);

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

            var expiryDate = currentTime + expiryTimeSpan;

            var token = new JwtSecurityToken(
                issuer: _openSettingsConfiguration.Client.Name,
                audience: audience,
                claims: claims,
                notBefore: currentTime.UtcDateTime,
                expires: expiryDate.UtcDateTime,
                signingCredentials: providerTokenInfo.SigningCredential
            );

            var accessToken = WriteJwtToken(token);

            var tokenResponse = new GenerateTokenResponse
            {
                AccessToken = new GenerateTokenResponseToken
                {
                    Value = accessToken,
                    ExpiryDate = expiryDate,
                    ExpiresInSeconds = expiryTimeSpan.TotalSeconds
                },
                Claims = claims
            };

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
                cacheEntry.AbsoluteExpiration = response.AccessToken.ExpiryDate - OpenSettingsDefaults.TimeSpans.TokenExpirySafetyMargin;
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

                var tokenResponse = await GenerateTokenAsync($"{input.ClientId}", tokenExpiryTime, claims, cancellationToken);

                return tokenResponse;
            }
        }

        private static RsaSecurityKey[] GenerateSigningKeys(TokenKeySetSigningKey[] keys)
        {
            var issuerSigningKeys = keys.Where(k => k.IsActive).Select(signingKey =>
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
    }
}