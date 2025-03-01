using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
using OpenSettings.Services.Sql.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ConfigurationSqlModel = OpenSettings.Domains.Sql.Entities.ConfigurationSqlModel;

namespace OpenSettings.Services.Sql
{
    internal sealed class AppsSqlService : IAppsSqlService
    {
        private const string InitialSettingVersion = "0";

        private readonly ILogger _logger;
        private readonly IIdentifiersSqlService _identifiersSqlService;
        private readonly IAppGroupsSqlService _appGroupsSqlService;
        private readonly ITagsSqlService _tagsSqlService;
        private readonly ICompressionFactory _compressionFactory;
        private readonly IPasswordHasher<AppSqlModel> _passwordHasher;
        private readonly OpenSettingsDbContext _context;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly ProviderInfo _providerInfo;

        public AppsSqlService(
            ILogger<AppsSqlService> logger,
            IIdentifiersSqlService identifiersSqlService,
            IAppGroupsSqlService appGroupsSqlService,
            ITagsSqlService tagsSqlService,
            ICompressionFactory compressionFactory,
            IPasswordHasher<AppSqlModel> passwordHasher,
            OpenSettingsDbContext context,
            OpenSettingsConfiguration openSettingsConfiguration,
            ProviderInfo providerInfo)
        {
            _logger = logger;
            _identifiersSqlService = identifiersSqlService;
            _appGroupsSqlService = appGroupsSqlService;
            _tagsSqlService = tagsSqlService;
            _compressionFactory = compressionFactory;
            _passwordHasher = passwordHasher;
            _context = context;
            _openSettingsConfiguration = openSettingsConfiguration;
            _providerInfo = providerInfo;
        }

        public async Task<IJsonResponse<SyncAppDataResponse>> SyncAppDataAsync(SyncAppDataInput input, CancellationToken cancellationToken = default)
        {
            try
            {
                input.UserId = input.UserId ?? await GetOrCreateUserAsync(input.Client.Id, input.Client.Secret, input.Client.Name, cancellationToken);

                var identifier = await _identifiersSqlService.GetOrCreateAsync(input.IdentifierName, SetSortOrderPosition.Bottom, input.UserId, cancellationToken);


                if (!identifier.Success)
                {
                    return identifier.Status.ToFailureJsonResponse<SyncAppDataResponse>(identifier.Errors);
                }

                var classNameToCount = new Dictionary<string, int>();

                foreach (var setting in input.Settings)
                {
                    classNameToCount[setting.SettingClass.Name] = Constants.ClassNameToCount.GetValueOrDefault(setting.SettingClass.Name, 0) + 1;
                }

                var partialApp = await _context.Apps
                    .AsNoTracking()
#if !NETSTANDARD2_0
                    .AsSplitQuery()
#endif
                    .Include(a => a.AppIdentifierMappings)
                    .Where(a => a.ClientId == input.Client.Id && a.ClientName == input.Client.Name)
                    .OrderBy(a => a.Id)
                    .Select(a => new
                    {
                        a.Id,
                        a.HashedClientSecret,
                        a.RowVersion,
                        MappedAppIdentifierIds = new HashSet<int>(a.AppIdentifierMappings.Select(i => i.IdentifierId))
                    })
                    .FirstOrDefaultAsync(cancellationToken); ;

                return partialApp == null
                    ? await HandleNewAppAsync(input, classNameToCount, identifier.Data.Id, cancellationToken)
                    : await HandleExistingAppAsync(input, classNameToCount, identifier.Data.Id, partialApp.Id, partialApp.HashedClientSecret, partialApp.MappedAppIdentifierIds, cancellationToken);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError.ToFailureJsonResponse<SyncAppDataResponse>(ex);
            }
        }

        public async Task<IJsonResponse> GetGroupedAppsAsync(GetGroupedAppsInput input, CancellationToken cancellationToken = default)
        {
            var query = _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.Group)
                .Include(a => a.AppTagMappings).ThenInclude(a => a.Tag).AsQueryable();

            if (int.TryParse(input.GroupId, out var appGroupId) && appGroupId > -2)
            {
                query = appGroupId == -1
                    ? query.Where(a => !a.GroupId.HasValue)
                    : appGroupId > 0
                        ? query.Where(a => a.GroupId == appGroupId)
                        : query.Where(a => a.GroupId.HasValue);
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
                    .SearchBy(fields, $"%{searchTermLowercase}%", _context)
                    .OrderBy(a => a.ClientNameLowercase.IndexOf(searchTermLowercase)).ThenBy(a => a.Group.SortOrder);
            }
            else
            {
                query = query.OrderBy(a => a.Group.SortOrder);
            }

            var entities = await GetGroupedAppsResponseApp(query).ToArrayAsync(cancellationToken);

            var groupNameToAppsMap = entities
                .GroupBy(e => e.Group.Name)
                .ToDictionary(e => e.Key, e => e.ToArray());

            return HttpStatusCode.OK.ToSuccessJsonResponse(new GetGroupedAppsResponse
            {
                GroupNameToApps = groupNameToAppsMap,
                GroupsCount = groupNameToAppsMap.Count,
                AppsCount = entities.Length
            });
        }

        public async Task<IJsonResponse<GetAppResponse>> GetAppByIdAsync(GetAppInput input, CancellationToken cancellationToken = default)
        {
            var appIdRule = JsonValidationRules.GreaterThanRule("AppId", input.AppIdOrSlug, 0);

            if (appIdRule.IsFailed())
            {
                return appIdRule.Failure.ToJsonResponse<GetAppResponse>();
            }

            var appId = appIdRule.GetStoredValue<int>();

            return await GetAppByIdOrSlugAsync(a => a.Id == appId, cancellationToken);
        }

        public Task<IJsonResponse<GetAppResponse>> GetAppBySlugAsync(GetAppInput input, CancellationToken cancellationToken = default)
        {
            input.AppIdOrSlug = input.AppIdOrSlug?.ToSlug();

            return GetAppByIdOrSlugAsync(a => a.Slug == input.AppIdOrSlug, cancellationToken);
        }

        public async Task<IJsonResponse> UpdateAppAsync(UpdateAppInput input, CancellationToken cancellationToken)
        {
            var appIdRule = JsonValidationRules.GreaterThanRule(nameof(input.AppId), input.AppId, 0);

            if (appIdRule.IsFailed())
            {
                return appIdRule.Failure.ToJsonResponse();
            }

            var appId = appIdRule.GetStoredValue<int>();

            var entity = await _context.Apps
                .AsNoTracking()
                .Include(a => a.AppTagMappings).ThenInclude(a => a.Tag)
                .Where(a => a.Id == appId)
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
                        TagId = t.TagId,
                        Tag = new TagSqlModel
                        {
                            Id = t.Tag.Id,
                            Name = t.Tag.Name,
                            SortOrder = t.Tag.SortOrder
                        }
                    }).ToList()
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.AppNotFound);
            }

            if (!input.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict(input.AppId, entity.RowVersion, input.RowVersion, false);
            }

            _context.Apps.Attach(entity);

            var currentTime = DateTime.UtcNow;
            var rowVersion = currentTime.ToRowVersion();

            var trimmedClientName = input.ClientName.Trim();
            var trimmedClientNameLowercase = trimmedClientName.ToLowerInvariant();

            if (entity.Slug != input.Slug)
            {
                var slug = await GenerateAppSlugAsync(trimmedClientNameLowercase, input.Slug, currentTime, entity.Id, cancellationToken);

                if (slug == null)
                {
                    return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.SlugAlreadyExists);
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
                entity.GroupId = null;

                _context.MarkAsModified(entity, e => e.GroupId);
            }
            else
            {
                var groupJsonResponse = await _appGroupsSqlService.GetOrCreateAsync(input.Group.Name, SetSortOrderPosition.Bottom, input.UpdatedById, cancellationToken);

                if (!groupJsonResponse.Success)
                {
                    return groupJsonResponse.ToJsonResponse();
                }

                var groupEntity = new AppGroupSqlModel
                {
                    Id = groupJsonResponse.Data.Id,
                    Name = groupJsonResponse.Data.Name,
                    SortOrder = groupJsonResponse.Data.SortOrder
                };

                _context.Attach(groupEntity);

                entity.Group = groupEntity;
            }

            var existingTagIds = new HashSet<int>(entity.AppTagMappings.Select(t => t.Tag.Id));

            var newTagIds = new HashSet<int>(input.Tags.Select(tag => int.TryParse(tag.Id, out var tagId) ? tagId : (int?)null).Where(tagId => tagId.HasValue).Select(tagId => tagId.Value));

            var tagsToRemove = entity.AppTagMappings.Where(at => !newTagIds.Contains(at.TagId)).ToList();

            foreach (var tagToRemove in tagsToRemove)
            {
                entity.AppTagMappings.Remove(tagToRemove);
            }

            foreach (var tag in input.Tags)
            {
                if (!int.TryParse(tag.Id, out var tagId))
                {
                    continue;
                }

                if (tagId > 0 && !existingTagIds.Contains(tagId))
                {
                    var tagEntity = new TagSqlModel { Id = tagId, Name = tag.Name };

                    _context.Tags.Attach(tagEntity);

                    entity.AppTagMappings.Add(new AppTagMappingSqlModel
                    {
                        Tag = tagEntity,
                        CreatedOn = currentTime
                    });
                }
                else if (tagId == 0 && !string.IsNullOrWhiteSpace(tag.Name))
                {
                    var getOrCreateTag = await _tagsSqlService.GetOrCreateAsync(tag.Name, SetSortOrderPosition.Bottom, input.UpdatedById, cancellationToken);

                    if (!getOrCreateTag.Success)
                    {
                        return getOrCreateTag.ToJsonResponse();
                    }

                    var tagEntity = new TagSqlModel { Id = getOrCreateTag.Data.Id, Name = tag.Name };

                    _context.Tags.Attach(tagEntity);

                    entity.AppTagMappings.Add(new AppTagMappingSqlModel
                    {
                        Tag = tagEntity,
                        CreatedOn = currentTime
                    });
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse(new UpdateAppResponse
            {
                DisplayName = entity.DisplayName,
                ClientName = entity.ClientName,
                Slug = entity.Slug,
                Group = entity.Group == null
                    ? null
                    : new GetGroupedAppsResponseAppGroup
                    {
                        Id = $"{entity.Group.Id}",
                        Name = entity.Group.Name,
                        SortOrder = entity.Group.SortOrder
                    },
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                WikiUrl = entity.WikiUrl,
                Tags = entity.AppTagMappings.Select(a => new UpdateAppResponseTag
                {
                    Id = $"{a.Tag.Id}",
                    Name = a.Tag.Name,
                    SortOrder = a.Tag.SortOrder
                }).ToArray(),
                RowVersion = entity.RowVersion
            });
        }

        public async Task<IJsonResponse<GetRegisteredAppResponse>> GetRegisteredAppAsync(GetRegisteredAppInput input, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Apps
                .AsNoTracking()
                .Where(a => a.ClientId == input.ClientId)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    a.ClientName,
                    a.HashedClientSecret,
                    IsRegistered = true,
                    IsClientIdUnique = true,
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity != null)
            {
                var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(null, entity.HashedClientSecret, $"{input.ClientSecret}");

                return HttpStatusCode.OK.ToSuccessJsonResponseOf(new GetRegisteredAppResponse
                {
                    ClientName = entity.ClientName,
                    IsRegistered = entity.IsRegistered,
                    IsClientIdUnique = true,
                    IsClientSecretMatched = passwordVerificationResult != PasswordVerificationResult.Failed
                });
            }

            var isClientIdUnique = !await _context.Apps.AsNoTracking().AnyAsync(a => a.ClientId == input.ClientId, cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponseOf(new GetRegisteredAppResponse
            {
                ClientName = string.Empty,
                IsRegistered = false,
                IsClientIdUnique = isClientIdUnique,
                IsClientSecretMatched = false,
            });
        }

        public async Task<IJsonResponse<FetchAppDataResponse>> FetchAppDataAsync(FetchAppDataInput input, CancellationToken cancellationToken = default)
        {
            input.IdentifierName = input.IdentifierName.Trim().ToLowerInvariant();

            var query = _context.Settings.AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.App)
                .Include(a => a.SettingClass)
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
                    DataTask = _compressionFactory.DecompressToUtf8StringAsync(entity.Data, entity.CompressionType, cancellationToken),
                    UpdatedOn = entity.UpdatedOn.GetValueOrDefault(),
                    entity.StoreInSeparateFile,
                    entity.IgnoreOnFileChange,
                    entity.RegistrationMode
                };
            }).ToArray();

            await Task.WhenAll(rawReadResponseData.Select(r => r.DataTask));

            return HttpStatusCode.OK.ToSuccessJsonResponseOf(new FetchAppDataResponse
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

        public async Task<IJsonResponse> GetAppsAsync(GetAppsInput input, CancellationToken cancellationToken = default)
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

                return HttpStatusCode.OK.ToSuccessJsonResponse(unfilteredEntities);
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
                .SearchBy(fields, $"%{searchTermLowercase}%", _context)
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

            return HttpStatusCode.OK.ToSuccessJsonResponse(filteredEntities);
        }

        private async Task<string> GenerateAppSlugAsync(string clientName, string slug, DateTime currentTime, int? id = null, CancellationToken cancellationToken = default)
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

        public async Task<IJsonResponse> CreateAppAsync(CreateAppInput input, CancellationToken cancellationToken = default)
        {
            var clientIdNotEmptyRule = JsonValidationRules.NotEmptyRule("Client.Id", input.Client.Id);
            var clientSecretNotEmptyRule = JsonValidationRules.NotEmptyRule("Client.Secret", input.Client.Secret);
            var clientNameNotEmptyRule = JsonValidationRules.NotEmptyRule("Client.Name", input.Client.Name);

            var failure = new[] { clientIdNotEmptyRule, clientSecretNotEmptyRule, clientNameNotEmptyRule }.ValidateFirstOrDefault();

            if (failure != null)
            {
                return failure.ToJsonResponse();
            }

            var trimmedClientName = input.Client.Name.Trim();
            var trimmedClientNameLowercase = trimmedClientName.ToLowerInvariant();

            var currentTime = DateTime.UtcNow;

            var slug = await GenerateAppSlugAsync(input.Client.Name, input.Slug, currentTime, cancellationToken: cancellationToken);

            if (slug == null)
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.SlugAlreadyExists);
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
                Settings = Array.Empty<SettingSqlModel>(),
                Instances = Array.Empty<InstanceSqlModel>(),
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
                var groupJsonResponse = await _appGroupsSqlService.GetOrCreateAsync(input.Group.Name, SetSortOrderPosition.Bottom, input.CreatedById, cancellationToken);

                if (!groupJsonResponse.Success)
                {
                    return groupJsonResponse.ToJsonResponse();
                }

                var groupEntity = new AppGroupSqlModel
                {
                    Id = groupJsonResponse.Data.Id,
                    Name = groupJsonResponse.Data.Name,
                    SortOrder = groupJsonResponse.Data.SortOrder
                };

                _context.Attach(groupEntity);

                appSqlModel.Group = groupEntity;
            }
            else
            {
                appSqlModel.GroupId = null;
            }

            var newTags = new List<TagSqlModel>();

            var existingTags = new HashSet<int>(input.Tags.Select(t =>
            {
                if (!int.TryParse(t.Id, out var tagId))
                {
                    return 0;
                }

                if (tagId > 0)
                {
                    return tagId;
                }

                if (tagId != 0 || string.IsNullOrWhiteSpace(t.Name))
                {
                    return 0;
                }

                var tagName = t.Name.Trim();
                var trimmedTagNameLowercase = tagName.ToLowerInvariant();
                var tagSlug = tagName.ToSlug();

                newTags.Add(new TagSqlModel { Name = tagName, NameLowercase = trimmedTagNameLowercase, Slug = tagSlug, CreatedById = input.CreatedById, CreatedOn = currentTime });

                return 0;

            }).Where(t => t > 0));

            var tagIdToTag = await _context.Tags
                .AsNoTracking()
                .Where(t => existingTags.Contains(t.Id))
                .Select(t => new TagSqlModel { Id = t.Id, Name = t.Name, SortOrder = t.SortOrder })
                .ToDictionaryAsync(t => t.Id, cancellationToken);

            var missingTags = string.Join(",", existingTags.Except(tagIdToTag.Keys));

            if (missingTags.Length > 0)
            {
                _logger.LogWarning("Missing tags detected during app creation: {missingTags}", missingTags);
            }

            if (newTags.Count > 0)
            {
                int newTagSortOrderStartingPoint;

                try
                {
                    newTagSortOrderStartingPoint = await _context.Tags.AsNoTracking().MaxAsync(s => s.SortOrder, cancellationToken) + Constants.SortOrderGap;
                }
                catch (InvalidOperationException)
                {
                    newTagSortOrderStartingPoint = 0;
                }

                foreach (var tag in newTags)
                {
                    tag.SortOrder = newTagSortOrderStartingPoint;

                    _context.Tags.Add(tag);

                    newTagSortOrderStartingPoint += Constants.SortOrderGap;
                }

                await _context.SaveChangesAsync(cancellationToken);

                foreach (var tag in newTags)
                {
                    _context.Entry(tag).State = EntityState.Detached;
                }
            }

            foreach (var tagEntity in tagIdToTag.Values.Concat(newTags))
            {
                _context.Tags.Attach(tagEntity);

                appSqlModel.AppTagMappings.Add(new AppTagMappingSqlModel
                {
                    Tag = tagEntity,
                    CreatedOn = currentTime,
                    CreatedById = input.CreatedById
                });
            }

            var appUserModel = new UserSqlModel
            {
                Id = input.Client.Id,
                AuthScheme = Constants.OpenSettingsBasicAuthScheme,
                OAuthProvider = null,
                ProviderId = clientIdAsString,
                Email = clientIdAsString,
                EmailLowercase = clientIdAsStringLowercase,
                Username = clientIdAsString,
                UsernameLowercase = clientIdAsStringLowercase,
                HashedPassword = hashedPassword,
                Name = trimmedClientName,
                NameLowercase = trimmedClientNameLowercase,
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
                Group = appSqlModel.Group == null
                    ? null
                    : new GetGroupedAppsResponseAppGroup
                    {
                        Id = $"{appSqlModel.Group.Id}",
                        Name = appSqlModel.Group.Name,
                        SortOrder = appSqlModel.Group.SortOrder
                    },
                Tags = appSqlModel.AppTagMappings.Select(a => new GetGroupedAppsResponseAppTag
                {
                    Id = $"{a.Tag.Id}",
                    Name = a.Tag.Name,
                    SortOrder = a.Tag.SortOrder
                }).ToArray(),
                RowVersion = appSqlModel.RowVersion
            };

            return HttpStatusCode.OK.ToSuccessJsonResponse(data);
        }

        public async Task<IJsonResponse> GetGroupedAppDataByAppIdAsync(GetGroupedAppDataByAppInput input, CancellationToken cancellationToken = default)
        {
            var appIdRule = JsonValidationRules.GreaterThanRule("AppId", input.AppIdOrSlug, 0);

            if (appIdRule.IsFailed())
            {
                return appIdRule.Failure.ToJsonResponse();
            }

            var appId = appIdRule.GetStoredValue<int>();

            return await GetGroupedAppDataByAppIdOrSlugAsync(a => a.Id == appId, cancellationToken);
        }

        public Task<IJsonResponse> GetGroupedAppDataByAppSlugAsync(GetGroupedAppDataByAppInput input, CancellationToken cancellationToken = default)
        {
            input.AppIdOrSlug = input.AppIdOrSlug?.ToSlug();

            return GetGroupedAppDataByAppIdOrSlugAsync(a => a.Slug == input.AppIdOrSlug, cancellationToken);
        }


        public async Task<IJsonResponse> GetGroupedAppDataByAppIdAndIdentifierIdAsync(GetGroupedAppDataByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
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

            return await GetGroupedAppDataByAppIdOrAppSlugAndIdentifierIdAsync(a => a.Id == appId, identifierId, cancellationToken);
        }

        public async Task<IJsonResponse> GetGroupedAppDataByAppSlugAndIdentifierSlugAsync(GetGroupedAppDataByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
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
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.IdentifierNotFound);
            }

            input.AppIdOrSlug = input.AppIdOrSlug?.ToSlug();

            return await GetGroupedAppDataByAppIdOrAppSlugAndIdentifierIdAsync(a => a.Slug == input.AppIdOrSlug, identifier.Id, cancellationToken);
        }


        public async Task<IJsonResponse> DeleteAppAsync(DeleteAppInput input, CancellationToken cancellationToken)
        {
            var appIdRule = JsonValidationRules.GreaterThanRule(nameof(input.AppId), input.AppId, 0);

            if (appIdRule.IsFailed())
            {
                return appIdRule.Failure.ToJsonResponse();
            }

            var appId = appIdRule.GetStoredValue<int>();

            var entity = await _context.Apps
                .AsNoTracking()
                .Where(a => a.Id == appId)
                .OrderBy(a => a.Id)
                .Select(a => new AppSqlModel { Id = a.Id, RowVersion = a.RowVersion })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.AppNotFound);
            }

            if (!input.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict(input.AppId, entity.RowVersion, input.RowVersion, false);
            }

            _context.Apps.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse();
        }

        private async Task<IJsonResponse> GetGroupedAppDataByAppIdOrSlugAsync(Expression<Func<AppSqlModel, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.Configurations)
                .Include(a => a.Settings).ThenInclude(a => a.SettingClass)
                .Include(a => a.Instances)
                .Include(a => a.AppIdentifierMappings).ThenInclude(a => a.Identifier)
                .Where(predicate)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    Instances = a.Instances.Select(i => new
                    {
                        Id = $"{i.Id}",
                        i.DynamicId,
                        i.IdentifierId,
                        i.Name,
                        i.Version,
                        i.Urls,
                        i.IsActive,
                        i.IpAddress,
                        i.MachineName,
                        i.Environment,
                        i.ReloadStrategies,
                        i.ServiceType,
                        i.CreatedOn,
                        i.UpdatedOn,
                    }).ToArray(),
                    Configurations = a.Configurations.Select(c => new
                    {
                        Id = $"{c.Id}",
                        c.AllowAnonymousAccess,
                        c.StoreInSeparateFile,
                        c.IgnoreOnFileChange,
                        c.RegistrationMode,
                        c.Consumer,
                        c.Provider,
                        c.IdentifierId,
                        c.RowVersion
                    }).ToArray(),
                    Settings = a.Settings.Select(s => new
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
                            Id = $"{s.SettingClass.Id}",
                            Name = s.SettingClass.Name,
                            Namespace = s.SettingClass.Namespace,
                            FullName = s.SettingClass.FullName,
                            RowVersion = s.SettingClass.RowVersion
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
                                Order = m.Identifier.SortOrder
                            },
                            m.RowVersion
                        }).ToArray()
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.AppNotFound);
            }

            if (entity.AppIdentifierMappings.Length == 0)
            {
                return HttpStatusCode.OK.ToSuccessJsonResponse(new GetGroupedAppDataResponse());
            }

            var firstMapping = entity.AppIdentifierMappings.First();

            int minSortOrder = firstMapping.Identifier.Order,
                maxSortOrder = firstMapping.Identifier.Order,
                mappingMinSortOrder = firstMapping.SortOrder,
                mappingMaxSortOrder = firstMapping.SortOrder;

            var identifierToConfiguration = entity.Configurations.ToDictionary(c => c.IdentifierId, c => new GetGroupedAppDataResponseConfiguration
            {
                Id = c.Id,
                AllowAnonymousAccess = c.AllowAnonymousAccess,
                StoreInSeparateFile = c.StoreInSeparateFile,
                IgnoreOnFileChange = c.IgnoreOnFileChange,
                RegistrationMode = c.RegistrationMode,
                Consumer = c.Consumer,
                Provider = c.Provider,
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
                    IpAddress = s.IpAddress,
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
                    SortOrder = mapping.Identifier.Order,
                    MappingSortOrder = mapping.SortOrder,
                    MappingRowVersion = mapping.RowVersion
                };

                minSortOrder = Math.Min(mapping.Identifier.Order, minSortOrder);
                maxSortOrder = Math.Min(mapping.Identifier.Order, maxSortOrder);

                mappingMinSortOrder = Math.Min(mapping.SortOrder, mappingMinSortOrder);
                mappingMaxSortOrder = Math.Max(mapping.SortOrder, mappingMaxSortOrder);

                identifierIdToConfiguration[identifierId] = identifierToConfiguration.GetValueOrDefault(mapping.Identifier.Id, null);

                identifierIdToSettings[identifierId] = identifierToSettings.GetValueOrDefault(mapping.Identifier.Id, Array.Empty<GetGroupedAppDataResponseSetting>());

                identifierIdToInstances[identifierId] = identifierToInstancesMap.GetValueOrDefault(mapping.Identifier.Id, Array.Empty<GetGroupedAppDataResponseInstance>());
            }

            return HttpStatusCode.OK.ToSuccessJsonResponse(new GetGroupedAppDataResponse
            {
                IdentifierInfo = new GetGroupedAppDataResponseIdentifierInfo
                {
                    MinSortOrder = minSortOrder,
                    MaxSortOrder = maxSortOrder,
                    MappingMinSortOrder = mappingMinSortOrder,
                    MappingMaxSortOrder = mappingMaxSortOrder
                },
                IdentifierIdToIdentifier = identifierIdToIdentifier,
                IdentifierIdToConfiguration = identifierIdToConfiguration,
                IdentifierIdToSettings = identifierIdToSettings,
                IdentifierIdToInstances = identifierIdToInstances
            });
        }


        private async Task<IJsonResponse<GetAppResponse>> GetAppByIdOrSlugAsync(Expression<Func<AppSqlModel, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var query = _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.Group)
                .Include(a => a.AppTagMappings).ThenInclude(a => a.Tag)
                .Where(predicate)
                .OrderBy(a => a.Id);

            var entity = await GetAppResponse(query).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureJsonResponse<GetAppResponse, Errors>(Errors.AppNotFound)
                : HttpStatusCode.OK.ToSuccessJsonResponseOf(entity);
        }

        private async Task<IJsonResponse> GetGroupedAppDataByAppIdOrAppSlugAndIdentifierIdAsync(Expression<Func<AppSqlModel, bool>> predicate, int identifierId, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.Settings).ThenInclude(a => a.SettingClass)
                .Include(a => a.Instances)
                .Include(a => a.AppIdentifierMappings).ThenInclude(a => a.Identifier)
                .Where(predicate)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    Instances = a.Instances.Where(i => i.IdentifierId == identifierId).Select(i => new
                    {
                        Id = $"{i.Id}",
                        i.DynamicId,
                        i.IdentifierId,
                        i.Name,
                        i.Urls,
                        i.IsActive,
                        i.IpAddress,
                        i.MachineName,
                        i.Environment,
                        i.ReloadStrategies,
                        i.ServiceType,
                        i.Version,
                        i.CreatedOn,
                        i.UpdatedOn
                    }).ToArray(),
                    Configuration = a.Configurations.Where(c => c.IdentifierId == identifierId).Select(c => new
                    {
                        Id = $"{c.Id}",
                        c.AllowAnonymousAccess,
                        c.StoreInSeparateFile,
                        c.IgnoreOnFileChange,
                        c.RegistrationMode,
                        c.Consumer,
                        c.Provider,
                        c.IdentifierId,
                        c.RowVersion
                    }).FirstOrDefault(),
                    Settings = a.Settings.Where(s => s.IdentifierId == identifierId).Select(s => new
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
                            Id = $"{s.SettingClass.Id}",
                            Name = s.SettingClass.Name,
                            Namespace = s.SettingClass.Namespace,
                            FullName = s.SettingClass.FullName,
                            RowVersion = s.SettingClass.RowVersion
                        }
                    }).ToArray(),
                    AppIdentifierMapping = a.AppIdentifierMappings.Where(m => m.Identifier.Id == identifierId).Select(m =>
                        new
                        {
                            m.SortOrder,
                            Identifier = new
                            {
                                m.Identifier.Name,
                                m.Identifier.SortOrder
                            },
                            m.RowVersion
                        }).FirstOrDefault()
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.AppNotFound);
            }

            if (entity.AppIdentifierMapping == null)
            {
                return HttpStatusCode.OK.ToSuccessJsonResponse(new GetGroupedAppDataResponse());
            }

            return HttpStatusCode.OK.ToSuccessJsonResponse(new GetGroupedAppDataByIdentifierIdResponse
            {
                Identifier = new GetGroupedAppDataByIdentifierIdResponseIdentifier
                {
                    Id = $"{identifierId}",
                    Name = entity.AppIdentifierMapping.Identifier.Name,
                    SortOrder = entity.AppIdentifierMapping.Identifier.SortOrder,
                    MappingSortOrder = entity.AppIdentifierMapping.SortOrder,
                    MappingRowVersion = entity.AppIdentifierMapping.RowVersion
                },
                Configuration = new GetGroupedAppDataByIdentifierIdResponseConfiguration
                {
                    Id = entity.Configuration.Id,
                    AllowAnonymousAccess = entity.Configuration.AllowAnonymousAccess,
                    StoreInSeparateFile = entity.Configuration.StoreInSeparateFile,
                    IgnoreOnFileChange = entity.Configuration.IgnoreOnFileChange,
                    RegistrationMode = entity.Configuration.RegistrationMode,
                    Consumer = entity.Configuration.Consumer,
                    Provider = entity.Configuration.Provider,
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
                    IpAddress = instance.IpAddress,
                    MachineName = instance.MachineName,
                    Environment = instance.Environment,
                    ReloadStrategies = instance.ReloadStrategies,
                    ServiceType = instance.ServiceType,
                    CreatedOn = instance.CreatedOn,
                    UpdatedOn = instance.UpdatedOn
                }).ToArray()
            });
        }

        private async Task<IJsonResponse<SyncAppDataResponse>> HandleNewAppAsync(SyncAppDataInput input, Dictionary<string, int> classNameToCount, int identifierId, CancellationToken cancellationToken = default)
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

                return new SettingSqlModel
                {
                    CompressionType = _openSettingsConfiguration.Provider.CompressionType,
                    CompressionLevel = _openSettingsConfiguration.Provider.CompressionLevel,
                    Data = await _compressionFactory.CompressAsync(_openSettingsConfiguration.Provider.CompressionType, setting.Data, _openSettingsConfiguration.Provider.CompressionLevel, cancellationToken),
                    ComputedIdentifier = setting.ComputedIdentifier,
                    IdentifierId = identifierId,
                    Version = InitialSettingVersion,
                    DataValidationDisabled = false,
                    StoreInSeparateFile = setting.StoreInSeparateFile,
                    IgnoreOnFileChange = setting.IgnoreOnFileChange,
                    RegistrationMode = setting.RegistrationMode,
                    SettingClass = new SettingClassSqlModel
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

            var trimmedInstanceName = input.Instance.InstanceName.Trim();
            var trimmedInstanceNameLowercase = trimmedInstanceName.ToLowerInvariant();
            var instanceSlug = trimmedInstanceName.ToSlug();

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

            var configuration = new ConfigurationSqlModel
            {
                AllowAnonymousAccess = input.Configuration.AllowAnonymousAccess,
                StoreInSeparateFile = input.Configuration.StoreInSeparateFile,
                IgnoreOnFileChange = input.Configuration.IgnoreOnFileChange,
                RegistrationMode = input.Configuration.RegistrationMode,
                Consumer = input.Configuration.Consumer,
                Provider = input.Configuration.Provider,
                IdentifierId = identifierId,
                CreatedOn = currentTime,
                CreatedById = input.UserId
            };

            var app = new AppSqlModel
            {
                DisplayName = trimmedClientName,
                DisplayNameLowercase = trimmedClientNameLowercase,
                ClientName = trimmedClientName,
                ClientNameLowercase = trimmedClientNameLowercase,
                Slug = appSlugTask.Result,
                Configurations = new ConfigurationSqlModel[]
                {
                    configuration
                },
                Settings = settingsTask.Result,
                Instances = new[]
                {
                    new InstanceSqlModel
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
                        CreatedOn = currentTime,
                    }
                },
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

                return HttpStatusCode.OK.ToSuccessJsonResponseOf(new SyncAppDataResponse
                {
                    Settings = settings,
                    Configuration = new SyncAppDataResponseConfiguration
                    {
                        AllowAnonymousAccess = configuration.AllowAnonymousAccess,
                        StoreInSeparateFile = configuration.StoreInSeparateFile,
                        IgnoreOnFileChange = configuration.IgnoreOnFileChange,
                        RegistrationMode = configuration.RegistrationMode,
                        Consumer = configuration.Consumer,
                        Provider = configuration.Provider
                    },
                    ProviderInfo = _providerInfo
                });
            }
            catch (Exception ex)
            {
                return ex.ToJsonResponse<SyncAppDataResponse>();
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
                AuthScheme = Constants.OpenSettingsBasicAuthScheme,
                OAuthProvider = null,
                ProviderId = clientIdAsString,
                Email = clientIdAsString,
                EmailLowercase = clientIdAsStringLowercase,
                HashedPassword = _passwordHasher.HashPassword(null, $"{clientSecret}"),
                Username = clientIdAsString,
                UsernameLowercase = clientIdAsStringLowercase,
                Name = trimmedClientName,
                NameLowercase = trimmedClientNameLowercase,
                DisplayName = trimmedClientName,
                LastLogin = currentTime,
                CreatedOn = currentTime,
                IsActive = true
            };

            _context.Users.Add(appUserModel);

            await _context.SaveChangesAsync(cancellationToken);

            return clientId;
        }

        private async Task<IJsonResponse<SyncAppDataResponse>> HandleExistingAppAsync(SyncAppDataInput input, Dictionary<string, int> classNameToCount, int identifierId, int appId, string hashedClientSecret, ICollection<int> mappedAppIdentifierIds, CancellationToken cancellationToken = default)
        {
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(null, hashedClientSecret, $"{input.Client.Secret}");

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return HttpStatusCode.Unauthorized.ToFailureJsonResponse<SyncAppDataResponse, Errors>(Errors.InvalidCredentials);
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
                        .MaxAsync(s => s.SortOrder, cancellationToken) + Constants.SortOrderGap;
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

            var instanceName = input.Instance.InstanceName.Trim();
            var instanceNameLowercase = instanceName.ToLowerInvariant();
            var instanceSlug = instanceName.ToSlug();

            var instance = await _context.Instances
                .AsNoTracking()
                .Where(a => a.NameLowercase == instanceNameLowercase && a.IdentifierId == identifierId && a.AppId == appId)
                .OrderBy(a => a.Id)
                .Select(a => new InstanceSqlModel
                {
                    Id = a.Id
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (instance == null)
            {
                app.Instances.Add(new InstanceSqlModel
                {
                    Name = instanceName,
                    NameLowercase = instanceNameLowercase,
                    Slug = instanceSlug,
                    IdentifierId = identifierId,
                    DynamicId = input.Instance.DynamicId,
                    Urls = Array.Empty<string>(),
                    MachineName = input.Instance.MachineName,
                    Environment = input.Instance.Environment,
                    ReloadStrategies = input.Instance.ReloadStrategies,
                    ServiceType = input.Instance.ServiceType,
                    Version = input.Instance.Version,
                    CreatedOn = currentTime
                });
            }
            else
            {
                _context.Instances.Attach(instance);

                instance.Name = instanceName;
                instance.NameLowercase = instanceNameLowercase;
                instance.Slug = instanceSlug;
                instance.DynamicId = input.Instance.DynamicId;
                instance.MachineName = input.Instance.MachineName;
                instance.Environment = input.Instance.Environment;
                instance.ReloadStrategies = input.Instance.ReloadStrategies;
                instance.ServiceType = input.Instance.ServiceType;
                instance.Version = input.Instance.Version;
                instance.UpdatedOn = currentTime;

                _context.MarkAsModified(instance,
                    i => i.Name,
                    i => i.NameLowercase,
                    i => i.Slug,
                    i => i.DynamicId,
                    i => i.MachineName,
                    i => i.Environment,
                    i => i.ReloadStrategies,
                    i => i.ServiceType,
                    i => i.Version,
                    i => i.UpdatedOn);
            }

            var configuration = await _context.Configurations
                .AsNoTracking()
                .Where(c => c.AppId == appId && c.IdentifierId == identifierId)
                .Select(c => new ConfigurationSqlModel
                {
                    AllowAnonymousAccess = c.AllowAnonymousAccess,
                    StoreInSeparateFile = c.StoreInSeparateFile,
                    IgnoreOnFileChange = c.IgnoreOnFileChange,
                    RegistrationMode = c.RegistrationMode,
                    Consumer = c.Consumer,
                    Provider = c.Provider
                }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (configuration == null)
            {
                configuration = new ConfigurationSqlModel
                {
                    AllowAnonymousAccess = input.Configuration.AllowAnonymousAccess,
                    StoreInSeparateFile = input.Configuration.StoreInSeparateFile,
                    IgnoreOnFileChange = input.Configuration.IgnoreOnFileChange,
                    RegistrationMode = input.Configuration.RegistrationMode,
                    Consumer = input.Configuration.Consumer,
                    Provider = input.Configuration.Provider,
                    IdentifierId = identifierId,
                    CreatedOn = currentTime,
                    CreatedById = input.UserId
                };

                app.Configurations.Add(configuration);
            }

            var computedIdentifierToSetting = await _context.Settings
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.SettingClass)
                .Where(a => a.AppId == appId && a.IdentifierId == identifierId)
                .Select(a => new SettingSqlModel
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
                    SettingClass = new SettingClassSqlModel
                    {
                        Id = a.SettingClass.Id,
                        RowVersion = a.SettingClass.RowVersion
                    }
                }).ToDictionaryAsync(a => a.ComputedIdentifier, cancellationToken);

            using (var internalContext = OpenSettingsInternalDbContext.GetInstance(_openSettingsConfiguration.Provider, _openSettingsConfiguration.LoggerFactory))
            {
                var settings = await HandleSettingsAsync(internalContext, input, classNameToCount, computedIdentifierToSetting, app.Settings, identifierId, currentTime, cancellationToken);

                await Task.WhenAll(internalContext.SaveChangesAsync(cancellationToken), _context.SaveChangesAsync(cancellationToken));

                return HttpStatusCode.OK.ToSuccessJsonResponseOf(new SyncAppDataResponse
                {
                    Settings = settings,
                    ProviderInfo = _providerInfo,
                    Configuration = new SyncAppDataResponseConfiguration
                    {
                        AllowAnonymousAccess = configuration.AllowAnonymousAccess,
                        StoreInSeparateFile = configuration.StoreInSeparateFile,
                        IgnoreOnFileChange = configuration.IgnoreOnFileChange,
                        RegistrationMode = configuration.RegistrationMode,
                        Consumer = configuration.Consumer,
                        Provider = configuration.Provider
                    }
                });
            }
        }

        private Task<SyncAppDataResponseSetting[]> HandleSettingsAsync(
            OpenSettingsInternalDbContext internalContext,
            SyncAppDataInput input,
            Dictionary<string, int> classNameToCount,
            Dictionary<Guid, SettingSqlModel> computedIdentifierToSetting,
            ICollection<SettingSqlModel> settings,
            int identifierId,
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

        private async Task<SyncAppDataResponseSetting> HandleExistingSettingAsync(OpenSettingsInternalDbContext internalContext, SettingSqlModel existingSetting, SyncAppDataInputSetting inputSetting, Guid? userId, DateTime currentTime, bool isUniqueClassName, CancellationToken cancellationToken)
        {
            internalContext.Settings.Attach(existingSetting);

            var decompressedData = await _compressionFactory.DecompressToUtf8StringAsync(existingSetting.Data, existingSetting.CompressionType, cancellationToken);

            var jsonMergeResult = JsonHelper.Merge(inputSetting.Data, decompressedData);

            var rowVersion = currentTime.ToRowVersion();

            string data;

            if (!jsonMergeResult.IsFaulted)
            {
                data = JsonSerializer.Serialize(jsonMergeResult.Data, Constants.UnsafeRelaxedJsonSerializerOptions);

                if (decompressedData != data)
                {
                    if (!existingSetting.DataRestored)
                    {
                        existingSetting.SettingHistories.Add(new SettingHistorySqlModel
                        {
                            Data = existingSetting.Data,
                            Version = existingSetting.Version,
                            Slug = existingSetting.Version.ToSlug(),
                            CreatedOn = currentTime,
                            CreatedById = userId
                        });
                    }

                    existingSetting.CompressionType = _openSettingsConfiguration.Provider.CompressionType;
                    existingSetting.CompressionLevel = _openSettingsConfiguration.Provider.CompressionLevel;
                    existingSetting.Data = await _compressionFactory.CompressAsync(_openSettingsConfiguration.Provider.CompressionType, data, _openSettingsConfiguration.Provider.CompressionLevel, cancellationToken);
                    existingSetting.Version = Helper.CalculateVersion(currentTime, existingSetting.CreatedOn);
                    existingSetting.DataRestored = false;
                    existingSetting.UpdatedOn = currentTime;
                    existingSetting.UpdatedById = userId;
                    existingSetting.RowVersion = rowVersion;
                }
            }
            else
            {
                data = decompressedData;
            }

            if (existingSetting.StoreInSeparateFile && existingSetting.IgnoreOnFileChange == true && !isUniqueClassName)
            {
                existingSetting.IgnoreOnFileChange = false;
            }

            existingSetting.SettingClass.Identifier = inputSetting.SettingClass.Identifier;
            existingSetting.SettingClass.Name = inputSetting.SettingClass.Name;
            existingSetting.SettingClass.FullName = inputSetting.SettingClass.FullName;
            existingSetting.SettingClass.Namespace = inputSetting.SettingClass.Namespace;
            existingSetting.SettingClass.Properties = inputSetting.SettingClass.Properties;
            existingSetting.SettingClass.UpdatedOn = currentTime;
            existingSetting.SettingClass.UpdatedById = userId;
            existingSetting.SettingClass.RowVersion = rowVersion;

            return new SyncAppDataResponseSetting
            {
                ComputedIdentifier = existingSetting.ComputedIdentifier,
                Data = data,
                StoreInSeparateFile = existingSetting.StoreInSeparateFile,
                IgnoreOnFileChange = existingSetting.IgnoreOnFileChange,
                RegistrationMode = existingSetting.RegistrationMode
            };
        }

        private async Task<SyncAppDataResponseSetting> HandleNewSettingAsync(ICollection<SettingSqlModel> settings, SyncAppDataInputSetting inputSetting, int identifierId, Guid? userId, DateTime currentTime, bool isUniqueClassName, CancellationToken cancellationToken)
        {
            var newSetting = new SettingSqlModel
            {
                CompressionType = _openSettingsConfiguration.Provider.CompressionType,
                CompressionLevel = _openSettingsConfiguration.Provider.CompressionLevel,
                Data = await _compressionFactory.CompressAsync(_openSettingsConfiguration.Provider.CompressionType, inputSetting.Data, _openSettingsConfiguration.Provider.CompressionLevel, cancellationToken),
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
                SettingClass = new SettingClassSqlModel
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
                Group = a.GroupId.HasValue
                    ? new GetAppResponseGroup
                    {
                        Id = $"{a.Group.Id}",
                        Name = a.Group.Name,
                        SortOrder = a.Group.SortOrder
                    }
                    : GetAppResponseGroup.UngroupedApps,
                Tags = a.AppTagMappings.OrderBy(t => t.Tag.SortOrder).Select(t => new GetAppResponseTag
                {
                    Id = $"{t.Tag.Id}",
                    Name = t.Tag.Name,
                    SortOrder = t.Tag.SortOrder
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
                Group = a.GroupId.HasValue
                    ? new GetGroupedAppsResponseAppGroup
                    {
                        Id = $"{a.Group.Id}",
                        Name = a.Group.Name,
                        SortOrder = a.Group.SortOrder
                    }
                    : GetGroupedAppsResponseAppGroup.UngroupedApps,
                Tags = a.AppTagMappings.OrderBy(t => t.Tag.SortOrder).Select(t => new GetGroupedAppsResponseAppTag
                {
                    Id = $"{t.Tag.Id}",
                    Name = t.Tag.Name,
                    SortOrder = t.Tag.SortOrder
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