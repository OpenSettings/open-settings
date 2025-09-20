using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace OpenSettings.Models
{
    internal class OpenSettingsClaims
    {
        public Guid JsonTokenId { get; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        public Guid TenantId { get; set; }

        public string DisplayName { get; set; }

        public string UserInitials { get; set; }

        public AuthType AuthType { get; set; } = AuthType.Unset;

        public AuthMethod AuthMethod { get; set; } = AuthMethod.Unset;

        public List<Claim> GenerateClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(OpenSettingsDefaults.ClaimTypes.JsonTokenId, $"{JsonTokenId}"),
                new Claim(OpenSettingsDefaults.ClaimTypes.TenantId, $"{TenantId}"),
                new Claim(OpenSettingsDefaults.ClaimTypes.DbUserId, $"{UserId}"),
                new Claim(OpenSettingsDefaults.ClaimTypes.DbUserDisplayName, DisplayName ?? string.Empty),
                new Claim(OpenSettingsDefaults.ClaimTypes.DbUserInitials, UserInitials ?? Helpers.Helper.GetInitials(DisplayName)),
                new Claim(OpenSettingsDefaults.ClaimTypes.AuthType, $"{AuthType}"),
                new Claim(OpenSettingsDefaults.ClaimTypes.AuthMethod, $"{AuthMethod}")
            };

            return claims;
        }
    }
}
