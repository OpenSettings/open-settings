using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a user group-claim mapping entity.
    /// </summary>
    [Table("UserGroupClaimMappings")]
    public class UserGroupClaimMappingModel : EntityBase<int>
    {
        /// <summary>
        /// The id of the associated user group.
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// The id of the associated user claim.
        /// </summary>
        public int ClaimId { get; set; }

        /// <summary>
        /// The id of the user who created this user group-claim mapping.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user group associated with this mapping.
        /// </summary>
        public virtual UserGroupSqlModel Group { get; set; }

        /// <summary>
        /// The user claim associated with this mapping.
        /// </summary>
        public virtual UserClaimSqlModel Claim { get; set; }

        /// <summary>
        /// The user who created this user group-claim mapping.
        /// </summary>
        [ForeignKey(nameof(CreatedById))]
        public virtual UserSqlModel CreatedBy { get; set; }

        [NotMapped]
        public new int Id { get; set; }

        [NotMapped]
        public new DateTime? UpdatedOn { get; set; }
    }
}