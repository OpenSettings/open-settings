using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ogu.Response.Abstractions;
using Ogu.Response.Json;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
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
    internal sealed class InstancesSqlService : IInstancesSqlService
    {
        private readonly OpenSettingsDbContext _context;
        private readonly IPasswordHasher<AppSqlModel> _passwordHasher;

        public InstancesSqlService(OpenSettingsDbContext context, IPasswordHasher<AppSqlModel> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<IJsonResponse> CreateInstanceAsync(CreateInstanceInput input, CancellationToken cancellationToken)
        {
            var trimmedInstanceName = input.InstanceName.Trim();
            var trimmedInstanceNameLowercase = trimmedInstanceName.ToLowerInvariant();
            var identifierNameLowercase = input.IdentifierName.Trim().ToLowerInvariant();

            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.Instances).ThenInclude(i => i.Identifier)
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
                    IsInstanceExists = a.Instances.Any(i => i.NameLowercase == trimmedInstanceNameLowercase && i.Identifier.NameLowercase == identifierNameLowercase)
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.AppNotFound);
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(null, entity.HashedClientSecret, $"{input.ClientSecret}");

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                HttpStatusCode.Unauthorized.ToFailureJsonResponse(Errors.InvalidCredentials);
            }

            if (entity.IsInstanceExists)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.InstanceAlreadyExists);
            }

            if (entity.IdentifierMapping == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.AppIdentifierMappingNotFound);
            }

            _context.Instances.Add(new InstanceSqlModel
            {
                Name = trimmedInstanceName,
                NameLowercase = trimmedInstanceNameLowercase,
                Slug = trimmedInstanceName.ToSlug(),
                DynamicId = input.DynamicId,
                Urls = input.Urls,
                Version = input.Version,
                IsActive = input.IsActive,
                IpAddress = input.IpAddress,
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

            return HttpStatusCode.OK.ToSuccessJsonResponse();
        }

        public async Task<IJsonResponse> UpdateInstanceAsync(UpdateInstanceInput input, CancellationToken cancellationToken)
        {
            var trimmedInstanceNameLowercase = input.InstanceName.Trim().ToLowerInvariant();
            var identifierNameLowercase = input.IdentifierName.Trim().ToLowerInvariant();

            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.Instances).ThenInclude(i => i.Identifier)
                .Where(a => a.ClientId == input.ClientId)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    a.HashedClientSecret,
                    Instance = a.Instances.Where(i => i.NameLowercase == trimmedInstanceNameLowercase && i.Identifier.NameLowercase == identifierNameLowercase)
                        .Select(i => new InstanceSqlModel
                        {
                            Id = i.Id
                        }).FirstOrDefault()
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.AppNotFound);
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(null, entity.HashedClientSecret, $"{input.ClientSecret}");

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                HttpStatusCode.Unauthorized.ToFailureJsonResponse(Errors.InvalidCredentials);
            }

            if (entity.Instance == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.InstanceNotFound);
            }

            _context.Instances.Attach(entity.Instance);

            _context.MarkAsModified(entity.Instance,
                e => e.Urls,
                e => e.IpAddress,
                e => e.IsActive,
                e => e.UpdatedOn
                );

            var currentTime = DateTime.UtcNow;

            entity.Instance.Urls = input.Urls;
            entity.Instance.IpAddress = input.IpAddress;
            entity.Instance.IsActive = input.IsActive;
            entity.Instance.UpdatedOn = currentTime;

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse();
        }

        public async Task<IJsonResponse> DeleteInstanceAsync(DeleteInstanceInput input, CancellationToken cancellationToken = default)
        {
            var instanceIdRule = JsonValidationRules.GreaterThanRule(nameof(input.InstanceId), input.InstanceId, 0);

            if (instanceIdRule.IsFailed())
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(instanceIdRule.Failure);
            }

            var instanceId = instanceIdRule.GetStoredValue<int>();

            var entity = await _context.Instances.AsNoTracking().Where(i => i.Id == instanceId).OrderBy(i => i.Id)
                .Select(i => new InstanceSqlModel
                {
                    Id = instanceId
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.InstanceNotFound);
            }

            _context.Instances.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse();
        }

        public async Task<IJsonResponse> GetInstancesByAppIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var appIdRule = JsonValidationRules.GreaterThanRule("AppId", input.AppIdOrSlug, 0);

            if (appIdRule.IsFailed())
            {
                return appIdRule.Failure.ToJsonResponse();
            }

            var appId = appIdRule.GetStoredValue<int>();

            return await GetInstancesByAppIdOrAppSlugAsync(a => a.Id == appId, input, cancellationToken);
        }

        public Task<IJsonResponse> GetInstancesByAppSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            input.AppIdOrSlug = input.AppIdOrSlug?.ToSlug();

            return GetInstancesByAppIdOrAppSlugAsync(a => a.Slug == input.AppIdOrSlug, input, cancellationToken);
        }

        public async Task<IJsonResponse> GetInstancesByAppIdAndIdentifierIdAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
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

            var isIdentifierExists = await _context.Identifiers.AsNoTracking().AnyAsync(s => s.Id == identifierId, cancellationToken);

            return isIdentifierExists
                ? await GetInstancesByAppAndIdentifierAsync(a => a.Id == appId, identifierId, cancellationToken)
                : HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.IdentifierNotFound);
        }

        public async Task<IJsonResponse> GetInstancesByAppSlugAndIdentifierSlugAsync(GetInstancesInput input, CancellationToken cancellationToken = default)
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
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.IdentifierNotFound);
            }

            return await GetInstancesByAppAndIdentifierAsync(a => a.Slug == input.AppIdOrSlug, identifier.Id, cancellationToken);
        }

        private async Task<IJsonResponse> GetInstancesByAppAndIdentifierAsync(Expression<Func<AppSqlModel, bool>> predicate, int identifierId, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.Instances)
                .Where(predicate)
                .Select(a => new
                {
                    Instances = a.Instances.Where(i => i.IdentifierId == identifierId).Select(i =>
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
                            CreatedOn = i.CreatedOn,
                            UpdatedOn = i.UpdatedOn
                        }).ToArray()
                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.AppNotFound)
                : HttpStatusCode.OK.ToSuccessJsonResponse(entity.Instances);
        }


        private async Task<IJsonResponse> GetInstancesByAppIdOrAppSlugAsync(Expression<Func<AppSqlModel, bool>> predicate, GetInstancesInput input, CancellationToken cancellationToken = default)
        {
            var isValidIdentifierId = int.TryParse(input.IdentifierIdOrSlug, out var identifierId);

            var entity = await _context.Apps
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(a => a.Instances)
                .Where(predicate)
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    Instances = isValidIdentifierId
                        ? a.Instances.Where(i => i.IdentifierId == identifierId).Select(i =>
                            MapToGetInstancesResponseInstance(i, input.IdentifierIdOrSlug)).ToArray()
                        : a.Instances.Select(i => MapToGetInstancesResponseInstance(i, input.IdentifierIdOrSlug))
                            .ToArray()

                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null
                ? HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.AppNotFound)
                : HttpStatusCode.OK.ToSuccessJsonResponse(entity.Instances);
        }

        private static GetInstancesResponseInstance MapToGetInstancesResponseInstance(InstanceSqlModel instance, string identifierId)
        {
            return new GetInstancesResponseInstance
            {
                Id = $"{instance.Id}",
                DynamicId = instance.DynamicId,
                IdentifierId = identifierId,
                Name = instance.Name,
                Urls = instance.Urls,
                IsActive = instance.IsActive,
                MachineName = instance.MachineName,
                ReloadStrategies = instance.ReloadStrategies,
                ServiceType = instance.ServiceType,
                Version = instance.Version,
                CreatedOn = instance.CreatedOn,
                UpdatedOn = instance.UpdatedOn
            };
        }
    }
}