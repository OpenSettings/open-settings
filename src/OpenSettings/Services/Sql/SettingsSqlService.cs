using Microsoft.EntityFrameworkCore;
using Ogu.Compressions.Abstractions;
using Ogu.Response.Abstractions;
using Ogu.Response.Json;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Sql.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql
{
    internal sealed class SettingsSqlService : ISettingsSqlService
    {
        private readonly IDataChangeService _dataChangeService;
        private readonly IIdentifiersService _identifiersService;
        private readonly ICompressionFactory _compressionFactory;
        private readonly OpenSettingsDbContext _context;
        private readonly DataValidationService _settingsDataValidationService;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;

        public SettingsSqlService(
            IDataChangeService dataChangeService,
            IIdentifiersService identifiersService,
            ICompressionFactory compressionFactory,
            OpenSettingsDbContext context,
            DataValidationService settingsDataValidationService,
            OpenSettingsConfiguration openSettingsConfiguration)
        {
            _dataChangeService = dataChangeService;
            _identifiersService = identifiersService;
            _compressionFactory = compressionFactory;
            _context = context;
            _settingsDataValidationService = settingsDataValidationService;
            _openSettingsConfiguration = openSettingsConfiguration;
        }

        public async Task<IJsonResponse> GetSettingsByAppIdAndIdentifierIdAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var appIdValidationRule = JsonValidationRules.GreaterThanRule("AppId", input.AppIdOrSlug, 0);
            var IdentifierIdValidationRule = JsonValidationRules.GreaterThanRule("IdentifierId", input.IdentifierIdOrSlug, 0);

            var failure = new ValidationRule[] { appIdValidationRule, IdentifierIdValidationRule }.ValidateFirstOrDefault();

            if (failure != null)
            {
                return failure.ToJsonResponse();
            }

            var appId = appIdValidationRule.GetStoredValue<int>();
            var IdentifierId = IdentifierIdValidationRule.GetStoredValue<int>();

            return await GetSettingsByAppAndIdentifierAsync(a => a.Id == appId, IdentifierId, cancellationToken);
        }

        public async Task<IJsonResponse> GetSettingsByAppSlugAndIdentifierSlugAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var identifierSlug = input.IdentifierIdOrSlug?.ToSlug();
            var appSlug = input.AppIdOrSlug?.ToSlug();

            var identifier = await _context.Identifiers
                .AsNoTracking()
                .Where(s => s.Slug == identifierSlug)
                .OrderBy(s => s.Id)
                .Select(s => new { s.Id })
                .FirstOrDefaultAsync(cancellationToken);

            if (identifier == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.IdentifierNotFound);
            }

            return await GetSettingsByAppAndIdentifierAsync(a => a.Slug == appSlug, identifier.Id, cancellationToken);
        }

        public async Task<IJsonResponse> GetSettingsDataAsync(GetSettingsDataInput input, CancellationToken cancellationToken = default)
        {
            var query = _context.Settings.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(input.AppId))
            {
                var appIdRule = JsonValidationRules.GreaterThanRule(nameof(input.AppId), input.AppId, 0);

                if (appIdRule.IsFailed())
                {
                    return appIdRule.Failure.ToJsonResponse();
                }

                var appId = appIdRule.GetStoredValue<int>();

                query = query.Where(s => s.AppId == appId);
            }

            if (!string.IsNullOrWhiteSpace(input.IdentifierId))
            {
                var IdentifierIdRule = JsonValidationRules.GreaterThanRule(nameof(input.IdentifierId),
                    input.IdentifierId, 0);

                if (IdentifierIdRule.IsFailed())
                {
                    return IdentifierIdRule.Failure.ToJsonResponse();
                }

                var IdentifierId = IdentifierIdRule.GetStoredValue<int>();

                query = query.Where(s => s.IdentifierId == IdentifierId);
            }

            if (!string.IsNullOrWhiteSpace(input.Ids))
            {
                var idArray = input.Ids
                    .Split(Constants.CommaSeparator, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => int.TryParse(i, out var parsedId) ? (int?)parsedId : null)
                    .Where(i => i.HasValue)
                    .Select(i => i.Value)
                    .ToArray();

                if (idArray.Length > 0)
                {
                    query = query.Where(a => idArray.Contains(a.Id));
                }
            }

            var entities = await query
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    a.Id,
                    a.CompressionType,
                    a.Data,
                }).ToArrayAsync(cancellationToken);

            var tasks = entities.Select(async s =>
            {
                var data = await _compressionFactory.DecompressToUtf8StringAsync(s.Data, s.CompressionType, cancellationToken);

                return new GetSettingsDataResponseSetting
                {
                    Id = s.Id.ToString(),
                    Data = data,
                };
            });

            return HttpStatusCode.OK.ToSuccessJsonResponse(new GetSettingsDataResponse
            {
                Settings = await Task.WhenAll(tasks)
            });
        }

        public async Task<IJsonResponse> CopySettingToAsync(CopySettingToInput input, CancellationToken cancellationToken = default)
        {
            var settingIdRule = JsonValidationRules.GreaterThanRule(nameof(input.SettingId), input.SettingId, 0);
            var targetAppIdRule = JsonValidationRules.GreaterThanRule(nameof(input.TargetAppId), input.TargetAppId, 0);
            var identifierIdRule = JsonValidationRules.GreaterThanRule(nameof(input.IdentifierId), input.IdentifierId, -1);

            var validationFailure = new[] { settingIdRule, targetAppIdRule, identifierIdRule }.ValidateFirstOrDefault();

            if (validationFailure != null)
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(validationFailure);
            }

            var settingId = settingIdRule.GetStoredValue<int>();
            var targetAppId = targetAppIdRule.GetStoredValue<int>();
            var identifierId = identifierIdRule.GetStoredValue<int>();

            var sourceSetting = await _context.Settings
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.SettingClass)
                .Include(a => a.App).ThenInclude(a => a.AppIdentifierMappings).ThenInclude(a => a.Identifier)
                .Where(a => a.Id == settingId)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    a.AppId,
                    a.App.ClientId,
                    AppSlug = a.App.Slug,
                    a.CompressionType,
                    a.CompressionLevel,
                    a.Data,
                    a.ComputedIdentifier,
                    a.DataValidationDisabled,
                    a.IdentifierId,
                    a.SettingClass.Namespace,
                    a.SettingClass.Name,
                    a.SettingClass.FullName,
                    a.SettingClass.Identifier,
                    a.SettingClass.Properties,
                    Identifiers = a.App.AppIdentifierMappings.Select(m => new { m.IdentifierId, m.Identifier.Name, m.Identifier.SortOrder, MappingSortOrder = m.SortOrder }).ToArray(),
                }).FirstOrDefaultAsync(cancellationToken);

            if (sourceSetting == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.SettingNotFound);
            }

            Guid clientId;
            string appSlug;
            var identifierIdToIdentifier = sourceSetting.Identifiers.ToDictionary(s => s.IdentifierId);

            if (sourceSetting.AppId != targetAppId)
            {
                var targetApp = await _context.Apps
                    .AsNoTracking()
#if !NETSTANDARD2_0
                    .AsSplitQuery()
#endif
                    .Include(a => a.AppIdentifierMappings).ThenInclude(a => a.Identifier)
                    .Where(a => a.Id == targetAppId)
                    .OrderBy(a => a.Id)
                    .Select(a => new
                    {
                        a.ClientId,
                        a.Slug,
                        Identifiers = a.AppIdentifierMappings.Select(m => new { m.IdentifierId, m.Identifier.Name, m.Identifier.SortOrder, MappingSortOrder = m.SortOrder }).ToArray()
                    }).FirstOrDefaultAsync(cancellationToken);

                if (targetApp == null)
                {
                    return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.TargetAppNotFound);
                }

                clientId = targetApp.ClientId;
                appSlug = targetApp.Slug;
                identifierIdToIdentifier = targetApp.Identifiers.ToDictionary(s => s.IdentifierId);
            }
            else if (sourceSetting.IdentifierId == identifierId)
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.DuplicateSetting);
            }
            else
            {
                clientId = sourceSetting.ClientId;
                appSlug = sourceSetting.AppSlug;
            }

            string identifierName = null;
            int identifierSortOrder;
            int identifierMappingSortOrder;

            if (identifierId > 0)
            {
                var identifierEntity = await _context.Identifiers.AsNoTracking().Where(i => i.Id == identifierId)
                    .OrderBy(i => i.Id).Select(
                        i => new
                        {
                            i.SortOrder
                        }).FirstOrDefaultAsync(cancellationToken);

                if (identifierEntity == null)
                {
                    return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.IdentifierNotFound);
                }

                identifierSortOrder = identifierEntity.SortOrder;

                var hasSomeSetting = await HasSomeSettingAsync(targetAppId, identifierId, sourceSetting.ComputedIdentifier, cancellationToken);

                if (hasSomeSetting)
                {
                    return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.DuplicateTargetSetting);
                }
            }
            else if (identifierId == 0 && !string.IsNullOrWhiteSpace(input.IdentifierName))
            {
                var identifierGetOrCreateResponse = await _identifiersService.GetOrCreateAsync(input.IdentifierName, SetSortOrderPosition.Bottom, input.UserId, cancellationToken);

                if (!identifierGetOrCreateResponse.Success)
                {
                    return identifierGetOrCreateResponse.ToJsonResponse();
                }

                identifierId = identifierGetOrCreateResponse.Data.Id;
                identifierName = identifierGetOrCreateResponse.Data.Name;
                identifierSortOrder = identifierGetOrCreateResponse.Data.SortOrder;

                if (!identifierGetOrCreateResponse.Data.IsNewlyCreated)
                {
                    var hasSomeSetting = await HasSomeSettingAsync(targetAppId, identifierId, sourceSetting.ComputedIdentifier, cancellationToken);

                    if (hasSomeSetting)
                    {
                        return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.DuplicateTargetSetting);
                    }
                }
            }
            else
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.IdentifierMustNotEmpty);
            }

            var currentTime = DateTime.UtcNow;

            var app = new AppSqlModel { Id = targetAppId };

            _context.Apps.Attach(app);

            if (identifierIdToIdentifier.TryGetValue(identifierId, out var identifier))
            {
                identifierName = identifier.Name;
                identifierSortOrder = identifier.SortOrder;
                identifierMappingSortOrder = identifier.MappingSortOrder;
            }
            else
            {
                try
                {
                    identifierMappingSortOrder =
                        await _context.AppIdentifierMappings.AsNoTracking()
                            .Where(a => a.AppId == targetAppId)
                            .MaxAsync(s => s.SortOrder, cancellationToken) + Constants.SortOrderGap;
                }
                catch (InvalidOperationException)
                {
                    identifierMappingSortOrder = 0;
                }

                app.AppIdentifierMappings.Add(new AppIdentifierMappingSqlModel
                {
                    AppId = sourceSetting.AppId,
                    IdentifierId = identifierId,
                    SortOrder = identifierMappingSortOrder,
                    CreatedOn = currentTime,
                    CreatedById = input.UserId
                });
            }

            var configuration = await _context.Configurations.AsNoTracking()
                .AnyAsync(c => c.AppId == targetAppId && c.IdentifierId == identifierId, cancellationToken);

            if (!configuration)
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

            var newSetting = new SettingSqlModel
            {
                AppId = sourceSetting.AppId,
                CompressionType = sourceSetting.CompressionType,
                CompressionLevel = sourceSetting.CompressionLevel,
                Data = sourceSetting.Data,
                ComputedIdentifier = sourceSetting.ComputedIdentifier,
                Version = "0",
                DataValidationDisabled = sourceSetting.DataValidationDisabled,
                IdentifierId = identifierId,
                SettingClass = new SettingClassSqlModel
                {
                    Namespace = sourceSetting.Namespace,
                    Name = sourceSetting.Name,
                    FullName = sourceSetting.FullName,
                    Identifier = sourceSetting.Identifier,
                    Properties = sourceSetting.Properties
                },
                CreatedOn = currentTime,
                CreatedById = input.UserId
            };

            app.Settings.Add(newSetting);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse(new CopySettingToResponse
            {
                ClientId = clientId,
                AppSlug = appSlug,
                Identifier = new CopySettingToResponseIdentifier
                {
                    Id = $"{newSetting.IdentifierId}",
                    Name = identifierName,
                    SortOrder = identifierSortOrder,
                    MappingSortOrder = identifierMappingSortOrder
                },
                Setting = new CopySettingToResponseSetting
                {
                    Id = $"{newSetting.Id}",
                    ComputedIdentifier = sourceSetting.ComputedIdentifier,
                    ClassId = $"{newSetting.SettingClass.Id}"
                }
            });
        }

        public async Task<IJsonResponse> GetSettingAsync(GetSettingInput input, CancellationToken cancellationToken = default)
        {
            var settingIdValidationRule = JsonValidationRules.GreaterThanRule(nameof(input.Id), input.Id, 0);

            if (settingIdValidationRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(settingIdValidationRule.Failure);
            }

            var settingId = settingIdValidationRule.GetStoredValue<int>();

            var entity = await _context.Settings
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Where(s => s.Id == settingId)
                .OrderBy(s => s.Id)
                .Select(s => new GetSettingResponse
                {
                    CompressionType = s.CompressionType,
                    CompressionLevel = s.CompressionLevel,
                    Data = s.Data,
                    DataRestored = s.DataRestored,
                    DataValidationDisabled = s.DataValidationDisabled,
                    StoreInSeparateFile = s.StoreInSeparateFile,
                    IgnoreOnFileChange = s.IgnoreOnFileChange,
                    RegistrationMode = s.RegistrationMode,
                    ComputedIdentifier = s.ComputedIdentifier,
                    Version = s.Version,
                    IdentifierId = $"{s.IdentifierId}",
                    AppId = $"{s.AppId}",
                    CreatedById = s.CreatedById,
                    UpdatedById = s.UpdatedById,
                    CreatedOn = s.CreatedOn,
                    UpdatedOn = s.UpdatedOn,
                    RowVersion = s.RowVersion,
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.SettingNotFound);
            }

            return HttpStatusCode.OK.ToSuccessJsonResponse(entity);
        }

        public async Task<IJsonResponse> GetSettingDataAsync(GetSettingDataInput input, CancellationToken cancellationToken = default)
        {
            var settingIdValidationRule = JsonValidationRules.GreaterThanRule(nameof(input.SettingId), input.SettingId, 0);

            if (settingIdValidationRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(settingIdValidationRule.Failure);
            }

            var settingId = settingIdValidationRule.GetStoredValue<int>();

            var entity = await _context.Settings
                .AsNoTracking()
                .Where(a => a.Id == settingId)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    a.CompressionType,
                    a.Data
                })
                .FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.SettingNotFound)
                : HttpStatusCode.OK.ToSuccessJsonResponse(new GetSettingDataResponse
                {
                    Data = await _compressionFactory.DecompressToUtf8StringAsync(entity.Data, entity.CompressionType, cancellationToken)
                });
        }

        public async Task<IJsonResponse> DeleteSettingAsync(DeleteSettingInput input, CancellationToken cancellationToken = default)
        {
            var settingIdValidationRule = JsonValidationRules.GreaterThanRule(nameof(input.SettingId), input.SettingId, 0);

            if (settingIdValidationRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(settingIdValidationRule.Failure);
            }

            var settingId = settingIdValidationRule.GetStoredValue<int>();

            var entity = await _context.Settings
                .AsNoTracking()
                .Where(s => s.Id == settingId)
                .OrderBy(s => s.Id)
                .Select(s => new SettingSqlModel
                {
                    Id = settingId,
                    RowVersion = s.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.SettingNotFound);
            }

            if (!input.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict($"{entity.Id}", entity.RowVersion, input.RowVersion, false);
            }

            _context.Settings.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse();
        }

        public async Task<IJsonResponse<GetSettingsLastUpdatedComputedIdentifiersResponse>> GetSettingsLastUpdatedComputedIdentifiersAsync(GetSettingsLastUpdatedComputedIdentifiersInput input, CancellationToken cancellationToken = default)
        {
            input.IdentifierName = input.IdentifierName.ToLowerInvariant();

            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.Settings).ThenInclude(s => s.Identifier)
                .Include(a => a.Settings).ThenInclude(s => s.SettingClass)
                .Where(a => a.ClientId == input.ClientId)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    Settings = a.Settings
                        .Where(s => s.Identifier.NameLowercase == input.IdentifierName && input.LastUpdatedOn.HasValue ? s.UpdatedOn > input.LastUpdatedOn : s.UpdatedOn.HasValue)
                        .Select(s => new { s.ComputedIdentifier, s.UpdatedOn })
                        .ToArray()
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse<GetSettingsLastUpdatedComputedIdentifiersResponse, Errors>(Errors.AppNotFound);
            }

            var computedIdentifierToUpdatedOn = entity.Settings.ToDictionary(s => s.ComputedIdentifier, s => s.UpdatedOn.GetValueOrDefault());

            return HttpStatusCode.OK.ToSuccessJsonResponseOf(new GetSettingsLastUpdatedComputedIdentifiersResponse
            {
                ComputedIdentifierToUpdatedOn = computedIdentifierToUpdatedOn
            });
        }

        public async Task<IJsonResponse> GetSettingByIdAsync(GetSettingByIdInput input, CancellationToken cancellationToken = default)
        {
            var settingIdRule = JsonValidationRules.GreaterThanRule(nameof(input.SettingId), input.SettingId, 0);

            if (settingIdRule.IsFailed())
            {
                return settingIdRule.Failure.ToJsonResponse();
            }

            var settingId = settingIdRule.GetStoredValue<int>();

            var isDataExcluded = input.Excludes.Contains("data");

            var entity = await _context.Settings
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(s => s.SettingClass)
                .Where(s => s.Id == settingId)
                .OrderBy(s => s.Id)
                .Select(s => new
                {
                    s.CompressionType,
                    s.CompressionLevel,
                    Data = isDataExcluded ? null : s.Data,
                    s.DataRestored,
                    s.IdentifierId,
                    s.RegistrationMode,
                    s.DataValidationDisabled,
                    s.StoreInSeparateFile,
                    s.IgnoreOnFileChange,
                    s.ComputedIdentifier,
                    s.Version,
                    SettingRowVersion = s.RowVersion,
                    ClassId = s.SettingClass.Id,
                    ClassNamespace = s.SettingClass.Namespace,
                    ClassName = s.SettingClass.Name,
                    ClassFullName = s.SettingClass.FullName,
                    ClassRowVersion = s.SettingClass.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.SettingNotFound)
                : HttpStatusCode.OK.ToSuccessJsonResponse(new GetSettingByIdResponse
                {
                    Data = entity.Data == null ? null : await _compressionFactory.DecompressToUtf8StringAsync(entity.Data, entity.CompressionType, cancellationToken),
                    DataRestored = entity.DataRestored,
                    IdentifierId = $"{entity.IdentifierId}",
                    RegistrationMode = entity.RegistrationMode,
                    DataValidationDisabled = entity.DataValidationDisabled,
                    StoreInSeparateFile = entity.StoreInSeparateFile,
                    IgnoreOnFileChange = entity.IgnoreOnFileChange,
                    ComputedIdentifier = entity.ComputedIdentifier,
                    Version = entity.Version,
                    RowVersion = entity.SettingRowVersion,
                    Class = new GetSettingByIdResponseClass
                    {
                        Id = $"{entity.ClassId}",
                        Namespace = entity.ClassNamespace,
                        Name = entity.ClassName,
                        FullName = entity.ClassFullName,
                        RowVersion = entity.ClassRowVersion
                    }
                });
        }

        public async Task<IJsonResponse> UpdateSettingAsync(UpdateSettingInput input, CancellationToken cancellationToken = default)
        {
            var settingIdValidationRule = JsonValidationRules.GreaterThanRule(nameof(input.SettingId), input.SettingId, 0);

            if (settingIdValidationRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(settingIdValidationRule.Failure);
            }

            var settingId = settingIdValidationRule.GetStoredValue<int>();

            var entity = await _context.Settings
                .AsNoTracking()
                .Include(s => s.SettingClass)
                .Where(s => s.Id == settingId)
                .OrderBy(s => s.Id)
                .Select(s => new SettingSqlModel
                {
                    Id = settingId,
                    ComputedIdentifier = s.ComputedIdentifier,
                    AppId = s.AppId,
                    IdentifierId = s.IdentifierId,
                    SettingClass = new SettingClassSqlModel
                    {
                        Id = s.SettingClass.Id,
                        RowVersion = s.SettingClass.RowVersion
                    },
                    RowVersion = s.RowVersion
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.SettingNotFound);
            }

            var conflicts = new List<ConflictModel>();

            if (!input.SettingRowVersion.SequenceEqual(entity.RowVersion))
            {
                conflicts.Add(new ConflictModel
                {
                    Id = "SettingId",
                    CurrentRowVersion = entity.RowVersion,
                    ProposedRowVersion = input.SettingRowVersion,
                    Deleted = false
                });
            }

            if (!input.ClassRowVersion.SequenceEqual(entity.SettingClass.RowVersion))
            {
                conflicts.Add(new ConflictModel
                {
                    Id = "ClassId",
                    CurrentRowVersion = entity.SettingClass.RowVersion,
                    ProposedRowVersion = input.ClassRowVersion,
                    Deleted = false
                });
            }

            if (conflicts.Count > 0)
            {
                return FailureResponses.Conflict(conflicts.ToArray());
            }

            if (input.ComputedIdentifier != entity.ComputedIdentifier)
            {
                var hasDuplicateComputedIdentifier = await _context.Settings.AsNoTracking()
                    .Where(s => s.AppId == entity.AppId && s.IdentifierId == entity.IdentifierId &&
                                s.ComputedIdentifier == input.ComputedIdentifier).AnyAsync(cancellationToken);

                if (hasDuplicateComputedIdentifier)
                {
                    return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.DuplicateComputedIdentifier);
                }
            }

            var identicalClassNameSettings = await _context.Settings
                .AsNoTracking()
                .Include(s => s.SettingClass)
                .Where(s =>
                    s.Id != entity.Id &&
                    s.AppId == entity.AppId &&
                    s.IdentifierId == entity.IdentifierId &&
                    s.SettingClass.Name == input.ClassName)
                .OrderBy(s => s.Id)
                .Select(s => new SettingSqlModel
                {
                    Id = s.Id,
                    IgnoreOnFileChange = s.IgnoreOnFileChange,
                    RowVersion = s.RowVersion
                })
                .ToArrayAsync(cancellationToken);

            var ignoreOnFileChange = input.StoreInSeparateFile ? input.IgnoreOnFileChange.GetValueOrDefault(false) : (bool?)null;

            if (identicalClassNameSettings.Length > 0)
            {
                var hasChanges = false;

                foreach (var entitySetting in identicalClassNameSettings)
                {
                    if (entitySetting.IgnoreOnFileChange != true)
                    {
                        continue;
                    }

                    if (input.IgnoreOnFileChange == true)
                    {
                        return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.IgnoreOnFileChangeNotSupported);
                    }

                    _context.Attach(entitySetting);

                    entitySetting.IgnoreOnFileChange = false;

                    _context.MarkAsModified(entitySetting, e => e.IgnoreOnFileChange);

                    hasChanges = true;
                }

                if (hasChanges)
                {
                    await _context.SaveChangesAsync(cancellationToken);
#if NETSTANDARD2_0
                    foreach (var entityEntry in _context.ChangeTracker.Entries().Where(x => x.Entity != null))
                    {
                        entityEntry.State = EntityState.Detached;
                    }
#else
                    _context.ChangeTracker.Clear();
#endif
                }
            }

            _context.Settings.Attach(entity);

            var currentTime = DateTime.UtcNow;
            var rowVersion = currentTime.ToRowVersion();

            entity.SettingClass.Namespace = input.ClassNamespace;
            entity.SettingClass.Name = input.ClassName;
            entity.SettingClass.FullName = input.ClassFullName;
            entity.SettingClass.UpdatedOn = currentTime;
            entity.SettingClass.UpdatedById = input.UpdatedById;
            entity.SettingClass.RowVersion = rowVersion;

            entity.ComputedIdentifier = input.ComputedIdentifier;
            entity.DataValidationDisabled = input.DataValidationDisabled;
            entity.UpdatedOn = currentTime;
            entity.UpdatedById = input.UpdatedById;
            entity.StoreInSeparateFile = input.StoreInSeparateFile;
            entity.IgnoreOnFileChange = ignoreOnFileChange;
            entity.RegistrationMode = input.RegistrationMode;
            entity.RowVersion = rowVersion;

            _context.MarkAsModified(entity.SettingClass,
                e => e.Namespace,
                e => e.Name,
                e => e.FullName,
                e => e.UpdatedOn,
                e => e.UpdatedById,
                e => e.RowVersion);

            _context.MarkAsModified(entity,
                e => e.ComputedIdentifier,
                e => e.DataValidationDisabled,
                e => e.UpdatedOn,
                e => e.UpdatedById,
                e => e.StoreInSeparateFile,
                e => e.IgnoreOnFileChange,
                e => e.RegistrationMode,
                e => e.RowVersion);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse(new UpdateSettingResponse { RowVersion = rowVersion });
        }

        public async Task<IJsonResponse> CreateSettingAsync(CreateSettingInput input, CancellationToken cancellationToken = default)
        {
            var appIdRule = JsonValidationRules.GreaterThanRule(nameof(input.AppId), input.AppId, 0);
            var computedIdentifierRule = JsonValidationRules.NotEmptyRule(nameof(input.ComputedIdentifier), input.ComputedIdentifier);
            var identifierIdRule = JsonValidationRules.GreaterThanRule(nameof(input.IdentifierId), input.IdentifierId, 0);
            var validJsonRule = JsonValidationRules.ValidJsonRule(nameof(input.Data), input.Data);

            var failure = new[] { appIdRule, computedIdentifierRule, identifierIdRule, validJsonRule }.ValidateFirstOrDefault();

            if (failure != null)
            {
                return failure.ToJsonResponse();
            }

            var appId = appIdRule.GetStoredValue<int>();
            var identifierId = identifierIdRule.GetStoredValue<int>();

            var entity = await _context.Apps
                .AsNoTracking()
                .Include(a => a.Settings).ThenInclude(s => s.SettingClass)
                .Where(a => a.Id == appId)
                .OrderBy(a => a.Id)
                .Select(a => new AppSqlModel
                {
                    Settings = a.Settings.Select(s => new SettingSqlModel
                    {
                        Id = s.Id,
                        ComputedIdentifier = s.ComputedIdentifier,
                        IdentifierId = s.IdentifierId,
                        IgnoreOnFileChange = s.IgnoreOnFileChange,
                        RowVersion = s.RowVersion,
                        SettingClass = new SettingClassSqlModel
                        {
                            Name = s.SettingClass.Name
                        }
                    }).ToList()
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.AppNotFound);
            }

            if (entity.Settings.Count > 0)
            {
                var hasChanges = false;

                foreach (var entitySetting in entity.Settings)
                {
                    if (entitySetting.IdentifierId == identifierId &&
                        entitySetting.ComputedIdentifier == input.ComputedIdentifier)
                    {
                        return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.DuplicateSetting);
                    }

                    if (entitySetting.SettingClass.Name != input.ClassName ||
                        entitySetting.IgnoreOnFileChange != true)
                    {
                        continue;
                    }

                    if (input.IgnoreOnFileChange == true)
                    {
                        return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.IgnoreOnFileChangeNotSupported);
                    }

                    _context.Attach(entitySetting);

                    entitySetting.IgnoreOnFileChange = false;

                    _context.MarkAsModified(entitySetting, e => e.IgnoreOnFileChange);

                    hasChanges = true;
                }

                if (hasChanges)
                {
                    await _context.SaveChangesAsync(cancellationToken);
#if NETSTANDARD2_0
                    foreach (var entityEntry in _context.ChangeTracker.Entries().Where(x => x.Entity != null))
                    {
                        entityEntry.State = EntityState.Detached;
                    }
#else
                    _context.ChangeTracker.Clear();
#endif
                }
            }

            var currentTime = DateTime.UtcNow;

            entity.Id = appId;

            entity.Settings.Clear();

            _context.Apps.Attach(entity);

            var setting = new SettingSqlModel
            {
                CompressionType = _openSettingsConfiguration.Provider.CompressionType,
                CompressionLevel = _openSettingsConfiguration.Provider.CompressionLevel,
                Data = await _compressionFactory.CompressAsync(_openSettingsConfiguration.Provider.CompressionType, input.Data, _openSettingsConfiguration.Provider.CompressionLevel, cancellationToken),
                ComputedIdentifier = input.ComputedIdentifier,
                IdentifierId = identifierId,
                Version = "0",
                CreatedOn = currentTime,
                CreatedById = input.CreatedById,
                StoreInSeparateFile = input.StoreInSeparateFile,
                IgnoreOnFileChange = input.StoreInSeparateFile ? input.IgnoreOnFileChange.GetValueOrDefault(false) : (bool?)null,
                RegistrationMode = input.RegistrationMode,
                SettingClass = new SettingClassSqlModel
                {
                    Name = input.ClassName ?? string.Empty,
                    FullName = input.ClassFullName ?? string.Empty,
                    Namespace = input.ClassNamespace ?? string.Empty,
                    CreatedOn = currentTime,
                    CreatedById = input.CreatedById
                }
            };

            entity.Settings.Add(setting);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse(new CreateSettingResponse
            {
                SettingId = $"{setting.Id}",
                ClassId = $"{setting.SettingClass.Id}"
            });
        }

        public async Task<IJsonResponse<UpdateSettingDataResponse>> UpdateSettingDataAsync(UpdateSettingDataInput input, CancellationToken cancellationToken)
        {
            var settingIdValidationRule = JsonValidationRules.GreaterThanRule(nameof(input.SettingId), input.SettingId, 0);
            var validJsonRule = JsonValidationRules.ValidJsonRule(nameof(input.Data), input.Data);

            var failure = new ValidationRule[] { settingIdValidationRule, validJsonRule }.ValidateFirstOrDefault();

            if (failure != null)
            {
                return failure.ToJsonResponse<UpdateSettingDataResponse>();
            }

            var settingId = settingIdValidationRule.GetStoredValue<int>();

            var entity = await _context.Settings
                .AsNoTracking()
                .Include(a => a.App)
                .Include(a => a.SettingClass)
                .Include(a => a.Identifier)
                .Where(a => a.Id == settingId)
                .OrderBy(a => a.Id)
                .Select(a => new SettingSqlModel
                {
                    Id = settingId,
                    CompressionType = a.CompressionType,
                    CompressionLevel = a.CompressionLevel,
                    Data = a.Data,
                    ComputedIdentifier = a.ComputedIdentifier,
                    Version = a.Version,
                    DataRestored = a.DataRestored,
                    DataValidationDisabled = a.DataValidationDisabled,
                    CreatedOn = a.CreatedOn,
                    RowVersion = a.RowVersion,
                    App = new AppSqlModel
                    {
                        Id = a.App.Id,
                        ClientId = a.App.ClientId
                    },
                    SettingClass = new SettingClassSqlModel
                    {
                        Id = a.Id,
                        Properties = a.SettingClass.Properties
                    },
                    Identifier = new IdentifierSqlModel
                    {
                        Id = a.Id,
                        Name = a.Identifier.Name
                    }
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse<UpdateSettingDataResponse, Errors>(Errors.SettingNotFound);
            }

            if (!input.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict<UpdateSettingDataResponse>($"{entity.Id}", entity.RowVersion, input.RowVersion, false);
            }

            var decompressedEntityData = await _compressionFactory.DecompressToUtf8StringAsync(entity.Data, entity.CompressionType, cancellationToken);

            if (input.Data == decompressedEntityData)
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse<UpdateSettingDataResponse, Errors>(Errors.NoChanges);
            }

            if (!entity.DataValidationDisabled && !_settingsDataValidationService.IsDataMappingValid(input.Data, entity.SettingClass.Properties))
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse<UpdateSettingDataResponse, Errors>(Errors.InvalidSettingData);
            }

            var currentTime = DateTime.UtcNow;

            var previousVersion = entity.Version;

            _context.Settings.Attach(entity);

            if (!entity.DataRestored)
            {
                var history = new SettingHistorySqlModel
                {
                    CompressionType = entity.CompressionType,
                    CompressionLevel = entity.CompressionLevel,
                    Data = entity.Data,
                    Version = previousVersion,
                    Slug = previousVersion.ToSlug(),
                    CreatedOn = currentTime,
                    CreatedById = input.UpdatedById
                };

                entity.SettingHistories.Add(history);
            }

            entity.CompressionType = _openSettingsConfiguration.Provider.CompressionType;
            entity.CompressionLevel = _openSettingsConfiguration.Provider.CompressionLevel;
            entity.Data = await _compressionFactory.CompressAsync(_openSettingsConfiguration.Provider.CompressionType, input.Data, _openSettingsConfiguration.Provider.CompressionLevel, cancellationToken);
            entity.Version = Helper.CalculateVersion(currentTime, entity.CreatedOn);
            entity.UpdatedOn = currentTime;
            entity.UpdatedById = input.UpdatedById;
            entity.DataRestored = false;
            entity.RowVersion = currentTime.ToRowVersion();

            await _context.SaveChangesAsync(cancellationToken);

            if (_dataChangeService != null)
            {
                await _dataChangeService.NotifyChangeAsync(entity.App.ClientId, entity.Identifier.Name, entity.ComputedIdentifier, cancellationToken);
            }

            return HttpStatusCode.OK.ToSuccessJsonResponseOf(new UpdateSettingDataResponse
            {
                ClientId = entity.App.ClientId,
                Setting = new UpdateSettingDataResponseSetting
                {
                    ComputedIdentifier = entity.ComputedIdentifier,
                    CurrentVersion = entity.Version,
                    PreviousVersion = previousVersion,
                    IdentifierName = entity.Identifier.Name,
                    DataValidationDisabled = entity.DataValidationDisabled,
                    DataRestored = entity.DataRestored,
                    RowVersion = entity.RowVersion
                }
            });
        }

        private async Task<IJsonResponse> GetSettingsByAppAndIdentifierAsync(Expression<Func<AppSqlModel, bool>> predicate, int identifierId, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.Settings).ThenInclude(a => a.SettingClass)
                .Where(predicate)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    Settings = a.Settings.Where(s => s.IdentifierId == identifierId).Select(s => new GetSettingsByAppAndIdentifierResponseSetting
                    {
                        Id = $"{s.Id}",
                        ComputedIdentifier = s.ComputedIdentifier,
                        Version = s.Version,
                        DataValidationDisabled = s.DataValidationDisabled,
                        DataRestored = s.DataRestored,
                        Class = new GetSettingsByAppAndIdentifierResponseSettingClass
                        {
                            Id = $"{s.SettingClass.Id}",
                            Name = s.SettingClass.Name,
                            Namespace = s.SettingClass.Namespace,
                            FullName = s.SettingClass.FullName
                        }
                    }).ToArray()
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.AppNotFound);
            }

            return HttpStatusCode.OK.ToSuccessJsonResponse(entity.Settings);
        }

        private async Task<bool> HasSomeSettingAsync(int appId, int IdentifierId, Guid computedIdentifier, CancellationToken cancellationToken)
        {
            return await _context.Settings
                .AsNoTracking()
                .Where(a => a.AppId == appId &&
                            a.ComputedIdentifier == computedIdentifier &&
                            a.IdentifierId == IdentifierId)
                .AnyAsync(cancellationToken);
        }
    }
}