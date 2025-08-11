using Microsoft.EntityFrameworkCore;
using Ogu.Response.Abstractions;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Sql.Interfaces;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql
{
    internal sealed class UserSqlService : IUserSqlService
    {
        private const string IdentityProviderClaimTypeName = "http://schemas.microsoft.com/identity/claims/identityprovider";

        private readonly OpenSettingsDbContext _context;

        public UserSqlService(OpenSettingsDbContext context)
        {
            _context = context;
        }

        public async Task<GetOrCreateUserResponse> GetOrCreateUserAsync(GetOrCreateUserInput input, CancellationToken cancellationToken)
        {
            var externalId = GetFirstClaimOrDefault(input.Principal, ClaimTypes.NameIdentifier, "sub", "id")?.Value;

            if (string.IsNullOrWhiteSpace(externalId))
            {
                return null;
            }

            var identityProvider = GetFirstClaimOrDefault(input.Principal, IdentityProviderClaimTypeName)?.Value;

            var entity = await _context.Users
                .AsNoTracking()
                .Where(u => u.ExternalId == externalId && u.IdentityProvider == identityProvider)
                .OrderBy(u => u.Id)
                .Select(u => new UserSqlModel { Id = u.Id, DisplayName = u.DisplayName, Initials = u.Initials, IsActive = u.IsActive })
                .FirstOrDefaultAsync(cancellationToken);

            var currentTime = DateTime.UtcNow;

            if (entity == null)
            {
                var trimmedEmail = GetFirstClaimOrDefault(input.Principal, ClaimTypes.Email, "email")?.Value?.Trim() ?? string.Empty;
                var trimmedName = GetFirstClaimOrDefault(input.Principal, ClaimTypes.Name, "name")?.Value?.Trim() ?? string.Empty;
                var trimmedGivenName = GetFirstClaimOrDefault(input.Principal, ClaimTypes.GivenName, "given_name")?.Value?.Trim() ?? string.Empty;
                var trimmedFamilyName = GetFirstClaimOrDefault(input.Principal, ClaimTypes.Surname, "family_name")?.Value?.Trim() ?? string.Empty;
                var trimmedUsername = GetFirstClaimOrDefault(input.Principal, "preferred_username")?.Value?.Trim() ?? string.Empty;

                if (!string.IsNullOrWhiteSpace(trimmedName))
                {
                    var nameParts = trimmedName.Split(OpenSettingsDefaults.Separators.SpaceSeparator, StringSplitOptions.RemoveEmptyEntries);

                    if (nameParts.Length > 0)
                    {
                        if (trimmedGivenName == string.Empty)
                        {
                            trimmedGivenName = string.Join(OpenSettingsDefaults.Format.Space, nameParts.Take(nameParts.Length > 1 ? nameParts.Length - 1 : 1));
                        }

                        if (trimmedFamilyName == string.Empty && nameParts.Length > 1)
                        {
                            trimmedFamilyName = nameParts[nameParts.Length - 1];
                        }
                    }
                }

                var id = Guid.NewGuid();

                entity = new UserSqlModel
                {
                    Id = id,
                    AuthType = input.AuthType,
                    IdentityProvider = identityProvider,
                    ExternalId = externalId,
                    Email = trimmedEmail,
                    EmailLowercase = trimmedEmail.ToLowerInvariant(),
                    Username = trimmedUsername,
                    UsernameLowercase = trimmedUsername.ToLowerInvariant(),
                    HashedPassword = null,
                    GivenName = trimmedGivenName,
                    GivenNameLowercase = trimmedGivenName.ToLowerInvariant(),
                    FamilyName = trimmedFamilyName,
                    FamilyNameLowercase = trimmedFamilyName.ToLowerInvariant(),
                    FullName = trimmedName,
                    FullNameLowercase = trimmedName.ToLowerInvariant(),
                    Slug = id.ToString().ToSlug(),
                    DisplayName = trimmedName,
                    Initials = Helper.GetInitials(trimmedName),
                    LastLogin = currentTime,
                    CreatedOn = currentTime,
                    IsActive = true
                };

                _context.Users.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new GetOrCreateUserResponse
                {
                    Id = entity.Id,
                    DisplayName = entity.DisplayName,
                    Initials = entity.Initials,
                    IsActive = true,
                    IsNewlyCreated = true
                };
            }

            if (!entity.IsActive)
            {
                return new GetOrCreateUserResponse
                {
                    Id = entity.Id,
                    DisplayName = entity.DisplayName,
                    Initials = entity.Initials,
                    IsActive = false,
                    IsNewlyCreated = false
                };
            }

            _context.Users.Attach(entity);

            entity.LastLogin = currentTime;

            await _context.SaveChangesAsync(cancellationToken);

            return new GetOrCreateUserResponse
            {
                Id = entity.Id,
                DisplayName = entity.DisplayName,
                Initials = entity.Initials,
                IsActive = true,
                IsNewlyCreated = false
            };
        }

        private static Claim GetFirstClaimOrDefault(ClaimsPrincipal claimsPrincipal, params string[] claimTypes)
        {
            return claimTypes.Select(claimsPrincipal.FindFirst).FirstOrDefault(claim => claim != null);
        }

        public Task<IResponse> CreateUserAsync(CreateUserInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GetPaginatedUsersAsync(GetPaginatedInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GetUserByIdAsync(GetUserInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GetUserBySlugAsync(GetUserInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> UpdateUserAsync(UpdateUserInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> DeleteUserAsync(DeleteUserInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}