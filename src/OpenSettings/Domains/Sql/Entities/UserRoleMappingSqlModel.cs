using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a user-role mapping entity.
    /// </summary>
    [Table("UserRoleMappings")]
    public class UserRoleMappingSqlModel : EntityBase<int>
    {
        /// <summary>
        /// The id of the associated user.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The id of the associated user role.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// The id of the user who created this user-role mapping.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user associated with this mapping.
        /// </summary>
        public virtual UserSqlModel User { get; set; }

        /// <summary>
        /// The role associated with this mapping.
        /// </summary>
        public virtual UserRoleSqlModel Role { get; set; }

        /// <summary>
        /// The user who created this user-role mapping.
        /// </summary>
        [ForeignKey(nameof(CreatedById))]
        public virtual UserSqlModel CreatedBy { get; set; }

        [NotMapped]
        public new int Id { get; set; }

        [NotMapped]
        public new DateTime? UpdatedOn { get; set; }
    }
}