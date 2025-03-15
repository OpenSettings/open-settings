using Microsoft.EntityFrameworkCore;
using Ogu.Compressions.Abstractions;
using Ogu.Response.Json;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Extensions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.MemoryCache;
using OpenSettings.Services.Sql.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql
{
    internal sealed class SettingHistoriesSqlService : ISettingHistoriesSqlService
    {
        private readonly IDataChangeService _dataChangeService;
        private readonly ICompressionFactory _compressionFactory;
        private readonly OpenSettingsDbContext _context;
        private readonly OpenSettingsMemoryCache _openSettingsMemoryCache;

        public SettingHistoriesSqlService(
            IDataChangeService dataChangeService,
            ICompressionFactory compressionFactory,
            OpenSettingsDbContext context,
            OpenSettingsMemoryCache openSettingsMemoryCache)
        {
            _dataChangeService = dataChangeService;
            _compressionFactory = compressionFactory;
            _context = context;
            _openSettingsMemoryCache = openSettingsMemoryCache;
        }

        public async Task<IJsonResponse> GetSettingHistoryDataAsync(GetSettingHistoryDataInput input, CancellationToken cancellationToken = default)
        {
            var historyIdRule = JsonValidationRules.GreaterThanRule(nameof(input.HistoryId), input.HistoryId, 0);

            if (historyIdRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(historyIdRule.Failure);
            }

            var historyId = historyIdRule.GetStoredValue<int>();

            var entity = await _context.SettingHistories
                .AsNoTracking()
                .Where(s => s.Id == historyId)
                .OrderBy(s => s.Id)
                .Select(s => new
                {
                    s.CompressionType,
                    s.Data,
                    s.RowVersion
                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.HistoryNotFound)
                : HttpStatusCode.OK.ToSuccessJsonResponse(new GetSettingHistoryDataResponse
                {
                    Data = await _compressionFactory.DecompressToUtf8StringAsync(entity.Data, entity.CompressionType, cancellationToken),
                    RowVersion = entity.RowVersion
                });
        }

        public async Task<IJsonResponse> GetSettingHistoryByIdAsync(GetSettingHistoryInput input, CancellationToken cancellationToken = default)
        {
            var historyIdRule = JsonValidationRules.GreaterThanRule("HistoryId", input.HistoryIdOrSlug, 0);

            if (historyIdRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(historyIdRule.Failure);
            }

            var historyId = historyIdRule.GetStoredValue<int>();

            return await GetSettingHistoryByIdOrSlugAsync(s => s.Id == historyId, cancellationToken);
        }

        public Task<IJsonResponse> GetSettingHistoryBySlugAsync(GetSettingHistoryInput input, CancellationToken cancellationToken = default)
        {
            input.HistoryIdOrSlug = input.HistoryIdOrSlug?.ToSlug();

            return GetSettingHistoryByIdOrSlugAsync(s => s.Slug == input.HistoryIdOrSlug, cancellationToken);
        }

        public async Task<IJsonResponse> GetSettingHistoriesAsync(GetSettingHistoriesInput input, CancellationToken cancellationToken = default)
        {
            var settingIdRule = JsonValidationRules.GreaterThanRule(nameof(input.SettingId), input.SettingId, 0);

            if (settingIdRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(settingIdRule.Failure);
            }

            var settingId = settingIdRule.GetStoredValue<int>();

            var isDataExcluded = input.Excludes.Contains("data");

            var entities = await _context.SettingHistories
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(s => s.Setting)
                .Where(s => s.SettingId == settingId)
                .OrderByDescending(a => a.CreatedOn)
                .Select(s => new
                {
                    s.Id,
                    Data = isDataExcluded ? null : s.Data,
                    s.CompressionType,
                    s.CompressionLevel,
                    s.Version,
                    s.Slug,
                    s.SettingId,
                    s.CreatedById,
                    s.RestoredById,
                    s.RowVersion,
                    s.CreatedOn,
                    s.UpdatedOn
                }).ToArrayAsync(cancellationToken);

            var settingHistoriesResponse = await Task.WhenAll(entities.Select(async e => new GetSettingHistoriesResponse
            {
                Id = $"{e.Id}",
                Data = e.Data == null
                    ? null
                    : await _compressionFactory.DecompressToUtf8StringAsync(e.Data, e.CompressionType, cancellationToken),
                Version = e.Version,
                Slug = e.Slug,
                CreatedById = e.CreatedById,
                RestoredById = e.RestoredById,
                RowVersion = e.RowVersion,
                CreatedOn = e.CreatedOn,
                UpdatedOn = e.UpdatedOn
            }));

            return HttpStatusCode.OK.ToSuccessJsonResponse(settingHistoriesResponse);
        }

        public async Task<IJsonResponse<RestoreSettingHistoryResponse>> RestoreSettingHistoryAsync(RestoreSettingHistoryInput input, CancellationToken cancellationToken)
        {
            var historyIdRule = JsonValidationRules.GreaterThanRule(nameof(input.HistoryId), input.HistoryId, 0);

            if (historyIdRule.IsFailed())
            {
                return historyIdRule.Failure.ToJsonResponse<RestoreSettingHistoryResponse>();
            }

            var historyId = historyIdRule.GetStoredValue<int>();

            var entity = await _context.SettingHistories
                .AsNoTracking()
                .Include(a => a.Setting).ThenInclude(a => a.App)
                .Include(a => a.Setting).ThenInclude(a => a.Identifier)
                .Where(a => a.Id == historyId)
                .OrderBy(a => a.Id)
                .Select(a => new SettingHistorySqlModel
                {
                    Id = historyId,
                    Data = a.Data,
                    Version = a.Version,
                    RowVersion = a.RowVersion,
                    Setting = new SettingSqlModel
                    {
                        Id = a.Setting.Id,
                        CompressionType = a.Setting.CompressionType,
                        CompressionLevel = a.Setting.CompressionLevel,
                        Data = a.Setting.Data,
                        ComputedIdentifier = a.Setting.ComputedIdentifier,
                        Identifier = new IdentifierSqlModel
                        {
                            Name = a.Setting.Identifier.Name,
                        },
                        Version = a.Setting.Version,
                        DataRestored = a.Setting.DataRestored,
                        RowVersion = a.Setting.RowVersion,
                        App = new AppSqlModel
                        {
                            ClientId = a.Setting.App.ClientId
                        }
                    }
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse<RestoreSettingHistoryResponse, Errors>(Errors.HistoryNotFound);
            }

            if (entity.Version == entity.Setting.Version)
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse<RestoreSettingHistoryResponse, Errors>(Errors.HistoryAlreadyRestored);
            }

            if (!input.HistoryRowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict<RestoreSettingHistoryResponse>($"{entity.Id}", entity.RowVersion, input.HistoryRowVersion, false);
            }

            if (!input.SettingRowVersion.SequenceEqual(entity.Setting.RowVersion))
            {
                return FailureResponses.Conflict<RestoreSettingHistoryResponse>($"{entity.Setting.Id}", entity.Setting.RowVersion, input.SettingRowVersion, false);
            }

            var currentTime = DateTime.UtcNow;
            var rowVersion = currentTime.ToRowVersion();
            var previousVersion = entity.Setting.Version;

            var computedIdentifier = entity.Setting.ComputedIdentifier;

            var setting = new SettingSqlModel { Id = entity.Setting.Id, RowVersion = entity.Setting.RowVersion };

            _context.Settings.Attach(setting);

            var clientId = entity.Setting.App.ClientId;
            var identifierName = entity.Setting.Identifier.Name;

            if (entity.Setting.DataRestored)
            {
                entity.Setting = null;

                _context.SettingHistories.Attach(entity);

                entity.RestoredById = input.UserId;
                entity.UpdatedOn = currentTime;
                entity.RowVersion = rowVersion;
            }
            else
            {
                var history = new SettingHistorySqlModel
                {
                    CompressionType = entity.Setting.CompressionType,
                    CompressionLevel = entity.Setting.CompressionLevel,
                    Data = entity.Setting.Data,
                    Version = previousVersion,
                    Slug = previousVersion.ToSlug(),
                    CreatedOn = currentTime,
                    RestoredById = input.UserId
                };

                setting.SettingHistories.Add(history);
            }

            setting.CompressionType = entity.CompressionType;
            setting.CompressionLevel = entity.CompressionLevel;
            setting.Data = entity.Data;
            setting.Version = entity.Version;
            setting.UpdatedOn = currentTime;
            setting.DataRestored = true;
            setting.UpdatedById = input.UserId;
            setting.RowVersion = rowVersion;

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                await _dataChangeService.NotifyChangeAsync(clientId, identifierName, computedIdentifier, CancellationToken.None);

                return HttpStatusCode.OK.ToSuccessJsonResponseOf(new RestoreSettingHistoryResponse
                {
                    ClientId = clientId,
                    Setting = new RestoreSettingHistoryResponseSetting
                    {
                        IdentifierName = identifierName,
                        ComputedIdentifier = computedIdentifier,
                        CurrentVersion = setting.Version,
                        PreviousVersion = previousVersion,
                        RowVersion = setting.RowVersion
                    },
                    HistoryRowVersion = entity.RowVersion
                });
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return await ex.ToJsonResponseAsync<RestoreSettingHistoryResponse>(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                return HttpStatusCode.InternalServerError.ToFailureJsonResponse<RestoreSettingHistoryResponse>("Exception", ex.HResult == -2146233088 ? "User not found in db. Re-login might be needed to resolve this issue." : "Db update exception occurred.");
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError.ToFailureJsonResponse<RestoreSettingHistoryResponse>(ex);
            }
        }

        private async Task<IJsonResponse> GetSettingHistoryByIdOrSlugAsync(Expression<Func<SettingHistorySqlModel, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entity = await _context.SettingHistories
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(s => s.Id)
                .Select(s => new
                {
                    s.Data,
                    s.CompressionType,
                    s.CompressionLevel,
                    s.Version,
                    s.Slug,
                    SettingId = $"{s.SettingId}",
                    s.CreatedById,
                    s.RestoredById,
                    s.RowVersion,
                    s.CreatedOn,
                    s.UpdatedOn
                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.HistoryNotFound)
                : HttpStatusCode.OK.ToSuccessJsonResponse(new GetSettingHistoryResponse
                {
                    Data = await _compressionFactory.DecompressToUtf8StringAsync(entity.Data, entity.CompressionType, cancellationToken),
                    Version = entity.Version,
                    Slug = entity.Slug,
                    SettingId = entity.SettingId,
                    CreatedById = entity.CreatedById,
                    RestoredById = entity.RestoredById,
                    RowVersion = entity.RowVersion,
                    CreatedOn = entity.CreatedOn,
                    UpdatedOn = entity.UpdatedOn
                });
        }
    }
}