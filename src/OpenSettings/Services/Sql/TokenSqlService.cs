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
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Services.Sql
{
    public class KeySet
    {
        public SigningKey[] Keys { get; set; } = Array.Empty<SigningKey>();

        /// <summary>
        /// JSON representation of the active public JWKS (read-only for consumers).
        /// </summary>
        public string ActivePublicJwksJson { get; set; }
    }

    public class SigningKey
    {
        /// <summary>
        /// The Key ID (kid) used in JWKS and JWT headers to identify this key (e.g. opensettings/4b975f16e6ea49379fa41a9a4e1251ae ).
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        /// The type of cryptographic key (e.g. "RSA").
        /// </summary>
        public string KeyType { get; set; }

        /// <summary>
        /// The cryptographic algorithm used for signing (e.g. "RS256").
        /// </summary>
        public string Algorithm { get; set; }

        /// <summary>
        /// The size of the key in bits (e.g. 2048, 4096).
        /// </summary>
        public int KeySizeInBits { get; set; }

        /// <summary>
        /// The private key bytes in a serialized format (e.g. PKCS#8).
        /// </summary>
        public byte[] PrivateKey { get; set; }

        /// <summary>
        /// The date and time when the entity was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Whether this key is currently active for signing.
        /// </summary>
        public bool IsActive { get; set; }
    }

    internal sealed class TokenSqlService : TokenServiceBase, ITokenSqlService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly ILogger _logger;

        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly ProviderInfo _providerInfo;
        private readonly SigningCredentials _signingCredentials;
        private readonly bool _isOAuth2AuthorityMissing;

        public TokenSqlService(IServiceProvider serviceProvider) : base(new JwtSecurityTokenHandler())
        {
            _serviceProvider = serviceProvider;
            _httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            _openSettingsMemoryCache = serviceProvider.GetRequiredService<IOpenSettingsMemoryCache>();
            _openSettingsConfiguration = serviceProvider.GetRequiredService<OpenSettingsConfiguration>();
            _providerInfo = serviceProvider.GetRequiredService<ProviderInfo>();
            _logger = _openSettingsConfiguration.LoggerFactory.CreateLogger<TokenSqlService>();

            _signingCredentials = new SigningCredentials(OpenSettingsDefaults.Caches.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            _isOAuth2AuthorityMissing = string.IsNullOrWhiteSpace(_providerInfo.OAuth2.Authority);
        }

        public async Task<IResponse<GenerateMachineToMachineTokenResponse>> GenerateMachineToMachineTokenAsync(GenerateMachineToMachineTokenInput input, CancellationToken cancellationToken)
        {
            var clientId = $"{input.ClientId}";
            var clientSecret = $"{input.ClientSecret}";

            if (input.CallerType == CallerType.Service)
            {
                return await GenerateMachineToMachineTokenForServiceAsync(input, clientId, clientSecret, cancellationToken);
            }

            var expires = DateTimeOffset.UtcNow + OpenSettingsDefaults.TimeSpans.TokenExpiryTimeSpan;

            var response = await InternalGenerateMachineToMachineTokenAsync(input, clientId, clientSecret, expires, cancellationToken);

            return response == null
                ? HttpStatusCode.Unauthorized.ToFailureResponse<GenerateMachineToMachineTokenResponse>()
                : HttpStatusCode.OK.ToSuccessResponseOf(response);
        }

        public ValueTask<bool> IsOAuth2TokenExpiredAsync(string accessToken, Func<Task<string>> refreshTokenRetrieveFunc)
        {
            var jwtSecurityToken = ReadJwtToken(accessToken);

            return IsOAuth2TokenExpiredAsync(jwtSecurityToken, refreshTokenRetrieveFunc);
        }

        public async ValueTask<bool> IsOAuth2TokenExpiredAsync(JwtSecurityToken jwtSecurityToken, Func<Task<string>> refreshTokenRetrieveFunc)
        {
            var refreshTokenKey = OpenSettingsDefaults.Caches.TokenServiceRefreshOAuth2TokenCacheEntry.GetKey(jwtSecurityToken.Id);

            if (TokenHelper.IsTokenExpired(jwtSecurityToken))
            {
                refreshTokenKey.Remove(_openSettingsMemoryCache);
                return true;
            }

            if (refreshTokenKey.TryGetValue(_openSettingsMemoryCache, out _))
            {
                return false;
            }

            var refreshToken = await refreshTokenRetrieveFunc();

            if (!string.IsNullOrWhiteSpace(refreshToken))
            {
                refreshTokenKey.Set(_openSettingsMemoryCache, refreshToken, cacheEntry =>
                {
                    cacheEntry.AbsoluteExpiration = new DateTimeOffset(jwtSecurityToken.ValidTo, TimeSpan.Zero);
                });
            }

            return false;
        }

        public async Task<IResponse<RefreshUserTokenResponse>> RefreshOAuth2TokenAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var jwtSecurityToken = ReadJwtToken(accessToken);

            var refreshTokenKey = OpenSettingsDefaults.Caches.TokenServiceRefreshOAuth2TokenCacheEntry.GetKey(jwtSecurityToken.Id);

            var currentTime = DateTime.UtcNow;

            if (TokenHelper.IsTokenExpired(jwtSecurityToken, currentTime))
            {
                return HttpStatusCode.Forbidden.ToFailureResponse<RefreshUserTokenResponse, Errors>(Errors.TokenExpired);
            }

            if (!TokenHelper.IsTokenExpirationTimeLessThan(jwtSecurityToken, TimeSpan.FromMinutes(1), currentTime))
            {
                return HttpStatusCode.BadRequest.ToFailureResponse<RefreshUserTokenResponse, Errors>(Errors.TokenRefreshNotAllowedYet);
            }

            if (!refreshTokenKey.TryGetValue(_openSettingsMemoryCache, out string cachedRefreshToken) || // CachedRefreshToken stored during the initial login process. // todo we should store this in the persistent so it will be distributed
                string.IsNullOrWhiteSpace(cachedRefreshToken))
            {
                return HttpStatusCode.NotFound.ToFailureResponse<RefreshUserTokenResponse, Errors>(Errors.RefreshTokenNotFound);
            }

            if (_isOAuth2AuthorityMissing)
            {
                return HttpStatusCode.InternalServerError.ToFailureResponse<RefreshUserTokenResponse, Errors>(Errors.MissingOAuth2Authority);
            }

            using (var request = new HttpRequestMessage(HttpMethod.Post, "connect/token"))
            {
                request.Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>(OpenSettingsDefaults.ClaimTypes.GrantType, OpenSettingsDefaults.ClaimTypes.RefreshToken),
                    new KeyValuePair<string, string>(OpenSettingsDefaults.ClaimTypes.RefreshToken, cachedRefreshToken),
                    new KeyValuePair<string, string>(OpenSettingsDefaults.ClaimTypes.ClientId, _openSettingsConfiguration.Controller.OAuth2.ClientId),
                    new KeyValuePair<string, string>(OpenSettingsDefaults.ClaimTypes.ClientSecret, _openSettingsConfiguration.Controller.OAuth2.ClientSecret)
                });

                using (var response = await GetOAuth2AuthorityHttpClient().SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync(
#if NET5_0_OR_GREATER
                            cancellationToken
#endif
                            );

                        _logger.LogError("Failed to refresh oauth2 token. Status Code: {statusCode}, Content: {content}", response.StatusCode, content);

                        return response.StatusCode.ToFailureResponse<RefreshUserTokenResponse>(content);
                    }

                    var connectTokenResponse = await response.Content.ReadFromJsonAsync<ConnectTokenResponse>(cancellationToken: cancellationToken);

                    var refreshedJwtSecurityToken = ReadJwtToken(connectTokenResponse.AccessToken);

                    refreshTokenKey = OpenSettingsDefaults.Caches.TokenServiceRefreshOAuth2TokenCacheEntry.GetKey(refreshedJwtSecurityToken.Id);

                    refreshTokenKey.Set(_openSettingsMemoryCache, connectTokenResponse.RefreshToken, cacheEntry =>
                    {
                        cacheEntry.AbsoluteExpiration = new DateTimeOffset(refreshedJwtSecurityToken.ValidTo, TimeSpan.Zero);
                    });

                    return HttpStatusCode.OK.ToSuccessResponseOf(new RefreshUserTokenResponse
                    {
                        AccessToken = connectTokenResponse.AccessToken
                    });
                }
            }
        }

        public async Task<string> GetPublicJwksAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                const string configKey = "jwks";

                var configKeyLowercase = configKey.ToLowerInvariant();

                var compressionProvider = scope.ServiceProvider.GetRequiredService<Ogu.Compressions.Abstractions.ICompressionProvider>();

                var openSettingsDbContext = scope.ServiceProvider.GetRequiredService<OpenSettingsDbContext>();

                var configuration = await openSettingsDbContext.GlobalConfigurations
                    .AsNoTracking()
                    .Where(g => g.KeyLowercase == configKeyLowercase)
                    .FirstOrDefaultAsync(cancellationToken);

                KeySet keySet;

                if (configuration == null)
                {
                    const int keySizeInBits = 2048;

                    using (var rsa = RSA.Create())
                    {
                        rsa.KeySize = keySizeInBits;

                        var privateKey = rsa.ExportPkcs8PrivateKey();

                        var rsaKey = new RsaSecurityKey(rsa)
                        {
                            KeyId = $"opensettings/{Guid.NewGuid():N}",
                        };

                        var jwk = JsonWebKeyConverter.ConvertFromRSASecurityKey(rsaKey);

                        jwk.Use = "sig";
                        jwk.Alg = SecurityAlgorithms.RsaSha256;

                        var jwkJson = JsonSerializer.Serialize(new
                        {
                            keys = new[] { jwk }
                        });

                        keySet = new KeySet
                        {
                            Keys = new SigningKey[]
                            {
                                new SigningKey
                                {
                                    KeyId = rsaKey.KeyId,
                                    KeyType = "RSA",
                                    Algorithm = jwk.Alg,
                                    KeySizeInBits = keySizeInBits,
                                    PrivateKey = privateKey,
                                    CreatedOn = DateTime.UtcNow,
                                    IsActive = true
                                }
                            },
                            ActivePublicJwksJson = jwkJson
                        };

                        var data = JsonSerializer.SerializeToUtf8Bytes(keySet);

                        var compressedData = await compressionProvider.CompressAsync(_openSettingsConfiguration.Provider.CompressionType, data, cancellationToken);

                        configuration = new GlobalConfigurationSqlModel
                        {
                            Key = configKey,
                            KeyLowercase = configKeyLowercase,
                            Data = compressedData,
                            ClientId = null,
                            IdentifierId = null,
                            SerializerType = SerializerType.Json,
                            CompressionType = _openSettingsConfiguration.Provider.CompressionType,
                            CompressionLevel = _openSettingsConfiguration.Provider.CompressionLevel,
                            Version = "0",
                            CreatedById = null,
                            UpdatedById = null,
                            RowVersion = Array.Empty<byte>(),
                            CreatedOn = DateTime.UtcNow,
                            UpdatedOn = null
                        };

                        var entry = openSettingsDbContext.GlobalConfigurations.Add(configuration);

                        await openSettingsDbContext.SaveChangesAsync(cancellationToken);

                        openSettingsDbContext.Entry(entry.Entity).State = EntityState.Detached;
                    }
                }
                else
                {
                    keySet = await compressionProvider.DecompressJsonDataAsync<KeySet>(configuration.CompressionType, configuration.Data, cancellationToken);
                }

                return keySet.ActivePublicJwksJson;
            }
        }

        private async Task<IResponse<GenerateMachineToMachineTokenResponse>> GenerateMachineToMachineTokenForServiceAsync(GenerateMachineToMachineTokenInput input, string clientId, string clientSecret, CancellationToken cancellationToken)
        {
            var tokenCacheEntryKey = OpenSettingsDefaults.Caches.TokenServiceGenerateMachineToMachineTokenCacheEntry.GetKey(clientId, clientSecret);

            if (tokenCacheEntryKey.TryGetValue(_openSettingsMemoryCache, out GenerateMachineToMachineTokenResponse response))
            {
                return HttpStatusCode.OK.ToSuccessResponseOf(response);
            }

            var expires = DateTimeOffset.UtcNow + OpenSettingsDefaults.TimeSpans.TokenExpiryTimeSpan;

            response = await InternalGenerateMachineToMachineTokenAsync(input, clientId, clientSecret, expires, cancellationToken);

            if (response == null)
            {
                return HttpStatusCode.Unauthorized.ToFailureResponse<GenerateMachineToMachineTokenResponse>();
            }

            tokenCacheEntryKey.Set(_openSettingsMemoryCache, response, cacheEntry =>
            {
                cacheEntry.AbsoluteExpiration = expires - OpenSettingsDefaults.TimeSpans.TokenExpirySafetyMargin;
            });

            return HttpStatusCode.OK.ToSuccessResponseOf(response);
        }

        private async Task<GenerateMachineToMachineTokenResponse> InternalGenerateMachineToMachineTokenAsync(GenerateMachineToMachineTokenInput input, string clientId, string clientSecret, DateTimeOffset expires, CancellationToken cancellationToken)
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

                //var refreshToken = Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
                //var hashedRefreshToken = SHA256.HashData(refreshToken);

                var claims = Helper.GetOpenSettingsClaims(clientId, registeredApp.ClientName, AuthType.Machine, AuthMethod.Jwt)
                    .Concat(new[]
                        { new Claim(OpenSettingsDefaults.ClaimTypes.JsonTokenId, $"{Guid.NewGuid()}") }
                    );

                var token = new JwtSecurityToken(
                    issuer: _openSettingsConfiguration.Client.Name,
                    audience: registeredApp.ClientName,
                    claims: claims,
                    expires: expires.UtcDateTime,
                    signingCredentials: _signingCredentials
                );

                var accessToken = WriteJwtToken(token);

                return new GenerateMachineToMachineTokenResponse(accessToken, expires, OpenSettingsDefaults.TimeSpans.TokenExpiryTimeSpan.TotalSeconds);
            }
        }

        private HttpClient GetOAuth2AuthorityHttpClient()
        {
            var httpClient = _httpClientFactory.CreateClient();

            httpClient.BaseAddress = new Uri(_providerInfo.OAuth2.Authority);

            return httpClient;
        }
    }
}