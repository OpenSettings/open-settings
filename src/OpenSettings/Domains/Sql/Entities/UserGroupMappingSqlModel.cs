using System;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a user-group mapping entity.
    /// </summary>
    public class UserGroupMappingSqlModel : EntityBase<int>
    {
        /// <summary>
        /// The id of the associated user.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The id of the associated user group.
        /// </summary>
        public int UserGroupId { get; set; }

        /// <summary>
        /// The user associated with this mapping.
        /// </summary>
        public virtual UserSqlModel User { get; set; }

        /// <summary>
        /// The user group associated with this mapping.
        /// </summary>
        public virtual UserGroupSqlModel UserGroup { get; set; }

        /// <summary>
        /// The id of the user who created this user-group mapping.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user who created this user user-group mapping.
        /// </summary>
        public virtual UserSqlModel CreatedBy { get; set; }
    }
}