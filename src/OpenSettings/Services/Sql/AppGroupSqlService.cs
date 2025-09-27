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
    internal sealed class AppGroupSqlService : IAppGroupSqlService
    {
        private readonly OpenSettingsDbContext _context;
        private readonly ISortOrderSqlService _sortOrderService;

        public AppGroupSqlService(OpenSettingsDbContext context, ISortOrderSqlService sortOrderService)
        {
            _context = context;
            _sortOrderService = sortOrderService;
        }

        public async Task<IResponse> GetPaginatedAppGroupsAsync(GetPaginatedInput input, CancellationToken cancellationToken = default)
        {
            var sortOrderBounds = await _sortOrderService.GetSortOrderBoundsAsync(_context.AppGroups, cancellationToken);

            if (sortOrderBounds == null)
            {
                return HttpStatusCode.OK.ToSuccessResponse(new GetPaginatedAppGroupsResponse(input, 0, null, 0, 0));
            }

            if (string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                return await GetUnfilteredPaginatedGroupsAsync(input, sortOrderBounds, cancellationToken);
            }

            try
            {
                var searchLowercase = input.SearchTerm.Trim().ToLowerInvariant();

                var filteredQuery = _context.AppGroups
                    .AsNoTracking()
                    .SearchBy(a => a.NameLowercase, searchLowercase, _context);

                var filteredTotalItemsCount = await filteredQuery.CountAsync(cancellationToken);

                var filteredEntitiesQuery = filteredQuery
#if !NETSTANDARD2_0
                    .AsSplitQuery()
#endif
                    .Include(a => a.Apps)
                    .Include(a => a.CreatedBy)
                    .Include(a => a.UpdatedBy)
                    .OrderBy(a => a.NameLowercase.IndexOf(searchLowercase));

                filteredEntitiesQuery = string.IsNullOrWhiteSpace(input.SortBy)
                    ? filteredEntitiesQuery.ThenBy(a => a.SortOrder)
                    : Sort(null, filteredEntitiesQuery, input.SortBy, input.SortDirection);

                var filteredEntities = await filteredEntitiesQuery
                    .Select(entity => MapToGroupModelForPaginatedResponseData(entity))
                    .ToPaginatedArrayAsync(input.PageIndex, input.PageSize, cancellationToken);

                return HttpStatusCode.OK.ToSuccessResponse(new GetPaginatedAppGroupsResponse(input, filteredTotalItemsCount, filteredEntities, sortOrderBounds.MinSortOrder, sortOrderBounds.MaxSortOrder));
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError.ToFailureResponse(ex);
            }
        }

        public async Task<IResponse> DeleteUnmappedAppGroupsAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _context.AppGroups
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.Apps)
                .Where(a => !a.Apps.Any())
                .Select(a => new AppGroupSqlModel { Id = a.Id, RowVersion = a.RowVersion })
                .ToArrayAsync(cancellationToken);

            if (entities.Length == 0)
            {
                return HttpStatusCode.OK.ToSuccessResponse(new DeleteUnmappedItemsResponse { DeletedItemCount = 0 });
            }

            _context.AppGroups.RemoveRange(entities);

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

        public async Task<IResponse> GetAppGroupsAsync(GetAppGroupsInput input, CancellationToken cancellationToken = default)
        {
            if (!string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                return await GetGroupsBySearchAsync(input, cancellationToken);
            }

            var query = _context.AppGroups.AsNoTracking();

            if (input.HasMappings.HasValue)
            {
                query = query
                    .Include(a => a.Apps)
#if !NETSTANDARD2_0
                    .AsSplitQuery()
#endif
                    .Include(a => a.Apps)
                    .Where(a => input.HasMappings.Value ? a.Apps.Any() : !a.Apps.Any());
            }

            var data = await query
                .OrderBy(a => a.SortOrder)
                .Select(a => new GetAppGroupsResponseGroup
                {
                    Id = $"{a.Id}",
                    Name = a.Name,
                    SortOrder = a.SortOrder,
                    RowVersion = a.RowVersion
                }).ToArrayAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse(new GetAppGroupsResponse(data));
        }

        public async Task<IResponse> CreateAppGroupAsync(CreateAppGroupInput input, CancellationToken cancellationToken = default)
        {
            var groupNameRule = ValidationRules.NotEmptyRule(nameof(input.Name), input.Name);

            if (groupNameRule.IsFailed())
            {
                return groupNameRule.Failure.ToResponse();
            }

            var trimmedName = input.Name.Trim();
            var trimmedNameLowercase = trimmedName.ToLowerInvariant();
            var slug = trimmedName.ToSlug();

            if (await _context.AppGroups.AsNoTracking().AnyAsync(s => s.Slug == slug, cancellationToken))
            {
                return ValidationFailures.AlreadyExists(nameof(AppTagSqlModel.Slug), slug).ToResponse();
            }

            if (input.SetSortOrderPosition.HasValue)
            {
                try
                {
                    input.SortOrder = input.SetSortOrderPosition == SetSortOrderPosition.Bottom
                        ? await _context.AppGroups.AsNoTracking().MaxAsync(s => s.SortOrder, cancellationToken) + OpenSettingsDefaults.SortOrderGap
                        : await _context.AppGroups.AsNoTracking().MinAsync(s => s.SortOrder, cancellationToken) - OpenSettingsDefaults.SortOrderGap;
                }
                catch (InvalidOperationException)
                {
                    // ignored
                }
            }
            else if (await _context.AppGroups.AsNoTracking().AnyAsync(s => s.SortOrder == input.SortOrder, cancellationToken))
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.DuplicateSortOrder);
            }

            var entity = new AppGroupSqlModel
            {
                Name = trimmedName,
                NameLowercase = trimmedNameLowercase,
                Slug = slug,
                SortOrder = input.SortOrder,
                CreatedOn = DateTime.UtcNow,
                CreatedById = input.CreatedById
            };

            _context.AppGroups.Add(entity);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                return HttpStatusCode.OK.ToSuccessResponse(new CreateAppGroupResponse
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

        public Task<IResponse> GetAppGroupByIdAsync(GetAppGroupInput input, CancellationToken cancellationToken = default)
        {
            return GetAppGroupByIdOrSlugAsync(g => g.Id == Guid.Parse(input.GroupIdOrSlug), cancellationToken);
        }

        public Task<IResponse> GetAppGroupBySlugAsync(GetAppGroupInput input, CancellationToken cancellationToken = default)
        {
            input.GroupIdOrSlug = input.GroupIdOrSlug?.ToSlug();

            return GetAppGroupByIdOrSlugAsync(g => g.Slug == input.GroupIdOrSlug, cancellationToken);
        }

        public async Task<IResponse> UpdateAppGroupAsync(UpdateAppGroupInput input, CancellationToken cancellationToken = default)
        {
            var nameRule = ValidationRules.NotEmptyRule(nameof(input.Name), input.Name);

            if (nameRule.IsFailed())
            {
                return nameRule.Failure.ToResponse();
            }

            var trimmedName = input.Name.Trim();
            var trimmedNameLowercase = trimmedName.ToLowerInvariant();
            var slug = trimmedName.ToSlug();

            if (await _context.AppGroups.AsNoTracking().AnyAsync(s => s.Slug == slug && s.Id != input.AppGroupId, cancellationToken))
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.GroupAlreadyExists);
            }

            if (input.SetSortOrderPosition.HasValue)
            {
                try
                {
                    if (input.SetSortOrderPosition == SetSortOrderPosition.Bottom)
                    {
                        var maxOrder = await _context.AppGroups.AsNoTracking().Where(s => s.Id != input.AppGroupId).MaxAsync(s => s.SortOrder, cancellationToken);

                        input.SortOrder = input.SortOrder > maxOrder ? input.SortOrder : maxOrder + OpenSettingsDefaults.SortOrderGap;
                    }
                    else
                    {
                        var minOrder = await _context.AppGroups.AsNoTracking().Where(s => s.Id != input.AppGroupId).MinAsync(s => s.SortOrder, cancellationToken);

                        input.SortOrder = input.SortOrder < minOrder ? input.SortOrder : minOrder - OpenSettingsDefaults.SortOrderGap;
                    }
                }
                catch (InvalidOperationException)
                {
                    // ignored
                }
            }
            else if (await _context.AppGroups.AsNoTracking().AnyAsync(s => s.Id != input.AppGroupId && s.SortOrder == input.SortOrder, cancellationToken))
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.DuplicateSortOrder);
            }

            var entity = new AppGroupSqlModel
            {
                Id = input.AppGroupId,
                RowVersion = input.RowVersion
            };

            _context.AppGroups.Attach(entity);

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

                return HttpStatusCode.OK.ToSuccessResponse(new UpdateAppGroupResponse(
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
                return HttpStatusCode.InternalServerError.ToFailureResponse(ex);
            }
        }

        public async Task<IResponse> DeleteAppGroupAsync(DeleteAppGroupInput input, CancellationToken cancellationToken = default)
        {
            _context.AppGroups.Remove(new AppGroupSqlModel { Id = input.AppGroupId, RowVersion = input.RowVersion });

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

        public async Task<IResponse> UpdateAppGroupSortOrderAsync(UpdateAppGroupSortOrderInput input, CancellationToken cancellationToken = default)
        {
            var entity = await _context.AppGroups
                .AsNoTracking()
                .Where(a => a.Id == input.AppGroupId)
                .OrderBy(a => a.Id)
                .Select(a => new AppGroupSqlModel
                {
                    Id = input.AppGroupId,
                    SortOrder = a.SortOrder,
                    RowVersion = a.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.GroupNotFound);
            }

            if (!input.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict($"{input.AppGroupId}", entity.RowVersion, input.RowVersion, false);
            }

            var foundEntity = await _sortOrderService.FindNeighbour(_context.AppGroups, entity.Id, entity.SortOrder, input.Direction)
                .Select(a => new AppGroupSqlModel
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
                return await _sortOrderService.ReorderAsync(_context.AppGroups, input.UpdatedById, cancellationToken);
            }

            _context.AppGroups.AttachRange(foundEntity, entity);

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

                return HttpStatusCode.OK.ToSuccessResponse(new UpdateSortOrderResponse
                {
                    Source = new UpdateSortOrderResponseSource
                    {
                        NewSortOrder = entity.SortOrder,
                        OldSortOrder = foundEntity.SortOrder
                    },
                    Neighbour = new UpdateSortOrderResponseNeighbour
                    {
                        Id = $"{foundEntity.Id}",
                        NewSortOrder = foundEntity.SortOrder,
                        OldSortOrder = entity.SortOrder
                    },
                    RowVersion = rowVersion
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

        public async Task<IResponse> DragAppGroupAsync(DragItemSortOrderInput input, CancellationToken cancellationToken = default)
        {
            var ids = new Guid[] { input.SourceId, input.TargetId };

            var entities = await _context.AppGroups
                .AsNoTracking()
                .Where(a => ids.Contains(a.Id))
                .Select(a => new AppGroupSqlModel
                {
                    Id = a.Id,
                    SortOrder = a.SortOrder,
                    RowVersion = a.RowVersion
                }).ToArrayAsync(cancellationToken);

            var sourceEntity = entities.FirstOrDefault(a => a.Id == input.SourceId);

            if (sourceEntity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.SourceGroupNotFound);
            }

            if (!input.SourceRowVersion.SequenceEqual(sourceEntity.RowVersion))
            {
                return FailureResponses.Conflict($"{input.SourceId}", sourceEntity.RowVersion, input.SourceRowVersion, false);
            }

            var targetEntity = entities.FirstOrDefault(a => a.Id == input.TargetId);

            if (targetEntity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.TargetGroupNotFound);
            }

            if (sourceEntity.SortOrder == targetEntity.SortOrder)
            {
                return await _sortOrderService.ReorderAsync(_context.AppGroups, input.UpdatedById,cancellationToken);
            }

            var targetNeighbour = await _sortOrderService
                .FindNeighbour(_context.AppGroups, targetEntity.Id, targetEntity.SortOrder, input.Direction)
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

            var anyMatch = await _context.AppGroups.AsNoTracking().AnyAsync(s => s.SortOrder == sourceNewSortOrder, cancellationToken);

            if (anyMatch)
            {
                return await _sortOrderService.ReorderAsync(_context.AppGroups, input.UpdatedById, cancellationToken);
            }

            var currentTime = DateTime.UtcNow;
            var rowVersion = RowVersionHelper.Date(currentTime);

            _context.AppGroups.Attach(sourceEntity);

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
            var trimmedNameLowercase = name.ToLowerInvariant();
            var slug = name.ToSlug();

            var entity = await _context.AppGroups
                .AsNoTracking()
                .Where(a => a.Slug == slug)
                .OrderBy(a => a.Id)
                .Select(a => new AppGroupSqlModel { Id = a.Id, Name = a.Name, SortOrder = a.SortOrder })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity != null)
            {
                return HttpStatusCode.OK.ToSuccessResponseOf(new GetOrCreateResponse
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    SortOrder = entity.SortOrder,
                    IsNewlyCreated = false
                });
            }

            int sortOrder;

            try
            {
                sortOrder = setSortOrderPosition == SetSortOrderPosition.Bottom
                    ? await _context.AppGroups.AsNoTracking().MaxAsync(s => s.SortOrder, cancellationToken) + OpenSettingsDefaults.SortOrderGap
                    : await _context.AppGroups.AsNoTracking().MinAsync(s => s.SortOrder, cancellationToken) - OpenSettingsDefaults.SortOrderGap;
            }
            catch (InvalidOperationException)
            {
                sortOrder = 0;
            }

            entity = new AppGroupSqlModel
            {
                Name = name,
                NameLowercase = trimmedNameLowercase,
                Slug = slug,
                SortOrder = sortOrder,
                CreatedById = createdById,
                CreatedOn = DateTime.UtcNow
            };

            _context.AppGroups.Add(entity);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                _context.Detach(entity);

                return HttpStatusCode.OK.ToSuccessResponseOf(new GetOrCreateResponse
                {
                    Id = entity.Id,
                    Name = name,
                    SortOrder = sortOrder,
                    IsNewlyCreated = true
                });
            }
            catch (Exception ex)
            {
                return ex.ToResponse<GetOrCreateResponse>();
            }
        }

        public async Task<IResponse> ReorderAppGroupsAsync(Guid? updatedById)
        {
            try
            {
                var reorderResponse = await _sortOrderService.ReorderAsync(_context.AppGroups, updatedById);

                return HttpStatusCode.OK.ToSuccessResponse(reorderResponse);
            }
            catch (Exception ex)
            {
                return ex.ToResponse();
            }
        }

        private async Task<IResponse> GetAppGroupByIdOrSlugAsync(Expression<Func<AppGroupSqlModel, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entity = await _context.AppGroups
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(a => a.Id)
                .Select(a => new GetAppGroupResponse
                {
                    Id = a.Id,
                    Name = a.Name,
                    Slug = a.Slug,
                    SortOrder = a.SortOrder,
                    RowVersion = a.RowVersion
                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureResponse(Errors.GroupNotFound)
                : HttpStatusCode.OK.ToSuccessResponse(entity);
        }

        private async Task<IResponse> GetUnfilteredPaginatedGroupsAsync(GetPaginatedInput input, SortOrderBounds sortOrderBounds, CancellationToken cancellationToken = default)
        {
            try
            {
                var unfilteredQuery = _context.AppGroups.AsNoTracking();

                var unfilteredEntitiesQuery = unfilteredQuery
#if !NETSTANDARD2_0
                    .AsSplitQuery()
#endif
                    .Include(a => a.Apps)
                    .Include(a => a.CreatedBy)
                    .Include(a => a.UpdatedBy)
                    .AsQueryable();

                unfilteredEntitiesQuery = string.IsNullOrWhiteSpace(input.SortBy)
                    ? unfilteredEntitiesQuery.OrderBy(a => a.SortOrder)
                    : Sort(unfilteredEntitiesQuery, null, input.SortBy, input.SortDirection);

                var unfilteredEntities = await unfilteredEntitiesQuery
                    .Select(entity => MapToGroupModelForPaginatedResponseData(entity))
                    .ToPaginatedArrayAsync(input.PageIndex, input.PageSize, cancellationToken);

                return HttpStatusCode.OK.ToSuccessResponse(new GetPaginatedAppGroupsResponse(input, sortOrderBounds.Count, unfilteredEntities, sortOrderBounds.MinSortOrder, sortOrderBounds.MaxSortOrder));
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError.ToFailureResponse(ex);
            }
        }

        private async Task<IResponse> GetGroupsBySearchAsync(GetAppGroupsInput input, CancellationToken cancellationToken)
        {
            var searchLowercase = input.SearchTerm.ToLowerInvariant();

            var query = _context.AppGroups.AsNoTracking();

            var data = await query.SearchBy(a => a.NameLowercase, searchLowercase, _context)
                .OrderBy(a => a.NameLowercase.IndexOf(searchLowercase))
                .ThenBy(a => a.SortOrder)
                .Select(a => new GetAppGroupsResponseGroup
                {
                    Id = $"{a.Id}",
                    Name = a.Name,
                    SortOrder = a.SortOrder,
                    RowVersion = a.RowVersion
                }).ToArrayAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse(new GetAppGroupsResponse(data));
        }

        private static IOrderedQueryable<AppGroupSqlModel> Sort(
            IQueryable<AppGroupSqlModel> source,
            IOrderedQueryable<AppGroupSqlModel> orderedSource,
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
                    return Helper.ApplySorting(source, orderedSource, a => a.Apps.Count(), direction);
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

        private static ModelForPaginatedResponseData MapToGroupModelForPaginatedResponseData(AppGroupSqlModel entity)
        {
            return new ModelForPaginatedResponseData
            {
                Id = $"{entity.Id}",
                Name = entity.Name,
                Slug = entity.Slug,
                SortOrder = entity.SortOrder,
                MappingCount = entity.Apps.Count(),
                CreatedOn = entity.CreatedOn,
                UpdatedOn = entity.UpdatedOn,
                CreatedBy = entity.CreatedBy?.DisplayName,
                UpdatedBy = entity.UpdatedBy?.DisplayName,
                RowVersion = entity.RowVersion
            };
        }
    }
}