using OpenSettings.Models;
using OpenSettings.Services;
using System;
using System.Collections.Generic;

namespace OpenSettings.Domains.Sql.Entities
{
    public class LoginEntrySqlModel : EntityBase<Guid>
    {
        /// <summary>
        /// The state id which relevant to login.
        /// </summary>
        public Guid StateId { get; set; }

        /// <summary>
        /// The issuer which created the login entry.
        /// </summary>
        public Guid Issuer { get; set; }

        /// <summary>
        /// The audience which initiated the login.
        /// </summary>
        public Guid Audience { get; set; }

        public string RemoteIpAddress { get; set; }

        public string UserAgent { get; set; }

        public AuthType AuthType { get; set; }

        public AuthMethod AuthMethod { get; set; }

        public string AccessToken { get; set; }

        public DateTimeOffset? AccessTokenExpiryDate { get; set; }

        public string RefreshToken { get; set; }

        public DateTimeOffset? RefreshTokenExpiryDate { get; set; }

        public string Scopes { get; set; }

        /// <summary>
        /// Specify whether login completed successfully.
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Additional metadata associated with the login entry, stored as key-value pairs.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();

        public Guid? UserId { get; set; }

        /// <summary>
        /// The user who logged in.
        /// </summary>
        public virtual UserSqlModel User { get; set; }

        /// <summary>
        /// The instance id of the provider service which processed the login.
        /// This comes from <see cref="ProviderCoordinationTimedService.ProviderRegistryId"/> which corresponds the ProviderRegistry's id field.
        /// </summary>
        public Guid? ProviderRegistryId { get; set; }

        public virtual ProviderRegistrySqlModel ProviderRegistry { get; set; }
    }
}