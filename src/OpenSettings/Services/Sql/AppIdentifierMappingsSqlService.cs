using Microsoft.EntityFrameworkCore;
using Ogu.Response.Abstractions;
using Ogu.Response.Json;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Extensions;
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
using OpenSettings.Configurations;

namespace OpenSettings.Services.Sql
{
    internal sealed class AppIdentifierMappingsSqlService : IAppIdentifierMappingsSqlService
    {
        private readonly OpenSettingsDbContext _context;
        private readonly Guid _clientId;
        private readonly ILocksSqlService _locksSqlService;
        private readonly IIdentifiersSqlService _identifiersSqlService;

        public AppIdentifierMappingsSqlService(OpenSettingsDbContext context, OpenSettingsConfiguration openSettingsConfiguration, ILocksSqlService locksSqlService, IIdentifiersSqlService identifiersSqlService)
        {
            _context = context;
            _clientId = openSettingsConfiguration.Client.Id;
            _locksSqlService = locksSqlService;
            _identifiersSqlService = identifiersSqlService;
        }

        public async Task<IJsonResponse> CreateAppIdentifierMappingAsync(CreateAppIdentifierMappingInput input, CancellationToken cancellationToken = default)
        {
            var identifierIdRule = JsonValidationRules.GreaterThanRule("IdentifierId", input.Identifier.Id, -1);
            var appIdRule = JsonValidationRules.GreaterThanRule(nameof(input.AppId), input.AppId, 0);

            var failure = new ValidationRule[] { identifierIdRule, appIdRule }.ValidateFirstOrDefault();

            if (failure != null)
            {
                return failure.ToJsonResponse();
            }

            var identifierId = identifierIdRule.GetStoredValue<int>();
            var appId = appIdRule.GetStoredValue<int>();
            int identifierSortOrder;

            if (identifierId == 0)
            {
                var identifierNameRule = JsonValidationRules.NotEmptyRule("IdentifierName", input.Identifier.Name);

                if (identifierNameRule.IsFailed())
                {
                    return identifierNameRule.Failure.ToJsonResponse();
                }

                var identifierResponse = await _identifiersSqlService.GetOrCreateAsync(input.Identifier.Name, SetSortOrderPosition.Bottom, input.UserId, cancellationToken);

                if (!identifierResponse.Success)
                {
                    return identifierResponse.ToJsonResponse();
                }

                var identifier = identifierResponse.Data;

                identifierId = identifier.Id;
                identifierSortOrder = identifier.SortOrder;
            }
            else
            {
                var identifier = await _context.Identifiers
                    .AsNoTracking()
                    .Where(s => s.Id == identifierId)
                    .Select(s => new { s.SortOrder })
                    .FirstOrDefaultAsync(cancellationToken);

                if (identifier == null)
                {
                    return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.IdentifierNotFound);
                }

                identifierSortOrder = identifier.SortOrder;
            }

            var app = await _context.Apps.AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.Configurations)
                .Include(a => a.AppIdentifierMappings)
                .Where(a => a.Id == appId)
                .Select(a => new AppSqlModel
                {
                    Id = appId,
                    AppIdentifierMappings = a.AppIdentifierMappings.Where(m => m.IdentifierId == identifierId).ToList(),
                    Configurations = a.Configurations.Where(c => c.IdentifierId == identifierId).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (app == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.AppNotFound);
            }

            if (app.AppIdentifierMappings.Count == 1)
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.MappingAlreadyExists);
            }

            _context.Attach(app);

            var currentTime = DateTime.UtcNow;

            if (app.Configurations.Count != 1)
            {
                app.Configurations.Add(new ConfigurationSqlModel
                {
                    StoreInSeparateFile = false,
                    IgnoreOnFileChange = false,
                    RegistrationMode = RegistrationMode.Configure,
                    Consumer = new ConfigurationConsumer(),
                    Provider = new ConfigurationProvider(),
                    IdentifierId = identifierId,
                    CreatedOn = currentTime,
                    CreatedById = input.UserId
                });
            }
            
            int mappingSortOrder;

            try
            {
                mappingSortOrder = input.SetSortOrderPosition == SetSortOrderPosition.Bottom
                    ? await _context.AppIdentifierMappings.AsNoTracking()
                        .Where(a => a.AppId == appId)
                        .MaxAsync(s => s.SortOrder, cancellationToken) + Constants.SortOrderGap
                    : await _context.AppIdentifierMappings.AsNoTracking()
                        .Where(a => a.AppId == appId)
                        .MinAsync(s => s.SortOrder, cancellationToken) - Constants.SortOrderGap;
            }
            catch (InvalidOperationException)
            {
                mappingSortOrder = 0;
            }

            var entity = new AppIdentifierMappingSqlModel
            {
                AppId = appId,
                IdentifierId = identifierId,
                SortOrder = mappingSortOrder,
                CreatedOn = currentTime,
                CreatedById = input.UserId
            };

            app.AppIdentifierMappings.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse(new CreateAppIdentifierMappingResponse
            {
                AppId = input.AppId,
                Identifier = new CreateAppIdentifierMappingResponseIdentifier
                {
                    Id = $"{identifierId}",
                    SortOrder = identifierSortOrder,
                    MappingSortOrder = mappingSortOrder,
                }
            });
        }

        public async Task<IJsonResponse> GetAppIdentifierMappingByAppIdAndIdentifierIdAsync(GetAppIdentifierMappingByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var appIdRule = JsonValidationRules.GreaterThanRule("AppId", input.AppIdOrSlug, 0);
            var identifierIdRule = JsonValidationRules.GreaterThanRule("IdentifierId", input.IdentifierIdOrSlug, 0);

            var failure = new ValidationRule[] { appIdRule, identifierIdRule }.ValidateFirstOrDefault();

            if (failure != null)
            {
                return failure.ToJsonResponse();
            }

            var appId = appIdRule.GetStoredValue<int>();
            var identifierId = identifierIdRule.GetStoredValue<int>();

            var entity = await _context.AppIdentifierMappings
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.App)
                .Include(a => a.Identifier)
                .Where(a => a.AppId == appId && a.IdentifierId == identifierId)
                .Select(a => new GetAppIdentifierMappingByAppAndIdentifierResponse
                {
                    MappingSortOrder = a.SortOrder,
                    AppId = input.AppIdOrSlug,
                    Identifier = new GetAppIdentifierMappingByAppAndIdentifierResponseIdentifier
                    {
                        Id = input.IdentifierIdOrSlug,
                        SortOrder = a.Identifier.SortOrder
                    }
                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.MappingNotFound)
                : HttpStatusCode.OK.ToSuccessJsonResponse(entity);
        }

        public async Task<IJsonResponse> GetAppIdentifierMappingByAppSlugAndIdentifierSlugAsync(GetAppIdentifierMappingByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
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
                    MappingSortOrder = a.SortOrder,
                    AppId = $"{a.AppId}",
                    Identifier = new GetAppIdentifierMappingByAppAndIdentifierResponseIdentifier
                    {
                        Id = $"{a.Identifier.Id}",
                        SortOrder = a.Identifier.SortOrder
                    }
                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.MappingNotFound)
                : HttpStatusCode.OK.ToSuccessJsonResponse(entity);
        }

        public async Task<IJsonResponse> GetAppIdentifierMappingsByAppIdAsync(GetAppIdentifierMappingsInput input, CancellationToken cancellationToken)
        {
            var appIdRule = JsonValidationRules.GreaterThanRule("AppId", input.AppIdOrSlug, 0);

            if (appIdRule.IsFailed())
            {
                return appIdRule.Failure.ToJsonResponse();
            }

            var appId = appIdRule.GetStoredValue<int>();

            return await GetAppIdentifierMappingsByAppAsync(a => a.Id == appId, cancellationToken);
        }

        public Task<IJsonResponse> GetAppIdentifierMappingsByAppSlugAsync(GetAppIdentifierMappingsInput input, CancellationToken cancellationToken)
        {
            input.AppIdOrSlug = input.AppIdOrSlug?.ToSlug();

            return GetAppIdentifierMappingsByAppAsync(a => a.Slug == input.AppIdOrSlug, cancellationToken);
        }

        private async Task<IJsonResponse> GetAppIdentifierMappingsByAppAsync(Expression<Func<AppSqlModel, bool>> predicate, CancellationToken cancellationToken = default)
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
                        MappingSortOrder = m.SortOrder,
                        MappingRowVersion = m.RowVersion
                    }).ToArray()
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.AppNotFound);
            }

            if (entity.Identifiers.Length == 0)
            {
                return HttpStatusCode.OK.ToSuccessJsonResponse(new GetAppIdentifierMappingsResponse());
            }

            var firstIdentifier = entity.Identifiers[0];

            int minOrder = firstIdentifier.SortOrder, maxOrder = firstIdentifier.SortOrder, mappingMinOrder = firstIdentifier.MappingSortOrder, mappingMaxOrder = firstIdentifier.MappingSortOrder;

            foreach (var identifier in entity.Identifiers.Skip(1))
            {
                minOrder = Math.Min(identifier.SortOrder, minOrder);
                maxOrder = Math.Min(identifier.SortOrder, maxOrder);

                mappingMinOrder = Math.Min(identifier.MappingSortOrder, mappingMinOrder);
                mappingMaxOrder = Math.Max(identifier.MappingSortOrder, mappingMaxOrder);
            }

            return HttpStatusCode.OK.ToSuccessJsonResponse(new GetAppIdentifierMappingsResponse
            {
                MinSortOrder = minOrder,
                MaxSortOrder = maxOrder,
                MappingMinSortOrder = mappingMinOrder,
                MappingMaxSortOrder = mappingMaxOrder,
                Identifiers = entity.Identifiers
            });
        }

        public async Task<IJsonResponse> DeleteAppIdentifierMappingAsync(DeleteAppIdentifierMappingInput input, CancellationToken cancellationToken = default)
        {
            var appIdRule = JsonValidationRules.GreaterThanRule(nameof(input.AppId), input.AppId, 0);
            var identifierIdRule = JsonValidationRules.GreaterThanRule(nameof(input.IdentifierId), input.IdentifierId, 0);

            var failure = new ValidationRule[] { appIdRule, identifierIdRule }.ValidateFirstOrDefault();

            if (failure != null)
            {
                return failure.ToJsonResponse();
            }

            var appId = appIdRule.GetStoredValue<int>();
            var identifierId = identifierIdRule.GetStoredValue<int>();

            var entity = await _context.AppIdentifierMappings
                .AsNoTracking()
                .Where(a => a.IdentifierId == identifierId && a.AppId == appId)
                .OrderBy(a => a.IdentifierId)
                .Select(a => new AppIdentifierMappingSqlModel { AppId = appId, IdentifierId = identifierId, RowVersion = a.RowVersion })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.MappingNotFound);
            }

            if (!input.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict($"{entity.AppId}-${entity.IdentifierId}", entity.RowVersion, input.RowVersion, true);
            }

            _context.AppIdentifierMappings.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse();
        }

        public async Task<IJsonResponse> UpdateAppIdentifierMappingSortOrderAsync(UpdateAppIdentifierMappingSortOrderInput input, CancellationToken cancellationToken = default)
        {
            var appIdRule = JsonValidationRules.GreaterThanRule(nameof(input.AppId), input.AppId, 0);
            var identifierIdRule = JsonValidationRules.GreaterThanRule(nameof(input.IdentifierId), input.IdentifierId, 0);

            var failure = new ValidationRule[] { appIdRule, identifierIdRule }.ValidateFirstOrDefault();

            if (failure != null)
            {
                return failure.ToJsonResponse();
            }

            var appId = appIdRule.GetStoredValue<int>();
            var identifierId = identifierIdRule.GetStoredValue<int>();

            var entity = await _context.AppIdentifierMappings
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Where(a => a.IdentifierId == identifierId && a.AppId == appId)
                .OrderBy(a => a.IdentifierId)
                .Select(a => new AppIdentifierMappingSqlModel
                {
                    IdentifierId = identifierId,
                    AppId = appId,
                    SortOrder = a.SortOrder,
                    RowVersion = a.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.MappingNotFound);
            }

            if (!input.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict($"{entity.AppId}-{entity.IdentifierId}", entity.RowVersion, input.RowVersion, false);
            }

            var query = _context.AppIdentifierMappings.AsNoTracking();

            var foundEntity = (input.Ascent
                    ? query.Where(a => a.SortOrder >= entity.SortOrder && a.AppId == entity.AppId && a.IdentifierId != identifierId)
                        .OrderBy(a => a.SortOrder)
                    : query.Where(a => a.SortOrder <= entity.SortOrder && a.AppId == entity.AppId && a.IdentifierId != identifierId)
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
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(input.Ascent ? Errors.MaxSortOrderReached : Errors.MinSortOrderReached);
            }

            if (entity.SortOrder == foundEntity.SortOrder)
            {
                try
                {
                    await ReorderAsync(entity.AppId);

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

            _context.AppIdentifierMappings.AttachRange(foundEntity, entity);

            var currentTime = DateTime.UtcNow;
            var rowVersion = currentTime.ToRowVersion();

            (entity.SortOrder, foundEntity.SortOrder) = (foundEntity.SortOrder, entity.SortOrder);

            foundEntity.UpdatedOn = currentTime;
            foundEntity.UpdatedById = input.UpdatedById;
            foundEntity.RowVersion = rowVersion;

            entity.UpdatedOn = currentTime;
            entity.UpdatedById = input.UpdatedById;
            entity.RowVersion = currentTime.ToRowVersion();

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                return HttpStatusCode.OK.ToSuccessJsonResponse(new UpdateAppIdentifierMappingSortOrderResponse
                {
                    SortOrder = entity.SortOrder,
                    RowVersion = entity.RowVersion
                });
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

        private async Task<ReorderResponse> ReorderAsync(int appId)
        {
            var key = $"{nameof(AppIdentifierMappingsSqlService)}-{appId}";

            var lockAcquired = await _locksSqlService.AcquireLockAsync(new AcquireLockInput
            { Key = key, Owner = Environment.MachineName, Timeout = TimeSpan.FromSeconds(30) });

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

                var response = new ReorderResponse
                {
                    RowVersion = currentTime.ToRowVersion()
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
                    entity.UpdatedById = _clientId;

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