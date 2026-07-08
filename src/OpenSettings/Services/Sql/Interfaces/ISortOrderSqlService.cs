using Microsoft.EntityFrameworkCore;
using Ogu.Response.Abstractions;
using OpenSettings.Domains.Sql;
using OpenSettings.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql.Interfaces
{
    internal interface ISortOrderSqlService
    {
        IQueryable<T> FindNeighbour<T>(DbSet<T> items, Guid id, int sortOrder, MoveDirection direction) where T : class, IOrderedEntity, new();

        Task<IResponse> ReorderAsync<T>(DbSet<T> items, Guid? updatedById, CancellationToken cancellationToken) where T : class, IOrderedEntity, new();

        Task<ReorderOutput> ReorderAsync<T>(DbSet<T> items, Guid? updatedById) where T : class, IOrderedEntity, new();

        Task<int> MinSortOrderAsync<T>(DbSet<T> items, CancellationToken cancellationToken = default) where T: class, IOrderedEntity, new();

        Task<int> MaxSortOrderAsync<T>(DbSet<T> items, CancellationToken cancellationToken = default) where T: class, IOrderedEntity, new();

        Task<SortOrderBounds> GetSortOrderBoundsAsync<T>(DbSet<T> items, CancellationToken cancellationToken = default) where T : class, IOrderedEntity, new();
    }
}