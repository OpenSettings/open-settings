using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a user role-group mapping entity.
    /// </summary>
    [Table("UserRoleGroupMappings")]
    public class UserRoleGroupMappingModel : EntityBase<int>
    {
        /// <summary>
        /// The id of the associated user role.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// The id of the associated user group.
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// The id of the user who created this user role-group.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user role associated with this mapping.
        /// </summary>
        public virtual UserRoleSqlModel Role { get; set; }

        /// <summary>
        /// The user group associated with this mapping.
        /// </summary>
        public virtual UserGroupSqlModel Group { get; set; }

        /// <summary>
        /// The user who created this user role-group mapping.
        /// </summary>
        [ForeignKey(nameof(CreatedById))]
        public virtual UserSqlModel CreatedBy { get; set; }

        [NotMapped]
        public new int Id { get; set; }

        [NotMapped]
        public new DateTime? UpdatedOn { get; set; }
    }
}