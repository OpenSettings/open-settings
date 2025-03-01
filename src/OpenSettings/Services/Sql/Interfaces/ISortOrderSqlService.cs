using Microsoft.EntityFrameworkCore;
using Ogu.Response.Json;
using OpenSettings.Domains.Sql;
using OpenSettings.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql.Interfaces
{
    internal interface ISortOrderSqlService
    {
        IQueryable<T> FindNeighbour<T>(DbSet<T> items, int id, int order, bool ascent) where T : class, IOrderedEntity, new();

        Task<IJsonResponse> ReorderAsync<T>(DbSet<T> items, CancellationToken cancellationToken) where T : class, IOrderedEntity, new();

        Task<ReorderResponse> ReorderAsync<T>(DbSet<T> items) where T : class, IOrderedEntity, new();

        Task<int> MinSortOrderAsync<T>(DbSet<T> items, CancellationToken cancellationToken = default) where T: class, IOrderedEntity, new();

        Task<int> MaxSortOrderAsync<T>(DbSet<T> items, CancellationToken cancellationToken = default) where T: class, IOrderedEntity, new();

        Task<SortOrderBounds> GetSortOrderBoundsAsync<T>(DbSet<T> items, CancellationToken cancellationToken = default) where T : class, IOrderedEntity, new();
    }
}