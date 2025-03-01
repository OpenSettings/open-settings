using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Ogu.Response.Json;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Services.MemoryCache;
using OpenSettings.Services.Sql.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql
{
    internal sealed class ProviderSqlService : IProviderSqlService
    {
        private static readonly CacheModel GetProviderAsyncCache = new CacheModel("pss:gpa", TimeSpan.FromSeconds(30));

        private readonly OpenSettingsDbContext _context;
        private readonly ProviderInfo _providerInfo;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly IMemoryCache _memoryCache;

        public ProviderSqlService(OpenSettingsDbContext context, ProviderInfo providerInfo, OpenSettingsConfiguration openSettingsConfiguration, OpenSettingsMemoryCache memoryCache)
        {
            _context = context;
            _providerInfo = providerInfo;
            _openSettingsConfiguration = openSettingsConfiguration;
            _memoryCache = memoryCache;
        }

        public async Task<IJsonResponse<ProviderInfo>> GetProviderAsync(CancellationToken cancellationToken = default)
        {
            if (GetProviderAsyncCache.TryGetValue<IJsonResponse<ProviderInfo>>(_memoryCache, out var response))
            {
                return response;
            }

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

            response = HttpStatusCode.OK.ToSuccessJsonResponseOf(_providerInfo);

            GetProviderAsyncCache.Set(_memoryCache, response);

            return HttpStatusCode.OK.ToSuccessJsonResponseOf(_providerInfo);
        }
    }
}