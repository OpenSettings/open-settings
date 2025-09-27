using Microsoft.EntityFrameworkCore;
using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Sql.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql
{
    internal sealed class IdentifierSqlService : IIdentifierSqlService
    {
        private readonly OpenSettingsDbContext _context;
        private readonly ISortOrderSqlService _sortOrderService;

        public IdentifierSqlService(OpenSettingsDbContext context, ISortOrderSqlService sortOrderService)
        {
            _context = context;
            _sortOrderService = sortOrderService;
        }

        public async Task<IResponse> GetPaginatedIdentifiersAsync(GetPaginatedInput input, CancellationToken cancellationToken = default)
        {
            var sortOrderBounds = await _sortOrderService.GetSortOrderBoundsAsync(_context.Identifiers, cancellationToken);

            if (sortOrderBounds == null)
            {
                return HttpStatusCode.OK.ToSuccessResponse(new GetPaginatedIdentifiersResponse(input, 0, null, 0, 0));
            }

            if (string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                return await GetUnfilteredPaginatedIdentifiersAsync(input, sortOrderBounds, cancellationToken);
            }

            try
            {
                var searchLowercase = input.SearchTerm.ToLowerInvariant();

                var filteredQuery = _context.Identifiers
                    .AsNoTracking()
                    .SearchBy(a => a.NameLowercase, searchLowercase, _context);

                var filteredTotalItemsCount = await filteredQuery.CountAsync(cancellationToken);

                var filteredEntitiesQuery = filteredQuery
#if !NETSTANDARD2_0
                    .AsSplitQuery()
#endif
                    .Include(a => a.AppIdentifierMappings)
                    .Include(a => a.CreatedBy)
                    .Include(a => a.UpdatedBy)
                    .OrderBy(a => a.NameLowercase.IndexOf(searchLowercase));

                filteredEntitiesQuery = string.IsNullOrWhiteSpace(input.SortBy)
                    ? filteredEntitiesQuery.ThenBy(a => a.SortOrder)
                    : Sort(null, filteredEntitiesQuery, input.SortBy, input.SortDirection);

                var filteredEntities = await filteredEntitiesQuery
                    .Select(entity => MapToIdentifierModelForPaginatedResponseData(entity))
                    .ToPaginatedArrayAsync(input.PageIndex, input.PageSize, cancellationToken);

                return HttpStatusCode.OK.ToSuccessResponse(new GetPaginatedIdentifiersResponse(input, filteredTotalItemsCount, filteredEntities, sortOrderBounds.MinSortOrder, sortOrderBounds.MaxSortOrder));
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError.ToFailureResponse(ex);
            }
        }

        public async Task<IResponse> DeleteUnmappedIdentifiersAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _context.Identifiers
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppIdentifierMappings)
                .Where(a => !a.AppIdentifierMappings.Any())
                .Select(a => new IdentifierSqlModel { Id = a.Id, RowVersion = a.RowVersion })
                .ToArrayAsync(cancellationToken);

            if (entities.Length == 0)
            {
                return HttpStatusCode.OK.ToSuccessResponse(new DeleteUnmappedItemsResponse { DeletedItemCount = 0 });
            }

            _context.Identifiers.RemoveRange(entities);

            try
            {
                var count = await _context.SaveChangesAsync(cancellationToken);

                return HttpStatusCode.OK.ToSuccessResponse(new DeleteUnmappedItemsResponse { DeletedItemCount = count });
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

        public async Task<IResponse> GetIdentifiersAsync(GetIdentifiersInput input, CancellationToken cancellationToken = default)
        {
            if (!string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                return await GetIdentifiersBySearchAsync(input, cancellationToken);
            }

            var query = _context.Identifiers.AsNoTracking();

            if (input.AppId.HasValue && input.AppId != Guid.Empty)
            {
                query = query
                    .Include(a => a.AppIdentifierMappings)
                    .Where(a => input.IsAppMapped
                        ? a.AppIdentifierMappings.Any(m => m.AppId == input.AppId.Value)
                        : a.AppIdentifierMappings.All(m => m.AppId != input.AppId.Value));
            }

            var data = await query
                .OrderBy(a => a.SortOrder)
                .Select(a => new GetIdentifiersResponseIdentifier
                {
                    Id = $"{a.Id}",
                    Name = a.Name,
                    Slug = a.Slug,
                    SortOrder = a.SortOrder,
                    RowVersion = a.RowVersion
                }).ToArrayAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse(new GetIdentifiersResponse(data));
        }

        public async Task<IResponse> CreateIdentifierAsync(CreateIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var nameRule = ValidationRules.NotEmptyRule(nameof(input.Name), input.Name);

            if (nameRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(nameRule.Failure);
            }

            var trimmedName = input.Name.Trim();
            var trimmedNameLowercase = trimmedName.ToLowerInvariant();
            var slug = trimmedName.ToSlug();

            if (await _context.Identifiers.AsNoTracking().AnyAsync(s => s.Slug == slug, cancellationToken))
            {
                return ValidationFailures.AlreadyExists(nameof(AppTagSqlModel.Slug), slug).ToResponse();
            }

            if (input.SetSortOrderPosition.HasValue)
            {
                try
                {
                    input.SortOrder = input.SetSortOrderPosition == SetSortOrderPosition.Bottom
                        ? await _context.Identifiers.AsNoTracking().MaxAsync(s => s.SortOrder, cancellationToken) + OpenSettingsDefaults.SortOrderGap
                        : await _context.Identifiers.AsNoTracking().MinAsync(s => s.SortOrder, cancellationToken) - OpenSettingsDefaults.SortOrderGap;
                }
                catch (InvalidOperationException)
                {
                    // ignored
                }
            }
            else if(await _context.Identifiers.AsNoTracking().AnyAsync(s => s.SortOrder == input.SortOrder, cancellationToken))
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.DuplicateSortOrder);
            }

            var entity = new IdentifierSqlModel
            {
                Name = trimmedName,
                NameLowercase = trimmedNameLowercase,
                Slug = slug,
                SortOrder = input.SortOrder,
                CreatedOn = DateTime.UtcNow,
                CreatedById = input.CreatedById
            };

            _context.Identifiers.Add(entity);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                return HttpStatusCode.OK.ToSuccessResponse(new CreateIdentifierResponse
                {
                    Id = $"{entity.Id}",
                    Name = entity.Name,
                    SortOrder = entity.SortOrder
                });
            }
            catch (Exception ex)
            {
                return ex.ToResponse();
            }
        }

        public async Task<IResponse> GetIdentifierByIdAsync(GetIdentifierInput input, CancellationToken cancellationToken = default)
        {
            return await GetIdentifierByIdOrSlugAsync(s => s.Id == Guid.Parse(input.IdentifierIdOrSlug), cancellationToken);
        }

        public Task<IResponse> GetIdentifierBySlugAsync(GetIdentifierInput input, CancellationToken cancellationToken = default)
        {
            input.IdentifierIdOrSlug = input.IdentifierIdOrSlug?.ToSlug();

            return GetIdentifierByIdOrSlugAsync(s => s.Slug == input.IdentifierIdOrSlug, cancellationToken);
        }

        public async Task<IResponse> UpdateIdentifierAsync(UpdateIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var nameRule = ValidationRules.NotEmptyRule(nameof(input.Name), input.Name);

            if (nameRule.IsFailed())
            {
                return nameRule.Failure.ToResponse();
            }

            var trimmedName = input.Name.Trim();
            var trimmedNameLowercase = trimmedName.ToLowerInvariant();
            var slug = trimmedName.ToSlug();

            if (await _context.Identifiers.AsNoTracking().AnyAsync(s => s.Slug == slug && s.Id != input.IdentifierId, cancellationToken))
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.IdentifierAlreadyExists);
            }

            if (input.SetSortOrderPosition.HasValue)
            {
                try
                {
                    if (input.SetSortOrderPosition == SetSortOrderPosition.Bottom)
                    {
                        var maxOrder = await _context.Identifiers.AsNoTracking().Where(s => s.Id != input.IdentifierId).MaxAsync(s => s.SortOrder, cancellationToken);

                        input.SortOrder = input.SortOrder > maxOrder ? input.SortOrder : maxOrder + OpenSettingsDefaults.SortOrderGap;
                    }
                    else
                    {
                        var minOrder = await _context.Identifiers.AsNoTracking().Where(s => s.Id != input.IdentifierId).MinAsync(s => s.SortOrder, cancellationToken);

                        input.SortOrder = input.SortOrder < minOrder ? input.SortOrder : minOrder - OpenSettingsDefaults.SortOrderGap;
                    }
                }
                catch(InvalidOperationException)
                {
                    // ignored
                }
            }
            else if (await _context.Identifiers.AsNoTracking().AnyAsync(s => s.Id != input.IdentifierId && s.SortOrder == input.SortOrder, cancellationToken))
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.DuplicateSortOrder);
            }

            var entity = new IdentifierSqlModel
            {
                Id = input.IdentifierId,
                RowVersion = input.RowVersion
            };

            _context.Identifiers.Attach(entity);

            var currentTime = DateTime.UtcNow;

            entity.Name = trimmedName;
            entity.NameLowercase = trimmedNameLowercase;
            entity.Slug = slug;
            entity.SortOrder = input.SortOrder;
            entity.UpdatedById = input.UpdatedById;
            entity.UpdatedOn = currentTime;
            entity.RowVersion = RowVersionHelper.Date(currentTime);

            _context.MarkAsModified(entity,
                e => e.Name,
                e => e.NameLowercase,
                e => e.Slug,
                e => e.SortOrder,
                e => e.UpdatedById,
                e => e.UpdatedOn,
                e => e.RowVersion);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                return HttpStatusCode.OK.ToSuccessResponse(new UpdateIdentifierResponse(
                    entity.Name,
                    entity.Slug,
                    entity.SortOrder,
                    entity.UpdatedById,
                    currentTime,
                    entity.RowVersion));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return await ex.ToResponseAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                return HttpStatusCode.InternalServerError.ToFailureResponse(ex.HResult == -2146233088 ? Errors.UserNotFound : Errors.DbUpdateException);
            }
            catch (Exception ex)
            {
                return ex.ToResponse();
            }
        }

        public async Task<IResponse> DeleteIdentifierAsync(DeleteIdentifierInput input, CancellationToken cancellationToken = default)
        {
            _context.Identifiers.Remove(new IdentifierSqlModel { Id = input.IdentifierId, RowVersion = input.RowVersion });

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                return HttpStatusCode.OK.ToSuccessResponse();
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

        public async Task<IResponse> UpdateIdentifierSortOrderAsync(UpdateIdentifierSortOrderInput input, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Identifiers
                .AsNoTracking()
                .Where(a => a.Id == input.IdentifierId)
                .OrderBy(a => a.Id)
                .Select(a => new IdentifierSqlModel
                {
                    Id = input.IdentifierId,
                    SortOrder = a.SortOrder,
                    RowVersion = a.RowVersion 
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.IdentifierNotFound);
            }

            if (!input.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict($"{input.IdentifierId}", entity.RowVersion, input.RowVersion, false);
            }

            var foundEntity = await _sortOrderService.FindNeighbour(_context.Identifiers, entity.Id, entity.SortOrder, input.Direction)
                .Select(a => new IdentifierSqlModel
                {
                    Id = a.Id,
                    SortOrder = a.SortOrder,
                    RowVersion = a.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (foundEntity == null)
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(input.Direction == MoveDirection.Down ? Errors.MaxSortOrderReached : Errors.MinSortOrderReached);
            }

            if (entity.SortOrder == foundEntity.SortOrder)
            {
                return await _sortOrderService.ReorderAsync(_context.Identifiers, input.UpdatedById,cancellationToken);
            }

            _context.Identifiers.AttachRange(foundEntity, entity);

            var currentTime = DateTime.UtcNow;
            var rowVersion = RowVersionHelper.Date(currentTime);

            (entity.SortOrder, foundEntity.SortOrder) = (foundEntity.SortOrder, entity.SortOrder);

            foundEntity.UpdatedOn = currentTime;
            foundEntity.UpdatedById = input.UpdatedById;
            foundEntity.RowVersion = rowVersion;

            entity.UpdatedOn = currentTime;
            entity.UpdatedById = input.UpdatedById;
            entity.RowVersion = rowVersion;

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                return HttpStatusCode.OK.ToSuccessResponse();
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

        public async Task<IResponse> DragIdentifierAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default)
        {
            var ids = new[] { input.SourceId, input.TargetId };

            var entities = await _context.Identifiers
                .AsNoTracking()
                .Where(a => ids.Contains(a.Id))
                .Select(a => new IdentifierSqlModel
                {
                    Id = a.Id,
                    SortOrder = a.SortOrder,
                    RowVersion = a.RowVersion
                }).ToArrayAsync(cancellationToken);

            var sourceEntity = entities.FirstOrDefault(a => a.Id == input.SourceId);

            if (sourceEntity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.SourceIdentifierNotFound);
            }

            if (!input.SourceRowVersion.SequenceEqual(sourceEntity.RowVersion))
            {
                return FailureResponses.Conflict($"{input.SourceId}", sourceEntity.RowVersion, input.SourceRowVersion, false);
            }

            var targetEntity = entities.FirstOrDefault(a => a.Id == input.TargetId);

            if (targetEntity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.TargetIdentifierNotFound);
            }

            if (sourceEntity.SortOrder == targetEntity.SortOrder)
            {
                return await _sortOrderService.ReorderAsync(_context.Identifiers, input.UpdatedById, cancellationToken);
            }

            var targetNeighbour = await _sortOrderService
                .FindNeighbour(_context.Identifiers, targetEntity.Id, targetEntity.SortOrder, input.Direction)
                .Select(s => new { s.Id, Order = s.SortOrder })
                .FirstOrDefaultAsync(cancellationToken);

            if (targetNeighbour == null)
            {
                targetNeighbour = new
                {
                    Id = Guid.Empty,
                    Order = input.Direction == MoveDirection.Down ? targetEntity.SortOrder + OpenSettingsDefaults.SortOrderGap : targetEntity.SortOrder - OpenSettingsDefaults.SortOrderGap
                };
            }
            else if (targetNeighbour.Id == sourceEntity.Id)
            {
                return HttpStatusCode.OK.ToSuccessResponse(new DragItemSortOrderResponse
                {
                    Source = new DragItemSortOrderResponseSource
                    {
                        NewSortOrder = sourceEntity.SortOrder,
                        OldSortOrder = sourceEntity.SortOrder,
                        RowVersion = sourceEntity.RowVersion
                    }
                });
            }

            var sourceNewSortOrder = (targetEntity.SortOrder + targetNeighbour.Order) / 2;
            var sourceOldSortOrder = sourceEntity.SortOrder;

            var anyMatch = await _context.Identifiers.AsNoTracking().AnyAsync(s => s.SortOrder == sourceNewSortOrder, cancellationToken);

            if (anyMatch)
            {
                return await _sortOrderService.ReorderAsync(_context.Identifiers, input.UpdatedById,cancellationToken);
            }

            var currentTime = DateTime.UtcNow;

            var rowVersion = RowVersionHelper.Date(currentTime);

            _context.Identifiers.Attach(sourceEntity);

            sourceEntity.SortOrder = sourceNewSortOrder;
            sourceEntity.UpdatedOn = currentTime;
            sourceEntity.UpdatedById = input.UpdatedById;
            sourceEntity.RowVersion = rowVersion;

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                return HttpStatusCode.OK.ToSuccessResponse(new DragItemSortOrderResponse
                {
                    Source = new DragItemSortOrderResponseSource
                    {
                        NewSortOrder = sourceNewSortOrder,
                        OldSortOrder = sourceOldSortOrder,
                        RowVersion = rowVersion
                    }
                });
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

        public async Task<IResponse<GetOrCreateResponse>> GetOrCreateAsync(string name, SetSortOrderPosition setSortOrderPosition, Guid? createdById, CancellationToken cancellationToken = default)
        {
            name = name.Trim();
            var nameLowercase = name.ToLowerInvariant();
            var slug = name.ToSlug();

            var entity = await _context.Identifiers
                .AsNoTracking()
                .Where(a => a.Slug == slug)
                .OrderBy(a => a.Id)
                .Select(a => new IdentifierSqlModel { Id = a.Id, Name = a.Name, SortOrder = a.SortOrder })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity != null)
            {
                return HttpStatusCode.OK.ToSuccessResponseOf(new GetOrCreateResponse
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Slug = slug,
                    SortOrder = entity.SortOrder,
                    IsNewlyCreated = false
                });
            }

            int sortOrder;

            try
            {
                sortOrder = setSortOrderPosition == SetSortOrderPosition.Bottom
                    ? await _context.Identifiers.AsNoTracking().MaxAsync(s => s.SortOrder, cancellationToken) + OpenSettingsDefaults.SortOrderGap
                    : await _context.Identifiers.AsNoTracking().MinAsync(s => s.SortOrder, cancellationToken) - OpenSettingsDefaults.SortOrderGap;
            }
            catch(InvalidOperationException)
            {
                sortOrder = 0;
            }

            entity = new IdentifierSqlModel
            {
                Id = Guid.NewGuid(),
                Name = name,
                NameLowercase = nameLowercase,
                Slug = slug,
                SortOrder = sortOrder,
                CreatedById = createdById,
                CreatedOn = DateTime.UtcNow
            };

            _context.Identifiers.Add(entity);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                _context.Detach(entity);

                return HttpStatusCode.OK.ToSuccessResponseOf(new GetOrCreateResponse
                {
                    Id = entity.Id,
                    Name = name,
                    Slug = slug,
                    SortOrder = sortOrder,
                    IsNewlyCreated = true
                });
            }
            catch (Exception ex)
            {
                return ex.ToResponse<GetOrCreateResponse>();
            }
        }

        public async Task<IResponse> ReorderIdentifiersAsync(Guid? updatedById)
        {
            try
            {
                var reorderResponse = await _sortOrderService.ReorderAsync(_context.Identifiers, updatedById);

                return HttpStatusCode.OK.ToSuccessResponse(reorderResponse);
            }
            catch (Exception ex)
            {
                return ex.ToResponse();
            }
        }

        private async Task<IResponse> GetIdentifierByIdOrSlugAsync(Expression<Func<IdentifierSqlModel, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Identifiers
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(a => a.Id)
                .Select(a => new GetIdentifierResponse
                {
                    Id = a.Id,
                    Name = a.Name,
                    Slug = a.Slug,
                    SortOrder = a.SortOrder,
                    RowVersion = a.RowVersion
                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureResponse(Errors.IdentifierNotFound)
                : HttpStatusCode.OK.ToSuccessResponse(entity);
        }

        private async Task<IResponse> GetUnfilteredPaginatedIdentifiersAsync(GetPaginatedInput input, SortOrderBounds sortOrderBounds, CancellationToken cancellationToken = default)
        {
            try
            {
                var unfilteredQuery = _context.Identifiers.AsNoTracking();

                var unfilteredEntitiesQuery = unfilteredQuery
#if !NETSTANDARD2_0
                    .AsSplitQuery()
#endif
                    .Include(a => a.AppIdentifierMappings)
                    .Include(a => a.CreatedBy)
                    .Include(a => a.UpdatedBy)
                    .AsQueryable();

                unfilteredEntitiesQuery = string.IsNullOrWhiteSpace(input.SortBy)
                    ? unfilteredEntitiesQuery.OrderBy(a => a.SortOrder)
                    : Sort(unfilteredEntitiesQuery, null, input.SortBy, input.SortDirection);

                var unfilteredEntities = await unfilteredEntitiesQuery
                    .Select(entity => MapToIdentifierModelForPaginatedResponseData(entity))
                    .ToPaginatedArrayAsync(input.PageIndex, input.PageSize, cancellationToken);

                return HttpStatusCode.OK.ToSuccessResponse(new GetPaginatedIdentifiersResponse(input, sortOrderBounds.Count, unfilteredEntities, sortOrderBounds.MinSortOrder, sortOrderBounds.MaxSortOrder));
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError.ToFailureResponse(ex);
            }
        }

        private async Task<IResponse> GetIdentifiersBySearchAsync(GetIdentifiersInput input, CancellationToken cancellationToken)
        {
            var searchLowercase = input.SearchTerm.ToLowerInvariant();

            var query = _context.Identifiers.AsNoTracking();

            if (input.AppId.HasValue && input.AppId != Guid.Empty)
            {
                query = query
                    .Include(a => a.AppIdentifierMappings)
                    .Where(a => input.IsAppMapped
                        ? a.AppIdentifierMappings.Any(m => m.AppId == input.AppId.Value)
                        : a.AppIdentifierMappings.All(m => m.AppId != input.AppId.Value));
            }

            var data = await query.SearchBy(a => a.NameLowercase, searchLowercase, _context)
                .OrderBy(a => a.NameLowercase.IndexOf(searchLowercase))
                .ThenBy(a => a.SortOrder)
                .Select(a => new GetIdentifiersResponseIdentifier
                {
                    Id = $"{a.Id}",
                    Name = a.Name,
                    Slug = a.Slug,
                    SortOrder = a.SortOrder,
                    RowVersion = a.RowVersion
                }).ToArrayAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse(new GetIdentifiersResponse(data));
        }

        private static IOrderedQueryable<IdentifierSqlModel> Sort(
            IQueryable<IdentifierSqlModel> source,
            IOrderedQueryable<IdentifierSqlModel> orderedSource,
            string sortBy,
            SortDirection direction
        )
        {
            var key = (sortBy ?? string.Empty).Trim().ToLowerInvariant();

            switch (key)
            {
                case "id":
                    return Helper.ApplySorting(source, orderedSource, a => a.Id, direction);
                case "name":
                    return Helper.ApplySorting(source, orderedSource, a => a.Name, direction);
                case "sortorder":
                    return Helper.ApplySorting(source, orderedSource, a => a.SortOrder, direction);
                case "mappingcount":
                    return Helper.ApplySorting(source, orderedSource, a => a.AppIdentifierMappings.Count(), direction);
                case "createdon":
                    return Helper.ApplySorting(source, orderedSource, a => a.CreatedOn, direction);
                case "createdby":
                    return Helper.ApplySorting(source, orderedSource, a => a.CreatedBy, direction);
                case "updatedon":
                    return Helper.ApplySorting(source, orderedSource, a => a.UpdatedOn, direction);
                case "updatedby":
                    return Helper.ApplySorting(source, orderedSource, a => a.UpdatedBy, direction);
                default:
                    return Helper.ApplySorting(source, orderedSource, a => a.Id, direction);
            }
        }

        private static ModelForPaginatedResponseData MapToIdentifierModelForPaginatedResponseData(IdentifierSqlModel entity)
        {
            return new ModelForPaginatedResponseData
            {
                Id = $"{entity.Id}",
                Name = entity.Name,
                Slug = entity.Slug,
                SortOrder = entity.SortOrder,
                MappingCount = entity.AppIdentifierMappings.Count(),
                CreatedOn = entity.CreatedOn,
                UpdatedOn = entity.UpdatedOn,
                CreatedBy = entity.CreatedBy?.DisplayName,
                UpdatedBy = entity.UpdatedBy?.DisplayName,
                RowVersion = entity.RowVersion
            };
        }
    }
}