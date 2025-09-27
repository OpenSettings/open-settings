using System;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a user-role mapping entity.
    /// </summary>
    public class UserRoleMappingSqlModel : EntityBase<Guid>
    {
        public Guid? TenantId { get; set; }

        public virtual TenantSqlModel Tenant { get; set; }

        /// <summary>
        /// The id of the associated user.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The id of the associated user role.
        /// </summary>
        public Guid UserRoleId { get; set; }

        /// <summary>
        /// The user associated with this mapping.
        /// </summary>
        public virtual UserSqlModel User { get; set; }

        /// <summary>
        /// The role associated with this mapping.
        /// </summary>
        public virtual UserRoleSqlModel UserRole { get; set; }

        /// <summary>
        /// The id of the user who created this user-role mapping.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user who created this user-role mapping.
        /// </summary>
        public virtual UserSqlModel CreatedBy { get; set; }
    }
}