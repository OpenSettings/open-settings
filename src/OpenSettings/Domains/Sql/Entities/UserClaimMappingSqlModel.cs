using System;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a user-claim mapping entity.
    /// </summary>
    public class UserClaimMappingSqlModel : EntityBase<Guid>
    {
        public Guid? TenantId { get; set; }

        /// <summary>
        /// The id of the associated user.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The id of the associated user claim.
        /// </summary>
        public Guid UserClaimId { get; set; }

        /// <summary>
        /// The user associated with this mapping.
        /// </summary>
        public virtual UserSqlModel User { get; set; }

        /// <summary>
        /// The claim associated with this mapping.
        /// </summary>
        public virtual UserClaimSqlModel UserClaim { get; set; }

        /// <summary>
        /// The id of the user who created this user-claim mapping.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user who created this user-claim mapping.
        /// </summary>
        public virtual UserSqlModel CreatedBy { get; set; }
    }
}