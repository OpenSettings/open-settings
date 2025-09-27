using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
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
    internal sealed class AppSqlService : IAppSqlService
    {
        private const string InitialSettingVersion = "0";

        private readonly ILogger _logger;
        private readonly IIdentifierSqlService _identifierSqlService;
        private readonly IAppGroupSqlService _appGroupSqlService;
        private readonly IAppTagSqlService _appTagSqlService;
        private readonly ICompressionProvider _compressionProvider;
        private readonly IPasswordHasher<AppSqlModel> _passwordHasher;
        private readonly OpenSettingsDbContext _context;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly ProviderInfo _providerInfo;

        public AppSqlService(
            IIdentifierSqlService identifierSqlService,
            IAppGroupSqlService appGroupSqlService,
            IAppTagSqlService appTagSqlService,
            ICompressionProvider compressionProvider,
            IPasswordHasher<AppSqlModel> passwordHasher,
            OpenSettingsDbContext context,
            OpenSettingsConfiguration openSettingsConfiguration,
            ProviderInfo providerInfo)
        {
            _logger = openSettingsConfiguration.LoggerFactory.CreateLogger<AppSqlService>();
            _identifierSqlService = identifierSqlService;
            _appGroupSqlService = appGroupSqlService;
            _appTagSqlService = appTagSqlService;
            _compressionProvider = compressionProvider;
            _passwordHasher = passwordHasher;
            _context = context;
            _openSettingsConfiguration = openSettingsConfiguration;
            _providerInfo = providerInfo;
        }

        public async Task<IResponse<SyncAppDataResponse>> SyncAppDataAsync(SyncAppDataInput input, CancellationToken cancellationToken = default)
        {
            try
            {
                input.UserId = input.UserId ?? await GetOrCreateUserAsync(input.Client.Id, input.Client.Secret, input.Client.Name, cancellationToken);

                var identifier = await _identifierSqlService.GetOrCreateAsync(input.IdentifierName, SetSortOrderPosition.Bottom, input.UserId, cancellationToken);

                if (!identifier.Success)
                {
                    return identifier.Status.ToFailureResponse<SyncAppDataResponse>(identifier.Errors);
                }

                var classNameToCount = new Dictionary<string, int>();

                foreach (var setting in input.Settings)
                {
                    classNameToCount[setting.SettingClass.Name] = classNameToCount.GetValueOrDefault(setting.SettingClass.Name, 0) + 1;
                }

                var clientNameLowercase = input.Client.Name.Trim().ToLowerInvariant();

                var partialApp = await _context.Apps
                    .AsNoTracking()
#if !NETSTANDARD2_0
                    .AsSplitQuery()
#endif
                    .Include(a => a.AppIdentifierMappings)
                    .Where(a => a.ClientId == input.Client.Id || a.ClientNameLowercase == clientNameLowercase)
                    .OrderBy(a => a.Id)
                    .Select(a => new
                    {
                        a.Id,
                        a.ClientId,
                        a.ClientNameLowercase,
                        a.HashedClientSecret,
                        a.RowVersion,
                        MappedAppIdentifierIds = new HashSet<Guid>(a.AppIdentifierMappings.Select(i => i.IdentifierId))
                    })
                    .FirstOrDefaultAsync(cancellationToken);

                if (partialApp == null)
                {
                    return await HandleNewAppAsync(input, classNameToCount, identifier.Data.Id, cancellationToken);
                }

                if (partialApp.ClientNameLowercase != clientNameLowercase)
                {
                    return HttpStatusCode.BadRequest.ToFailureResponse<SyncAppDataResponse, Errors>(Errors.MismatchedClientName);
                }

                if (partialApp.ClientId != input.Client.Id)
                {
                    return HttpStatusCode.BadRequest.ToFailureResponse<SyncAppDataResponse, Errors>(Errors.MismatchedClientId);
                }

                return await HandleExistingAppAsync(input, classNameToCount, identifier.Data.Id, partialApp.Id, partialApp.HashedClientSecret, partialApp.MappedAppIdentifierIds, cancellationToken);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError.ToFailureResponse<SyncAppDataResponse>(ex);
            }
        }

        public async Task<IResponse> GetGroupedAppsAsync(GetGroupedAppsInput input, CancellationToken cancellationToken = default)
        {
            var query = _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppGroup)
                .Include(a => a.AppTagMappings).ThenInclude(a => a.AppTag).AsQueryable();

            switch (input.AppGroupId)
            {
                case "-1":
                    query = query.Where(a => !a.AppGroupId.HasValue);
                    break;
                case "0":
                    query = query.Where(a => a.AppGroupId.HasValue);
                    break;
                default:

                    if (Guid.TryParse(input.AppGroupId, out var appGroupId) && appGroupId != Guid.Empty)
                    {
                        query = query.Where(a => a.AppGroupId == appGroupId);
                    }

                    break;
            }

            if (!string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                var searchTermLowercase = input.SearchTerm.ToLowerInvariant();

                var fields = new Expression<Func<AppSqlModel, string>>[]
                {
                    app => app.ClientNameLowercase,
                    app => app.DisplayNameLowercase,
                    app => app.ClientIdLowercase
                };

                query = query
                    .SearchBy(fields, searchTermLowercase, _context)
                    .OrderBy(a => a.ClientNameLowercase.IndexOf(searchTermLowercase)).ThenBy(a => a.AppGroup.SortOrder);
            }
            else
            {
                query = query.OrderBy(a => a.AppGroup.SortOrder);
            }

            var entities = await GetGroupedAppsResponseApp(query).ToArrayAsync(cancellationToken);

            var groupNameToAppsMap = entities
                .GroupBy(e => e.Group.Name)
                .ToDictionary(e => e.Key, e => e.ToArray());

            return HttpStatusCode.OK.ToSuccessResponse(new GetGroupedAppsResponse
            {
                GroupNameToApps = groupNameToAppsMap,
                GroupCount = groupNameToAppsMap.Count,
                AppCount = entities.Length
            });
        }

        public async Task<IResponse<GetAppResponse>> GetAppByIdAsync(GetAppInput input, CancellationToken cancellationToken = default)
        {
            return await GetAppByIdOrSlugAsync(a => a.Id == Guid.Parse(input.AppIdOrSlug), cancellationToken);
        }

        public Task<IResponse<GetAppResponse>> GetAppBySlugAsync(GetAppInput input, CancellationToken cancellationToken = default)
        {
            input.AppIdOrSlug = input.AppIdOrSlug?.ToSlug();

            return GetAppByIdOrSlugAsync(a => a.Slug == input.AppIdOrSlug, cancellationToken);
        }

        public async Task<IResponse> UpdateAppAsync(UpdateAppInput input, CancellationToken cancellationToken)
        {
            var entity = await _context.Apps
                .AsNoTracking()
                .Include(a => a.AppTagMappings).ThenInclude(a => a.AppTag)
                .Where(a => a.Id == input.AppId)
                .OrderBy(a => a.Id)
                .Select(a => new AppSqlModel
                {
                    Id = a.Id,
                    ClientId = a.ClientId,
                    Slug = a.Slug,
                    RowVersion = a.RowVersion,
                    AppTagMappings = a.AppTagMappings.Select(t => new AppTagMappingSqlModel
                    {
                        AppId = t.AppId,
                        AppTagId = t.AppTagId,
                        AppTag = new AppTagSqlModel
                        {
                            Id = t.AppTag.Id,
                            Name = t.AppTag.Name,
                            SortOrder = t.AppTag.SortOrder
                        }
                    }).ToList()
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.AppNotFound);
            }

            if (!input.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict($"{input.AppId}", entity.RowVersion, input.RowVersion, false);
            }

            _context.Apps.Attach(entity);

            var currentTime = DateTime.UtcNow;
            var rowVersion = RowVersionHelper.Date(currentTime);

            var trimmedClientName = input.ClientName.Trim();
            var trimmedClientNameLowercase = trimmedClientName.ToLowerInvariant();

            if (entity.Slug != input.Slug)
            {
                var slug = await GenerateAppSlugAsync(trimmedClientNameLowercase, input.Slug, currentTime, entity.Id, cancellationToken);

                if (slug == null)
                {
                    return HttpStatusCode.BadRequest.ToFailureResponse(Errors.SlugAlreadyExists);
                }

                entity.Slug = slug;
            }

            entity.DisplayName = string.IsNullOrWhiteSpace(input.DisplayName) ? trimmedClientName : input.DisplayName.Trim();
            entity.DisplayNameLowercase = entity.DisplayName.ToLowerInvariant();
            entity.ClientName = trimmedClientName;
            entity.ClientNameLowercase = trimmedClientNameLowercase;
            entity.Description = input.Description;
            entity.ImageUrl = input.ImageUrl;
            entity.WikiUrl = input.WikiUrl;
            entity.UpdatedById = input.UpdatedById;
            entity.UpdatedOn = currentTime;
            entity.RowVersion = rowVersion;

            if (string.IsNullOrWhiteSpace(input.Group?.Name))
            {
                entity.AppGroupId = null;

                _context.MarkAsModified(entity, e => e.AppGroupId);
            }
            else
            {
                var groupJsonResponse = await _appGroupSqlService.GetOrCreateAsync(input.Group.Name, SetSortOrderPosition.Bottom, input.UpdatedById, cancellationToken);

                if (!groupJsonResponse.Success)
                {
                    return groupJsonResponse.ToResponse();
                }

                var groupEntity = new AppGroupSqlModel
                {
                    Id = groupJsonResponse.Data.Id,
                    Name = groupJsonResponse.Data.Name,
                    SortOrder = groupJsonResponse.Data.SortOrder
                };

                _context.Attach(groupEntity);

                entity.AppGroup = groupEntity;
            }

            var existingTagIds = new HashSet<Guid>(entity.AppTagMappings.Select(t => t.AppTag.Id));

            var newTagIds = new HashSet<Guid>(input.Tags.Select(tag => Guid.TryParse(tag.Id, out var tagId) ? tagId : (Guid?)null).Where(tagId => tagId.HasValue).Select(tagId => tagId.Value));

            var tagsToRemove = entity.AppTagMappings.Where(at => !newTagIds.Contains(at.AppTagId)).ToList();

            foreach (var tagToRemove in tagsToRemove)
            {
                entity.AppTagMappings.Remove(tagToRemove);
            }

            foreach (var tag in input.Tags)
            {
                if (!Guid.TryParse(tag.Id, out var tagId) || tagId == Guid.Empty)
                {
                    if (!string.IsNullOrWhiteSpace(tag.Name))
                    {
                        var getOrCreateTag = await _appTagSqlService.GetOrCreateAsync(tag.Name, SetSortOrderPosition.Bottom, input.UpdatedById, cancellationToken);

                        if (!getOrCreateTag.Success)
                        {
                            return getOrCreateTag.ToResponse();
                        }

                        var tagEntity = new AppTagSqlModel { Id = getOrCreateTag.Data.Id, Name = tag.Name };

                        _context.AppTags.Attach(tagEntity);

                        entity.AppTagMappings.Add(new AppTagMappingSqlModel
                        {
                            AppTag = tagEntity,
                            CreatedOn = currentTime
                        });
                    }

                    continue;
                }

                if (!existingTagIds.Contains(tagId))
                {
                    var tagEntity = new AppTagSqlModel { Id = tagId, Name = tag.Name };

                    _context.AppTags.Attach(tagEntity);

                    entity.AppTagMappings.Add(new AppTagMappingSqlModel
                    {
                        AppTag = tagEntity,
                        CreatedOn = currentTime
                    });
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse(new UpdateAppResponse
            {
                DisplayName = entity.DisplayName,
                ClientName = entity.ClientName,
                Slug = entity.Slug,
                Group = entity.AppGroup == null
                    ? null
                    : new GetGroupedAppsResponseAppGroup
                    {
                        Id = $"{entity.AppGroup.Id}",
                        Name = entity.AppGroup.Name,
                        SortOrder = entity.AppGroup.SortOrder
                    },
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                WikiUrl = entity.WikiUrl,
                Tags = entity.AppTagMappings.Select(a => new UpdateAppResponseTag
                {
                    Id = $"{a.AppTag.Id}",
                    Name = a.AppTag.Name,
                    SortOrder = a.AppTag.SortOrder
                }).ToArray(),
                RowVersion = entity.RowVersion
            });
        }

        public async Task<IResponse<GetRegisteredAppResponse>> GetRegisteredAppAsync(GetRegisteredAppInput input, CancellationToken cancellationToken = default)
        {
            Expression<Func<AppSqlModel, bool>> appFindExpression = a => a.TenantId == input.TenantId && a.ClientId == input.ClientId;

            var entity = await _context.Apps
                .AsNoTracking()
                .Where(appFindExpression)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    a.ClientName,
                    a.HashedClientSecret,
                    IsRegistered = true,
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity != null)
            {
                var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(null, entity.HashedClientSecret, $"{input.ClientSecret}");

                return HttpStatusCode.OK.ToSuccessResponseOf(new GetRegisteredAppResponse
                {
                    ClientName = entity.ClientName,
                    IsRegistered = entity.IsRegistered,
                    IsClientSecretMatched = passwordVerificationResult != PasswordVerificationResult.Failed
                });
            }

            return HttpStatusCode.OK.ToSuccessResponseOf(new GetRegisteredAppResponse
            {
                ClientName = string.Empty,
                IsRegistered = false,
                IsClientSecretMatched = false,
            });
        }

        public async Task<IResponse<FetchAppDataResponse>> FetchAppDataAsync(FetchAppDataInput input, CancellationToken cancellationToken = default)
        {
            input.IdentifierName = input.IdentifierName.Trim().ToLowerInvariant();

            var query = _context.AppSettings.AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.App)
                .Include(a => a.AppSettingClass)
                .Include(a => a.Identifier)
                .Where(a => a.App.ClientId == input.ClientId && a.Identifier.NameLowercase == input.IdentifierName);

            if (input.ComputedIdentifiers.Count > 0)
            {
                query = query.Where(a => input.ComputedIdentifiers.Contains(a.ComputedIdentifier));
            }

            if (input.StoreInSeparateFile.HasValue)
            {
                query = query.Where(a => a.StoreInSeparateFile == input.StoreInSeparateFile.Value);
            }

            var entities = await query.Select(a => new
            {
                a.UpdatedOn,
                a.CompressionType,
                a.CompressionLevel,
                a.Data,
                a.ComputedIdentifier,
                a.StoreInSeparateFile,
                a.IgnoreOnFileChange,
                a.RegistrationMode
            }).ToArrayAsync(cancellationToken);

            if (entities.Length == 0)
            {
                return null;
            }

            var lastUpdatedOn = DateTime.MinValue;

            var rawReadResponseData = entities.Select(entity =>
            {
                if (entity.UpdatedOn > lastUpdatedOn)
                {
                    lastUpdatedOn = entity.UpdatedOn.Value;
                }

                return new
                {
                    entity.ComputedIdentifier,
                    DataTask = _compressionProvider.DecompressToUtf8StringAsync(entity.Data, entity.CompressionType, cancellationToken),
                    UpdatedOn = entity.UpdatedOn.GetValueOrDefault(),
                    entity.StoreInSeparateFile,
                    entity.IgnoreOnFileChange,
                    entity.RegistrationMode
                };
            }).ToArray();

            await Task.WhenAll(rawReadResponseData.Select(r => r.DataTask));

            return HttpStatusCode.OK.ToSuccessResponseOf(new FetchAppDataResponse
            {
                LastUpdatedOn = lastUpdatedOn,
                Settings = rawReadResponseData.Select(d => new FetchAppDataResponseSetting
                {
                    ComputedIdentifier = d.ComputedIdentifier,
                    Data = d.DataTask.Result,
                    UpdatedOn = d.UpdatedOn,
                    StoreInSeparateFile = d.StoreInSeparateFile,
                    IgnoreOnFileChange = d.IgnoreOnFileChange,
                    RegistrationMode = d.RegistrationMode
                }).ToArray()
            });
        }

        public async Task<IResponse> GetAppsAsync(GetAppsInput input, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                var unfilteredEntities = await _context.Apps
                    .AsNoTracking()
                    .Select(a => new GetAppsResponseApp
                    {
                        Id = $"{a.Id}",
                        Client = new GetAppsResponseAppClient
                        {
                            Id = a.ClientId,
                            Name = a.ClientName
                        }
                    }).ToArrayAsync(cancellationToken);

                return HttpStatusCode.OK.ToSuccessResponse(unfilteredEntities);
            }

            var searchTermLowercase = input.SearchTerm.ToLowerInvariant();

            var fields = new Expression<Func<AppSqlModel, string>>[]
            {
                app => app.ClientNameLowercase,
                app => app.DisplayNameLowercase,
                app => app.ClientIdLowercase
            };

            var filteredEntities = await _context.Apps
                .AsNoTracking()
                .SearchBy(fields, searchTermLowercase, _context)
                .OrderBy(a => a.ClientNameLowercase.IndexOf(searchTermLowercase))
                .Select(a => new GetAppsResponseApp
                {
                    Id = $"{a.Id}",
                    Client = new GetAppsResponseAppClient
                    {
                        Id = a.ClientId,
                        Name = a.ClientName
                    }
                }).ToArrayAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse(filteredEntities);
        }

        private async Task<string> GenerateAppSlugAsync(string clientName, string slug, DateTime currentTime, Guid? id = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                slug = clientName.ToSlug();

                return await _context.Apps.AsNoTracking().AnyAsync(a => id.HasValue
                    ? a.Id != id.Value && a.Slug == slug
                    : a.Slug == slug,
                    cancellationToken) ? $"{slug}-{((DateTimeOffset)currentTime).ToUnixTimeMilliseconds()}" : slug;
            }

            slug = slug.ToSlug();

            return await _context.Apps.AsNoTracking().AnyAsync(a => id.HasValue
                    ? a.Id != id.Value && a.Slug == slug
                    : a.Slug == slug,
                cancellationToken) ? null : slug;
        }

        public async Task<IResponse> CreateAppAsync(CreateAppInput input, CancellationToken cancellationToken = default)
        {
            var clientIdNotEmptyRule = ValidationRules.NotEmptyRule("Client.Id", input.Client.Id);
            var clientSecretNotEmptyRule = ValidationRules.NotEmptyRule("Client.Secret", input.Client.Secret);
            var clientNameNotEmptyRule = ValidationRules.NotEmptyRule("Client.Name", input.Client.Name);

            var failure = new[] { clientIdNotEmptyRule, clientSecretNotEmptyRule, clientNameNotEmptyRule }.ValidateFirstOrDefault();

            if (failure != null)
            {
                return failure.ToResponse();
            }

            var trimmedClientName = input.Client.Name.Trim();
            var trimmedClientNameLowercase = trimmedClientName.ToLowerInvariant();

            var currentTime = DateTime.UtcNow;

            var slug = await GenerateAppSlugAsync(input.Client.Name, input.Slug, currentTime, cancellationToken: cancellationToken);

            if (slug == null)
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.SlugAlreadyExists);
            }

            var displayName = string.IsNullOrWhiteSpace(input.DisplayName) ? trimmedClientName : input.DisplayName.Trim();

            var clientIdAsString = $"{input.Client.Id}";
            var clientIdAsStringLowercase = clientIdAsString.ToLowerInvariant();
            var clientSecretAsString = $"{input.Client.Secret}";
            var hashedPassword = _passwordHasher.HashPassword(null, clientSecretAsString);

            var appSqlModel = new AppSqlModel
            {
                DisplayName = displayName,
                DisplayNameLowercase = displayName.ToLowerInvariant(),
                ClientName = trimmedClientName,
                ClientNameLowercase = trimmedClientNameLowercase,
                Slug = slug,
                AppSettings = Array.Empty<AppSettingSqlModel>(),
                AppInstances = Array.Empty<AppInstanceSqlModel>(),
                ClientId = input.Client.Id,
                ClientIdLowercase = clientIdAsStringLowercase,
                HashedClientSecret = hashedPassword,
                Description = input.Description,
                ImageUrl = input.ImageUrl,
                WikiUrl = input.WikiUrl,
                CreatedById = input.CreatedById
            };

            if (input.Group != null)
            {
                var groupJsonResponse = await _appGroupSqlService.GetOrCreateAsync(input.Group.Name, SetSortOrderPosition.Bottom, input.CreatedById, cancellationToken);

                if (!groupJsonResponse.Success)
                {
                    return groupJsonResponse.ToResponse();
                }

                var groupEntity = new AppGroupSqlModel
                {
                    Id = groupJsonResponse.Data.Id,
                    Name = groupJsonResponse.Data.Name,
                    SortOrder = groupJsonResponse.Data.SortOrder
                };

                _context.Attach(groupEntity);

                appSqlModel.AppGroup = groupEntity;
            }
            else
            {
                appSqlModel.AppGroupId = null;
            }

            var newTags = new List<AppTagSqlModel>();

            var existingTags = new HashSet<Guid>(input.Tags.Select(t =>
            {
                if (!Guid.TryParse(t.Id, out var tagId))
                {
                    return null;
                }

                if (tagId != Guid.Empty)
                {
                    return tagId;
                }

                if (string.IsNullOrWhiteSpace(t.Name))
                {
                    return null;
                }

                var tagName = t.Name.Trim();
                var trimmedTagNameLowercase = tagName.ToLowerInvariant();
                var tagSlug = tagName.ToSlug();

                newTags.Add(new AppTagSqlModel
                {
                    Id = Guid.NewGuid(),
                    Name = tagName,
                    NameLowercase = trimmedTagNameLowercase,
                    Slug = tagSlug,
                    CreatedById = input.CreatedById,
                    CreatedOn = currentTime
                });

                return (Guid?)null;

            }).Where(t => t != null).Select(t => t.Value));

            var tagIdToTag = await _context.AppTags
                .AsNoTracking()
                .Where(t => existingTags.Contains(t.Id))
                .Select(t => new AppTagSqlModel { Id = t.Id, Name = t.Name, SortOrder = t.SortOrder })
                .ToDictionaryAsync(t => t.Id, cancellationToken);

            var missingTags = string.Join(OpenSettingsDefaults.Format.Comma, existingTags.Except(tagIdToTag.Keys));

            if (missingTags.Length > 0)
            {
                _logger.LogWarning("Missing tags detected during app creation: {missingTags}", missingTags);
            }

            if (newTags.Count > 0)
            {
                int newTagSortOrderStartingPoint;

                try
                {
                    newTagSortOrderStartingPoint = await _context.AppTags.AsNoTracking().MaxAsync(s => s.SortOrder, cancellationToken) + OpenSettingsDefaults.SortOrderGap;
                }
                catch (InvalidOperationException)
                {
                    newTagSortOrderStartingPoint = 0;
                }

                var tagEntityEntries = new List<EntityEntry<AppTagSqlModel>>(newTags.Count);

                foreach (var tag in newTags)
                {
                    tag.SortOrder = newTagSortOrderStartingPoint;

                    tagEntityEntries.Add(_context.AppTags.Add(tag));

                    newTagSortOrderStartingPoint += OpenSettingsDefaults.SortOrderGap;
                }

                await _context.SaveChangesAsync(cancellationToken);

                foreach (var tagEntityEntry in tagEntityEntries)
                {
                    tagEntityEntry.State = EntityState.Detached;
                }
            }

            foreach (var tagEntity in tagIdToTag.Values.Concat(newTags))
            {
                _context.AppTags.Attach(tagEntity);

                appSqlModel.AppTagMappings.Add(new AppTagMappingSqlModel
                {
                    AppTag = tagEntity,
                    CreatedOn = currentTime,
                    CreatedById = input.CreatedById
                });
            }

            var appUserModel = new UserSqlModel
            {
                Id = input.Client.Id,
                AuthType = AuthType.Machine,
                IdentityProvider = null,
                ExternalId = clientIdAsString,
                Email = clientIdAsString,
                EmailLowercase = clientIdAsStringLowercase,
                Username = clientIdAsString,
                UsernameLowercase = clientIdAsStringLowercase,
                HashedPassword = hashedPassword,
                FullName = trimmedClientName,
                FullNameLowercase = trimmedClientNameLowercase,
                DisplayName = trimmedClientName,
                LastLogin = currentTime,
                CreatedOn = currentTime,
                IsActive = true
            };

            _context.Apps.Add(appSqlModel);
            _context.Users.Add(appUserModel);

            await _context.SaveChangesAsync(cancellationToken);

            var data = new GetGroupedAppsResponseApp
            {
                Id = $"{appSqlModel.Id}",
                DisplayName = appSqlModel.DisplayName,
                Slug = appSqlModel.Slug,
                Description = appSqlModel.Description,
                ImageUrl = appSqlModel.ImageUrl,
                WikiUrl = appSqlModel.WikiUrl,
                Client = new GetGroupedAppsResponseAppClient
                {
                    Id = appSqlModel.ClientId,
                    Name = appSqlModel.ClientName
                },
                Group = appSqlModel.AppGroup == null
                    ? null
                    : new GetGroupedAppsResponseAppGroup
                    {
                        Id = $"{appSqlModel.AppGroup.Id}",
                        Name = appSqlModel.AppGroup.Name,
                        SortOrder = appSqlModel.AppGroup.SortOrder
                    },
                Tags = appSqlModel.AppTagMappings.Select(a => new GetGroupedAppsResponseAppTag
                {
                    Id = $"{a.AppTag.Id}",
                    Name = a.AppTag.Name,
                    SortOrder = a.AppTag.SortOrder
                }).ToArray(),
                RowVersion = appSqlModel.RowVersion
            };

            return HttpStatusCode.OK.ToSuccessResponse(data);
        }

        public async Task<IResponse> GetGroupedAppDataByAppIdAsync(GetGroupedAppDataByAppInput input, CancellationToken cancellationToken = default)
        {
            return await GetGroupedAppDataByPredicateAsync(a => a.Id == Guid.Parse(input.AppIdOrSlug), cancellationToken);
        }

        public Task<IResponse> GetGroupedAppDataByAppSlugAsync(GetGroupedAppDataByAppInput input, CancellationToken cancellationToken = default)
        {
            input.AppIdOrSlug = input.AppIdOrSlug?.ToSlug();

            return GetGroupedAppDataByPredicateAsync(a => a.Slug == input.AppIdOrSlug, cancellationToken);
        }


        public async Task<IResponse> GetGroupedAppDataByAppIdAndIdentifierIdAsync(GetGroupedAppDataByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            return await GetGroupedAppDataByAppIdOrAppSlugAndIdentifierIdAsync(a => a.Id == Guid.Parse(input.AppIdOrSlug), Guid.Parse(input.IdentifierIdOrSlug), cancellationToken);
        }

        public async Task<IResponse> GetGroupedAppDataByAppSlugAndIdentifierSlugAsync(GetGroupedAppDataByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            input.IdentifierIdOrSlug = input.IdentifierIdOrSlug?.ToSlug();

            var identifier = await _context.Identifiers
                .AsNoTracking()
                .Where(s => s.Slug == input.IdentifierIdOrSlug)
                .OrderBy(s => s.Id)
                .Select(s => new { s.Id })
                .FirstOrDefaultAsync(cancellationToken);

            if (identifier == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.IdentifierNotFound);
            }

            input.AppIdOrSlug = input.AppIdOrSlug?.ToSlug();

            return await GetGroupedAppDataByAppIdOrAppSlugAndIdentifierIdAsync(a => a.Slug == input.AppIdOrSlug, identifier.Id, cancellationToken);
        }


        public async Task<IResponse> DeleteAppAsync(DeleteAppInput input, CancellationToken cancellationToken)
        {
            var entity = await _context.Apps
                .AsNoTracking()
                .Where(a => a.Id == input.AppId)
                .OrderBy(a => a.Id)
                .Select(a => new AppSqlModel { Id = a.Id, RowVersion = a.RowVersion })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.AppNotFound);
            }

            if (!input.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict($"{input.AppId}", entity.RowVersion, input.RowVersion, false);
            }

            _context.Apps.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse();
        }

        private async Task<IResponse> GetGroupedAppDataByPredicateAsync(Expression<Func<AppSqlModel, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppConfigurations)
                .Include(a => a.AppSettings).ThenInclude(a => a.AppSettingClass)
                .Include(a => a.AppInstances)
                .Include(a => a.AppIdentifierMappings).ThenInclude(a => a.Identifier)
                .Where(predicate)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    Instances = a.AppInstances.Select(i => new
                    {
                        Id = $"{i.Id}",
                        i.DynamicId,
                        i.IdentifierId,
                        i.Name,
                        i.Version,
                        i.PackVersion,
                        i.Urls,
                        i.IsActive,
                        i.RemoteIpAddress,
                        i.MachineName,
                        i.Environment,
                        i.ReloadStrategies,
                        i.ServiceType,
                        i.CreatedOn,
                        i.UpdatedOn,
                    }).ToArray(),
                    Configurations = a.AppConfigurations.Select(c => new
                    {
                        Id = $"{c.Id}",
                        c.StoreInSeparateFile,
                        c.IgnoreOnFileChange,
                        c.RegistrationMode,
                        c.Consumer,
                        c.Provider,
                        c.Controller,
                        c.Spa,
                        c.IdentifierId,
                        c.RowVersion
                    }).ToArray(),
                    Settings = a.AppSettings.Select(s => new
                    {
                        Id = $"{s.Id}",
                        s.ComputedIdentifier,
                        s.Version,
                        s.IdentifierId,
                        s.DataValidationDisabled,
                        s.DataRestored,
                        s.StoreInSeparateFile,
                        s.IgnoreOnFileChange,
                        s.RegistrationMode,
                        s.RowVersion,
                        Class = new GetGroupedAppDataResponseSettingClass
                        {
                            Id = $"{s.AppSettingClass.Id}",
                            Name = s.AppSettingClass.Name,
                            Namespace = s.AppSettingClass.Namespace,
                            FullName = s.AppSettingClass.FullName,
                            RowVersion = s.AppSettingClass.RowVersion
                        }
                    }).ToArray(),
                    AppIdentifierMappings = a.AppIdentifierMappings.Select(m =>
                        new
                        {
                            m.SortOrder,
                            Identifier = new
                            {
                                m.Identifier.Id,
                                m.Identifier.Name,
                                m.Identifier.Slug,
                                Order = m.Identifier.SortOrder
                            },
                            m.RowVersion
                        }).ToArray()
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.AppNotFound);
            }

            if (entity.AppIdentifierMappings.Length == 0)
            {
                return HttpStatusCode.OK.ToSuccessResponse(new GetGroupedAppDataResponse());
            }

            var firstMapping = entity.AppIdentifierMappings.First();

            int minSortOrder = firstMapping.Identifier.Order,
                maxSortOrder = firstMapping.Identifier.Order,
                mappingMinSortOrder = firstMapping.SortOrder,
                mappingMaxSortOrder = firstMapping.SortOrder;

            var identifierToConfiguration = entity.Configurations.ToDictionary(c => c.IdentifierId, c => new GetGroupedAppDataResponseConfiguration
            {
                Id = c.Id,
                StoreInSeparateFile = c.StoreInSeparateFile,
                IgnoreOnFileChange = c.IgnoreOnFileChange,
                RegistrationMode = c.RegistrationMode,
                Consumer = c.Consumer,
                Provider = c.Provider,
                Controller = c.Controller,
                Spa = c.Spa,
                RowVersion = c.RowVersion
            });

            var identifierToSettings = entity.Settings
                .GroupBy(a => a.IdentifierId)
                .ToDictionary(a => a.Key, a => a.Select(s => new GetGroupedAppDataResponseSetting
                {
                    Id = s.Id,
                    ComputedIdentifier = s.ComputedIdentifier,
                    Version = s.Version,
                    DataValidationDisabled = s.DataValidationDisabled,
                    DataRestored = s.DataRestored,
                    StoreInSeparateFile = s.StoreInSeparateFile,
                    IgnoreOnFileChange = s.IgnoreOnFileChange,
                    RegistrationMode = s.RegistrationMode,
                    RowVersion = s.RowVersion,
                    Class = s.Class
                }).ToArray());

            var identifierToInstancesMap = entity.Instances
                .GroupBy(a => a.IdentifierId)
                .ToDictionary(a => a.Key, a => a.Select(s => new GetGroupedAppDataResponseInstance
                {
                    Id = s.Id,
                    DynamicId = s.DynamicId,
                    Name = s.Name,
                    Version = s.Version,
                    Urls = s.Urls,
                    IsActive = s.IsActive,
                    RemoteIpAddress = s.RemoteIpAddress,
                    MachineName = s.MachineName,
                    Environment = s.Environment,
                    ReloadStrategies = s.ReloadStrategies,
                    ServiceType = s.ServiceType,
                    CreatedOn = s.CreatedOn,
                    UpdatedOn = s.UpdatedOn
                }).ToArray());

            var identifierIdToIdentifier = new Dictionary<string, GetGroupedAppDataResponseIdentifier>();

            var identifierIdToConfiguration = new Dictionary<string, GetGroupedAppDataResponseConfiguration>();

            var identifierIdToSettings = new Dictionary<string, GetGroupedAppDataResponseSetting[]>();

            var identifierIdToInstances = new Dictionary<string, GetGroupedAppDataResponseInstance[]>();

            foreach (var mapping in entity.AppIdentifierMappings)
            {
                var identifierId = $"{mapping.Identifier.Id}";

                identifierIdToIdentifier[identifierId] = new GetGroupedAppDataResponseIdentifier
                {
                    Id = identifierId,
                    Name = mapping.Identifier.Name,
                    Slug = mapping.Identifier.Slug,
                    SortOrder = mapping.Identifier.Order,
                    AppMapping = new GetGroupedAppDataResponseIdentifierAppMapping
                    {
                        SortOrder = mapping.SortOrder,
                        RowVersion = mapping.RowVersion
                    }
                };

                minSortOrder = Math.Min(mapping.Identifier.Order, minSortOrder);
                maxSortOrder = Math.Min(mapping.Identifier.Order, maxSortOrder);

                mappingMinSortOrder = Math.Min(mapping.SortOrder, mappingMinSortOrder);
                mappingMaxSortOrder = Math.Max(mapping.SortOrder, mappingMaxSortOrder);

                identifierIdToConfiguration[identifierId] = identifierToConfiguration.GetValueOrDefault(mapping.Identifier.Id, null);

                identifierIdToSettings[identifierId] = identifierToSettings.GetValueOrDefault(mapping.Identifier.Id, Array.Empty<GetGroupedAppDataResponseSetting>());

                identifierIdToInstances[identifierId] = identifierToInstancesMap.GetValueOrDefault(mapping.Identifier.Id, Array.Empty<GetGroupedAppDataResponseInstance>());
            }

            return HttpStatusCode.OK.ToSuccessResponse(new GetGroupedAppDataResponse
            {
                IdentifierInfo = new GetGroupedAppDataResponseIdentifierInfo
                {
                    SortOrderRange = new SortOrderRange
                    {
                        Min = minSortOrder,
                        Max = maxSortOrder
                    },
                    AppMappingSortOrderRange = new SortOrderRange
                    {
                        Min = mappingMinSortOrder,
                        Max = mappingMaxSortOrder
                    }
                },
                IdentifierIdToIdentifier = identifierIdToIdentifier,
                IdentifierIdToConfiguration = identifierIdToConfiguration,
                IdentifierIdToSettings = identifierIdToSettings,
                IdentifierIdToInstances = identifierIdToInstances
            });
        }


        private async Task<IResponse<GetAppResponse>> GetAppByIdOrSlugAsync(Expression<Func<AppSqlModel, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var query = _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppGroup)
                .Include(a => a.AppTagMappings).ThenInclude(a => a.AppTag)
                .Where(predicate)
                .OrderBy(a => a.Id);

            var entity = await GetAppResponse(query).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureResponse<GetAppResponse, Errors>(Errors.AppNotFound)
                : HttpStatusCode.OK.ToSuccessResponseOf(entity);
        }

        private async Task<IResponse> GetGroupedAppDataByAppIdOrAppSlugAndIdentifierIdAsync(Expression<Func<AppSqlModel, bool>> predicate, Guid identifierId, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppSettings).ThenInclude(a => a.AppSettingClass)
                .Include(a => a.AppInstances)
                .Include(a => a.AppIdentifierMappings).ThenInclude(a => a.Identifier)
                .Where(predicate)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    Instances = a.AppInstances.Where(i => i.IdentifierId == identifierId).Select(i => new
                    {
                        Id = $"{i.Id}",
                        i.DynamicId,
                        i.IdentifierId,
                        i.Name,
                        i.Urls,
                        i.IsActive,
                        i.RemoteIpAddress,
                        i.MachineName,
                        i.Environment,
                        i.ReloadStrategies,
                        i.ServiceType,
                        i.Version,
                        i.PackVersion,
                        i.CreatedOn,
                        i.UpdatedOn
                    }).ToArray(),
                    Configuration = a.AppConfigurations.Where(c => c.IdentifierId == identifierId).Select(c => new
                    {
                        Id = $"{c.Id}",
                        c.StoreInSeparateFile,
                        c.IgnoreOnFileChange,
                        c.RegistrationMode,
                        c.Consumer,
                        c.Provider,
                        c.Controller,
                        c.Spa,
                        c.IdentifierId,
                        c.RowVersion
                    }).FirstOrDefault(),
                    Settings = a.AppSettings.Where(s => s.IdentifierId == identifierId).Select(s => new
                    {
                        Id = $"{s.Id}",
                        s.ComputedIdentifier,
                        s.Version,
                        s.DataValidationDisabled,
                        s.DataRestored,
                        s.RowVersion,
                        s.StoreInSeparateFile,
                        s.IgnoreOnFileChange,
                        s.RegistrationMode,
                        Class = new GetGroupedAppDataByIdentifierIdResponseSettingClass
                        {
                            Id = $"{s.AppSettingClass.Id}",
                            Name = s.AppSettingClass.Name,
                            Namespace = s.AppSettingClass.Namespace,
                            FullName = s.AppSettingClass.FullName,
                            RowVersion = s.AppSettingClass.RowVersion
                        }
                    }).ToArray(),
                    AppIdentifierMapping = a.AppIdentifierMappings.Where(m => m.Identifier.Id == identifierId).Select(m =>
                        new
                        {
                            m.SortOrder,
                            Identifier = new
                            {
                                m.Identifier.Name,
                                m.Identifier.Slug,
                                m.Identifier.SortOrder
                            },
                            m.RowVersion
                        }).FirstOrDefault()
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.AppNotFound);
            }

            if (entity.AppIdentifierMapping == null)
            {
                return HttpStatusCode.OK.ToSuccessResponse(new GetGroupedAppDataResponse());
            }

            return HttpStatusCode.OK.ToSuccessResponse(new GetGroupedAppDataByIdentifierIdResponse
            {
                Identifier = new GetGroupedAppDataByIdentifierIdResponseIdentifier
                {
                    Id = $"{identifierId}",
                    Name = entity.AppIdentifierMapping.Identifier.Name,
                    Slug = entity.AppIdentifierMapping.Identifier.Slug,
                    SortOrder = entity.AppIdentifierMapping.Identifier.SortOrder,
                    AppMapping = new GetGroupedAppDataByIdentifierIdResponseIdentifierAppMapping
                    {
                        SortOrder = entity.AppIdentifierMapping.SortOrder,
                        RowVersion = entity.AppIdentifierMapping.RowVersion
                    }
                },
                Configuration = new GetGroupedAppDataByIdentifierIdResponseConfiguration
                {
                    Id = entity.Configuration.Id,
                    StoreInSeparateFile = entity.Configuration.StoreInSeparateFile,
                    IgnoreOnFileChange = entity.Configuration.IgnoreOnFileChange,
                    RegistrationMode = entity.Configuration.RegistrationMode,
                    Consumer = entity.Configuration.Consumer,
                    Provider = entity.Configuration.Provider,
                    Controller = entity.Configuration.Controller,
                    Spa = entity.Configuration.Spa,
                    RowVersion = entity.Configuration.RowVersion
                },
                Settings = entity.Settings.Select(setting => new GetGroupedAppDataByIdentifierIdResponseSetting
                {
                    Id = setting.Id,
                    ComputedIdentifier = setting.ComputedIdentifier,
                    Version = setting.Version,
                    DataValidationDisabled = setting.DataValidationDisabled,
                    DataRestored = setting.DataRestored,
                    RowVersion = setting.RowVersion,
                    StoreInSeparateFile = setting.StoreInSeparateFile,
                    IgnoreOnFileChange = setting.IgnoreOnFileChange,
                    RegistrationMode = setting.RegistrationMode,
                    Class = setting.Class
                }).ToArray(),
                Instances = entity.Instances.Select(instance => new GetGroupedAppDataByIdentifierIdResponseInstance
                {
                    Id = instance.Id,
                    DynamicId = instance.DynamicId,
                    Name = instance.Name,
                    Version = instance.Version,
                    Urls = instance.Urls,
                    IsActive = instance.IsActive,
                    RemoteIpAddress = instance.RemoteIpAddress,
                    MachineName = instance.MachineName,
                    Environment = instance.Environment,
                    ReloadStrategies = instance.ReloadStrategies,
                    ServiceType = instance.ServiceType,
                    CreatedOn = instance.CreatedOn,
                    UpdatedOn = instance.UpdatedOn
                }).ToArray()
            });
        }

        private async Task<IResponse<SyncAppDataResponse>> HandleNewAppAsync(SyncAppDataInput input, Dictionary<string, int> classNameToCount, Guid identifierId, CancellationToken cancellationToken = default)
        {
            var settings = new List<SyncAppDataResponseSetting>(input.Settings.Count);

            var currentTime = DateTime.UtcNow;

            var settingTasks = input.Settings.Select(async setting =>
            {
                var isUniqueClassName = classNameToCount[setting.SettingClass.Name] == 1;

                setting.IgnoreOnFileChange = setting.StoreInSeparateFile
                    ? isUniqueClassName && setting.IgnoreOnFileChange.GetValueOrDefault(false)
                    : (bool?)null;

                settings.Add(new SyncAppDataResponseSetting
                {
                    ComputedIdentifier = setting.ComputedIdentifier,
                    Data = setting.Data,
                    StoreInSeparateFile = setting.StoreInSeparateFile,
                    IgnoreOnFileChange = setting.IgnoreOnFileChange,
                    RegistrationMode = setting.RegistrationMode
                });

                return new AppSettingSqlModel
                {
                    CompressionType = _openSettingsConfiguration.Provider.CompressionType,
                    CompressionLevel = _openSettingsConfiguration.Provider.CompressionLevel,
                    Data = await _compressionProvider.CompressAsync(_openSettingsConfiguration.Provider.CompressionType, setting.Data, _openSettingsConfiguration.Provider.CompressionLevel, cancellationToken),
                    ComputedIdentifier = setting.ComputedIdentifier,
                    IdentifierId = identifierId,
                    Version = InitialSettingVersion,
                    DataValidationDisabled = false,
                    StoreInSeparateFile = setting.StoreInSeparateFile,
                    IgnoreOnFileChange = setting.IgnoreOnFileChange,
                    RegistrationMode = setting.RegistrationMode,
                    AppSettingClass = new AppSettingClassSqlModel
                    {
                        Identifier = setting.SettingClass.Identifier,
                        Name = setting.SettingClass.Name,
                        FullName = setting.SettingClass.FullName,
                        Namespace = setting.SettingClass.Namespace,
                        Properties = setting.SettingClass.Properties,
                        CreatedOn = currentTime,
                        CreatedById = input.UserId
                    },
                    CreatedOn = currentTime,
                    CreatedById = input.UserId
                };
            }).ToArray();

            var appIdentifier = new IdentifierSqlModel
            {
                Id = identifierId
            };

            _context.Identifiers.Attach(appIdentifier);

            var trimmedClientName = input.Client.Name.Trim();
            var trimmedClientNameLowercase = trimmedClientName.ToLowerInvariant();
            var appSlugTask = GenerateAppSlugAsync(input.Client.Name, slug: null, currentTime, id: null, cancellationToken);
            var settingsTask = Task.WhenAll(settingTasks);

            await Task.WhenAll(appSlugTask, settingsTask);

            var configuration = new AppConfigurationSqlModel
            {

                IdentifierId = identifierId,
                CreatedOn = currentTime,
                CreatedById = input.UserId
            };

            if (input.Configuration != null)
            {
                configuration.StoreInSeparateFile = input.Configuration.StoreInSeparateFile;
                configuration.IgnoreOnFileChange = input.Configuration.IgnoreOnFileChange;
                configuration.RegistrationMode = input.Configuration.RegistrationMode;
                configuration.Consumer = input.Configuration.Consumer;
                configuration.Provider = input.Configuration.Provider;
                configuration.Controller = input.Configuration.Controller;
                configuration.Spa = input.Configuration.Spa;
            }

            var instances = new List<AppInstanceSqlModel>(1);

            if (input.Instance != null)
            {
                var trimmedInstanceName = input.Instance.InstanceName.Trim();
                var trimmedInstanceNameLowercase = trimmedInstanceName.ToLowerInvariant();
                var instanceSlug = trimmedInstanceName.ToSlug();

                instances.Add(new AppInstanceSqlModel
                {
                    Name = trimmedInstanceName,
                    NameLowercase = trimmedInstanceNameLowercase,
                    Slug = instanceSlug,
                    IdentifierId = identifierId,
                    DynamicId = input.Instance.DynamicId,
                    Urls = input.Instance.Urls,
                    MachineName = input.Instance.MachineName,
                    Environment = input.Instance.Environment,
                    ReloadStrategies = input.Instance.ReloadStrategies,
                    ServiceType = input.Instance.ServiceType,
                    Version = input.Instance.Version,
                    PackVersion = input.Instance.PackVersion,
                    CreatedOn = currentTime,
                });
            }

            var app = new AppSqlModel
            {
                DisplayName = trimmedClientName,
                DisplayNameLowercase = trimmedClientNameLowercase,
                ClientName = trimmedClientName,
                ClientNameLowercase = trimmedClientNameLowercase,
                Slug = appSlugTask.Result,
                AppConfigurations = new AppConfigurationSqlModel[]
                {
                    configuration
                },
                AppSettings = settingsTask.Result,
                AppInstances = instances,
                AppIdentifierMappings = new AppIdentifierMappingSqlModel[]
                {
                    new AppIdentifierMappingSqlModel
                    {
                        Identifier = appIdentifier,
                        CreatedOn = currentTime,
                        CreatedById = input.UserId
                    }
                },
                ClientId = input.Client.Id,
                ClientIdLowercase = $"{input.Client.Id}".ToLowerInvariant(),
                HashedClientSecret = _passwordHasher.HashPassword(null, $"{input.Client.Secret}"),
                CreatedOn = currentTime,
                CreatedById = input.UserId,
                Type = input.AppType
            };

            _context.Apps.Add(app);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                return HttpStatusCode.OK.ToSuccessResponseOf(new SyncAppDataResponse
                {
                    Settings = settings,
                    Configuration = new SyncAppDataResponseConfiguration
                    {
                        StoreInSeparateFile = configuration.StoreInSeparateFile,
                        IgnoreOnFileChange = configuration.IgnoreOnFileChange,
                        RegistrationMode = configuration.RegistrationMode,
                        Consumer = configuration.Consumer,
                        Provider = configuration.Provider,
                        Controller = configuration.Controller,
                        Spa = configuration.Spa
                    },
                    ProviderInfo = _providerInfo
                });
            }
            catch (Exception ex)
            {
                return ex.ToResponse<SyncAppDataResponse>();
            }
        }

        private async Task<Guid> GetOrCreateUserAsync(Guid clientId, Guid clientSecret, string clientName, CancellationToken cancellationToken = default)
        {
            var isExists = await _context.Users.AsNoTracking().Where(u => u.Id == clientId).AnyAsync(cancellationToken);

            if (isExists)
            {
                return clientId;
            }

            var trimmedClientName = clientName.Trim();
            var trimmedClientNameLowercase = trimmedClientName.ToLowerInvariant();

            var clientIdAsString = $"{clientId}";
            var clientIdAsStringLowercase = clientIdAsString.ToLowerInvariant();

            var currentTime = DateTime.UtcNow;

            var appUserModel = new UserSqlModel
            {
                Id = clientId,
                AuthType = AuthType.Machine,
                IdentityProvider = null,
                ExternalId = clientIdAsString,
                Email = clientIdAsString,
                EmailLowercase = clientIdAsStringLowercase,
                HashedPassword = _passwordHasher.HashPassword(null, $"{clientSecret}"),
                Username = clientIdAsString,
                UsernameLowercase = clientIdAsStringLowercase,
                GivenName = trimmedClientName,
                GivenNameLowercase = trimmedClientNameLowercase,
                FamilyName = "",
                FamilyNameLowercase = "",
                FullName = trimmedClientName,
                FullNameLowercase = trimmedClientNameLowercase,
                Slug = clientIdAsString.ToSlug(),
                DisplayName = trimmedClientName,
                Initials = Helper.GetInitials(trimmedClientName),
                LastLogin = currentTime,
                CreatedOn = currentTime,
                IsActive = true
            };

            _context.Users.Add(appUserModel);

            await _context.SaveChangesAsync(cancellationToken);

            return clientId;
        }

        private async Task<IResponse<SyncAppDataResponse>> HandleExistingAppAsync(SyncAppDataInput input, Dictionary<string, int> classNameToCount, Guid identifierId, Guid appId, string hashedClientSecret, HashSet<Guid> mappedAppIdentifierIds, CancellationToken cancellationToken = default)
        {
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(null, hashedClientSecret, $"{input.Client.Secret}");

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return HttpStatusCode.Unauthorized.ToFailureResponse<SyncAppDataResponse, Errors>(Errors.InvalidCredentials);
            }

            var currentTime = DateTime.UtcNow;

            var app = new AppSqlModel { Id = appId };

            _context.Apps.Attach(app);

            if (!mappedAppIdentifierIds.Contains(identifierId))
            {
                int mappingSortOrder;

                try
                {
                    mappingSortOrder = await _context.AppIdentifierMappings
                        .AsNoTracking()
                        .Where(a => a.AppId == appId)
                        .MaxAsync(s => s.SortOrder, cancellationToken) + OpenSettingsDefaults.SortOrderGap;
                }
                catch (InvalidOperationException)
                {
                    mappingSortOrder = 0;
                }

                var appIdentifier = new IdentifierSqlModel
                {
                    Id = identifierId
                };

                _context.Identifiers.Attach(appIdentifier);

                app.AppIdentifierMappings.Add(new AppIdentifierMappingSqlModel
                {
                    Identifier = appIdentifier,
                    SortOrder = mappingSortOrder,
                    CreatedOn = currentTime,
                    CreatedById = input.UserId
                });
            }

            if (input.Instance != null)
            {
                var instanceName = input.Instance.InstanceName.Trim();
                var instanceNameLowercase = instanceName.ToLowerInvariant();
                var instanceSlug = instanceName.ToSlug();

                var instance = await _context.AppInstances
                    .AsNoTracking()
                    .Where(a => a.NameLowercase == instanceNameLowercase && a.IdentifierId == identifierId && a.AppId == appId)
                    .OrderBy(a => a.Id)
                    .Select(a => new AppInstanceSqlModel
                    {
                        Id = a.Id
                    })
                    .FirstOrDefaultAsync(cancellationToken);

                if (instance == null)
                {
                    app.AppInstances.Add(new AppInstanceSqlModel
                    {
                        Name = instanceName,
                        NameLowercase = instanceNameLowercase,
                        Slug = instanceSlug,
                        DynamicId = input.Instance.DynamicId,
                        Urls = input.Instance.Urls,
                        Version = input.Instance.Version,
                        PackVersion = input.Instance.PackVersion,
                        IsActive = input.Instance.IsActive,
                        RemoteIpAddress = input.Instance.RemoteIpAddress,
                        MachineName = input.Instance.MachineName,
                        Environment = input.Instance.Environment,
                        ReloadStrategies = input.Instance.ReloadStrategies,
                        ServiceType = input.Instance.ServiceType,
                        DataAccessType = input.Instance.DataAccessType,
                        IdentifierId = identifierId,
                        CreatedOn = currentTime
                    });
                }
                else
                {
                    var instanceEntityEntry = _context.AppInstances.Attach(instance);

                    instance.Name = instanceName;
                    instance.NameLowercase = instanceNameLowercase;
                    instance.Slug = instanceSlug;
                    instance.DynamicId = input.Instance.DynamicId;
                    instance.Urls = input.Instance.Urls;
                    instance.Version = input.Instance.Version;
                    instance.PackVersion = input.Instance.PackVersion;
                    instance.IsActive = input.Instance.IsActive;
                    instance.RemoteIpAddress = input.Instance.RemoteIpAddress;
                    instance.MachineName = input.Instance.MachineName;
                    instance.Environment = input.Instance.Environment;
                    instance.ReloadStrategies = input.Instance.ReloadStrategies;
                    instance.ServiceType = input.Instance.ServiceType;
                    instance.DataAccessType = input.Instance.DataAccessType;
                    instance.UpdatedOn = currentTime;

                    instanceEntityEntry.MarkAsModified(
                        i => i.Name,
                        i => i.NameLowercase,
                        i => i.Slug,
                        i => i.DynamicId,
                        i => i.Urls,
                        i => i.Version,
                        i => i.PackVersion,
                        i => i.IsActive,
                        i => i.RemoteIpAddress,
                        i => i.MachineName,
                        i => i.Environment,
                        i => i.ReloadStrategies,
                        i => i.ServiceType,
                        i => i.DataAccessType,
                        i => i.UpdatedOn);
                }
            }

            var configuration = await _context.AppConfigurations
                .AsNoTracking()
                .Where(c => c.AppId == appId && c.IdentifierId == identifierId)
                .Select(c => new AppConfigurationSqlModel
                {
                    Id = c.Id,
                    StoreInSeparateFile = c.StoreInSeparateFile,
                    IgnoreOnFileChange = c.IgnoreOnFileChange,
                    RegistrationMode = c.RegistrationMode,
                    Consumer = c.Consumer,
                    Provider = c.Provider,
                    Controller = c.Controller,
                    Spa = c.Spa
                }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (configuration == null)
            {
                configuration = new AppConfigurationSqlModel
                {
                    IdentifierId = identifierId,
                    CreatedOn = currentTime,
                    CreatedById = input.UserId
                };

                if (input.Configuration != null)
                {
                    configuration.StoreInSeparateFile = input.Configuration.StoreInSeparateFile;
                    configuration.IgnoreOnFileChange = input.Configuration.IgnoreOnFileChange;
                    configuration.RegistrationMode = input.Configuration.RegistrationMode;
                    configuration.Consumer = input.Configuration.Consumer;
                    configuration.Provider = input.Configuration.Provider;
                    configuration.Controller = input.Configuration.Controller;
                    configuration.Spa = input.Configuration.Spa;
                }

                app.AppConfigurations.Add(configuration);
            }
            else if (input.Configuration != null && configuration.Consumer.ProviderUrl != input.Configuration.Consumer.ProviderUrl)
            {
                var configurationEntityEntry = _context.AppConfigurations.Attach(configuration);

                configuration.Consumer.ProviderUrl = input.Configuration.Consumer.ProviderUrl;

                configurationEntityEntry.MarkAsModified(c => c.Consumer);
            }

            var computedIdentifierToSetting = await _context.AppSettings
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppSettingClass)
                .Where(a => a.AppId == appId && a.IdentifierId == identifierId)
                .Select(a => new AppSettingSqlModel
                {
                    Id = a.Id,
                    Data = a.Data,
                    ComputedIdentifier = a.ComputedIdentifier,
                    CompressionType = a.CompressionType,
                    CompressionLevel = a.CompressionLevel,
                    DataRestored = a.DataRestored,
                    Version = a.Version,
                    DataValidationDisabled = a.DataValidationDisabled,
                    StoreInSeparateFile = a.StoreInSeparateFile,
                    IgnoreOnFileChange = a.IgnoreOnFileChange,
                    RegistrationMode = a.RegistrationMode,
                    CreatedOn = a.CreatedOn,
                    //RowVersion = a.RowVersion,
                    AppSettingClass = new AppSettingClassSqlModel
                    {
                        Id = a.AppSettingClass.Id,
                        RowVersion = a.AppSettingClass.RowVersion
                    }
                }).ToDictionaryAsync(a => a.ComputedIdentifier, cancellationToken);

            using (var internalContext = OpenSettingsInternalDbContext.GetInstance(_openSettingsConfiguration.Provider, _openSettingsConfiguration.LoggerFactory))
            {
                var settings = await HandleSettingsAsync(internalContext, input, classNameToCount, computedIdentifierToSetting, app.AppSettings, identifierId, currentTime, cancellationToken);

                await Task.WhenAll(internalContext.SaveChangesAsync(cancellationToken), _context.SaveChangesAsync(cancellationToken));

                return HttpStatusCode.OK.ToSuccessResponseOf(new SyncAppDataResponse
                {
                    Settings = settings,
                    ProviderInfo = _providerInfo,
                    Configuration = new SyncAppDataResponseConfiguration
                    {
                        StoreInSeparateFile = configuration.StoreInSeparateFile,
                        IgnoreOnFileChange = configuration.IgnoreOnFileChange,
                        RegistrationMode = configuration.RegistrationMode,
                        Consumer = configuration.Consumer,
                        Provider = configuration.Provider,
                        Controller = configuration.Controller,
                        Spa = configuration.Spa
                    }
                });
            }
        }

        private Task<SyncAppDataResponseSetting[]> HandleSettingsAsync(
            OpenSettingsInternalDbContext internalContext,
            SyncAppDataInput input,
            Dictionary<string, int> classNameToCount,
            Dictionary<Guid, AppSettingSqlModel> computedIdentifierToSetting,
            ICollection<AppSettingSqlModel> settings,
            Guid identifierId,
            DateTime currentTime,
            CancellationToken cancellationToken)
        {
            var tasks = input.Settings.Select(inputSetting =>
            {
                var isUniqueClassName = classNameToCount[inputSetting.SettingClass.Name] == 1;

                return computedIdentifierToSetting.TryGetValue(inputSetting.ComputedIdentifier,
                    out var existingSetting)
                    ? HandleExistingSettingAsync(internalContext, existingSetting, inputSetting, input.UserId, currentTime,
                        isUniqueClassName, cancellationToken)
                    : HandleNewSettingAsync(settings, inputSetting, identifierId, input.UserId,
                        currentTime, isUniqueClassName, cancellationToken);
            }).ToArray();

            return Task.WhenAll(tasks);
        }

        private async Task<SyncAppDataResponseSetting> HandleExistingSettingAsync(OpenSettingsInternalDbContext internalContext, AppSettingSqlModel existingAppSetting, SyncAppDataInputSetting inputSetting, Guid? userId, DateTime currentTime, bool isUniqueClassName, CancellationToken cancellationToken)
        {
            internalContext.AppSettings.Attach(existingAppSetting);

            var decompressedData = await _compressionProvider.DecompressToUtf8StringAsync(existingAppSetting.Data, existingAppSetting.CompressionType, cancellationToken);

            var jsonMergeResult = JsonHelper.Merge(inputSetting.Data, decompressedData);

            var rowVersion = RowVersionHelper.Date(currentTime);

            string data;

            if (!jsonMergeResult.IsFaulted)
            {
                data = JsonSerializer.Serialize(jsonMergeResult.Data, OpenSettingsDefaults.Serialization.UnsafeRelaxedJsonSerializerOptions);

                if (decompressedData != data)
                {
                    if (!existingAppSetting.DataRestored)
                    {
                        existingAppSetting.AppSettingHistories.Add(new AppSettingHistorySqlModel
                        {
                            Data = existingAppSetting.Data,
                            Version = existingAppSetting.Version,
                            Slug = existingAppSetting.Version.ToSlug(),
                            CreatedOn = currentTime,
                            CreatedById = userId
                        });
                    }

                    existingAppSetting.CompressionType = _openSettingsConfiguration.Provider.CompressionType;
                    existingAppSetting.CompressionLevel = _openSettingsConfiguration.Provider.CompressionLevel;
                    existingAppSetting.Data = await _compressionProvider.CompressAsync(_openSettingsConfiguration.Provider.CompressionType, data, _openSettingsConfiguration.Provider.CompressionLevel, cancellationToken);
                    existingAppSetting.Version = Helper.GenerateVersion(currentTime, existingAppSetting.CreatedOn);
                    existingAppSetting.DataRestored = false;
                    existingAppSetting.UpdatedOn = currentTime;
                    existingAppSetting.UpdatedById = userId;
                    existingAppSetting.RowVersion = rowVersion;
                }
            }
            else
            {
                data = decompressedData;
            }

            if (existingAppSetting.StoreInSeparateFile && existingAppSetting.IgnoreOnFileChange == true && !isUniqueClassName)
            {
                existingAppSetting.IgnoreOnFileChange = false;
            }

            existingAppSetting.AppSettingClass.Identifier = inputSetting.SettingClass.Identifier;
            existingAppSetting.AppSettingClass.Name = inputSetting.SettingClass.Name;
            existingAppSetting.AppSettingClass.FullName = inputSetting.SettingClass.FullName;
            existingAppSetting.AppSettingClass.Namespace = inputSetting.SettingClass.Namespace;
            existingAppSetting.AppSettingClass.Properties = inputSetting.SettingClass.Properties;
            existingAppSetting.AppSettingClass.UpdatedOn = currentTime;
            existingAppSetting.AppSettingClass.UpdatedById = userId;
            existingAppSetting.AppSettingClass.RowVersion = rowVersion;

            return new SyncAppDataResponseSetting
            {
                ComputedIdentifier = existingAppSetting.ComputedIdentifier,
                Data = data,
                StoreInSeparateFile = existingAppSetting.StoreInSeparateFile,
                IgnoreOnFileChange = existingAppSetting.IgnoreOnFileChange,
                RegistrationMode = existingAppSetting.RegistrationMode
            };
        }

        private async Task<SyncAppDataResponseSetting> HandleNewSettingAsync(ICollection<AppSettingSqlModel> settings, SyncAppDataInputSetting inputSetting, Guid identifierId, Guid? userId, DateTime currentTime, bool isUniqueClassName, CancellationToken cancellationToken)
        {
            var newSetting = new AppSettingSqlModel
            {
                CompressionType = _openSettingsConfiguration.Provider.CompressionType,
                CompressionLevel = _openSettingsConfiguration.Provider.CompressionLevel,
                Data = await _compressionProvider.CompressAsync(_openSettingsConfiguration.Provider.CompressionType, inputSetting.Data, _openSettingsConfiguration.Provider.CompressionLevel, cancellationToken),
                ComputedIdentifier = inputSetting.ComputedIdentifier,
                Version = InitialSettingVersion,
                DataRestored = false,
                DataValidationDisabled = false,
                StoreInSeparateFile = inputSetting.StoreInSeparateFile,
                IgnoreOnFileChange = inputSetting.StoreInSeparateFile
                    ? isUniqueClassName
                        ? inputSetting.IgnoreOnFileChange
                        : false
                    : null,
                RegistrationMode = inputSetting.RegistrationMode,
                IdentifierId = identifierId,
                AppSettingClass = new AppSettingClassSqlModel
                {
                    Identifier = inputSetting.SettingClass.Identifier,
                    Name = inputSetting.SettingClass.Name,
                    FullName = inputSetting.SettingClass.FullName,
                    Namespace = inputSetting.SettingClass.Namespace,
                    Properties = inputSetting.SettingClass.Properties,
                    CreatedOn = currentTime,
                    CreatedById = userId
                },
                CreatedOn = currentTime,
                CreatedById = userId
            };

            settings.Add(newSetting);

            return new SyncAppDataResponseSetting
            {
                ComputedIdentifier = newSetting.ComputedIdentifier,
                Data = inputSetting.Data,
                StoreInSeparateFile = newSetting.StoreInSeparateFile,
                IgnoreOnFileChange = newSetting.IgnoreOnFileChange,
                RegistrationMode = newSetting.RegistrationMode
            };
        }

        private static IQueryable<GetAppResponse> GetAppResponse(IQueryable<AppSqlModel> query)
        {
            return query.Select(a => new GetAppResponse
            {
                Id = $"{a.Id}",
                DisplayName = a.DisplayName,
                Slug = a.Slug,
                Description = a.Description,
                ImageUrl = a.ImageUrl,
                WikiUrl = a.WikiUrl,
                Client = new GetAppResponseClient
                {
                    Id = a.ClientId,
                    Name = a.ClientName
                },
                Group = a.AppGroupId.HasValue
                    ? new GetAppResponseGroup
                    {
                        Id = $"{a.AppGroup.Id}",
                        Name = a.AppGroup.Name,
                        SortOrder = a.AppGroup.SortOrder
                    }
                    : OpenSettingsDefaults.Caches.UngroupedAppsForGetAppResponse,
                Tags = a.AppTagMappings.OrderBy(t => t.AppTag.SortOrder).Select(t => new GetAppResponseTag
                {
                    Id = $"{t.AppTag.Id}",
                    Name = t.AppTag.Name,
                    SortOrder = t.AppTag.SortOrder
                }).ToArray(),
                RowVersion = a.RowVersion
            });
        }

        private static IQueryable<GetGroupedAppsResponseApp> GetGroupedAppsResponseApp(IQueryable<AppSqlModel> query)
        {
            return query.Select(a => new GetGroupedAppsResponseApp
            {
                Id = $"{a.Id}",
                DisplayName = a.DisplayName,
                Slug = a.Slug,
                Description = a.Description,
                ImageUrl = a.ImageUrl,
                WikiUrl = a.WikiUrl,
                Client = new GetGroupedAppsResponseAppClient
                {
                    Id = a.ClientId,
                    Name = a.ClientName
                },
                Group = a.AppGroupId.HasValue
                    ? new GetGroupedAppsResponseAppGroup
                    {
                        Id = $"{a.AppGroup.Id}",
                        Name = a.AppGroup.Name,
                        SortOrder = a.AppGroup.SortOrder
                    }
                    : OpenSettingsDefaults.Caches.UngroupedAppsForGetGroupedApps,
                Tags = a.AppTagMappings.OrderBy(t => t.AppTag.SortOrder).Select(t => new GetGroupedAppsResponseAppTag
                {
                    Id = $"{t.AppTag.Id}",
                    Name = t.AppTag.Name,
                    SortOrder = t.AppTag.SortOrder
                }).ToArray(),
                RowVersion = a.RowVersion
            });
        }

        private static PropertyInfoHelperModel[] MapProperties(IEnumerable<PropertyInfoHelperModel> properties)
        {
            return properties.Select(property => new PropertyInfoHelperModel
            {
                Name = property.Name,
                TypeIdentifier = property.TypeIdentifier,
                TypeName = property.TypeName,
                TypeFullName = property.TypeFullName,
                IsComplexType = property.IsComplexType,
                IsGenericType = property.IsGenericType,
                GenericTypeArguments = property.GenericTypeArguments.ToArray(),
                Attributes = property.Attributes.ToArray(),
                Properties = MapProperties(property.Properties)
            }).ToArray();
        }
    }
}