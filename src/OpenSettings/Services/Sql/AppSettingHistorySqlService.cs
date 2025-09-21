using Microsoft.EntityFrameworkCore;
using Ogu.Compressions.Abstractions;
using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Extensions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Sql.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql
{
    internal sealed class AppSettingHistorySqlService : IAppSettingHistorySqlService
    {
        private readonly IDataChangeService _dataChangeService;
        private readonly IDataValidationService _dataValidationService;
        private readonly ICompressionProvider _compressionProvider;
        private readonly OpenSettingsDbContext _context;

        public AppSettingHistorySqlService(
            IDataChangeService dataChangeService,
            IDataValidationService dataValidationService,
            ICompressionProvider compressionProvider,
            OpenSettingsDbContext context)
        {
            _dataChangeService = dataChangeService;
            _dataValidationService = dataValidationService;
            _compressionProvider = compressionProvider;
            _context = context;
        }

        public async Task<IResponse> GetAppSettingHistoryDataAsync(GetAppSettingHistoryDataInput input, CancellationToken cancellationToken = default)
        {
            var entity = await _context.AppSettingHistories
                .AsNoTracking()
                .Where(s => s.Id == input.AppSettingHistoryId)
                .OrderBy(s => s.Id)
                .Select(s => new
                {
                    s.CompressionType,
                    s.Data,
                    s.RowVersion
                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureResponse(Errors.HistoryNotFound)
                : HttpStatusCode.OK.ToSuccessResponse(new GetSettingHistoryDataResponse
                {
                    Data = await _compressionProvider.DecompressToUtf8StringAsync(entity.Data, entity.CompressionType, cancellationToken),
                    RowVersion = entity.RowVersion
                });
        }

        public async Task<IResponse> GetAppSettingHistoryByIdAsync(GetAppSettingHistoryInput input, CancellationToken cancellationToken = default)
        {
            var historyIdRule = ValidationRules.NotEmptyRule("HistoryId", input.AppHistoryIdOrSlug);

            if (historyIdRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(historyIdRule.Failure);
            }

            return await GetSettingHistoryByIdOrSlugAsync(s => s.Id == Guid.Parse(input.AppHistoryIdOrSlug), cancellationToken);
        }

        public Task<IResponse> GetAppSettingHistoryBySlugAsync(GetAppSettingHistoryInput input, CancellationToken cancellationToken = default)
        {
            input.AppHistoryIdOrSlug = input.AppHistoryIdOrSlug?.ToSlug();

            return GetSettingHistoryByIdOrSlugAsync(s => s.Slug == input.AppHistoryIdOrSlug, cancellationToken);
        }

        public async Task<IResponse> GetAppSettingHistoriesAsync(GetAppSettingHistoriesInput input, CancellationToken cancellationToken = default)
        {
            var isDataExcluded = input.Excludes.Contains("data");

            var entities = await _context.AppSettingHistories
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(s => s.AppSetting)
                .Where(s => s.AppSettingId == input.AppSettingId)
                .OrderByDescending(a => a.CreatedOn)
                .Select(s => new
                {
                    s.Id,
                    Data = isDataExcluded ? null : s.Data,
                    s.CompressionType,
                    s.CompressionLevel,
                    s.Version,
                    s.Slug,
                    SettingId = s.AppSettingId,
                    s.CreatedById,
                    s.RestoredById,
                    s.RowVersion,
                    s.CreatedOn,
                    s.RestoredOn
                }).ToArrayAsync(cancellationToken);

            var settingHistoriesResponse = await Task.WhenAll(entities.Select(async e => new GetSettingHistoriesResponse
            {
                Id = $"{e.Id}",
                Data = e.Data == null
                    ? null
                    : await _compressionProvider.DecompressToUtf8StringAsync(e.Data, e.CompressionType, cancellationToken),
                Version = e.Version,
                Slug = e.Slug,
                CreatedById = e.CreatedById,
                RestoredById = e.RestoredById,
                RowVersion = e.RowVersion,
                CreatedOn = e.CreatedOn,
                RestoredOn = e.RestoredOn
            }));

            return HttpStatusCode.OK.ToSuccessResponse(settingHistoriesResponse);
        }

        public async Task<IResponse<RestoreSettingHistoryResponse>> RestoreAppSettingHistoryAsync(RestoreAppSettingHistoryInput input, CancellationToken cancellationToken)
        {
            var entity = await _context.AppSettingHistories
                .AsNoTracking()
                .Include(a => a.AppSetting).ThenInclude(a => a.App)
                .Include(a => a.AppSetting).ThenInclude(a => a.Identifier)
                .Where(a => a.Id == input.AppSettingHistoryId)
                .OrderBy(a => a.Id)
                .Select(a => new AppSettingHistorySqlModel
                {
                    Id = input.AppSettingHistoryId,
                    Data = a.Data,
                    Version = a.Version,
                    RowVersion = a.RowVersion,
                    AppSetting = new AppSettingSqlModel
                    {
                        Id = a.AppSetting.Id,
                        CompressionType = a.AppSetting.CompressionType,
                        CompressionLevel = a.AppSetting.CompressionLevel,
                        Data = a.AppSetting.Data,
                        ComputedIdentifier = a.AppSetting.ComputedIdentifier,
                        DataValidationDisabled = a.AppSetting.DataValidationDisabled,
                        Identifier = new IdentifierSqlModel
                        {
                            Name = a.AppSetting.Identifier.Name,
                        },
                        Version = a.AppSetting.Version,
                        DataRestored = a.AppSetting.DataRestored,
                        RowVersion = a.AppSetting.RowVersion,
                        App = new AppSqlModel
                        {
                            ClientId = a.AppSetting.App.ClientId
                        },
                        AppSettingClass = new AppSettingClassSqlModel
                        {
                            Properties = a.AppSetting.AppSettingClass.Properties
                        }
                    }
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse<RestoreSettingHistoryResponse, Errors>(Errors.HistoryNotFound);
            }

            if (entity.Version == entity.AppSetting.Version)
            {
                return HttpStatusCode.BadRequest.ToFailureResponse<RestoreSettingHistoryResponse, Errors>(Errors.HistoryAlreadyRestored);
            }

            if (!input.HistoryRowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict<RestoreSettingHistoryResponse>($"{entity.Id}", entity.RowVersion, input.HistoryRowVersion, false);
            }

            if (!input.SettingRowVersion.SequenceEqual(entity.AppSetting.RowVersion))
            {
                return FailureResponses.Conflict<RestoreSettingHistoryResponse>($"{entity.AppSetting.Id}", entity.AppSetting.RowVersion, input.SettingRowVersion, false);
            }

            var decompressedData = await _compressionProvider.DecompressToUtf8StringAsync(entity.Data, entity.CompressionType, cancellationToken);

            if (!entity.AppSetting.DataValidationDisabled && !_dataValidationService.IsDataMappingValid(decompressedData, entity.AppSetting.AppSettingClass.Properties))
            {
                return HttpStatusCode.BadRequest.ToFailureResponse<RestoreSettingHistoryResponse, Errors>(Errors.InvalidSettingData);
            }

            var currentTime = DateTime.UtcNow;
            var rowVersion = currentTime.ToRowVersion();
            var previousVersion = entity.AppSetting.Version;

            var computedIdentifier = entity.AppSetting.ComputedIdentifier;

            var setting = new AppSettingSqlModel { Id = entity.AppSetting.Id, RowVersion = entity.AppSetting.RowVersion };

            _context.AppSettings.Attach(setting);

            var clientId = entity.AppSetting.App.ClientId;
            var identifierName = entity.AppSetting.Identifier.Name;

            if (entity.AppSetting.DataRestored)
            {
                entity.AppSetting = null;

                _context.AppSettingHistories.Attach(entity);

                entity.RestoredById = input.UserId;
                entity.RestoredOn = currentTime;
                entity.RowVersion = rowVersion;
            }
            else
            {
                var history = new AppSettingHistorySqlModel
                {
                    CompressionType = entity.AppSetting.CompressionType,
                    CompressionLevel = entity.AppSetting.CompressionLevel,
                    Data = entity.AppSetting.Data,
                    Version = previousVersion,
                    Slug = previousVersion.ToSlug(),
                    CreatedOn = currentTime,
                    RestoredById = input.UserId
                };

                setting.AppSettingHistories.Add(history);
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

                return HttpStatusCode.OK.ToSuccessResponseOf(new RestoreSettingHistoryResponse
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
                return await ex.ToResponseAsync<RestoreSettingHistoryResponse>(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                return HttpStatusCode.InternalServerError.ToFailureResponse<RestoreSettingHistoryResponse>("Exception", ex.HResult == -2146233088 ? "User not found in db. Re-login might be needed to resolve this issue." : "Db update exception occurred.");
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError.ToFailureResponse<RestoreSettingHistoryResponse>(ex);
            }
        }

        private async Task<IResponse> GetSettingHistoryByIdOrSlugAsync(Expression<Func<AppSettingHistorySqlModel, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entity = await _context.AppSettingHistories
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
                    SettingId = $"{s.AppSettingId}",
                    s.CreatedById,
                    s.RestoredById,
                    s.RowVersion,
                    s.CreatedOn,
                    s.RestoredOn
                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureResponse(Errors.HistoryNotFound)
                : HttpStatusCode.OK.ToSuccessResponse(new GetSettingHistoryResponse
                {
                    Data = await _compressionProvider.DecompressToUtf8StringAsync(entity.Data, entity.CompressionType, cancellationToken),
                    Version = entity.Version,
                    Slug = entity.Slug,
                    AppSettingId = entity.SettingId,
                    CreatedById = entity.CreatedById,
                    RestoredById = entity.RestoredById,
                    RowVersion = entity.RowVersion,
                    CreatedOn = entity.CreatedOn,
                    RestoredOn = entity.RestoredOn
                });
        }
    }
}