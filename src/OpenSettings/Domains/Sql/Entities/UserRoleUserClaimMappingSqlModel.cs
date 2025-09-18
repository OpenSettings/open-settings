using System;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a user role-claim mapping entity.
    /// </summary>
    public class UserRoleUserClaimMappingSqlModel : EntityBase<int>
    {
        /// <summary>
        /// The id of the associated user role.
        /// </summary>
        public int UserRoleId { get; set; }

        /// <summary>
        /// The id of the associated user claim.
        /// </summary>
        public int UserClaimId { get; set; }

        /// <summary>
        /// The user role associated with this mapping.
        /// </summary>
        public virtual UserRoleSqlModel UserRole { get; set; }

        /// <summary>
        /// The user claim associated with this mapping.
        /// </summary>
        public virtual UserClaimSqlModel UserClaim { get; set; }

        /// <summary>
        /// The id of the user who created this user role-claim.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user who created this user role-claim mapping.
        /// </summary>
        public virtual UserSqlModel CreatedBy { get; set; }
    }
}