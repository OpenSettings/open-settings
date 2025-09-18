using Microsoft.EntityFrameworkCore;
using Ogu.Compressions.Abstractions;
using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
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
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql
{
    internal sealed class AppSettingsSqlService : ISettingsSqlService
    {
        private readonly IDataChangeService _dataChangeService;
        private readonly IIdentifierService _identifiersService;
        private readonly ICompressionProvider _compressionProvider;
        private readonly OpenSettingsDbContext _context;
        private readonly IDataValidationService _dataValidationService;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;

        public AppSettingsSqlService(
            IDataChangeService dataChangeService,
            IIdentifierService identifiersService,
            ICompressionProvider compressionProvider,
            OpenSettingsDbContext context,
            IDataValidationService dataValidationService,
            OpenSettingsConfiguration openSettingsConfiguration)
        {
            _dataChangeService = dataChangeService;
            _identifiersService = identifiersService;
            _compressionProvider = compressionProvider;
            _context = context;
            _dataValidationService = dataValidationService;
            _openSettingsConfiguration = openSettingsConfiguration;
        }

        public async Task<IResponse> GetSettingsByAppIdAndIdentifierIdAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var appIdValidationRule = ValidationRules.GreaterThanRule("AppId", input.AppIdOrSlug, 0);
            var identifierIdValidationRule = ValidationRules.GreaterThanRule("IdentifierId", input.IdentifierIdOrSlug, 0);

            var failure = new ValidationRule[] { appIdValidationRule, identifierIdValidationRule }.ValidateFirstOrDefault();

            if (failure != null)
            {
                return failure.ToResponse();
            }

            var appId = appIdValidationRule.GetStoredValue<int>();
            var identifierId = identifierIdValidationRule.GetStoredValue<int>();

            return await GetSettingsByAppAndIdentifierAsync(a => a.Id == appId, identifierId, cancellationToken);
        }

        public async Task<IResponse> GetSettingsByAppSlugAndIdentifierSlugAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
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
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.IdentifierNotFound);
            }

            return await GetSettingsByAppAndIdentifierAsync(a => a.Slug == appSlug, identifier.Id, cancellationToken);
        }

        public async Task<IResponse> GetSettingsDataAsync(GetSettingsDataInput input, CancellationToken cancellationToken = default)
        {
            var query = _context.AppSettings.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(input.AppId))
            {
                var appIdRule = ValidationRules.GreaterThanRule(nameof(input.AppId), input.AppId, 0);

                if (appIdRule.IsFailed())
                {
                    return appIdRule.Failure.ToResponse();
                }

                var appId = appIdRule.GetStoredValue<int>();

                query = query.Where(s => s.AppId == appId);
            }

            if (!string.IsNullOrWhiteSpace(input.IdentifierId))
            {
                var IdentifierIdRule = ValidationRules.GreaterThanRule(nameof(input.IdentifierId),
                    input.IdentifierId, 0);

                if (IdentifierIdRule.IsFailed())
                {
                    return IdentifierIdRule.Failure.ToResponse();
                }

                var IdentifierId = IdentifierIdRule.GetStoredValue<int>();

                query = query.Where(s => s.IdentifierId == IdentifierId);
            }

            if (!string.IsNullOrWhiteSpace(input.Ids))
            {
                var idArray = input.Ids
                    .Split(OpenSettingsDefaults.Separators.CommaSeparator, StringSplitOptions.RemoveEmptyEntries)
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
                var data = await _compressionProvider.DecompressToUtf8StringAsync(s.Data, s.CompressionType, cancellationToken);

                return new GetSettingsDataResponseSetting
                {
                    Id = s.Id.ToString(),
                    Data = data,
                };
            });

            return HttpStatusCode.OK.ToSuccessResponse(new GetSettingsDataResponse
            {
                Settings = await Task.WhenAll(tasks)
            });
        }

        public async Task<IResponse> CopySettingToAsync(CopySettingToInput input, CancellationToken cancellationToken = default)
        {
            var settingIdRule = ValidationRules.GreaterThanRule(nameof(input.SettingId), input.SettingId, 0);
            var targetAppIdRule = ValidationRules.GreaterThanRule(nameof(input.TargetAppId), input.TargetAppId, 0);
            var identifierIdRule = ValidationRules.GreaterThanRule(nameof(input.IdentifierId), input.IdentifierId, -1);

            var validationFailure = new[] { settingIdRule, targetAppIdRule, identifierIdRule }.ValidateFirstOrDefault();

            if (validationFailure != null)
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(validationFailure);
            }

            var settingId = settingIdRule.GetStoredValue<int>();
            var targetAppId = targetAppIdRule.GetStoredValue<int>();
            var identifierId = identifierIdRule.GetStoredValue<int>();

            var sourceSetting = await _context.AppSettings
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppSettingClass)
                .Include(a => a.App).ThenInclude(a => a.AppIdentifierMappings).ThenInclude(a => a.Identifier)
                .Where(a => a.Id == settingId)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    a.AppId,
                    a.App.ClientId,
                    AppSlug = a.App.Slug,
                    a.SerializerType,
                    a.CompressionType,
                    a.CompressionLevel,
                    a.Data,
                    a.ComputedIdentifier,
                    a.DataValidationDisabled,
                    a.StoreInSeparateFile,
                    a.IgnoreOnFileChange,
                    a.RegistrationMode,
                    a.IsDraft,
                    a.IdentifierId,
                    a.AppSettingClass.Namespace,
                    a.AppSettingClass.Name,
                    a.AppSettingClass.FullName,
                    a.AppSettingClass.Identifier,
                    a.AppSettingClass.Properties,
                    Identifiers = a.App.AppIdentifierMappings.Select(m => new { m.IdentifierId, m.Identifier.Name, m.Identifier.SortOrder, MappingSortOrder = m.SortOrder }).ToArray(),
                }).FirstOrDefaultAsync(cancellationToken);

            if (sourceSetting == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.SettingNotFound);
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
                    return HttpStatusCode.NotFound.ToFailureResponse(Errors.TargetAppNotFound);
                }

                clientId = targetApp.ClientId;
                appSlug = targetApp.Slug;
                identifierIdToIdentifier = targetApp.Identifiers.ToDictionary(s => s.IdentifierId);
            }
            else if (sourceSetting.IdentifierId == identifierId)
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.DuplicateSetting);
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
                    return HttpStatusCode.NotFound.ToFailureResponse(Errors.IdentifierNotFound);
                }

                identifierSortOrder = identifierEntity.SortOrder;

                var hasSomeSetting = await HasSomeSettingAsync(targetAppId, identifierId, sourceSetting.ComputedIdentifier, cancellationToken);

                if (hasSomeSetting)
                {
                    return HttpStatusCode.BadRequest.ToFailureResponse(Errors.DuplicateTargetSetting);
                }
            }
            else if (identifierId == 0 && !string.IsNullOrWhiteSpace(input.IdentifierName))
            {
                var identifierGetOrCreateResponse = await _identifiersService.GetOrCreateAsync(input.IdentifierName, SetSortOrderPosition.Bottom, input.UserId, cancellationToken);

                if (!identifierGetOrCreateResponse.Success)
                {
                    return identifierGetOrCreateResponse.ToResponse();
                }

                identifierId = identifierGetOrCreateResponse.Data.Id;
                identifierName = identifierGetOrCreateResponse.Data.Name;
                identifierSortOrder = identifierGetOrCreateResponse.Data.SortOrder;

                if (!identifierGetOrCreateResponse.Data.IsNewlyCreated)
                {
                    var hasSomeSetting = await HasSomeSettingAsync(targetAppId, identifierId, sourceSetting.ComputedIdentifier, cancellationToken);

                    if (hasSomeSetting)
                    {
                        return HttpStatusCode.BadRequest.ToFailureResponse(Errors.DuplicateTargetSetting);
                    }
                }
            }
            else
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.IdentifierMustNotEmpty);
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
                            .MaxAsync(s => s.SortOrder, cancellationToken) + OpenSettingsDefaults.SortOrderGap;
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

            var configuration = await _context.AppConfigurations.AsNoTracking()
                .AnyAsync(c => c.AppId == targetAppId && c.IdentifierId == identifierId, cancellationToken);

            if (!configuration)
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
                    IdentifierId = identifierId,
                    CreatedOn = currentTime,
                    CreatedById = input.UserId
                });
            }

            var newSetting = new AppSettingSqlModel
            {
                Data = sourceSetting.Data,
                ComputedIdentifier = sourceSetting.ComputedIdentifier,
                SerializerType = sourceSetting.SerializerType,
                CompressionType = sourceSetting.CompressionType,
                CompressionLevel = sourceSetting.CompressionLevel,
                Version = "0",
                DataRestored = false,
                DataValidationDisabled = sourceSetting.DataValidationDisabled,
                StoreInSeparateFile = sourceSetting.StoreInSeparateFile,
                IgnoreOnFileChange = sourceSetting.IgnoreOnFileChange,
                RegistrationMode = sourceSetting.RegistrationMode,
                IsDraft = sourceSetting.IsDraft,
                IsCopied = true,
                CopiedOn = currentTime,
                IdentifierId = identifierId,
                AppId = sourceSetting.AppId,
                CopiedFromId = settingId,
                CreatedById = input.UserId,
                UpdatedById = null,
                RowVersion = Array.Empty<byte>(),
                CreatedOn = currentTime,
                AppSettingClass = new AppSettingClassSqlModel
                {
                    Namespace = sourceSetting.Namespace,
                    Name = sourceSetting.Name,
                    FullName = sourceSetting.FullName,
                    Identifier = sourceSetting.Identifier,
                    Properties = sourceSetting.Properties
                }
            };

            app.AppSettings.Add(newSetting);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse(new CopySettingToResponse
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
                    ClassId = $"{newSetting.AppSettingClass.Id}"
                }
            });
        }

        public async Task<IResponse> GetSettingAsync(GetSettingInput input, CancellationToken cancellationToken = default)
        {
            var settingIdValidationRule = ValidationRules.GreaterThanRule(nameof(input.Id), input.Id, 0);

            if (settingIdValidationRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(settingIdValidationRule.Failure);
            }

            var settingId = settingIdValidationRule.GetStoredValue<int>();

            var entity = await _context.AppSettings
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
                HttpStatusCode.BadRequest.ToFailureResponse(Errors.SettingNotFound);
            }

            return HttpStatusCode.OK.ToSuccessResponse(entity);
        }

        public async Task<IResponse> GetSettingDataAsync(GetSettingDataInput input, CancellationToken cancellationToken = default)
        {
            var settingIdValidationRule = ValidationRules.GreaterThanRule(nameof(input.SettingId), input.SettingId, 0);

            if (settingIdValidationRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(settingIdValidationRule.Failure);
            }

            var settingId = settingIdValidationRule.GetStoredValue<int>();

            var entity = await _context.AppSettings
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppSettingClass)
                .Where(a => a.Id == settingId)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    a.CompressionType,
                    a.Data,
                    a.AppSettingClass.Properties
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.SettingNotFound);
            }

            var data = await _compressionProvider.DecompressToUtf8StringAsync(entity.Data, entity.CompressionType, cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse(new GetSettingDataResponse
            {
                Data = data
            });

            //var jsonNode = JsonNode.Parse(data);

            //if (jsonNode == null)
            //{
            //    return HttpStatusCode.OK.ToSuccessResponse(new GetSettingDataResponse
            //    {
            //        Data = data
            //    });
            //}

            //foreach (var property in entity.Properties)
            //{
            //    if (property.IsStringType() && jsonNode[property.Name] != null && property.HasSecretTextAttribute())
            //    {
            //        jsonNode[property.Name] = OpenSettingsDefaults.Password;
            //    }
            //}

            //return HttpStatusCode.OK.ToSuccessResponse(new GetSettingDataResponse
            //{
            //    Data = jsonNode.ToJsonString(OpenSettingsDefaults.Serialization.UnsafeRelaxedJsonSerializerOptions)
            //});
        }

        public async Task<IResponse> DeleteSettingAsync(DeleteSettingInput input, CancellationToken cancellationToken = default)
        {
            var settingIdValidationRule = ValidationRules.GreaterThanRule(nameof(input.SettingId), input.SettingId, 0);

            if (settingIdValidationRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(settingIdValidationRule.Failure);
            }

            var settingId = settingIdValidationRule.GetStoredValue<int>();

            var entity = await _context.AppSettings
                .AsNoTracking()
                .Where(s => s.Id == settingId)
                .OrderBy(s => s.Id)
                .Select(s => new AppSettingSqlModel
                {
                    Id = settingId,
                    RowVersion = s.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.SettingNotFound);
            }

            if (!input.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict($"{entity.Id}", entity.RowVersion, input.RowVersion, false);
            }

            var appSettings = await _context.AppSettings.AsNoTracking().Where(a => a.CopiedFromId == settingId).Select(a => new AppSettingSqlModel { Id = a.Id }).ToArrayAsync(cancellationToken);

            if (appSettings.Length > 0)
            {
                foreach (var appSetting in appSettings)
                {
                    var entry = _context.Entry(appSetting);
                    appSetting.CopiedFromId = null;
                    entry.Property(e => e.CopiedFromId).IsModified = true;
                }

                await _context.SaveChangesAsync(cancellationToken);
            }

            _context.AppSettings.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse();
        }

        public async Task<IResponse<GetSettingsLastUpdatedComputedIdentifiersResponse>> GetSettingsLastUpdatedComputedIdentifiersAsync(GetSettingsLastUpdatedComputedIdentifiersInput input, CancellationToken cancellationToken = default)
        {
            input.IdentifierName = input.IdentifierName.ToLowerInvariant();

            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppSettings).ThenInclude(s => s.Identifier)
                .Include(a => a.AppSettings).ThenInclude(s => s.AppSettingClass)
                .Where(a => a.ClientId == input.ClientId)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    Settings = a.AppSettings
                        .Where(s => s.Identifier.NameLowercase == input.IdentifierName && input.LastUpdatedOn.HasValue ? s.UpdatedOn > input.LastUpdatedOn : s.UpdatedOn.HasValue)
                        .Select(s => new { s.ComputedIdentifier, s.UpdatedOn })
                        .ToArray()
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse<GetSettingsLastUpdatedComputedIdentifiersResponse, Errors>(Errors.AppNotFound);
            }

            var computedIdentifierToUpdatedOn = entity.Settings.ToDictionary(s => s.ComputedIdentifier, s => s.UpdatedOn.GetValueOrDefault());

            return HttpStatusCode.OK.ToSuccessResponseOf(new GetSettingsLastUpdatedComputedIdentifiersResponse
            {
                ComputedIdentifierToUpdatedOn = computedIdentifierToUpdatedOn
            });
        }

        public async Task<IResponse> GetSettingByIdAsync(GetSettingByIdInput input, CancellationToken cancellationToken = default)
        {
            var settingIdRule = ValidationRules.GreaterThanRule(nameof(input.SettingId), input.SettingId, 0);

            if (settingIdRule.IsFailed())
            {
                return settingIdRule.Failure.ToResponse();
            }

            var settingId = settingIdRule.GetStoredValue<int>();

            var isDataExcluded = input.Excludes.Contains("data");

            var entity = await _context.AppSettings
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(s => s.AppSettingClass)
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
                    ClassId = s.AppSettingClass.Id,
                    ClassNamespace = s.AppSettingClass.Namespace,
                    ClassName = s.AppSettingClass.Name,
                    ClassFullName = s.AppSettingClass.FullName,
                    ClassRowVersion = s.AppSettingClass.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureResponse(Errors.SettingNotFound)
                : HttpStatusCode.OK.ToSuccessResponse(new GetSettingByIdResponse
                {
                    Data = entity.Data == null ? null : await _compressionProvider.DecompressToUtf8StringAsync(entity.Data, entity.CompressionType, cancellationToken),
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

        public async Task<IResponse> UpdateSettingAsync(UpdateSettingInput input, CancellationToken cancellationToken = default)
        {
            var settingIdValidationRule = ValidationRules.GreaterThanRule(nameof(input.SettingId), input.SettingId, 0);

            if (settingIdValidationRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(settingIdValidationRule.Failure);
            }

            var settingId = settingIdValidationRule.GetStoredValue<int>();

            var entity = await _context.AppSettings
                .AsNoTracking()
                .Include(s => s.AppSettingClass)
                .Where(s => s.Id == settingId)
                .OrderBy(s => s.Id)
                .Select(s => new AppSettingSqlModel
                {
                    Id = settingId,
                    ComputedIdentifier = s.ComputedIdentifier,
                    AppId = s.AppId,
                    IdentifierId = s.IdentifierId,
                    AppSettingClass = new AppSettingClassSqlModel
                    {
                        Id = s.AppSettingClass.Id,
                        RowVersion = s.AppSettingClass.RowVersion
                    },
                    RowVersion = s.RowVersion
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.SettingNotFound);
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

            if (!input.ClassRowVersion.SequenceEqual(entity.AppSettingClass.RowVersion))
            {
                conflicts.Add(new ConflictModel
                {
                    Id = "ClassId",
                    CurrentRowVersion = entity.AppSettingClass.RowVersion,
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
                var hasDuplicateComputedIdentifier = await _context.AppSettings.AsNoTracking()
                    .Where(s => s.AppId == entity.AppId && s.IdentifierId == entity.IdentifierId &&
                                s.ComputedIdentifier == input.ComputedIdentifier).AnyAsync(cancellationToken);

                if (hasDuplicateComputedIdentifier)
                {
                    return HttpStatusCode.BadRequest.ToFailureResponse(Errors.DuplicateComputedIdentifier);
                }
            }

            var identicalClassNameSettings = await _context.AppSettings
                .AsNoTracking()
                .Include(s => s.AppSettingClass)
                .Where(s =>
                    s.Id != entity.Id &&
                    s.AppId == entity.AppId &&
                    s.IdentifierId == entity.IdentifierId &&
                    s.AppSettingClass.Name == input.ClassName)
                .OrderBy(s => s.Id)
                .Select(s => new AppSettingSqlModel
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
                        return HttpStatusCode.BadRequest.ToFailureResponse(Errors.IgnoreOnFileChangeNotSupported);
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

            _context.AppSettings.Attach(entity);

            var currentTime = DateTime.UtcNow;
            var rowVersion = currentTime.ToRowVersion();

            entity.AppSettingClass.Namespace = input.ClassNamespace;
            entity.AppSettingClass.Name = input.ClassName;
            entity.AppSettingClass.FullName = input.ClassFullName;
            entity.AppSettingClass.UpdatedOn = currentTime;
            entity.AppSettingClass.UpdatedById = input.UpdatedById;
            entity.AppSettingClass.RowVersion = rowVersion;

            entity.ComputedIdentifier = input.ComputedIdentifier;
            entity.DataValidationDisabled = input.DataValidationDisabled;
            entity.UpdatedOn = currentTime;
            entity.UpdatedById = input.UpdatedById;
            entity.StoreInSeparateFile = input.StoreInSeparateFile;
            entity.IgnoreOnFileChange = ignoreOnFileChange;
            entity.RegistrationMode = input.RegistrationMode;
            entity.RowVersion = rowVersion;

            _context.MarkAsModified(entity.AppSettingClass,
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

            return HttpStatusCode.OK.ToSuccessResponse(new UpdateSettingResponse { RowVersion = rowVersion });
        }

        public async Task<IResponse> CreateSettingAsync(CreateSettingInput input, CancellationToken cancellationToken = default)
        {
            var appIdRule = ValidationRules.GreaterThanRule(nameof(input.AppId), input.AppId, 0);
            var computedIdentifierRule = ValidationRules.NotEmptyRule(nameof(input.ComputedIdentifier), input.ComputedIdentifier);
            var identifierIdRule = ValidationRules.GreaterThanRule(nameof(input.IdentifierId), input.IdentifierId, 0);
            var validJsonRule = InternalExtensions.ValidJsonRule(nameof(input.Data), input.Data, storeParsedValue: false);

            var failure = new[] { appIdRule, computedIdentifierRule, identifierIdRule, validJsonRule }.ValidateFirstOrDefault();

            if (failure != null)
            {
                return failure.ToResponse();
            }

            var appId = appIdRule.GetStoredValue<int>();
            var identifierId = identifierIdRule.GetStoredValue<int>();

            var entity = await _context.Apps
                .AsNoTracking()
                .Include(a => a.AppSettings).ThenInclude(s => s.AppSettingClass)
                .Where(a => a.Id == appId)
                .OrderBy(a => a.Id)
                .Select(a => new AppSqlModel
                {
                    AppSettings = a.AppSettings.Select(s => new AppSettingSqlModel
                    {
                        Id = s.Id,
                        ComputedIdentifier = s.ComputedIdentifier,
                        IdentifierId = s.IdentifierId,
                        IgnoreOnFileChange = s.IgnoreOnFileChange,
                        RowVersion = s.RowVersion,
                        AppSettingClass = new AppSettingClassSqlModel
                        {
                            Name = s.AppSettingClass.Name
                        }
                    }).ToList()
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.AppNotFound);
            }

            if (entity.AppSettings.Count > 0)
            {
                var hasChanges = false;

                foreach (var entitySetting in entity.AppSettings)
                {
                    if (entitySetting.IdentifierId == identifierId &&
                        entitySetting.ComputedIdentifier == input.ComputedIdentifier)
                    {
                        return HttpStatusCode.BadRequest.ToFailureResponse(Errors.DuplicateSetting);
                    }

                    if (entitySetting.AppSettingClass.Name != input.ClassName ||
                        entitySetting.IgnoreOnFileChange != true)
                    {
                        continue;
                    }

                    if (input.IgnoreOnFileChange == true)
                    {
                        return HttpStatusCode.BadRequest.ToFailureResponse(Errors.IgnoreOnFileChangeNotSupported);
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

            entity.AppSettings.Clear();

            _context.Apps.Attach(entity);

            var setting = new AppSettingSqlModel
            {
                CompressionType = _openSettingsConfiguration.Provider.CompressionType,
                CompressionLevel = _openSettingsConfiguration.Provider.CompressionLevel,
                Data = await _compressionProvider.CompressAsync(_openSettingsConfiguration.Provider.CompressionType, input.Data, _openSettingsConfiguration.Provider.CompressionLevel, cancellationToken),
                ComputedIdentifier = input.ComputedIdentifier,
                IdentifierId = identifierId,
                Version = "0",
                CreatedOn = currentTime,
                CreatedById = input.CreatedById,
                StoreInSeparateFile = input.StoreInSeparateFile,
                IgnoreOnFileChange = input.StoreInSeparateFile ? input.IgnoreOnFileChange.GetValueOrDefault(false) : (bool?)null,
                RegistrationMode = input.RegistrationMode,
                AppSettingClass = new AppSettingClassSqlModel
                {
                    Name = input.ClassName ?? string.Empty,
                    FullName = input.ClassFullName ?? string.Empty,
                    Namespace = input.ClassNamespace ?? string.Empty,
                    CreatedOn = currentTime,
                    CreatedById = input.CreatedById
                }
            };

            entity.AppSettings.Add(setting);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse(new CreateSettingResponse
            {
                SettingId = $"{setting.Id}",
                ClassId = $"{setting.AppSettingClass.Id}"
            });
        }

        public async Task<IResponse<UpdateSettingDataResponse>> UpdateSettingDataAsync(UpdateSettingDataInput input, CancellationToken cancellationToken)
        {
            var settingIdValidationRule = ValidationRules.GreaterThanRule(nameof(input.SettingId), input.SettingId, 0);
            var validJsonRule = InternalExtensions.ValidJsonRule(nameof(input.Data), input.Data, storeParsedValue: true);

            var failure = new ValidationRule[] { settingIdValidationRule, validJsonRule }.ValidateFirstOrDefault();

            if (failure != null)
            {
                return failure.ToResponse<UpdateSettingDataResponse>();
            }

            var settingId = settingIdValidationRule.GetStoredValue<int>();

            var jsonDocument = validJsonRule.GetStoredValue<JsonDocument>();

            var entity = await _context.AppSettings
                .AsNoTracking()
                .Include(a => a.App)
                .Include(a => a.AppSettingClass)
                .Include(a => a.Identifier)
                .Where(a => a.Id == settingId)
                .OrderBy(a => a.Id)
                .Select(a => new AppSettingSqlModel
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
                    AppSettingClass = new AppSettingClassSqlModel
                    {
                        Id = a.Id,
                        Properties = a.AppSettingClass.Properties
                    },
                    Identifier = new IdentifierSqlModel
                    {
                        Id = a.Id,
                        Name = a.Identifier.Name
                    }
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse<UpdateSettingDataResponse, Errors>(Errors.SettingNotFound);
            }

            if (!input.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict<UpdateSettingDataResponse>($"{entity.Id}", entity.RowVersion, input.RowVersion, false);
            }

            var decompressedEntityData = await _compressionProvider.DecompressToUtf8StringAsync(entity.Data, entity.CompressionType, cancellationToken);

            if (input.Data == decompressedEntityData)
            {
                return HttpStatusCode.BadRequest.ToFailureResponse<UpdateSettingDataResponse, Errors>(Errors.NoChanges);
            }

            if (!entity.DataValidationDisabled && !_dataValidationService.IsDataMappingValid(jsonDocument, entity.AppSettingClass.Properties))
            {
                return HttpStatusCode.BadRequest.ToFailureResponse<UpdateSettingDataResponse, Errors>(Errors.InvalidSettingData);
            }

            jsonDocument.Dispose();

            var currentTime = DateTime.UtcNow;

            var previousVersion = entity.Version;

            _context.AppSettings.Attach(entity);

            if (!entity.DataRestored)
            {
                var history = new AppSettingHistorySqlModel
                {
                    CompressionType = entity.CompressionType,
                    CompressionLevel = entity.CompressionLevel,
                    Data = entity.Data,
                    Version = previousVersion,
                    Slug = previousVersion.ToSlug(),
                    CreatedOn = currentTime,
                    CreatedById = input.UpdatedById
                };

                entity.AppSettingHistories.Add(history);
            }

            entity.CompressionType = _openSettingsConfiguration.Provider.CompressionType;
            entity.CompressionLevel = _openSettingsConfiguration.Provider.CompressionLevel;
            entity.Data = await _compressionProvider.CompressAsync(_openSettingsConfiguration.Provider.CompressionType, input.Data, _openSettingsConfiguration.Provider.CompressionLevel, cancellationToken);
            entity.Version = Helper.GenerateVersion(currentTime, entity.CreatedOn);
            entity.UpdatedOn = currentTime;
            entity.UpdatedById = input.UpdatedById;
            entity.DataRestored = false;
            entity.RowVersion = currentTime.ToRowVersion();

            await _context.SaveChangesAsync(cancellationToken);

            if (_dataChangeService != null)
            {
                await _dataChangeService.NotifyChangeAsync(entity.App.ClientId, entity.Identifier.Name, entity.ComputedIdentifier, cancellationToken);
            }

            return HttpStatusCode.OK.ToSuccessResponseOf(new UpdateSettingDataResponse
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

        private async Task<IResponse> GetSettingsByAppAndIdentifierAsync(Expression<Func<AppSqlModel, bool>> predicate, int identifierId, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppSettings).ThenInclude(a => a.AppSettingClass)
                .Where(predicate)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    Settings = a.AppSettings.Where(s => s.IdentifierId == identifierId).Select(s => new GetSettingsByAppAndIdentifierResponseSetting
                    {
                        Id = $"{s.Id}",
                        ComputedIdentifier = s.ComputedIdentifier,
                        Version = s.Version,
                        DataValidationDisabled = s.DataValidationDisabled,
                        DataRestored = s.DataRestored,
                        Class = new GetSettingsByAppAndIdentifierResponseSettingClass
                        {
                            Id = $"{s.AppSettingClass.Id}",
                            Name = s.AppSettingClass.Name,
                            Namespace = s.AppSettingClass.Namespace,
                            FullName = s.AppSettingClass.FullName
                        }
                    }).ToArray()
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.AppNotFound);
            }

            return HttpStatusCode.OK.ToSuccessResponse(entity.Settings);
        }

        private async Task<bool> HasSomeSettingAsync(int appId, int IdentifierId, Guid computedIdentifier, CancellationToken cancellationToken)
        {
            return await _context.AppSettings
                .AsNoTracking()
                .Where(a => a.AppId == appId &&
                            a.ComputedIdentifier == computedIdentifier &&
                            a.IdentifierId == IdentifierId)
                .AnyAsync(cancellationToken);
        }
    }
}