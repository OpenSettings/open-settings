using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models;
using OpenSettings.Services.Interfaces;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ICompressionProvider = Ogu.Compressions.Abstractions.ICompressionProvider;

namespace OpenSettings.Services.Sql
{
    internal sealed class GlobalConfigurationSqlService : IGlobalConfigurationSqlService
    {
        private readonly ICompressionProvider _compressionProvider;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly OpenSettingsDbContext _openSettingsDbContext;

        public GlobalConfigurationSqlService(ICompressionProvider compressionProvider, OpenSettingsConfiguration openSettingsConfiguration, OpenSettingsDbContext openSettingsDbContext)
        {
            _compressionProvider = compressionProvider;
            _openSettingsConfiguration = openSettingsConfiguration;
            _openSettingsDbContext = openSettingsDbContext;
        }

        public async Task<TokenKeySet> GetTokenKeySetAsync(CancellationToken cancellationToken)
        {
            const string configKey = "token-key-set";

            var configKeyLowercase = configKey.ToLowerInvariant();

            var configuration = await _openSettingsDbContext.GlobalConfigurations
                .AsNoTracking()
                .Where(g => g.KeyLowercase == configKeyLowercase)
                .FirstOrDefaultAsync(cancellationToken);

            TokenKeySet keySet;
            TokenKeySetSigningKey signingKey;
            string jwkJson;
            byte[] data;
            byte[] compressedData;
            EntityEntry<GlobalConfigurationSqlModel> configurationEntry;

            if (configuration == null)
            {
                signingKey = CreateSigningKey();

                jwkJson = JsonSerializer.Serialize(new
                {
                    keys = new[] { signingKey.Jwk }
                });

                keySet = new TokenKeySet
                {
                    Keys = new TokenKeySetSigningKey[]
                    {
                        signingKey
                    },
                    PublicJwksJson = jwkJson
                };

                data = JsonSerializer.SerializeToUtf8Bytes(keySet);

                compressedData = await _compressionProvider.CompressAsync(_openSettingsConfiguration.Provider.CompressionType, data, cancellationToken);

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

                configurationEntry = _openSettingsDbContext.GlobalConfigurations.Add(configuration);

                await _openSettingsDbContext.SaveChangesAsync(cancellationToken);

                configurationEntry.State = EntityState.Detached;

                return keySet;
            }

            keySet = await _compressionProvider.DecompressJsonDataAsync<TokenKeySet>(configuration.CompressionType, configuration.Data, cancellationToken);

            if (keySet.Keys.Any(k => k.IsActive))
            {
                return keySet;
            }

            var configurationHistory = new GlobalConfigurationHistorySqlModel
            {
                Key = configuration.Key,
                KeyLowercase = configuration.KeyLowercase,
                Data = configuration.Data,
                ClientId = configuration.ClientId,
                IdentifierId = configuration.IdentifierId,
                SerializerType = configuration.SerializerType,
                CompressionType = configuration.CompressionType,
                CompressionLevel = configuration.CompressionLevel,
                Version = configuration.Version,
                CreatedById = null,
                RestoredById = null,
                RowVersion = Array.Empty<byte>(),
                CreatedOn = DateTime.UtcNow,
                RestoredOn = null
            };

            var configurationHistoryEntry = _openSettingsDbContext.GlobalConfigurationHistories.Add(configurationHistory);

            signingKey = CreateSigningKey();

            jwkJson = JsonSerializer.Serialize(new
            {
                keys = new[] { signingKey.Jwk }
            });

            keySet.PublicJwksJson = jwkJson;

            keySet.Keys = keySet.Keys.Append(signingKey).ToArray();
            data = JsonSerializer.SerializeToUtf8Bytes(keySet);

            compressedData = await _compressionProvider.CompressAsync(
                _openSettingsConfiguration.Provider.CompressionType, data, cancellationToken);

            configurationEntry = _openSettingsDbContext.GlobalConfigurations.Attach(configuration);

            var currentTime = DateTime.UtcNow;

            configuration.Data = compressedData;
            configuration.Version = Helper.GenerateVersion(currentTime, configuration.CreatedOn);
            configuration.SerializerType = SerializerType.Json;
            configuration.CompressionType = _openSettingsConfiguration.Provider.CompressionType;
            configuration.CompressionLevel = _openSettingsConfiguration.Provider.CompressionLevel;
            configuration.RowVersion = currentTime.ToRowVersion();
            configuration.UpdatedOn = currentTime;

            configurationEntry.MarkAsModified(
                e => e.Data,
                e => e.Version,
                e => e.SerializerType,
                e => e.CompressionType,
                e => e.CompressionLevel,
                e => e.RowVersion,
                e => e.UpdatedOn);

            await _openSettingsDbContext.SaveChangesAsync(cancellationToken);

            configurationEntry.State = EntityState.Detached;
            configurationHistoryEntry.State = EntityState.Detached;

            return keySet;
        }

        private static TokenKeySetSigningKey CreateSigningKey()
        {
            using (var rsa = RSA.Create())
            {
                const int keySizeInBits = 2048;

                rsa.KeySize = keySizeInBits;

                var privateKey = rsa.ExportPkcs8PrivateKey();

                var rsaKey = new RsaSecurityKey(rsa)
                {
                    KeyId = $"opensettings/{Guid.NewGuid():N}",
                };

                var jwk = JsonWebKeyConverter.ConvertFromRSASecurityKey(rsaKey);

                jwk.Use = "sig";
                jwk.Alg = SecurityAlgorithms.RsaSha256;

                return new TokenKeySetSigningKey
                {
                    KeyId = rsaKey.KeyId,
                    KeyType = "RSA",
                    Algorithm = jwk.Alg,
                    KeySizeInBits = keySizeInBits,
                    PrivateKey = privateKey,
                    Jwk = jwk,
                    CreatedOn = DateTime.UtcNow,
                    IsActive = true
                };
            }
        }
    }
}
