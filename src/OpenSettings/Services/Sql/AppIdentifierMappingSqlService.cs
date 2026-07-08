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
    internal sealed class AppIdentifierMappingSqlService : IAppIdentifierMappingSqlService
    {
        private readonly OpenSettingsDbContext _context;
        private readonly ILockSqlService _locksSqlService;
        private readonly IIdentifierSqlService _identifiersSqlService;

        public AppIdentifierMappingSqlService(OpenSettingsDbContext context, ILockSqlService locksSqlService, IIdentifierSqlService identifiersSqlService)
        {
            _context = context;
            _locksSqlService = locksSqlService;
            _identifiersSqlService = identifiersSqlService;
        }

        public async Task<IResponse> CreateAppIdentifierMappingAsync(CreateAppIdentifierMappingInput input, CancellationToken cancellationToken = default)
        {
            int identifierSortOrder;

            if (input.Identifier.Id == null || input.Identifier.Id == Guid.Empty)
            {
                var identifierNameRule = ValidationRules.NotEmptyRule("IdentifierName", input.Identifier.Name);

                if (identifierNameRule.IsFailed())
                {
                    return identifierNameRule.Failure.ToResponse();
                }

                var identifierResponse = await _identifiersSqlService.GetOrCreateAsync(input.Identifier.Name, SetSortOrderPosition.Bottom, input.UserId, cancellationToken);

                if (!identifierResponse.Success)
                {
                    return identifierResponse.ToResponse();
                }

                var identifier = identifierResponse.Data;

                input.Identifier.Id = identifier.Id;
                identifierSortOrder = identifier.SortOrder;
            }
            else
            {
                var identifier = await _context.Identifiers
                    .AsNoTracking()
                    .Where(s => s.Id == input.Identifier.Id)
                    .Select(s => new { s.SortOrder })
                    .FirstOrDefaultAsync(cancellationToken);

                if (identifier == null)
                {
                    return HttpStatusCode.NotFound.ToFailureResponse(Errors.IdentifierNotFound);
                }

                identifierSortOrder = identifier.SortOrder;
            }

            var app = await _context.Apps.AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppConfigurations)
                .Include(a => a.AppIdentifierMappings)
                .Where(a => a.Id == input.AppId)
                .Select(a => new AppSqlModel
                {
                    Id = input.AppId,
                    AppIdentifierMappings = a.AppIdentifierMappings.Where(m => m.IdentifierId == input.Identifier.Id).ToList(),
                    AppConfigurations = a.AppConfigurations.Where(c => c.IdentifierId == input.Identifier.Id).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (app == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.AppNotFound);
            }

            if (app.AppIdentifierMappings.Count == 1)
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.MappingAlreadyExists);
            }

            _context.Attach(app);

            var currentTime = DateTime.UtcNow;

            if (app.AppConfigurations.Count != 1)
            {
                app.AppConfigurations.Add(new AppConfigurationSqlModel
                {
                    StoreInSeparateFile = false,
                    IgnoreOnFileChange = false,
                    RegistrationMode = RegistrationMode.Both,
                    Consumer = new ConfigurationConsumer(),
                    Provider = new ConfigurationProvider(),
                    Controller = new ConfigurationController(),
                    Spa = new ConfigurationSpa(),
                    IdentifierId = input.Identifier.Id.Value,
                    CreatedOn = currentTime,
                    CreatedById = input.UserId
                });
            }

            int mappingSortOrder;

            try
            {
                mappingSortOrder = input.SetSortOrderPosition == SetSortOrderPosition.Bottom
                    ? await _context.AppIdentifierMappings.AsNoTracking()
                        .Where(a => a.AppId == input.AppId)
                        .MaxAsync(s => s.SortOrder, cancellationToken) + OpenSettingsDefaults.SortOrderGap
                    : await _context.AppIdentifierMappings.AsNoTracking()
                        .Where(a => a.AppId == input.AppId)
                        .MinAsync(s => s.SortOrder, cancellationToken) - OpenSettingsDefaults.SortOrderGap;
            }
            catch (InvalidOperationException)
            {
                mappingSortOrder = 0;
            }

            var entity = new AppIdentifierMappingSqlModel
            {
                AppId = input.AppId,
                IdentifierId = input.Identifier.Id.Value,
                SortOrder = mappingSortOrder,
                CreatedOn = currentTime,
                CreatedById = input.UserId
            };

            app.AppIdentifierMappings.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse(new CreateAppIdentifierMappingResponse
            {
                SortOrder = mappingSortOrder,
                AppId = input.AppId,
                Identifier = new CreateAppIdentifierMappingResponseIdentifier
                {
                    Id = input.Identifier.Id.Value,
                    SortOrder = identifierSortOrder,
                }
            });
        }

        public async Task<IResponse> GetAppIdentifierMappingByAppIdAndIdentifierIdAsync(GetAppIdentifierMappingByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var entity = await _context.AppIdentifierMappings
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.App)
                .Include(a => a.Identifier)
                .Where(a => a.AppId == Guid.Parse(input.AppIdOrSlug) && a.IdentifierId == Guid.Parse(input.IdentifierIdOrSlug))
                .Select(a => new GetAppIdentifierMappingByAppAndIdentifierResponse
                {
                    SortOrder = a.SortOrder,
                    AppId = input.AppIdOrSlug,
                    Identifier = new GetAppIdentifierMappingByAppAndIdentifierResponseIdentifier
                    {
                        Id = input.IdentifierIdOrSlug,
                        SortOrder = a.Identifier.SortOrder
                    }
                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureResponse(Errors.MappingNotFound)
                : HttpStatusCode.OK.ToSuccessResponse(entity);
        }

        public async Task<IResponse> GetAppIdentifierMappingByAppSlugAndIdentifierSlugAsync(GetAppIdentifierMappingByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            input.AppIdOrSlug = input.AppIdOrSlug?.ToSlug();
            input.IdentifierIdOrSlug = input.IdentifierIdOrSlug?.ToSlug();

            var entity = await _context.AppIdentifierMappings
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.App)
                .Include(a => a.Identifier)
                .Where(a => a.App.Slug == input.AppIdOrSlug &&
                            a.Identifier.Slug == input.IdentifierIdOrSlug)
                .Select(a => new GetAppIdentifierMappingByAppAndIdentifierResponse
                {
                    SortOrder = a.SortOrder,
                    AppId = $"{a.AppId}",
                    Identifier = new GetAppIdentifierMappingByAppAndIdentifierResponseIdentifier
                    {
                        Id = $"{a.Identifier.Id}",
                        SortOrder = a.Identifier.SortOrder
                    }
                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureResponse(Errors.MappingNotFound)
                : HttpStatusCode.OK.ToSuccessResponse(entity);
        }

        public async Task<IResponse> GetAppIdentifierMappingsByAppIdAsync(GetAppIdentifierMappingsInput input, CancellationToken cancellationToken)
        {
            return await GetAppIdentifierMappingsByAppAsync(a => a.Id == Guid.Parse(input.AppIdOrSlug), cancellationToken);
        }

        public Task<IResponse> GetAppIdentifierMappingsByAppSlugAsync(GetAppIdentifierMappingsInput input, CancellationToken cancellationToken)
        {
            input.AppIdOrSlug = input.AppIdOrSlug?.ToSlug();

            return GetAppIdentifierMappingsByAppAsync(a => a.Slug == input.AppIdOrSlug, cancellationToken);
        }

        private async Task<IResponse> GetAppIdentifierMappingsByAppAsync(Expression<Func<AppSqlModel, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppIdentifierMappings).ThenInclude(m => m.Identifier)
                .Where(predicate)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    Identifiers = a.AppIdentifierMappings.Select(m => new GetAppIdentifierMappingsResponseIdentifier
                    {
                        Id = $"{m.IdentifierId}",
                        SortOrder = m.Identifier.SortOrder,
                        AppMapping = new GetAppIdentifierMappingsResponseIdentifierAppMapping
                        {
                            SortOrder = m.SortOrder,
                            RowVersion = m.RowVersion
                        }
                    }).ToArray()
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.AppNotFound);
            }

            if (entity.Identifiers.Length == 0)
            {
                return HttpStatusCode.OK.ToSuccessResponse(new GetAppIdentifierMappingsResponse());
            }

            var firstIdentifier = entity.Identifiers[0];

            int identifierMinOrder = firstIdentifier.SortOrder, identifierMaxOrder = firstIdentifier.SortOrder, mappingMinOrder = firstIdentifier.AppMapping.SortOrder, mappingMaxOrder = firstIdentifier.AppMapping.SortOrder;

            foreach (var identifier in entity.Identifiers.Skip(1))
            {
                identifierMinOrder = Math.Min(identifier.SortOrder, identifierMinOrder);
                identifierMaxOrder = Math.Min(identifier.SortOrder, identifierMaxOrder);

                mappingMinOrder = Math.Min(identifier.AppMapping.SortOrder, mappingMinOrder);
                mappingMaxOrder = Math.Max(identifier.AppMapping.SortOrder, mappingMaxOrder);
            }

            return HttpStatusCode.OK.ToSuccessResponse(new GetAppIdentifierMappingsResponse
            {
                IdentifierSortOrderRange = new SortOrderRange
                {
                    Min = identifierMinOrder,
                    Max = identifierMaxOrder
                },
                AppIdentifierMappingSortOrderRange = new SortOrderRange
                {
                    Min = mappingMinOrder,
                    Max = mappingMaxOrder
                },
                Identifiers = entity.Identifiers
            });
        }

        public async Task<IResponse> DeleteAppIdentifierMappingAsync(DeleteAppIdentifierMappingInput input, CancellationToken cancellationToken = default)
        {
            var entity = await _context.AppIdentifierMappings
                .AsNoTracking()
                .Where(a => a.IdentifierId == input.IdentifierId && a.AppId == input.AppId)
                .OrderBy(a => a.IdentifierId)
                .Select(a => new AppIdentifierMappingSqlModel { AppId = input.AppId, IdentifierId = input.IdentifierId, RowVersion = a.RowVersion })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.MappingNotFound);
            }

            if (!input.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict($"{entity.AppId}-${entity.IdentifierId}", entity.RowVersion, input.RowVersion, true);
            }

            _context.AppIdentifierMappings.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse();
        }

        public async Task<IResponse> UpdateAppIdentifierMappingSortOrderAsync(UpdateAppIdentifierMappingSortOrderInput input, CancellationToken cancellationToken = default)
        {
            var entity = await _context.AppIdentifierMappings
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Where(a => a.IdentifierId == input.IdentifierId && a.AppId == input.AppId)
                .OrderBy(a => a.IdentifierId)
                .Select(a => new AppIdentifierMappingSqlModel
                {
                    IdentifierId = input.IdentifierId,
                    AppId = input.AppId,
                    SortOrder = a.SortOrder,
                    RowVersion = a.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.MappingNotFound);
            }

            if (!input.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict($"{entity.AppId}-{entity.IdentifierId}", entity.RowVersion, input.RowVersion, false);
            }

            var query = _context.AppIdentifierMappings.AsNoTracking();

            var moveDown = input.Direction == MoveDirection.Down;

            var foundEntity = (moveDown
                    ? query.Where(a => a.SortOrder >= entity.SortOrder && a.AppId == entity.AppId && a.IdentifierId != input.IdentifierId)
                        .OrderBy(a => a.SortOrder)
                    : query.Where(a => a.SortOrder <= entity.SortOrder && a.AppId == entity.AppId && a.IdentifierId != input.IdentifierId)
                        .OrderByDescending(a => a.SortOrder))
                .Select(a => new AppIdentifierMappingSqlModel
                {
                    AppId = entity.AppId,
                    IdentifierId = a.IdentifierId,
                    SortOrder = a.SortOrder,
                    RowVersion = a.RowVersion
                })
                .FirstOrDefault();

            if (foundEntity == null)
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(moveDown ? Errors.MaxSortOrderReached : Errors.MinSortOrderReached);
            }

            if (entity.SortOrder == foundEntity.SortOrder)
            {
                try
                {
                    await ReorderAsync(entity.AppId, input.UpdatedById);

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

            _context.AppIdentifierMappings.AttachRange(foundEntity, entity);

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

                return HttpStatusCode.OK.ToSuccessResponse(new UpdateAppIdentifierMappingSortOrderResponse
                {
                    SortOrder = entity.SortOrder,
                    RowVersion = entity.RowVersion
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

        private async Task<ReorderOutput> ReorderAsync(Guid appId, Guid? updatedById)
        {
            var key = $"{nameof(AppIdentifierMappingSqlService)}-{appId}";

            var lockAcquired = await _locksSqlService.AcquireLockAsync(new AcquireLockInput
            {
                Key = key,
                Owner = Environment.MachineName,
                Timeout = TimeSpan.FromSeconds(30)
            });

            if (!lockAcquired)
            {
                return null;
            }

            try
            {
                var entities = await _context.AppIdentifierMappings
                    .Where(a => a.AppId == appId)
                    .Select(a =>
                        new AppIdentifierMappingSqlModel
                        {
                            AppId = appId,
                            IdentifierId = a.IdentifierId,
                            SortOrder = a.SortOrder,
                            RowVersion = a.RowVersion
                        }).OrderBy(a => a.SortOrder)
                    .ToArrayAsync();

                var currentTime = DateTime.UtcNow;

                var response = new ReorderOutput
                {
                    RowVersion = RowVersionHelper.Date(currentTime)
                };

                for (var i = 0; i < entities.Length; i++)
                {
                    var entity = entities[i];

                    var newOrder = i * 10;

                    if (newOrder == entity.SortOrder)
                    {
                        continue;
                    }

                    _context.Attach(entity);

                    entity.SortOrder = newOrder;
                    entity.RowVersion = response.RowVersion;
                    entity.UpdatedOn = currentTime;
                    entity.UpdatedById = updatedById;

                    response.IdToSortOrder[$"{appId}-{entity.IdentifierId}"] = entity.SortOrder;
                }

                await _context.SaveChangesAsync();

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
    }
}