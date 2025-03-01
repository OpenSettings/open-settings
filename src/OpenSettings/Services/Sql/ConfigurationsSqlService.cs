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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql
{
    internal sealed class ConfigurationsSqlService : IConfigurationsSqlService
    {
        private readonly OpenSettingsDbContext _context;

        public ConfigurationsSqlService(OpenSettingsDbContext context)
        {
            _context = context;
        }

        public async Task<IJsonResponse> GetConfigurationByAppIdAndIdentifierIdAsync(GetConfigurationByAppAndIdentifierInput input,
            CancellationToken cancellationToken = default)
        {
            var appIdRule = JsonValidationRules.GreaterThanRule(nameof(input.AppIdOrSlug), input.AppIdOrSlug, 0);
            var identifierIdRule = JsonValidationRules.GreaterThanRule(nameof(input.IdentifierIdOrSlug), input.IdentifierIdOrSlug, 0);

            var failure = new ValidationRule[] { appIdRule, identifierIdRule }.ValidateFirstOrDefault();

            if (failure != null)
            {
                return failure.ToJsonResponse();
            }

            var appId = appIdRule.GetStoredValue<int>();
            var identifierId = identifierIdRule.GetStoredValue<int>();

            var entity = await _context.Configurations
                .AsNoTracking()
                .Where(c =>
                    c.AppId == appId &&
                    c.IdentifierId == identifierId)
                .Select(c => new GetConfigurationByAppAndIdentifierResponse
                {
                    Id = $"{c.Id}",
                    AllowAnonymousAccess = c.AllowAnonymousAccess,
                    StoreInSeparateFile = c.StoreInSeparateFile,
                    IgnoreOnFileChange = c.IgnoreOnFileChange,
                    RegistrationMode = c.RegistrationMode,
                    Consumer = c.Consumer,
                    Provider = c.Provider,
                    RowVersion = c.RowVersion,
                }).FirstOrDefaultAsync(cancellationToken);

            return entity == null 
                ? HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.ConfigurationNotFound) 
                : HttpStatusCode.OK.ToSuccessJsonResponse(entity);
        }

        public async Task<IJsonResponse> PatchConfigurationAsync(PatchConfigurationInput input, CancellationToken cancellationToken = default)
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

            var entity = await _context.Configurations
                .AsNoTracking()
                .Where(c => 
                            c.AppId == appId &&
                            c.IdentifierId == identifierId)
                .Select(c => new ConfigurationSqlModel
                {
                    Id = c.Id,
                    RowVersion = c.RowVersion,
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.ConfigurationNotFound);
            }

            if (!input.Body.RowVersion.SequenceEqual(entity.RowVersion))
            {
                return FailureResponses.Conflict($"{entity.Id}", entity.RowVersion, input.Body.RowVersion, false);
            }

            _context.Attach(entity);

            var updatedFieldNameToValue = new Dictionary<string, object>();

            if (input.Body.UpdatedFieldNameToValue.TryGetValue("allowanonymousaccess", out var allowAnonymousAccessObject))
            {
                if (!bool.TryParse(allowAnonymousAccessObject?.ToString(), out var allowAnonymousAccess))
                {
                    return HttpStatusCode.BadRequest.ToFailureJsonResponse(
                        JsonValidationFailures.InvalidBooleanFormat("AllowAnonymousAccess", allowAnonymousAccessObject));
                }

                entity.AllowAnonymousAccess = allowAnonymousAccess;
                updatedFieldNameToValue["AllowAnonymousAccess"] = allowAnonymousAccess;
                _context.MarkAsModified(entity, e => e.AllowAnonymousAccess);
            }

            if (input.Body.UpdatedFieldNameToValue.TryGetValue("storeinseparatefile", out var storeInSeparateFileObject))
            {
                if (!bool.TryParse(storeInSeparateFileObject?.ToString(), out var storeInSeparateFile))
                {
                    return HttpStatusCode.BadRequest.ToFailureJsonResponse(
                        JsonValidationFailures.InvalidBooleanFormat("StoreInSeparateFile", storeInSeparateFileObject));
                }

                entity.StoreInSeparateFile = storeInSeparateFile;
                updatedFieldNameToValue["StoreInSeparateFile"] = storeInSeparateFile;
                _context.MarkAsModified(entity, e => e.StoreInSeparateFile);
            }

            if (input.Body.UpdatedFieldNameToValue.TryGetValue("ignoreonfilechange", out var ignoreOnFileChangeObject))
            {
                if (!bool.TryParse(ignoreOnFileChangeObject?.ToString(), out var ignoreOnFileChange))
                {
                    return HttpStatusCode.BadRequest.ToFailureJsonResponse(
                        JsonValidationFailures.InvalidBooleanFormat("IgnoreOnFileChange", ignoreOnFileChangeObject));
                }

                entity.IgnoreOnFileChange = ignoreOnFileChange;
                updatedFieldNameToValue["IgnoreOnFileChange"] = ignoreOnFileChange;
                _context.MarkAsModified(entity, e => e.IgnoreOnFileChange);
            }

            if (input.Body.UpdatedFieldNameToValue.TryGetValue("registrationmode", out var registrationModeObject))
            {
                var registrationModeEnumRule = JsonValidationRules.ValidEnumRule<RegistrationMode>("RegistrationMode", registrationModeObject);

                if (registrationModeEnumRule.IsFailed())
                {
                    return registrationModeEnumRule.Failure.ToJsonResponse();
                }

                entity.RegistrationMode = registrationModeEnumRule.GetStoredValue<RegistrationMode>();
                updatedFieldNameToValue["RegistrationMode"] = entity.RegistrationMode;
                _context.MarkAsModified(entity, e => e.RegistrationMode);
            }

            if (input.Body.UpdatedFieldNameToValue.TryGetValue("consumer", out var consumerObject) && consumerObject != null)
            {
                try
                {
                    entity.Consumer = JsonSerializer.Deserialize<ConfigurationConsumer>($"{consumerObject}", Constants.JsonCaseInsensitiveOptions);
                    updatedFieldNameToValue["Consumer"] = entity.Consumer;
                    _context.MarkAsModified(entity, e => e.Consumer);
                }
                catch(Exception ex)
                {
                    return ex.ToJsonResponse();
                }
            }

            if (input.Body.UpdatedFieldNameToValue.TryGetValue("provider", out var providerObject) && providerObject != null)
            {
                try
                {
                    entity.Provider = JsonSerializer.Deserialize<ConfigurationProvider>($"{providerObject}", Constants.JsonCaseInsensitiveOptions);
                    updatedFieldNameToValue["Provider"] = entity.Provider;
                    _context.MarkAsModified(entity, e => e.Provider);
                }
                catch(Exception ex)
                {
                    return ex.ToJsonResponse();
                }
            }

            if (!_context.ChangeTracker.HasChanges())
            {
                return HttpStatusCode.OK.ToSuccessJsonResponse(new PatchConfigurationResponse
                {
                    RowVersion = entity.RowVersion
                });
            }

            var currentTime = DateTime.UtcNow;

            entity.RowVersion = currentTime.ToRowVersion();
            entity.UpdatedOn = currentTime;
            entity.UpdatedById = input.UpdatedById;

            _context.MarkAsModified(entity,
                e => e.RowVersion,
                e => e.UpdatedOn,
                e => e.UpdatedById);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse(new PatchConfigurationResponse
            {
                RowVersion = entity.RowVersion,
                UpdatedFieldNameToValue = updatedFieldNameToValue
            });
        }
    }
}