using Microsoft.EntityFrameworkCore;
using Ogu.Response.Json;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Sql.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql
{
    internal sealed class SortOrderSqlService : ISortOrderSqlService
    {
        private readonly ILocksSqlService _locksSqlService;
        private readonly OpenSettingsDbContext _context;
        private readonly Guid _clientId;

        public SortOrderSqlService(ILocksSqlService locksSqlService, OpenSettingsDbContext context, OpenSettingsConfiguration openSettingsConfiguration)
        {
            _locksSqlService = locksSqlService;
            _context = context;
            _clientId = openSettingsConfiguration.Client.Id;
        }

        public IQueryable<T> FindNeighbour<T>(DbSet<T> items, int id, int order, bool ascent) where T : class, IOrderedEntity, new()
        {
            return ascent
                ? items.AsNoTracking().Where(a => a.SortOrder >= order && a.Id != id).OrderBy(a => a.SortOrder)
                : items.AsNoTracking().Where(a => a.SortOrder <= order && a.Id != id).OrderByDescending(a => a.SortOrder);
        }

        public async Task<IJsonResponse> ReorderAsync<T>(DbSet<T> items, CancellationToken cancellationToken) where T : class, IOrderedEntity, new()
        {
            try
            {
                await ReorderAsync(items);

                return HttpStatusCode.Conflict.ToFailureJsonResponse(Errors.SortOrderBeingReprocessed);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return await ex.ToJsonResponseAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return ex.ToJsonResponse();
            }
        }

        public async Task<ReorderResponse> ReorderAsync<T>(DbSet<T> items) where T : class, IOrderedEntity, new()
        {
            var key = typeof(T).Name;

            var lockAcquired = await _locksSqlService.AcquireLockAsync(new AcquireLockInput
            {
                Key = key,
                Owner = Environment.MachineName,
                Timeout = TimeSpan.FromSeconds(45)
            });

            if (!lockAcquired)
            {
                return null;
            }

            try
            {
                var entities = await items
                    .Select(i => new T { Id = i.Id, SortOrder = i.SortOrder, RowVersion = i.RowVersion })
                    .OrderBy(i => i.SortOrder)
                    .ToArrayAsync();

                const int batchSize = 100;

                var batchCount = (int)Math.Ceiling((double)entities.Length / batchSize);

                var currentTime = DateTime.UtcNow;

                var response = new ReorderResponse
                {
                    RowVersion = currentTime.ToRowVersion()
                };

                for (var batchIndex = 0; batchIndex < batchCount; batchIndex++)
                {
                    var batch = entities.Skip(batchIndex * batchSize).Take(batchSize).ToArray();

                    for (var i = 0; i < batch.Length; i++)
                    {
                        var entity = batch[i];

                        var newOrder = batchIndex * batchSize + i * 10;

                        if (newOrder == entity.SortOrder)
                        {
                            continue;
                        }

                        _context.Attach(entity);

                        entity.SortOrder = newOrder;
                        entity.RowVersion = response.RowVersion;
                        entity.UpdatedOn = currentTime;
                        entity.UpdatedById = _clientId;

                        response.IdToSortOrder[$"{entity.Id}"] = entity.SortOrder;
                    }

                    await _context.SaveChangesAsync();
                }

                foreach (var entity in entities)
                {
                    _context.Entry(entity).State = EntityState.Detached;
                }

                return response;
            }
            finally
            {
                await _locksSqlService.ReleaseLockAsync(new ReleaseLockInput
                {
                    Key = key,
                    Owner = Environment.MachineName
                });
            }
        }

        public async Task<int> MinSortOrderAsync<T>(DbSet<T> items, CancellationToken cancellationToken = default) where T : class, IOrderedEntity, new()
        {
            try
            {
                return await items.AsNoTracking().MinAsync(i => i.SortOrder, cancellationToken);
            }
            catch (InvalidOperationException)
            {
                return 0;
            }
        }

        public async Task<int> MaxSortOrderAsync<T>(DbSet<T> items, CancellationToken cancellationToken = default) where T : class, IOrderedEntity, new()
        {
            try
            {
                return await items.AsNoTracking().MaxAsync(i => i.SortOrder, cancellationToken);
            }
            catch (InvalidOperationException)
            {
                return 0;
            }
        }

        public async Task<SortOrderBounds> GetSortOrderBoundsAsync<T>(DbSet<T> items, CancellationToken cancellationToken = default) where T : class, IOrderedEntity, new()
        {
            return await items.AsNoTracking().GroupBy(i => 1).Select(g => new SortOrderBounds
            {
                Count = g.Count(),
                MinSortOrder = g.Min(i => i.SortOrder),
                MaxSortOrder = g.Max(i => i.SortOrder)
            }).FirstOrDefaultAsync(cancellationToken);
        }
    }
}