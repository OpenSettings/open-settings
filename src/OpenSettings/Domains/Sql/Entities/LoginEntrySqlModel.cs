using OpenSettings.Models;
using OpenSettings.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    [Table("LoginEntries")]
    public class LoginEntrySqlModel : EntityBase<Guid>
    {
        public string StateId { get; set; }

        /// <summary>
        /// The client id which initiated the login.
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// The lowercase version of the <see cref="ClientId"/>, typically used for case-insensitive comparisons.
        /// </summary>
        public string ClientIdLowercase { get; set; }

        /// <summary>
        /// The instance id of the provider service which processed the login.
        /// This comes from <see cref="ProviderCoordinationTimedService.InstanceId"/> which corresponds the ProviderRegistry's id field.
        /// </summary>
        public Guid InstanceId { get; set; }

        public Guid? UserId { get; set; }

        /// <summary>
        /// The lowercase version of the <see cref="UserId"/>, typically used for case-insensitive comparisons.
        /// </summary>
        public string UserIdLowercase { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }

        public AuthType AuthType { get; set; }

        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Specify whether login completed successfully.
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Additional metadata associated with the login entry, stored as key-value pairs.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// The user who logged in.
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public virtual UserSqlModel User { get; set; }
    }
}