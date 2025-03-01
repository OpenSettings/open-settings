using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    /// <summary>
    /// Represents a user-claim mapping entity.
    /// </summary>
    [Table("UserClaimMappings")]
    public class UserClaimMappingSqlModel : EntityBase<int>
    {
        /// <summary>
        /// The id of the associated user.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The id of the associated user claim.
        /// </summary>
        public int ClaimId { get; set; }

        /// <summary>
        /// The id of the user who created this user-claim mapping.
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// The user associated with this mapping.
        /// </summary>
        public virtual UserSqlModel User { get; set; }

        /// <summary>
        /// The claim associated with this mapping.
        /// </summary>
        public virtual UserClaimSqlModel Claim { get; set; }

        /// <summary>
        /// The user who created this user-claim mapping.
        /// </summary>
        [ForeignKey(nameof(CreatedById))]
        public virtual UserSqlModel CreatedBy { get; set; }

        [NotMapped]
        public new int Id { get; set; }

        [NotMapped]
        public new DateTime? UpdatedOn { get; set; }
    }
}