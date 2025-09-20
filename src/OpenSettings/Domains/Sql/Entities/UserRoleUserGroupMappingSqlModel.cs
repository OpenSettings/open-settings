using System;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a user role-group mapping entity.
    /// </summary>
    public class UserRoleUserGroupMappingSqlModel : EntityBase<Guid>
    {
        public Guid? TenantId { get; set; }

        /// <summary>
        /// The id of the associated user role.
        /// </summary>
        public Guid UserRoleId { get; set; }

        /// <summary>
        /// The id of the associated user group.
        /// </summary>
        public Guid UserGroupId { get; set; }

        /// <summary>
        /// The user role associated with this mapping.
        /// </summary>
        public virtual UserRoleSqlModel UserRole { get; set; }

        /// <summary>
        /// The user group associated with this mapping.
        /// </summary>
        public virtual UserGroupSqlModel UserGroup { get; set; }

        /// <summary>
        /// The id of the user who created this user role-group.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user who created this user role-group mapping.
        /// </summary>
        public virtual UserSqlModel CreatedBy { get; set; }
    }
}