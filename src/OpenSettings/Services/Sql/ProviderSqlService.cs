using System;
using Microsoft.EntityFrameworkCore;
using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Models;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Sql.Interfaces;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql
{
    internal sealed class ProviderSqlService : IProviderSqlService
    {
        private readonly OpenSettingsDbContext _context;
        private readonly ProviderInfo _providerInfo;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;

        public ProviderSqlService(OpenSettingsDbContext context, ProviderInfo providerInfo,
            OpenSettingsConfiguration openSettingsConfiguration)
        {
            _context = context;
            _providerInfo = providerInfo;
            _openSettingsConfiguration = openSettingsConfiguration;
        }

        public async Task<IResponse<ProviderInfo>> GetProviderAsync(CancellationToken cancellationToken = default)
        {
            var entity = await _context.Configurations.AsNoTracking()
                .Include(e => e.App)
                .Include(e => e.Identifier)
                .Where(c => c.App.ClientId == _providerInfo.Client.Id &&
                            c.Identifier.NameLowercase == _openSettingsConfiguration.IdentifierNameLowercase)
                .Select(c => new
                {
                    c.Provider
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity != null)
            {
                _providerInfo.Redis.IsActive = entity.Provider.Redis.IsActive;
                _providerInfo.Redis.Configuration = entity.Provider.Redis.Configuration;
                _providerInfo.Redis.Channel = entity.Provider.Redis.Channel;

                _openSettingsConfiguration.Provider.CompressionType = entity.Provider.CompressionType;
                _openSettingsConfiguration.Provider.CompressionLevel = entity.Provider.CompressionLevel;
            }

            var providerInfo = new ProviderInfo
            {
                Client = new ProviderInfoClient
                {
                    Id = _providerInfo.Client.Id,
                    Name = _providerInfo.Client.Name,
                    Version = _providerInfo.Client.Version,
                },
                Authorize = _providerInfo.Authorize,
                PackInfo = new PackInfo
                {
                    Version = _providerInfo.PackInfo.Version,
                    Score = _providerInfo.PackInfo.Score,
                    IsPreview = _providerInfo.PackInfo.IsPreview
                },
                OAuth2 = new OAuth2Info
                {
                    Authority = _providerInfo.OAuth2.Authority,
                    AllowOfflineAccess = _providerInfo.OAuth2.AllowOfflineAccess,
                    IsActive = _providerInfo.OAuth2.IsActive
                },
                Redis = new RedisInfo
                {
                    Channel = _providerInfo.Redis.Channel,
                    Configuration = _providerInfo.Redis.Configuration,
                    IsActive = _providerInfo.Redis.IsActive
                }
            };

            return HttpStatusCode.OK.ToSuccessResponseOf(providerInfo);
        }

        public async Task<IResponse> GetPrimaryProviderAsync(CancellationToken cancellationToken = default)
        {
            var primaryProvider = await _context.ProviderRegistries
                .AsNoTracking()
                .Where(p => p.Type == ProviderRegistryType.Master)
                .OrderBy(p => p.LastHeartbeatOn)
                .Select(p => new GetPrimaryProviderResponse
                {
                    Id = p.Id,
                    Type = p.Type,
                    ClientId = p.ClientId,
                    Scheme = p.Scheme,
                    Host = p.Host,
                    Port = p.Port,
                    Region = p.Region,
                    Version = p.Version,
                    PackVersion = p.PackVersion,
                    LastHeartbeatOn = p.LastHeartbeatOn,
                    CreatedOn = p.CreatedOn
                })
                .FirstOrDefaultAsync(cancellationToken);

            return primaryProvider == null
                ? HttpStatusCode.NotFound.ToFailureResponse(Errors.PrimaryProviderNotFound)
                : HttpStatusCode.OK.ToSuccessResponse(primaryProvider);
        }
    }
}