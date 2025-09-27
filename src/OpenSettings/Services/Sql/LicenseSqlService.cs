using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Ogu.Response;
using Ogu.Response.Abstractions;
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
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using JsonWebTokenHandler = Microsoft.IdentityModel.JsonWebTokens.JsonWebTokenHandler;

namespace OpenSettings.Services.Sql
{
    internal sealed class LicenseSqlService : ILicenseSqlService
    {
        private const string LicenseFileName = "OpenSettings-License.key";

        private readonly JsonWebTokenHandler _jsonWebTokenHandler;
        private readonly string _licenseKeyFromProviderConfiguration;
        private readonly OpenSettingsDbContext _context;
        private readonly IOpenSettingsMemoryCache _openSettingsMemoryCache;
        private readonly ILogger _logger;

        public LicenseSqlService(IOpenSettingsMemoryCache openSettingsMemoryCache,  OpenSettingsConfiguration openSettingsConfiguration, OpenSettingsDbContext context)
        {
            _openSettingsMemoryCache = openSettingsMemoryCache;
            _logger = openSettingsConfiguration.LoggerFactory.CreateLogger<LicenseSqlService>();
            _jsonWebTokenHandler = new JsonWebTokenHandler();
            _licenseKeyFromProviderConfiguration = openSettingsConfiguration.Provider.LicenseKey;
            _context = context;
        }

        public async Task<IResponse> GetPaginatedLicensesAsync(GetPaginatedLicensesInput input, CancellationToken cancellationToken)
        {
            var query = _context.Licenses.AsNoTracking();

            var isSearchTermEmpty = string.IsNullOrWhiteSpace(input.PaginatedInput.SearchTerm);

            if (!isSearchTermEmpty)
            {
                query = SearchBy(query, input.PaginatedInput.SearchTerm, input.PaginatedInput.SearchBy, _context);
            }

            var itemCount = await query.CountAsync(cancellationToken);

            query = SortBy(query, isSearchTermEmpty, input.PaginatedInput.SortBy, input.PaginatedInput.SortDirection);

            var entities = await query
                .Select(c => new GetPaginatedLicensesResponseLicense(c))
                .ToPaginatedArrayAsync(input.PaginatedInput.PageIndex, input.PaginatedInput.PageSize, cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse(new GetPaginatedLicensesResponse(input.PaginatedInput, itemCount, entities));
        }

        public async Task<IResponse> SaveLicenseAsync(string licenseKey, CancellationToken cancellationToken)
        {
            var response = await SaveLicenseAsync(licenseKey, "input", cancellationToken);

            if (!response.Success)
            {
                return response;
            }

            var license = (License)response.Data;

            var previousLicenseReferenceId = LicenseProvider.Instance.License.ReferenceId;

            LicenseProvider.Instance.License = (int)license.Edition > (int)LicenseProvider.Instance.License.Edition
                ? license
                : license.Edition == LicenseProvider.Instance.License.Edition && (license.ExpiryDate == null ||
                    license.ExpiryDate > LicenseProvider.Instance.License.ExpiryDate)
                    ? license
                    : LicenseProvider.Instance.License;

            if (previousLicenseReferenceId != LicenseProvider.Instance.License.ReferenceId)
            {
                OpenSettingsDefaults.Caches.OpenSettingsSpaMiddlewareCacheEntryHtmlKey.Remove(_openSettingsMemoryCache);
            }

            return response;
        }

        public async Task<IResponse> DeleteLicenseAsync(DeleteLicenseInput input, CancellationToken cancellationToken)
        {
            var referenceIdRule = ValidationRules.NotEmptyRule(nameof(input.ReferenceId), input.ReferenceId);

            if (referenceIdRule.IsFailed())
            {
                return referenceIdRule.Failure.ToResponse();
            }

            var referenceIdLowercase = input.ReferenceId.ToLowerInvariant();

            var entity = await _context.Licenses.AsNoTracking()
                .Where(l => l.ReferenceIdLowercase == referenceIdLowercase).OrderBy(l => l.Id).Select(l => new { l.Id })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.LicenseNotFound);
            }

            _context.Licenses.Remove(new LicenseSqlModel { Id = entity.Id });

            await _context.SaveChangesAsync(cancellationToken);

            if (input.ReferenceId != LicenseProvider.Instance.License.ReferenceId)
            {
                return HttpStatusCode.OK.ToSuccessResponse();
            }

            LicenseProvider.Instance.License = await InitializeAsync(CancellationToken.None) ?? License.Community;

            OpenSettingsDefaults.Caches.OpenSettingsSpaMiddlewareCacheEntryHtmlKey.Remove(_openSettingsMemoryCache);

            return HttpStatusCode.OK.ToSuccessResponse();
        }

        public async Task<IResponse<License>> GetCurrentLicenseAsync(CancellationToken cancellationToken)
        {
            var license = LicenseProvider.Instance.License ?? (LicenseProvider.Instance.License = await InitializeAsync(cancellationToken));

            return HttpStatusCode.OK.ToSuccessResponseOf(license);
        }

        /// <summary>
        /// Saves the provided license key and its source.
        /// </summary>
        /// <param name="licenseKey">The license key to be saved.</param>
        /// <param name="licenseKeyObtainedFrom">The source from which the license key was obtained.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. If successful, it returns an <see cref="IResponse"/> with the license data.
        /// See data type: <see cref="License"/>.
        /// </returns>
        private async Task<IResponse> SaveLicenseAsync(string licenseKey, string licenseKeyObtainedFrom, CancellationToken cancellationToken)
        {
            var licenseKeyRule = ValidationRules.NotEmptyRule("LicenseKey", licenseKey);

            if (licenseKeyRule.IsFailed())
            {
                return licenseKeyRule.Failure.ToResponse();
            }

            var trimmedLicenseKey = licenseKey.Trim();

            var license = ValidateLicenseKey(trimmedLicenseKey);

            if (license == null)
            {
                _logger.LogError("Provided LicenseKey from '{licenseKeyObtainedFrom}' is invalid.", licenseKeyObtainedFrom);

                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.InvalidLicenseKey);
            }

            if (license.IsExpired)
            {
                _logger.LogError("Provided LicenseKey from {licenseKeyObtainedFrom} is expired.", licenseKeyObtainedFrom);

                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.LicenseExpired);
            }

            if (license.Edition == null)
            {
                _logger.LogError("Provided LicenseKey from {licenseKeyObtainedFrom} could not be recognized by this version.", licenseKeyObtainedFrom);

                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.UnrecognizedLicenseEdition);
            }

            var currentTime = DateTime.UtcNow;

            var referenceIdLowercase = license.ReferenceId.ToLowerInvariant();

            var licenseSqlModel = await _context.Licenses.AsNoTracking().Where(l => l.ReferenceIdLowercase == referenceIdLowercase).FirstOrDefaultAsync(cancellationToken);

            if (licenseSqlModel == null)
            {
                var issuedAt = license.IssuedAt ?? currentTime;
                var notBefore = license.NotBefore ?? issuedAt;

                _context.Licenses.Add(new LicenseSqlModel
                {
                    Id = Guid.NewGuid(),
                    ReferenceId = license.ReferenceId,
                    ReferenceIdLowercase = referenceIdLowercase,
                    Features = license.Features.ToArray(),
                    ExpiryDate = license.ExpiryDate,
                    IsExpired = license.IsExpired,
                    ExpiredOn = license.IsExpired ? currentTime : (DateTime?)null,
                    IsRevoked = false,
                    RevokedOn = null,
                    Key = trimmedLicenseKey,
                    Holder = license.Holder,
                    HolderLowercase = license.Holder.ToLowerInvariant(),
                    Edition = license.Edition.Value,
                    CreatedOn = currentTime,
                    IssuedAt = issuedAt,
                    NotBefore = notBefore,
                });

                await _context.SaveChangesAsync(cancellationToken);

                return HttpStatusCode.OK.ToSuccessResponse(license);
            }

            if (!licenseSqlModel.IsExpired)
            {
                return HttpStatusCode.Conflict.ToFailureResponse(Errors.LicenseAlreadyExists);
            }

            if (licenseSqlModel.IsRevoked)
            {
                _logger.LogError("Provided LicenseKey from {licenseKeyObtainedFrom} is revoked.", licenseKeyObtainedFrom);

                return HttpStatusCode.BadRequest.ToFailureResponse(Errors.LicenseRevoked);
            }

            var entry = _context.Attach(licenseSqlModel);

            licenseSqlModel.IsExpired = false;
            licenseSqlModel.ExpiredOn = null;
            licenseSqlModel.UpdatedOn = currentTime;

            entry.Property(l => l.IsExpired).IsModified = true;
            entry.Property(l => l.ExpiredOn).IsModified = true;
            entry.Property(l => l.UpdatedOn).IsModified = true;

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse(license);
        }

        private License ValidateLicenseKey(string licenseKey)
        {
            var rsaParameters = new RSAParameters
            {
                Modulus = Convert.FromBase64String("ozr5IfybZoQ4K96P/JKZYumGocHyA24vHsu0j39345nw4pRB0mz4omXRJTEWSx/EbLNJT8i6cGECZAL2+M9juytZiJTkvb9e/qOUHpy1yuh01YejwzUoClmvJdFidABXRSextuYB5u9Ogfm6UXtSkLFSGGe/XXM/jd7Ff+nO2EVnbX2FRKBBc4PlodKsxzvrnQP4gVL10fKDXv282vJh9ic1a8kQtbEMnkQpJQo9RkBKPIEhUqfuZe4fUkq5NuX1rUtuDrFRz70mhHGAMLS92MDgSF63crr3ugxnHr5pu0+NmPk8L6izM+oM+GQ5ATHTJOenBF6p+nhxevwJY80WyQ=="),
                Exponent = Convert.FromBase64String("AQAB")
            };

            var rsaSecurityKey = new RsaSecurityKey(rsaParameters)
            {
                KeyId = "opensettings/4b975f16e6ea49379fa41a9a4e1251ae"
            };

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = "https://opensettings.net",
                ValidAudience = "opensettings",
                IssuerSigningKey = rsaSecurityKey,
                ValidateLifetime = false // expired license key will still pass validation!
            };

            var tokenValidationResult = _jsonWebTokenHandler.ValidateToken(licenseKey, tokenValidationParameters);

            return tokenValidationResult.IsValid
                ? new License(new ClaimsPrincipal(tokenValidationResult.ClaimsIdentity))
                : null;
        }

        /// <summary>
        /// Initializes and retrieves a <see cref="License"/> object.
        /// This method never throws an exception but may return <c>null</c> based on the data.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The result is a <see cref="License"/> object, 
        /// or <c>null</c> if no valid data is found.
        /// </returns>
        private async Task<License> InitializeAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_licenseKeyFromProviderConfiguration))
                {
                    await SaveLicenseAsync(_licenseKeyFromProviderConfiguration, "provider configuration", cancellationToken);
                }

                var licenseKeyFromFile = GetLicenseKeyFromFile();

                if (!string.IsNullOrWhiteSpace(licenseKeyFromFile))
                {
                    await SaveLicenseAsync(licenseKeyFromFile, $"file '{LicenseFileName}'", cancellationToken);
                }

                var entities = await _context.Licenses.AsNoTracking().Where(l => !l.IsExpired).ToArrayAsync(cancellationToken);

                if (entities.Length == 0)
                {
                    return License.Community;
                }

                var licenseCombinations = entities.Select(l => new
                {
                    License = ValidateLicenseKey(l.Key),
                    LicenseSqlModel = l
                }).ToArray();

                var anyChanges = false;

                License license = null;

                var currentTime = DateTime.UtcNow;

                foreach (var combination in licenseCombinations)
                {
                    if (combination.License == null || combination.License.IsExpired || combination.LicenseSqlModel.IsRevoked)
                    {
                        var entry = _context.Attach(combination.LicenseSqlModel);

                        combination.LicenseSqlModel.IsExpired = true;
                        combination.LicenseSqlModel.IsRevoked = true;
                        combination.LicenseSqlModel.ExpiredOn = currentTime;
                        combination.LicenseSqlModel.RevokedOn = currentTime;
                        combination.LicenseSqlModel.UpdatedOn = currentTime;

                        entry.Property(l => l.IsExpired).IsModified = true;
                        entry.Property(l => l.IsRevoked).IsModified = true;
                        entry.Property(l => l.ExpiredOn).IsModified = true;
                        entry.Property(l => l.RevokedOn).IsModified = true;
                        entry.Property(l => l.UpdatedOn).IsModified = true;

                        anyChanges = true;

                        continue;
                    }

                    license = license == null
                        ? combination.License
                        : (int)combination.License.Edition.GetValueOrDefault() > (int)license.Edition.GetValueOrDefault()
                            ? combination.License
                            : combination.License.Edition == license.Edition &&
                              (combination.License.ExpiryDate == null || combination.License.ExpiryDate > license.ExpiryDate)
                                ? combination.License
                                : license;
                }

                if (anyChanges)
                {
                    await _context.SaveChangesAsync(cancellationToken);
                }

                if (license != null)
                {
                    return license;
                }

                license = License.Community;

                license.FailureReasons.Add(LicenseFailureReason.Invalid);

                return license;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred during the license initialization.");

                var license = License.Community;

                license.FailureReasons.Add(LicenseFailureReason.SqlException);

                return license;
            }
        }

        private static string GetLicenseKeyFromFile()
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, LicenseFileName);
            return File.Exists(filePath) ? File.ReadAllText(filePath).Trim() : null;
        }

        private static IQueryable<LicenseSqlModel> SearchBy(IQueryable<LicenseSqlModel> query, string searchTerm, string searchBy, OpenSettingsDbContext context)
        {
            var searchTermLowercase = searchTerm.Trim().ToLowerInvariant();

            if (string.IsNullOrWhiteSpace(searchBy))
            {
                query = query.SearchBy(new Expression<Func<LicenseSqlModel, string>>[]
                {
                    e => e.ReferenceIdLowercase
                }, searchTerm, context).OrderBy(e => e.ReferenceIdLowercase.IndexOf(searchTermLowercase));

                return query;
            }

            searchBy = searchBy.Trim().ToLowerInvariant();

            switch (searchBy)
            {
                case "referenceid":

                    return query.SearchBy(e => e.ReferenceIdLowercase, searchTermLowercase, context).OrderBy(e => e.ReferenceIdLowercase.IndexOf(searchTermLowercase));

                default:
                    return query;
            }
        }

        private static IQueryable<LicenseSqlModel> SortBy(IQueryable<LicenseSqlModel> query, bool isSearchTermEmpty, string sortBy, SortDirection sortDirection)
        {
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                return query;
            }

            sortBy = sortBy.Trim().ToLowerInvariant();

            switch (sortBy)
            {
                case "key":

                    if (sortDirection == SortDirection.Asc)
                    {
                        return isSearchTermEmpty
                            ? query.OrderBy(e => e.Key)
                            : ((IOrderedQueryable<LicenseSqlModel>)query).ThenBy(e => e.Key);
                    }

                    return isSearchTermEmpty
                        ? query.OrderByDescending(e => e.Key)
                        : ((IOrderedQueryable<LicenseSqlModel>)query).ThenByDescending(e => e.Key);

                default:
                    return query.OrderBy(e => e.Id);
            }
        }
    }
}