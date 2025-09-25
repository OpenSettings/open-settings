using Microsoft.EntityFrameworkCore;
using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
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
        private readonly ILockSqlService _locksSqlService;
        private readonly OpenSettingsDbContext _context;

        public SortOrderSqlService(ILockSqlService locksSqlService, OpenSettingsDbContext context)
        {
            _locksSqlService = locksSqlService;
            _context = context;
        }

        public IQueryable<T> FindNeighbour<T>(DbSet<T> items, Guid id, int sortOrder, MoveDirection direction) where T : class, IOrderedEntity, new()
        {
            return direction == MoveDirection.Down
                ? items.AsNoTracking().Where(a => a.SortOrder >= sortOrder && a.Id != id).OrderBy(a => a.SortOrder)
                : items.AsNoTracking().Where(a => a.SortOrder <= sortOrder && a.Id != id).OrderByDescending(a => a.SortOrder);
        }

        public async Task<IResponse> ReorderAsync<T>(DbSet<T> items, Guid? updatedById, CancellationToken cancellationToken) where T : class, IOrderedEntity, new()
        {
            try
            {
                await ReorderAsync(items, updatedById, CancellationToken.None);

                return HttpStatusCode.Conflict.ToFailureResponse(Errors.SortOrderBeingReprocessed);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return await ex.ToResponseAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return ex.ToResponse();
            }
        }

        public async Task<ReorderResponse> ReorderAsync<T>(DbSet<T> items, Guid? updatedById) where T : class, IOrderedEntity, new()
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
                    RowVersion = RowVersionHelper.Date(currentTime)
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
                        entity.UpdatedById = updatedById;

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