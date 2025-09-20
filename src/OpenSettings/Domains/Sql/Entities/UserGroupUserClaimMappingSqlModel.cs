using System;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a user group-claim mapping entity.
    /// </summary>
    public class UserGroupUserClaimMappingSqlModel : EntityBase<Guid>
    {
        public Guid? TenantId { get; set; }

        /// <summary>
        /// The id of the associated user group.
        /// </summary>
        public Guid UserGroupId { get; set; }

        /// <summary>
        /// The id of the associated user claim.
        /// </summary>
        public Guid UserClaimId { get; set; }

        /// <summary>
        /// The user group associated with this mapping.
        /// </summary>
        public virtual UserGroupSqlModel UserGroup { get; set; }

        /// <summary>
        /// The user claim associated with this mapping.
        /// </summary>
        public virtual UserClaimSqlModel UserClaim { get; set; }

        /// <summary>
        /// The id of the user who created this user group-claim mapping.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user who created this user group-claim mapping.
        /// </summary>
        public virtual UserSqlModel CreatedBy { get; set; }
    }
}