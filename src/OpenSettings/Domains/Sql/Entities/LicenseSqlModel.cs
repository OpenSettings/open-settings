using OpenSettings.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a license entity.
    /// </summary>
    [Table("Licenses")]
    public class LicenseSqlModel : EntityBase<int>
    {
        /// <summary>
        /// The unique reference identifier for the license.
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        /// The lowercase version of the <see cref="ReferenceId"/>, typically used for case-insensitive comparisons.
        /// </summary>
        public string ReferenceIdLowercase { get; set; }

        /// <summary>
        /// The list of features enabled by this license.
        /// </summary>
        public string[] Features { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The date and time when the license expires, if applicable.
        /// </summary>
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Indicates whether the license is expired.
        /// </summary>
        public bool IsExpired { get; set; }

        /// <summary>
        /// The date and time when the license was marked as expired.
        /// </summary>
        public DateTime? ExpiredOn { get; set; }

        /// <summary>
        /// Indicates whether the license has been revoked.
        /// </summary>
        public bool IsRevoked { get; set; }

        /// <summary>
        /// The date and time when the license was revoked.
        /// </summary>
        public DateTime? RevokedOn { get; set; }

        /// <summary>
        /// The key associated with the license.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The name of the license holder.
        /// </summary>
        public string Holder { get; set; }

        /// <summary>
        /// The lowercase version of the <see cref="Holder"/>, typically used for case-insensitive comparisons.
        /// </summary>
        public string HolderLowercase { get; set; }

        /// <summary>
        /// The edition of the license, defining its features and scope.
        /// </summary>
        public LicenseEdition Edition { get; set; }

        /// <summary>
        /// The date and time when the license was issued.
        /// </summary>
        public DateTime IssuedAt { get; set; }

        /// <summary>
        /// The date and time before which the license is not valid.
        /// </summary>
        public DateTime NotBefore { get; set; }
    }
}