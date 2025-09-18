using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Extensions;
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
    internal sealed class InstanceSqlService : IInstanceSqlService
    {
        private readonly OpenSettingsDbContext _context;
        private readonly IPasswordHasher<AppSqlModel> _passwordHasher;

        public InstanceSqlService(OpenSettingsDbContext context, IPasswordHasher<AppSqlModel> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<IResponse> CreateInstanceAsync(CreateInstanceInput input, CancellationToken cancellationToken)
        {
            var trimmedInstanceName = input.InstanceName.Trim();
            var trimmedInstanceNameLowercase = trimmedInstanceName.ToLowerInvariant();
            var identifierNameLowercase = input.IdentifierName.Trim().ToLowerInvariant();

            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppInstances).ThenInclude(i => i.Identifier)
                .Include(a => a.AppIdentifierMappings).ThenInclude(m => m.Identifier)
                .Where(a => a.ClientId == input.ClientId)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    a.HashedClientSecret,
                    AppId = a.Id,
                    IdentifierMapping = a.AppIdentifierMappings
                        .Where(m => m.Identifier.NameLowercase == trimmedInstanceNameLowercase)
                        .Select(m => new
                        {
                            IdentifierId = m.Id
                        }).FirstOrDefault(),
                    IsInstanceExists = a.AppInstances.Any(i => i.NameLowercase == trimmedInstanceNameLowercase && i.Identifier.NameLowercase == identifierNameLowercase)
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.AppNotFound);
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(null, entity.HashedClientSecret, $"{input.ClientSecret}");

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                HttpStatusCode.Unauthorized.ToFailureResponse(Errors.InvalidCredentials);
            }

            if (entity.IsInstanceExists)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.InstanceAlreadyExists);
            }

            if (entity.IdentifierMapping == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.AppIdentifierMappingNotFound);
            }

            _context.AppInstances.Add(new AppInstanceSqlModel
            {
                Name = trimmedInstanceName,
                NameLowercase = trimmedInstanceNameLowercase,
                Slug = trimmedInstanceName.ToSlug(),
                DynamicId = input.DynamicId,
                Urls = input.Urls,
                Version = input.Version,
                PackVersion = input.PackVersion,
                IsActive = input.IsActive,
                RemoteIpAddress = input.RemoteIpAddress,
                MachineName = input.MachineName,
                Environment = input.Environment,
                ReloadStrategies = input.ReloadStrategies,
                ServiceType = input.ServiceType,
                DataAccessType = input.DataAccessType,
                AppId = entity.AppId,
                IdentifierId = entity.IdentifierMapping.IdentifierId,
                CreatedOn = DateTime.UtcNow
            });

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse();
        }

        public async Task<IResponse> UpdateInstanceAsync(UpdateInstanceInput input, CancellationToken cancellationToken)
        {
            var trimmedInstanceNameLowercase = input.InstanceName.Trim().ToLowerInvariant();
            var identifierNameLowercase = input.IdentifierName.Trim().ToLowerInvariant();

            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppInstances).ThenInclude(i => i.Identifier)
                .Where(a => a.ClientId == input.ClientId)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    a.HashedClientSecret,
                    Instance = a.AppInstances.Where(i => i.NameLowercase == trimmedInstanceNameLowercase && i.Identifier.NameLowercase == identifierNameLowercase)
                        .Select(i => new AppInstanceSqlModel
                        {
                            Id = i.Id
                        }).FirstOrDefault()
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.AppNotFound);
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(null, entity.HashedClientSecret, $"{input.ClientSecret}");

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                HttpStatusCode.Unauthorized.ToFailureResponse(Errors.InvalidCredentials);
            }

            if (entity.Instance == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.InstanceNotFound);
            }

            _context.AppInstances.Attach(entity.Instance);

            _context.MarkAsModified(entity.Instance,
                e => e.Urls,
                e => e.RemoteIpAddress,
                e => e.IsActive,
                e => e.UpdatedOn
                );

            var currentTime = DateTime.UtcNow;

            entity.Instance.Urls = input.Urls;
            entity.Instance.RemoteIpAddress = input.RemoteIpAddress;
            entity.Instance.IsActive = input.IsActive;
            entity.Instance.UpdatedOn = currentTime;

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse();
        }

        public async Task<IResponse> DeleteInstanceAsync(DeleteInstanceInput input, CancellationToken cancellationToken = default)
        {
            var instanceIdRule = ValidationRules.GreaterThanRule(nameof(input.InstanceId), input.InstanceId, 0);

            if (instanceIdRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureResponse(instanceIdRule.Failure);
            }

            var instanceId = instanceIdRule.GetStoredValue<int>();

            var entity = await _context.AppInstances.AsNoTracking().Where(i => i.Id == instanceId).OrderBy(i => i.Id)
                .Select(i => new AppInstanceSqlModel
                {
                    Id = instanceId
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.InstanceNotFound);
            }

            _context.AppInstances.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessResponse();
        }

        public async Task<IResponse> GetInstancesByAppIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var appIdRule = ValidationRules.GreaterThanRule("AppId", input.AppIdOrSlug, 0);

            if (appIdRule.IsFailed())
            {
                return appIdRule.Failure.ToResponse();
            }

            var appId = appIdRule.GetStoredValue<int>();

            return await GetInstancesByAppIdOrAppSlugAsync(a => a.Id == appId, input, cancellationToken);
        }

        public Task<IResponse> GetInstancesByAppSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            input.AppIdOrSlug = input.AppIdOrSlug?.ToSlug();

            return GetInstancesByAppIdOrAppSlugAsync(a => a.Slug == input.AppIdOrSlug, input, cancellationToken);
        }

        public async Task<IResponse> GetInstancesByAppIdAndIdentifierIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var appIdRule = ValidationRules.GreaterThanRule("AppId", input.AppIdOrSlug, 0);
            var identifierIdRule = ValidationRules.GreaterThanRule("IdentifierId", input.IdentifierIdOrSlug, 0);

            var failure = new ValidationRule[] { appIdRule, identifierIdRule }.ValidateFirstOrDefault();

            if (failure != null)
            {
                return failure.ToResponse();
            }

            var appId = appIdRule.GetStoredValue<int>();
            var identifierId = identifierIdRule.GetStoredValue<int>();

            var isIdentifierExists = await _context.Identifiers.AsNoTracking().AnyAsync(s => s.Id == identifierId, cancellationToken);

            return isIdentifierExists
                ? await GetInstancesByAppAndIdentifierAsync(a => a.Id == appId, identifierId, cancellationToken)
                : HttpStatusCode.NotFound.ToFailureResponse(Errors.IdentifierNotFound);
        }

        public async Task<IResponse> GetInstancesByAppSlugAndIdentifierSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            input.AppIdOrSlug = input.AppIdOrSlug?.ToSlug();
            input.IdentifierIdOrSlug = input.IdentifierIdOrSlug?.ToSlug();

            var identifier = await _context.Identifiers.AsNoTracking()
                .Where(s => s.Slug == input.IdentifierIdOrSlug).OrderBy(s => s.Id).Select(s => new
                {
                    s.Id
                }).FirstOrDefaultAsync(cancellationToken);

            if (identifier == null)
            {
                return HttpStatusCode.NotFound.ToFailureResponse(Errors.IdentifierNotFound);
            }

            return await GetInstancesByAppAndIdentifierAsync(a => a.Slug == input.AppIdOrSlug, identifier.Id, cancellationToken);
        }

        private async Task<IResponse> GetInstancesByAppAndIdentifierAsync(Expression<Func<AppSqlModel, bool>> predicate, int identifierId, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppInstances)
                .Where(predicate)
                .Select(a => new
                {
                    Instances = a.AppInstances.Where(i => i.IdentifierId == identifierId).Select(i =>
                        new GetInstancesResponseInstance
                        {
                            Id = $"{i.Id}",
                            DynamicId = i.DynamicId,
                            IdentifierId = $"{identifierId}",
                            Name = i.Name,
                            Urls = i.Urls,
                            IsActive = i.IsActive,
                            MachineName = i.MachineName,
                            ReloadStrategies = i.ReloadStrategies,
                            ServiceType = i.ServiceType,
                            Version = i.Version,
                            PackVersion = i.PackVersion,
                            CreatedOn = i.CreatedOn,
                            UpdatedOn = i.UpdatedOn
                        }).ToArray()
                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureResponse(Errors.AppNotFound)
                : HttpStatusCode.OK.ToSuccessResponse(entity.Instances);
        }


        private async Task<IResponse> GetInstancesByAppIdOrAppSlugAsync(Expression<Func<AppSqlModel, bool>> predicate, GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var isValidIdentifierId = int.TryParse(input.IdentifierIdOrSlug, out var identifierId);

            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.AppInstances)
                .Where(predicate)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    Instances = isValidIdentifierId
                        ? a.AppInstances.Where(i => i.IdentifierId == identifierId).Select(i =>
                            MapToGetInstancesResponseInstance(i, input.IdentifierIdOrSlug)).ToArray()
                        : a.AppInstances.Select(i => MapToGetInstancesResponseInstance(i, input.IdentifierIdOrSlug))
                            .ToArray()

                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureResponse(Errors.AppNotFound)
                : HttpStatusCode.OK.ToSuccessResponse(entity.Instances);
        }

        private static GetInstancesResponseInstance MapToGetInstancesResponseInstance(AppInstanceSqlModel appInstance, string identifierId)
        {
            return new GetInstancesResponseInstance
            {
                Id = $"{appInstance.Id}",
                DynamicId = appInstance.DynamicId,
                IdentifierId = identifierId,
                Name = appInstance.Name,
                Urls = appInstance.Urls,
                IsActive = appInstance.IsActive,
                MachineName = appInstance.MachineName,
                ReloadStrategies = appInstance.ReloadStrategies,
                ServiceType = appInstance.ServiceType,
                Version = appInstance.Version,
                PackVersion = appInstance.PackVersion,
                CreatedOn = appInstance.CreatedOn,
                UpdatedOn = appInstance.UpdatedOn
            };
        }
    }
}