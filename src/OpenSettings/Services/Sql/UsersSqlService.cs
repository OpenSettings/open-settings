using Microsoft.EntityFrameworkCore;
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
    internal sealed class UsersSqlService : IUsersSqlService
    {
        private const string IdentityProviderClaimTypeName = "http://schemas.microsoft.com/identity/claims/identityprovider";

        private readonly OpenSettingsDbContext _context;

        public UsersSqlService(OpenSettingsDbContext context)
        {
            _context = context;
        }

        public async Task<GetOrCreateUserResponse> GetOrCreateUserAsync(GetOrCreateUserInput input, CancellationToken cancellationToken)
        {
            var providerId = GetFirstClaimOrDefault(input.Principal, ClaimTypes.NameIdentifier, "sub", "id")?.Value;

            if (string.IsNullOrWhiteSpace(providerId))
            {
                return null;
            }

            var oAuthProvider = GetFirstClaimOrDefault(input.Principal, IdentityProviderClaimTypeName)?.Value;

            var entity = await _context.Users
                .AsNoTracking()
                .Where(u => u.ProviderId == providerId && u.OAuthProvider == oAuthProvider)
                .OrderBy(u => u.Id)
                .Select(u => new UserSqlModel { Id = u.Id, DisplayName = u.DisplayName, Initials = u.Initials, IsActive = u.IsActive })
                .FirstOrDefaultAsync(cancellationToken);

            var currentTime = DateTime.UtcNow;

            if (entity == null)
            {
                var email = GetFirstClaimOrDefault(input.Principal, ClaimTypes.Email, "email")?.Value ?? string.Empty;
                var name = GetFirstClaimOrDefault(input.Principal, ClaimTypes.Name, "name")?.Value ?? string.Empty;
                var username = GetFirstClaimOrDefault(input.Principal, "preferred_username")?.Value ?? string.Empty;

                var trimmedName = name.Trim();

                var id = Guid.NewGuid();

                entity = new UserSqlModel
                {
                    Id = id,
                    AuthScheme = input.AuthScheme,
                    OAuthProvider = oAuthProvider,
                    ProviderId = providerId,
                    Email = email,
                    EmailLowercase = email.ToLowerInvariant(),
                    Username = username,
                    UsernameLowercase = username.ToLowerInvariant(),
                    HashedPassword = null,
                    Name = trimmedName,
                    NameLowercase = trimmedName.ToLowerInvariant(),
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
    }
}